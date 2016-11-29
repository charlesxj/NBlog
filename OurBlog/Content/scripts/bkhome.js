
if (window.top != window) {
    window.top.location.href = "/BkLogin/Index";
}

window.onload = function () {
    function setTimeShow() {
        document.getElementById("TimeShowDiv").innerText = null;
        document.getElementById("TimeShowDiv").innerText = new Date().toLongDateTimeString();
    }
    setInterval(setTimeShow, 1000);
}
function closeWindow() {
    if (confirm("您确定要关闭本页吗？")) {
        window.opener = null;
        window.open('', '_self', '');
        window.close();
    }
}

//创建tab，title判断已经创建，url用于显示内容
function InfoMgList(title, url) {
    if (!$('#tt').tabs('exists', title)) {
        $('#tt').tabs('add', {
            title: title,
            href: url,
            closable: true
        });
    }
}

//test for testing
$(function () {
    $('#tt').tabs({
        border: false,
        onSelect: function (title) {
            //{ alert(title + ' is selected'); }
        },
        //onBeforeClose: function (title) {
        //    return confirm('确认关闭'+title+'?');
        //}
        onBeforeClose: function (title, index) {
            var target = this;
            $.messager.confirm('Confirm', '确认关闭【' + title + '】', function (r) {
                if (r) {
                    var opts = $(target).tabs('options');
                    var bc = opts.onBeforeClose;
                    opts.onBeforeClose = function () { };  // allowed to close now
                    $(target).tabs('close', index);
                    opts.onBeforeClose = bc;  // restore the event function
                }
            });
            return false;	// prevent from closing
        }

    });
});
