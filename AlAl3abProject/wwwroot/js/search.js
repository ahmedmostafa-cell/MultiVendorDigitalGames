
const search = document.getElementById('search1');
const searchInput = search.value;

search.onchange = getSearchResults();

function getSearchResults() {
   
    const searchInput = search.value;
  /*  https://localhost:44369*/
    
    fetch(`https://eibtek2-001-site4.atempurl.com/api/SearchApi/${searchInput}`)
        .then(response => response.json())
        .then(data => {
            console.log(data);
            
        })
        .catch(error => {
            console.error("Error fetching data:", error);
        });
   
  
}


search.addEventListener('input', () => {
   
  
    setTimeout(getSearchResults, 3);
});


