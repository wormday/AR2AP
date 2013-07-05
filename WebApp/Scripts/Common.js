function ShowCommonDialog() {
    var dialogWidth = $(this).attr("dialogWidth");
    var dialogHeight = $(this).attr("dialogHeight");
    var dialogTitle = $(this).attr("dialogTitle");
    $("div#body").append("<div id='dialog' title=" + dialogTitle + "><div id='dialogContent'></div></div>");
    var showDialogContent = function (data) {
        var div = $("#dialogContent");
        div.html(data);
    }
    var showDialogResult = function (data) {
        var div = $("#dialogContent");
        if (data == 'OK') {
            alert("OK");
            $("#dialog").dialog("close");
        }
        else {
            div.html(data);
        }
    }
    $("#dialog").dialog({
        autoOpen: false,
        show: {
            effect: "blind",
            duration: 300
        },
        hide: {
            effect: "Clip",
            duration: 300
        },
        modal: true,
        height: dialogHeight,
        width: dialogWidth,
        buttons: {
            "Submit": function () {
                var frm = $("div#dialogContent form");
                $.post(frm.attr("action"), frm.serialize(), showDialogResult);
                var div = $("#dialogContent");
                div.html('<img src="/Images/loading01.gif" />正在提交，请稍后...');
            },
            "Cancel": function () { $(this).dialog("close"); },
            "ABC": function () { alert('dddd') }

        }
    });

    var div = $("#dialogContent");
    div.html('<img src="/Images/loading01.gif" />Loading...');
    $("#dialog").dialog("open");
    $.get($(this).attr("href"), '', showDialogContent);
    return false;
}