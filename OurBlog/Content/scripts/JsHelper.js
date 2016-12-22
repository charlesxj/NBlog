
; (function ($) {
    $.extend({
        "JsonToParmas": function (param, key) {
            return parseParams(param, key);
        }
    });
})(jQuery);

function parseParams(param, key) {
    var paramStr = "";
    if (param instanceof String || param instanceof Number || param instanceof Boolean) {
        paramStr += "&" + key + "=" + encodeURIComponent(param);
    } else {
        $.each(param, function (i) {
            var k = key == null ? i : key + (param instanceof Array ? "[" + i + "]" : "." + i);
            paramStr += '&' + parseParams(this, k);
        });
    }
    return paramStr.substr(1);
}

/**
* 扩展方法JsonToParmas功能
* 参数说明：param：出入的json对象；key(可选)，如果出入，这会给json数据中的每个字段加上一个key前缀。
* 举例：
var obj = {
"name": 'tom',
"class": {
    "className": 'class1'
},
"classMates": [{
    "name": 'lily'
}]
};
console.log(parseParam(obj));//name=tom&class.className=class1&classMates[0].name=lily
console.log(parseParam(obj, 'stu'));//stu.name=tom&stu.class.className=class1&stu.classMates[0].name=lily
*/