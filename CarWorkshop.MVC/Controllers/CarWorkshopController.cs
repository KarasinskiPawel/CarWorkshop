using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Application.Commands.CreateCarWorkshop;
using CarWorkshop.Application.Commands.Querrys.GetAllCarWorkshops;
using CarWorkshop.Application.Commands.Querrys.GetCarWorkshopByEncodedName;
using CarWorkshop.Application.Commands.UpdateCarWorkshop;
using CarWorkshop.Domain.Entities;
using CarWorkshop.MVC.Extensions;
using CarWorkshop.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarWorkshop.MVC.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public CarWorkshopController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            var carWorkshop = await _mediator.Send(new GetAllCarWorkshopsQuerry());
            return View(carWorkshop);
        }

        [Route("CarWorkshop/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var dto = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));

            return View(dto);
        }

        [Authorize(Roles = "Owner")]
        public ActionResult Create()
        {
            //if(!User.IsInRole("Owner"))
            //{
            //    return RedirectToAction("NoAccess", "Home");
            //}

            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Owner")]
        public async Task<IActionResult> Create(CreateCarWorkshopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            this.SetNotification("success", $"Created carworkshop: {command.Name}");

            return RedirectToAction(nameof(Index)); // To do refactor
        }

        [Route("CarWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var dto = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));

            if(!dto.IsEditable)
            {
                return RedirectToAction("NoAccess", "Home");
            }

            EditCarWorkshopCommand model = _mapper.Map<EditCarWorkshopCommand>(dto);

            return View(model);
        }

        [HttpPost]
        [Route("CarWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName, EditCarWorkshopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _mediator.Send(command);

            return RedirectToAction(nameof(Index)); // To do refactor
        }
    }
}
