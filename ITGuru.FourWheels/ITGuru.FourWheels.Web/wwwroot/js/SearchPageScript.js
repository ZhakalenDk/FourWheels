function Search() {
    // Declare variables
    var input, filter, table, tr, td, i, txtValue;
    input = document.getElementById("SearchInput");
    filter = input.value.toUpperCase();
    table = document.getElementById("SearchTable");
    tr = table.getElementsByTagName("tr");

    // Loop through all table rows, and hide those who don't match the search query
    for (i = 0; i < tr.length; i++) {
        td = tr[i].getElementsByTagName("td")[0];
        if (td) {
            txtValue = td.textContent || td.innerText;
            if (txtValue.toUpperCase().indexOf(filter) > -1) {
                tr[i].style.display = "";
            } else {
                tr[i].style.display = "none";
            }
        }
    }
}

// This is to ensure that the modal won't close, if the validation isn't valid.
$("btnCreate").click(function (e) {
    e.preventDefault();
});

$("btnUpdate").click(function (e) {
    e.preventDefault();
});

$("btnDelete").click(function (e) {
    e.preventDefault();
});