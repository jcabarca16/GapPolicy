$(document).ready(function () {
    $("#tabs-clients").tabs();
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
                        htmlText += '<td>' + '<a href="#" id="btn-delete-client" class="btn btn-primary" onclick="deleteClient(' + item.Identification + ')"> delete </a>' + ' | ' + '<a href="#" id="btn-update-client" class="btn btn-primary btn-info"> update </a>' + '</td>';
                        htmlText += '</tr>';
                    });
                }

                $("#tableClientInfo").dataTable().fnClearTable();
                $("#tableClientInfo").dataTable().fnDestroy();
                $('#tblClientInfo').html(htmlText);
                $('#tableClientInfo').DataTable();
                $("select[name*='tblClientInfo']").change();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
}
function deleteClient(identification) {

    var empObj = {
        Identification: identification,
    };

    processing: true; // for show progress bar  
    serverSide: true; // for process server side  
    filter: true; // this is for disable filter (search box)  
    orderMulti: false; // for disable multiple column at once
    paging: false;
    $.ajax(
        {
            url: "/Clients/DeleteClients",
            data: JSON.stringify(empObj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            success: function (result) {
                alert("Complete");
                loadClients();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
}