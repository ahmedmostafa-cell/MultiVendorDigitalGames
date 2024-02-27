

const myButtonn = document.getElementById('myButtonn');

myButtonn.addEventListener('click', (event) => {
    event.target.disabled = true;
});
var values = []; // Array of input values
var inputElements = document.querySelectorAll('input[data-item-id]');
let totalfirst = 0;
for (var i = 0; i < inputElements.length; i++) {
    values.push(inputElements[i].dataset.price);
    totalfirst += parseFloat(inputElements[i].dataset.price);
}
console.log(totalfirst);
$("#Total1").html(totalfirst);
$("#Total2").html(totalfirst);

function snd(e)
{
   
   
    let price = parseFloat($('#myInput').data("price"));
   
    $(e).parent().parent().next().find('div input').val(price * parseFloat($(e).val()));
    
    UpdateTotals();
}
function UpdateTotals() {
    let total = 0;
    $(".CartInput").each(function (index, element) {
       
        total = total + parseFloat($(element).val()) * parseFloat($(element).data("price"))
    })
    $("#Total1").html(total);
    $("#Total2").html(total);
    $("#Total3").html(total);
}

function applycoupon(e)
{
   
    const option = $(e).val();
    //https://localhost:44369
    
    fetch(`https://eibtek2-001-site4.atempurl.com/api/GetCouponDiscountApi/${option}`)
        .then(response => response.json())
        .then(data => {
            console.log(data.promocodeDiscountPercent);
            const pricebeforediscount = $("#Total2").text();
            if ($("#Total2").text() === null || undefined) {
                $("#Total2").html("")
                proceedcheckout(data.promocodeDiscountPercent , option);
            }
            else
            {
                const totalaftercoupon = parseFloat($("#Total2").text() - (parseFloat($("#Total2").text()) * data.promocodeDiscountPercent) / 100);
                $("#Total2").html(totalaftercoupon);
                proceedcheckout(data.promocodeDiscountPercent, option);

            }
           
            
          
        })
        .catch(error => {
            console.error("Error fetching data:", error);
        });
}




function proceedcheckout(discount, option)
{
    alert("Are you Sure you want to check out");
    // Array of input values
    var inputElements = document.querySelectorAll('input[data-item-id]');
   
    var valuesCheck = [];
    for (var i = 0; i < inputElements.length; i++) {
        valuesCheck.push({ id: inputElements[i].dataset.od, price: inputElements[i].dataset.price, qty: inputElements[i].value, promodiscount: discount, promotitle: option });
        console.log(inputElements[i].value);
    }
    console.log(valuesCheck);
   
    $.ajax({
        type: "POST",
        url: "/CheckOut/ProceedCheckout",
        data: JSON.stringify(valuesCheck),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
          
            window.location.href = "/CheckOut/Index?response=" + response;

        },
        error: function (response) {
            // Handle any errors that occur
        }
    });
   
}

