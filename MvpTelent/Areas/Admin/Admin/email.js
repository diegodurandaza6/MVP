const { flash } = require("modernizr");

function emailpopup(ClientId, Id) {

    model = {
        ClientId: ClientId,
        Id: Id
    };

    $.get("/Admin/Admin/emailpopup", model, function (response) {
        $("#email_PopUp").html(response);
        jQuery.noConflict();
        $("#email_PopUp").modal("show");
    });
}

function ActiveTab(Id, tabId) {

    url = "/Admin/Admin/clientdetail?Ids=" + Id + "&tid=" + tabId;
    window.location.href = url;
}
function emaildetails(ClientId, Id) {

    model = {
        ClientId: ClientId,
        Id: Id
    };

    $.get("/Admin/Admin/emaildetails", model, function (response) {
        $("#email_DetailsPopUp").html(response);
        jQuery.noConflict();
        $("#email_DetailsPopUp").modal("show");
    });
}


function GetEmailTemplateById(Id) {
    model = {
        Id: Id
    };
    $.post("/Admin/Admin/GetEmailTemplateById", model, function (data) {
        $("#Subject").val(data.Subject);
        $("#Description").text(data.Description);
        $("#Description1").text(data.Description1);
        $("#Description2").text(data.Description2);
        $("#Description3").text(data.Description3);
        //$("dv_Description").show();
    });



}
function unsubscribecontect(Id, subscribe) {
    if (unsubscribecontectConfirm() === false) {
        return false;
    }
    model = {
        Id: Id,
        Subscribe: subscribe
    };
    $.get("/Admin/Admin/unsubscribecontect", model, function (data) {
        toastr.success("Status updated successfully.");
        setTimeout(function () { location.reload() }, 600);
    });

}
function reminder1Change() {
    if ($("#FirstFollowDate").val().trim() !== '') {
        var _noOfDaysToAdd = 4;

        Date.prototype.toShortFormat = function () {
            var month_names = ["Jan", "Feb", "Mar",
                "Apr", "May", "Jun",
                "Jul", "Aug", "Sep",
                "Oct", "Nov", "Dec"];
            var day = this.getDate();
            var month_index = this.getMonth();
            var year = this.getFullYear();
            return "" + day + "-" + month_names[month_index] + "-" + year;
        }

        //..............Add days Follow Up 2 .................
        //..............Add days Follow Up 2 .................
        var aa = new Date($("#FirstFollowDate").val());
        var startDate = aa.toShortFormat();
        startDate = new Date(startDate.replace(/-/g, "/"));
        var endDate = "", noOfDaysToAdd = _noOfDaysToAdd, count = 0;
        while (count < noOfDaysToAdd) {
            endDate = new Date(startDate.setDate(startDate.getDate() + 1));
            if (endDate.getDay() !== 0 && endDate.getDay() !== 6) {
                count++;
            }
        }
         
        var x = new Date(endDate);
        var day = x.getDate();
        var month = parseInt(x.getMonth()) + 1;
        var year = x.getFullYear();
        $("#secondFollowDate").val(month + '/' + day + '/' + year);
        //if (day === 1) {
        //    var month1 = parseInt(x.getUTCMonth()) + 2;
        //    var year1 = x.getFullYear();
        //    $("#secondFollowDate").val(month1 + '/' + day + '/' + year1);
        //} else {
        //    var month = parseInt(x.getUTCMonth()) + 1;
        //    var year = x.getFullYear();
        //    $("#secondFollowDate").val(month + '/' + day + '/' + year);
        //}
        //..............Add days Follow Up 3 .................
        var aa = new Date($("#secondFollowDate").val());
        var startDate = aa.toShortFormat();
        startDate = new Date(startDate.replace(/-/g, "/"));
        var endDate = "", noOfDaysToAdd = _noOfDaysToAdd, count = 0;
        while (count < noOfDaysToAdd) {
            endDate = new Date(startDate.setDate(startDate.getDate() + 1));
            if (endDate.getDay() !== 0 && endDate.getDay() !== 6) {
                count++;
            }
        }  
        var x = new Date(endDate);
        var day = x.getDate();
        if (day === 1) {
            var month1 = parseInt(x.getUTCMonth()) + 2;
            var year1 = x.getFullYear();
            var dd = month + '/' + day + '/' + year;
            $("#thirdfollowdate").val(month1 + '/' + day + '/' + year1);
        } else {
            var month = parseInt(x.getUTCMonth()) + 1;
            var year = x.getFullYear();
            var dd = month + '/' + day + '/' + year;
            $("#thirdfollowdate").val(month + '/' + day + '/' + year);
        }
    }
}
function convertdate(date) { 
    var aa = new Date(date);
    var startDate = aa.toShortFormat();
    var x = new Date(startDate);
    var day = x.getDate();
    var date;
    if (day === 1) {
        var month1 = parseInt(x.getUTCMonth()) + 2;
        var year1 = x.getFullYear();
        date = year1 + '/' + month1 + '/' + day;
    }
    else {
        var month = parseInt(x.getUTCMonth()) + 1;
        var year = x.getFullYear();
        date = year + '/' + month + '/' + day;
    }
    return date;
}



function FollowUpOnChange(Id) {

    if ($('input[name="isfollow"]').prop("checked") === true) {
        $("#Dv_ReminderSection").show();
        $("#Dv_ReminderDescriptionSection").show();
    }
    else {
        $("#Dv_ReminderSection").hide();
        $("#Dv_ReminderDescriptionSection").hide();
    }
}

