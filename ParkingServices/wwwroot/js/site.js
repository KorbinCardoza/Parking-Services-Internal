var select = document.getElementById("mySelect");
var oTable = document.getElementById("table_id");
select.addEventListener("change", function () {
   
    var selectedValue = $(this).val();
    oTable.fnFilter()
    oTable.fnFilter("^" + selectedValue + "$", 2, true); //Exact value, column, reg
    alert(selectedValue);
});