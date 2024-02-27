

var typeid = document.getElementById('typeid');
var subcategoryid = document.getElementById('subcategoryid');

var selectElement2 = document.querySelector('#my-select');

selectElement2.addEventListener('change', function () {
    var selectedValue2 = this.value;
   
    localStorage.setItem('selectedValue', selectedValue2); // store the selected value in local storage
    window.location.href = '/SubCategory/IndexFilter?selectedValue2=' + selectedValue2 + '&typeid=' + typeid.value + '&subcategoryid=' + subcategoryid.value;
    //localStorage.clear();
});


// Retrieve the selected value from local storage and set it as the default option
const savedSelectedValue = localStorage.getItem('selectedValue');
if (savedSelectedValue) {
    selectElement2.value = savedSelectedValue;
}





