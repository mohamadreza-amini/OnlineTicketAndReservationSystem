// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function TestAjax(e) {


    let a = $("#input1").val();
    let data = { name: a }
    if (e.type == "click") {
        e.preventDefault();
        $.ajax({
            type: 'Post',
            url: '/Test/ajax',
            contentType: 'application/json',
            data: JSON.stringify(data),

            success: function (response) {
                alert(response)
            }

        })
    }
}


function AddResidenceCategory(e) {
    e.preventDefault();
    let CName = $("#CategoryName").val();
   
    let data = { CategoryName: CName }
    $.ajax({
        type: 'Post',
        url: '/Vehicle/AddResidenceCategory',
        contentType: 'application/json',  
        data: JSON.stringify(data),
        success: function (response) {
            alert(response)
        }
    })
}

function AddVehicleCategory(e) {
    e.preventDefault();
    let CName = $("#CategoryName").val();

    let data = { CategoryName: CName }
    $.ajax({
        type: 'Post',
        url: '/Vehicle/AddVehicleCategory',
        contentType: 'application/json',
        data: JSON.stringify(data),
        success: function (response) {
            alert(response)
        }
    })
}