function emailsend(Id) {

    debugger;

     
   

    var EmailId = '';
    $.each($("input[name='Email']:checked"), function () {
        EmailId = EmailId + $(this).attr("id") + ',';
    });
    if (EmailId === '') {
        toastr.info("Please select contact.");
        return false;
    }
    if ($("#TemplateId").val() == "") {
        toastr.info("Please select email templete.");
        return false;
    }


    if ($("#Subject").val() == "") {
        toastr.info("Please enter subject.");
        return false;
    } 

    var FollowUp = "";
    if ($('input[name="isfollow"]').prop("checked") === true) {
        FollowUp = 1; 
        if ($("#FirstFollowDate").val() == "") {
            toastr.info("Please select first follow up date.");
            return false;
        } 
    }
    else
    {
        FollowUp = 0;
        $('#Description1').val(null);
        $('#Description2').val(null);
        $('#Description3').val(null);
        $('#FirstFollowDate').val(null);
        $('#secondFollowDate').val(null);
        $('#thirdfollowdate').val(null);
    }
    var firstdate;
    var secondFollowDate;
    var thirdfollowdate;
    var Group;

    //if ($('input[name="isfollow"]').prop("checked") === true) {
    //    firstdate = convertdate($('#FirstFollowDate').val());
    //    secondFollowDate = convertdate($('#secondFollowDate').val());
    //    thirdfollowdate = convertdate($('#thirdfollowdate').val());
    //}

    $("#sendemailpopup").val('Sending...');
    $("#sendemailpopup").attr('disable', true);
     
    if ($("#GroupId").val() > 0) {
        Group = $("#GroupId option:selected").text();
    }
    model = {
        Id: Id,
        isfollow: FollowUp,
        EmailId: EmailId/*.slice(0, -1)*/,
        TemplateId: $("#TemplateId").val(),
        Subject: $('#Subject').val(),
        Description: $("#Description").val(),
        Description1: $("#Description1").val(),
        Description2: $("#Description2").val(),
        Description3: $("#Description3").val(),
        FirstFollowDate: $('#FirstFollowDate').val(),
        secondFollowDate: $('#secondFollowDate').val(),
        thirdfollowdate: $('#thirdfollowdate').val(),
        GroupId: $("#GroupId").val(),
        Group: Group
    };

    $("#sendemailpopup").text('Email sending...');
    $("#sendemailpopup").attr("disabled", true);
    $("#btn_emailsend").attr("disabled", true);
    $.post("/Admin/Admin/emailsend", model, function (data) {
        if (data === "1") {
            if (Id === 0) {
                toastr.success("Email sent successfully.");
                setTimeout(function () { location.reload() }, 400);
            }
            else {
                toastr.success("Email updated successfully.");
                setTimeout(function () { location.reload() }, 400);
            }
        } else {
            toastr.warning(data);
        }
    });
    $("#sendbtn").attr("disabled", false);
}

function ChanageFollowUpStatusConfirm(statusId) {
    if (statusId == 2) {
        return confirm(" Do you really want to deleted this record?");
    } else {

        return confirm(" Do you really want to change status?");
    }
}

function ChanageFollowUpStatus(Id, statusId) {

    if (ChanageFollowUpStatusConfirm(statusId) === false) {
        return false;
    }

    model = {
        Id: Id,
        StatusId: statusId
    };
    $.get("/Admin/Admin/ChanageFollowUpStatus", model, function (data) {
        toastr.success("Status updated successfully.");
        setTimeout(function () { location.reload() }, 600);
    });
}




function changePipelinestatusConfirm() {
    return confirm(" Do you really want to change the pipeline status ?");
}

function changePipelinestatus(Id, statusId) {

    if (changePipelinestatusConfirm() === false) {
        return false;
    }

    model = {
        Id: Id,
        StatusId: statusId
    };
    $.get("/Admin/Admin/changePipelinestatusConfirm", model, function (data) {
        toastr.success("Status updated successfully.");
        setTimeout(function () { location.reload() }, 600);
    });
}
function unsubscribecontectConfirm(statusId) {
    return confirm(" Do you really want to change the status?");
}

//function Candidategroup(Id) {
//     

//    //window.Location.href = url;
//    if ($("#GroupId").val() === 0) {

//        $("#Description").val(null);
//    }
//    else {
//        var GroupUrl = "/Home/candidatelist?groupId=" + Id;
//        $("#Description").val(GroupUrl);
//    }


//}


function emailEditpopup(Id) {
    model = {
        Id: Id
    },
        $.get("/Admin/Admin/emailEditpopup", model, function (response) {
            $("#Emaileditpopup_Id").html(response);
            jQuery.noConflict();
            $("#Emaileditpopup_Id").modal("show");
        });
}

function Updateemailsend(Id) {
    debugger;
    var dd = $("#Subject").val();
    if ($("#Subject").val() == "") {
        toastr.info("Please enter subject.");
        return false;
    }
    model = {
        Id: Id,
        Subject: $("#Subject").val(),
        Description1: $("#Description1").val(),
        Description2: $("#Description2").val(),
        Description3: $("#Description3").val(),
    }
    $.post("/Admin/Admin/Updateemailsend", model, function () {

        toastr.success("Email updated successfully.");
        setTimeout(function () { location.reload() }, 600);
    });
}