using CarWorkshop.Application.CarWorkshop;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.Querrys.GetAllCarWorkshops
{
    public class GetAllCarWorkshopsQuerry : IRequest<IEnumerable<CarWorkshopDto>>
    {

    }
}
