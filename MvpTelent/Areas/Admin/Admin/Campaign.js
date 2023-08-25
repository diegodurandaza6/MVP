 
function NewCampaign(Id)
{
    model = {
        Id: Id
    }
    $.get("/Admin/Admin/NewCampaign", model, function (response) {
        $("#AddCampaignPopup").html(response);
        $("#AddCampaignPopup").modal("show");

    })
}
function getTagBytypeId(Id) {
    var model = {
        Id: Id
    };
    $.get("/Admin/Admin/getTagBytypeId", model, function (datacollection) {
        var data = datacollection.CampaigntypeCollection;
        $("#tag").empty();
        var html = "";
        $.each(data, function () {
            html += '<li><a><input class="clstag" type="checkbox" name="' + this.Id + '" value="' + this.Id + '" /> ' + this.Name + '</a></li>';
        });
        $("#tag").append(html);        
        var data = $("#hdntagids").val();
        if (data != null)
        {
            var arr = data.split(',');
            for (i = 0; i < arr.length; ++i) {
                $("input[name=" + arr[i] + "]:checkbox").prop('checked', true);
            }
        }
    }); 
     
}
function AddUpdateCampaign(Id)
{ 
    var tagids = "";
    $("input:checkbox[class=clstag]:checked").each(function () {
        tagids += $(this).val() + ",";
    });
    tagids = tagids.slice(0, -1);
     
    AddUpdateCampaignvalidate();
    if ($('#CampaignForm_Popup').valid()) {
        model = {
            Id: Id,
            Name: $("#Name").val(),
            Subject: $("#Subject").val(),
            emailbody: $("#emailbody").val(),
            CStatusId: $("#CStatusId").val(),
            campaigntypeid: $("#campaigntypeid").val(),
            tagids: tagids
        }
        $.post("/Admin/Admin/AddUpdateCampaign", model, function (data) {

            if (Id === 0) {
                toastr.success("Campaign saved successfully.");
                setTimeout(function () { window.location.reload() }, 600);
            }
            else {
                toastr.success("Campaign updated successfully.");
                setTimeout(function () { window.location.reload() }, 600);
            }

        });
    }
}
function AddUpdateCampaignvalidate() {
    $("#CampaignForm_Popup").validate({
        rules: {
            Name: {
                required: true
            },
            Subject: {
                required: true
            },
            emailbody: {
                required: true
            },
              CStatusId: {
                required: true
            },
            campaigntypeid: {
                required: true
            }
        }
    });
}

function DeleteCampaign(Id)
{
    if (DeleteCompaignconfirm() === false) {
        return false;
    }

    model = {
        Id: Id
    };
    $.get("/Admin/Admin/DeleteCampaign", model, function (data) {
        toastr.success("Campaign deleted successfully.");
        setTimeout(function () { location.reload() }, 600);
    });

}
function DeleteCompaignconfirm() {
    return confirm("Are you sure  you want to deleted this campaign.");
}

function getcampainByName()
{
    var Name = $("#_Name").val();
    url = "/Admin/Admin/Campaign?Name=" + Name;
     window.location.href = url;
}

function Reset() {
    url = "/Admin/Admin/Campaign";
    window.location.href = url;
}

function getcampainById()
{
     
    var CampaignId = $("#CampaignId").val();
    url = "/Admin/Admin/campaignhistory?CampaignId=" + CampaignId;
    window.location.href = url;
}

function Resetcontact() {
    url = "/Admin/Admin/campaignhistory";
    window.location.href = url;
}