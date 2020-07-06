$(document).ready(function () {
    $("#tabs-policy-type").tabs();
    loadPolicyType();
});
function loadPolicyType() {
    processing: true; // for show progress bar  
    serverSide: true; // for process server side  
    filter: true; // this is for disable filter (search box)  
    orderMulti: false; // for disable multiple column at once
    paging: false;
    $.ajax(
        {
            url: "/PolicyType/GetPolicyType",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            success: function (result) {
                let htmlText = "";
                if (result.length > 0) {
                    $.each(result, function (key, item) {
                        htmlText += '<tr>';
                        htmlText += '<td>' + item.Id + '</td>';
                        htmlText += '<td>' + item.Type + '</td>';
                        htmlText += '<td>' + item.Description + '</td>';
                        htmlText += '<td>' + '<a href="#" id="btn-delete-policy-type" class="btn btn-primary" onclick="deletePolicyType(' + item.Id + ')"> delete </a>' + ' | ' + '<a href="#" id="btn-update-policy-type" class="btn btn-primary btn-info" onclick="showModalPolicyType(' + item.Id + ')"> update </a>' + '</td>';
                        htmlText += '</tr>';
                    });
                }

                $("#tablePolicyTypeInfo").dataTable().fnClearTable();
                $("#tablePolicyTypeInfo").dataTable().fnDestroy();
                $('#tblPolicyTypeInfo').html(htmlText);
                $('#tablePolicyTypeInfo').DataTable();
                $("select[name*='tblPolicyTypeInfo']").change();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
}
function deletePolicyType(id) {

    if (confirm("If you delete the policy type, the system eliminates the policies linked to this policy type, do you want to continue?") == true) {
        var empObj = {
            Id: id,
        };

        processing: true; // for show progress bar  
        serverSide: true; // for process server side  
        filter: true; // this is for disable filter (search box)  
        orderMulti: false; // for disable multiple column at once
        paging: false;
        $.ajax(
            {
                url: "/PolicyType/DeletePolicyType",
                data: JSON.stringify(empObj),
                type: "POST",
                contentType: "application/json;charset=utf-8",
                success: function (result) {
                    alert("Complete");
                    loadPolicyType();
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
    }

    
}
function showModalPolicyType(id) {

    processing: true; // for show progress bar  
    serverSide: true; // for process server side  
    filter: true; // this is for disable filter (search box)  
    orderMulti: false; // for disable multiple column at once
    paging: false;
    $.ajax(
        {
            url: "/PolicyType/GetPolicyTypeIdentification?Id=" + id,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            success: function (result) {
                if (result.length > 0) {
                    $('.form-panel').find('input').val('');

                    $('#txtPolicyTypeIdUp').val(result[0].Id);
                    $('#txtPolicyTypeTypeUp').val(result[0].Type);
                    $('#txtPolicyTypeDescriptionUp').val(result[0].Description);

                    $('#modalPolicyType').modal('show');
                }
                else {
                    alert("Error al obtener la informacion del PolicyType.");
                }
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
}
function updatePolicyType() {
    var empObj = {
        Id: $('#txtPolicyTypeIdUp').val(),
        Type: $('#txtPolicyTypeTypeUp').val(),
        Description: $('#txtPolicyTypeDescriptionUp').val(),
    };

    processing: true; // for show progress bar  
    serverSide: true; // for process server side  
    filter: true; // this is for disable filter (search box)  
    orderMulti: false; // for disable multiple column at once
    paging: false;
    $.ajax(
        {
            url: "/PolicyType/UpdatePolicyType",
            data: JSON.stringify(empObj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            success: function () {
                alert("Complete");
                loadPolicyType();
                $('#modalPolicyType').modal('hide');

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
}
function insertPolicyType() {
    var empObj = {
        Type: $('#txtPolicyTypeType').val(),
        Description: $('#txtPolicyTypeDescription').val(),
    };

    processing: true; // for show progress bar  
    serverSide: true; // for process server side  
    filter: true; // this is for disable filter (search box)  
    orderMulti: false; // for disable multiple column at once
    paging: false;
    $.ajax(
        {
            url: "/PolicyType/InsertPolicyType",
            data: JSON.stringify(empObj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            success: function () {
                alert("Complete");
                loadPolicyType();
                $("#tabs-policy-type").tabs("option", "active", 1);
                $('.form-panel').find('input').val('');

            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
}