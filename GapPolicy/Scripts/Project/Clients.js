$(document).ready(function () {
    loadClients();
});
function loadClients() {
    processing: true; // for show progress bar  
    serverSide: true; // for process server side  
    filter: true; // this is for disable filter (search box)  
    orderMulti: false; // for disable multiple column at once
    paging: false;
    $.ajax(
        {
            url: "/Clients/GetClients",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            success: function (result) {
                let htmlText = "";
                if (result.length > 0) {
                    $.each(result, function (key, item) {
                        htmlText += '<tr>';
                        htmlText += '<td>' + item.Identification + '</td>';
                        htmlText += '<td>' + item.Name + '</td>';
                        htmlText += '<td>' + item.PhoneNumber + '</td>';
                        htmlText += '<td>' + item.Mail + '</td>';
                        htmlText += '<td>' + item.Address + '</td>';
                        htmlText += '</tr>';
                    });
                }

                $("#tableClientInfo").dataTable().fnClearTable();
                $("#tableClientInfo").dataTable().fnDestroy();
                $('#tblClientInfo').html(htmlText);
                $("#tableClientInfo").dataTable();
                $("select[name*='tblClientInfo']").change();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
}