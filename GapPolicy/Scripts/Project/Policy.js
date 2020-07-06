$(document).ready(function () {
    //creamos los tabs
    $("#tabs-policy").tabs();

    //creamos los date piker
    $("#txtPolicyStartDate").datepicker();
    $("#txtPolicyEndDate").datepicker();
    $("#txtPolicyStartDateUP").datepicker();
    $("#txtPolicyEndDateUP").datepicker();

    //cargamos las polizas
    loadPolicy();
});
function loadPolicy() {
    processing: true; // for show progress bar  
    serverSide: true; // for process server side  
    filter: true; // this is for disable filter (search box)  
    orderMulti: false; // for disable multiple column at once
    paging: false;
    $.ajax(
        {
            url: "/Policy/GetPolicy",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            success: function (result) {
                let htmlText = "";
                if (result.length > 0) {
                    $.each(result, function (key, item) {
                        htmlText += '<tr>';
                        htmlText += '<td>' + item.Id + '</td>';
                        htmlText += '<td>' + item.Client + '</td>';
                        htmlText += '<td>' + item.TypeDescrip + '</td>';
                        htmlText += '<td>' + item.Percentage + '</td>';
                        htmlText += '<td>' + item.StartDate + '</td>';
                        htmlText += '<td>' + item.EndDate + '</td>';
                        htmlText += '<td>' + item.Period + '</td>';
                        htmlText += '<td>' + item.Cost + '</td>';
                        htmlText += '<td>' + item.RiskType + '</td>';
                        if (item.Status)
                            htmlText += '<td>' + 'Active' + '</td>';
                        else
                            htmlText += '<td>' + 'Cancel' + '</td>';
                        htmlText += '<td>' + '<a href="#" id="btn-delete-client" class="btn btn-primary" onclick="deletePolicy(' + item.Id + ')"> delete </a>' + ' | ' + '<a href="#" id="btn-update-policy" class="btn btn-primary btn-info" onclick="showModalPolicy(' + item.Id + ')"> update </a>' + '</td>';
                        htmlText += '</tr>';
                    });
                }

                $("#tablePolicyInfo").dataTable().fnClearTable();
                $("#tablePolicyInfo").dataTable().fnDestroy();
                $('#tblPolicyInfo').html(htmlText);
                $('#tablePolicyInfo').DataTable();
                $("select[name*='tblPolicyInfo']").change();

                //Cargamos los drop down
                loadClients();
                loadTypes();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
}
function deletePolicy(id) {

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
            url: "/Policy/DeletePolicy",
            data: JSON.stringify(empObj),
            type: "POST",
            contentType: "application/json;charset=utf-8",
            success: function (result) {
                alert("Complete");
                loadPolicy();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
}
function showModalPolicy(id) {

    processing: true; // for show progress bar  
    serverSide: true; // for process server side  
    filter: true; // this is for disable filter (search box)  
    orderMulti: false; // for disable multiple column at once
    paging: false;
    $.ajax(
        {
            url: "/Policy/GetPolicyId?Id=" + id,
            type: "GET",
            contentType: "application/json;charset=utf-8",
            success: function (result) {
                if (result.length > 0) {
                    $('.form-panel').find('input').val('');

                    $('#txtPolicyIdUp').val(result[0].Id);
                    $('#txtPolicyClientUP').val(result[0].Client);
                    $('#txtPolicyTypeUP').val(result[0].Type);
                    $('#txtPolicyPercentageUP').val(result[0].Percentage);
                    $('#txtPolicyStartDateUp').val(result[0].StartDate);
                    $('#txtPolicyEndDateUp').val(result[0].EndDate);
                    $('#txtPolicyPeriodUp').val(result[0].Period);
                    $('#txtPolicyCostUp').val(result[0].Cost);
                    $('#txtPolicyRiskTypeUp').val(result[0].RiskType);

                    $('#modalPolicy').modal('show');
                }
                else {
                    alert("Error al obtener la informacion de la poliza.");
                }
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
}
function updatePolicy() {

    if (($('#txtPolicyRiskTypeUp').val() == 'high') && ($('#txtPolicyPercentageUP').val() > 50)) {
        alert("If the risk is high, the coverage percentage must be less than or equal to 50%");
    }
    else {
        var empObj = {
            Id: $('#txtPolicyIdUp').val(),
            Client: $('#txtPolicyClientUP').val(),
            Type: $('#txtPolicyTypeUP').val(),
            Percentage: $('#txtPolicyPercentageUP').val(),
            StartDate: $('#txtPolicyStartDateUp').val(),
            EndDate: $('#txtPolicyEndDateUp').val(),
            Period: $('#txtPolicyPeriodUp').val(),
            Cost: $('#txtPolicyCostUp').val(),
            RiskType: $('#txtPolicyRiskTypeUp').val(),
        };

        processing: true; // for show progress bar  
        serverSide: true; // for process server side  
        filter: true; // this is for disable filter (search box)  
        orderMulti: false; // for disable multiple column at once
        paging: false;
        $.ajax(
            {
                url: "/Policy/UpdatePolicy",
                data: JSON.stringify(empObj),
                type: "POST",
                contentType: "application/json;charset=utf-8",
                success: function (result) {
                    alert("Complete");
                    loadPolicy();
                    $('#modalPolicy').modal('hide');

                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
    }
}
function insertPolicy() {

    if (($('#txtPolicyRiskType').val() == 'high') && ($('#txtPolicyPercentage').val() > 50)) {
        alert("If the risk is high, the coverage percentage must be less than or equal to 50%");
    }
    else {
        var empObj = {
            Client: $('#txtPolicyClient').val(),
            Type: $('#txtPolicyType').val(),
            Percentage: $('#txtPolicyPercentage').val(),
            StartDate: $('#txtPolicyStartDate').val(),
            EndDate: $('#txtPolicyEndDate').val(),
            Period: $('#txtPolicyPeriod').val(),
            Cost: $('#txtPolicyCost').val(),
            RiskType: $('#txtPolicyRiskType').val(),
        };

        processing: true; // for show progress bar  
        serverSide: true; // for process server side  
        filter: true; // this is for disable filter (search box)  
        orderMulti: false; // for disable multiple column at once
        paging: false;
        $.ajax(
            {
                url: "/Policy/InsertPolicy",
                data: JSON.stringify(empObj),
                type: "POST",
                contentType: "application/json;charset=utf-8",
                success: function (result) {
                    alert("Complete");
                    loadPolicy();
                    $("#tabs-policy").tabs("option", "active", 1);
                    $('.form-panel').find('input').val('');

                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            });
    }
}
function loadClients() {
    processing: true; // for show progress bar  
    serverSide: true; // for process server side  
    filter: true; // this is for disable filter (search box)  
    orderMulti: false; // for disable multiple column at once
    paging: false;
    $.ajax(
        {
            url: "/Policy/GetClients",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            success: function (result) {
                if (result.length > 0) {
                    $.each(result, function (key, item) {
                        $("#txtPolicyClient").append('<option value="' + item.Identification + '">' + item.Identification + '</option>');
                        $("#txtPolicyClientUP").append('<option value="' + item.Identification + '">' + item.Identification + '</option>');
                    });
                }
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
}
function loadTypes() {
    processing: true; // for show progress bar  
    serverSide: true; // for process server side  
    filter: true; // this is for disable filter (search box)  
    orderMulti: false; // for disable multiple column at once
    paging: false;
    $.ajax(
        {
            url: "/Policy/GetPolicyType",
            type: "GET",
            contentType: "application/json;charset=utf-8",
            success: function (result) {
                if (result.length > 0) {
                    $.each(result, function (key, item) {
                        $("#txtPolicyType").append('<option value="' + item.Id + '">' + item.Type + '</option>');
                        $("#txtPolicyTypeUP").append('<option value="' + item.Id + '">' + item.Type + '</option>');
                    });
                }
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
}
