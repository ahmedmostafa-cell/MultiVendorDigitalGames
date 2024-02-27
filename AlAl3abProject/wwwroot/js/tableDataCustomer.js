

updateTableWithoutParameter();



function updateTableWithoutParameter() {

   

    fetch(`https://localhost:44369/api/OrderApi/`)
                .then(response => response.json())
                .then(data => {
                    
                    const table = document.getElementById("example");
                    const tbody = table.getElementsByTagName("tbody")[0];

                    // Clear existing table rows
                    tbody.innerHTML = "";

                    // Add new rows based on the fetched data
                   
                    data.forEach(rowData => {
                        console.log(rowData);
                        const row = document.createElement("tr");
                        const column1 = document.createElement("td");
                        const column2 = document.createElement("td");
                        const column3 = document.createElement("td");
                        const column4 = document.createElement("td");
                       


                        column1.innerText = rowData.userName;
                        column2.innerText = rowData.sellerName;
                        column3.innerText = rowData.createdDate;
                       
                        column4.innerHTML = `<a href="/Admin/OrderDetails/IndexOrder?id=${rowData.consultingId}"  class='btn btn-info text-white' style='cursor:pointer'> تفاصيل</a >`


                        row.appendChild(column1);
                        row.appendChild(column2);
                        row.appendChild(column3);
                        row.appendChild(column4);
                       
                        tbody.appendChild(row);
                      
                    });

                   

                })
                .catch(error => {
                    console.error("Error fetching data:", error);
                });

        

}


