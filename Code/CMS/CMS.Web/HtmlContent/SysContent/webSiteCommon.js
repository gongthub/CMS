

function submitMessage() {
    $.ajax({
        url: "/WebSiteCommon/SubmitMessage",
        data: $("#formMessage").serialize(),
        type: "post",
        dataType: "json",
        success: function (data) {
            if (data.state == true) {
                alert(data.message);
                $("#formMessage")[0].reset();
            } else {
                alert(data.message);
            }
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            alert(errorThrown, "error");
        },
        beforeSend: function () {
        },
        complete: function () {
        }
    });
}
