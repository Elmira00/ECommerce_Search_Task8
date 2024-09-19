// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
// Initialization for ES Users

$(document).ready(function () {
    jQuery.noConflict();
    $("input").on("keypress", function (event) {
        const url = "https://localhost:7290/product/GetProductJsonData";
        var filteredProducts = [];
        $.ajax({
            type: "GET",
            url: url,
            contentType: 'application/json',
        })
            .done(function (response) {
            for (var i = 0; i < response.length; i++)
            {
                if (response[i].productName.toLowerCase().includes(event.key.toLowerCase())) {
                filteredProducts.push(response[i]); // Add matching products to filteredProducts
                    }
                }
                var content = "";
                //console.log(filteredProducts[1].productId);
                filteredProducts.forEach((p) => {
                    content += "<tr>";
                    content += "<td>";
                    content += `${p.productName}`;
                    content += "</td>";
                    content += "<td>";
                    content += `${p.unitPrice}`;
                    content += "</td>";
                    content += "<td>";
                    content += `${p.unitsInStock}`;
                    content += "</td>";
                    content += "<td>";
                    content += ` <a href="/Cart/AddToCart?productId=${p.productId}&page=@Model.CurrentPage&category=@Model.CurrentCategory"
                           class="btn btn-xs btn-success">Add To Cart</a>`;
                    content += "</td>";
                    content += "</tr>";
                });
                console.log(content)
                $("#ProductTableBody").html(content);
                console.log(filteredProducts);
            })
            .fail(function (msg) {
                alert("ERROR");
            })
        
            });
       
});