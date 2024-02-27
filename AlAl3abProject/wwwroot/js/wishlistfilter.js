



var selectElement = document.querySelector('#my-select');

selectElement.addEventListener('change', function () {
    var selectedValue = this.value;
    localStorage.setItem('selectedValue', selectedValue); // store the selected value in local storage
    window.location.href = '/Wishlist/IndexFilter?selectedValue=' + selectedValue;
    //localStorage.clear();
});


// Retrieve the selected value from local storage and set it as the default option
const savedSelectedValue = localStorage.getItem('selectedValue');
if (savedSelectedValue) {
    selectElement.value = savedSelectedValue;
}





