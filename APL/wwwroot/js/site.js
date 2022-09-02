// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function AjaxDropDown(event, url, elementId) {
    const id = event.target.value;
    //console.log(id);
    $.ajax({
        url: url,
        type: "GET",
        contentType: "application/json",
        data: { "id": id },
        success: function (response) {
            console.log(response);

            let select = document.getElementById(elementId);
            select.innerHTML = '';
            //let opt = document.createElement('option');

            for (var i = 0; i < response.length; i++) {
                let opt = document.createElement('option');
                opt.value = response[i].stadiumId;
                opt.innerHTML = response[i].stadiumName;
                console.log(opt);
                select.appendChild(opt);
            }
        },
        error: function (error) {
            console.log(error)
        }
    })

}
