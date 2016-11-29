$(function () {
    $("#imgCode").attr("src", "/BkLogin/ShowValidateCode?id=" + guid());
    $("#imgCode").click(changeCheckCode);
});


function guid() {
    return 'xxxxxxxx-xxxx-4xxx-yxxx-xxxxxxxxxxxx'.replace(/[xy]/g, function (c) {
        var r = Math.random() * 16 | 0, v = c == 'x' ? r : (r & 0x3 | 0x8);
        return v.toString(16);
    });

}

function changeCheckCode() {
    $("#imgCode").attr("src", "/BkLogin/ShowValidateCode?id=" + guid());
    //  $("#imgCode").attr("src", $("#imgCode").attr("src") + guid);
}

//异步请求成功之后，执行的代码。
function afterLogin(data) {
    alert(data);
    window.location.href = "/BkHome/index";
    //if (data.result == "ok") {
    //    window.location.href = "/BkHome/index";
    //} else {
    //    if (data.result == "error") {
    //        alert(data.info);
    //        changeCheckCode();
    //    } else {
    //        //window.top.location.href = "/Error.html";
    //    }

    //}
}

$(function () {
    $('#btnLogin').on('click', function (data) {
        $.ajax({
            method: "post",
            cache: false,
            url: "BkLogin/index",
            data: { LoginCode: $('#LoginCode').val(), LoginPwd: $('#LoginPwd').val(), vCode: $('#vCode').val() }
        }).done(function (data) {
            if (data.result == "ok") {
                window.location.href = "/BkHome/index";
            } else {
                if (data.result == "error") {
                    alert(data.info);
                    changeCheckCode();
                } else {
                    //window.top.location.href = "/Error.html";
                }

            }
        }).fail(function (jqXHR, textStatus) {
            alert("请求失败：" + textStatus);
        });
    });
});