// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const RenderCarWorkshopServices = (services, container) => {
    container.empty();

    for (const service of services) {
        container.append(
            '<h5 class="card-title"> ${service.description} </h5>'
        )
    }
}

const LoadCarWorkshopServices = () => {
    const container = $("#services")
    const carWorkshopsEncoedName = container.data("encoedeName")

    $.ajax({
        url: '/CarWorkshop/{encodedName}/CarWorkshopService',
        type: 'GET',

        success: function (data) {
            if (data.length) {
                container.html("Brak serwisów");
            } else {
                RenderCarWorkshopServices(data, container);
            }
        },

        error: function () {
            toastr["error"]("Something went wrong")
        }
    })
}