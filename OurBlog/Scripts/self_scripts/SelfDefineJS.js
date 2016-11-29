var txq = (function (txq) {
    /** 
    * 获取指定日期对象当前表示的季度（0 - 3）
    * 注:私有不对外公开!
    */
    var _getQuarter = function (date) {
        date = new Date(date);
        var m = date.getMonth();
        var q = 0;
        if (m >= 0 && m < 3) {
            q = 0;
        } else if (m >= 3 && m < 6) {
            q = 1;
        } else if (m >= 6 && m < 9) {
            q = 2;
        } else if (m >= 9 && m < 12) {
            q = 3;
        }
        return q;
    };

    /**
    * 扩展String类型的formatString功能
    * 
    * @example '字符串{0}字符串{1}字符串'.format('第一个变量','第二个变量');
    * @returns 格式化后的字符串
    */
    String.prototype.format = function () {
        var thisString = this;
        for (var i = 0; i < arguments.length; i++) {
            thisString = thisString.replace('{' + i + '}', arguments[i]);
        }
        return thisString;
    }

    /**
    * 获取当前日期时间的长字符串格式，返回的日期时间字符串格式如 “2013年05月16日 星期四 夏季, 下午 15:38:11”
    *  
    */
    Date.prototype.toLongDateTimeString = function () {
        var date = this;
        var year = date.getFullYear(),
            month = date.getMonth(),
            day = date.getDate(),
            hours = date.getHours(),
            minutes = date.getMinutes(),
            seconds = date.getSeconds(),
            week = date.getDay(),
            quarter = _getQuarter(date),
            hoursArray = ["午夜", "凌晨", "早上", "上午", "中午", "下午", "傍晚", "晚上"],
            weekArray = ["星期日", "星期一", "星期二", "星期三", "星期四", "星期五", "星期六"],
            //monthArray = ["01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"],
            quarterArray = ["春", "夏", "秋", "冬"],
            hourSpan = hoursArray[Math.floor(parseFloat(hours) / 3)],
            weekSpan = weekArray[week],
            //monthSpan = monthArray[month],
            quarterSpan = quarterArray[quarter];
        return "{0}年{1}月{2}日 {3} {4}季, {5} {6}:{7}:{8}".format(
                year,
                ("" + (month + 101)).substr(1),
                ("" + (day + 100)).substr(1),
                weekSpan,
                quarterSpan,
                hourSpan,
                ("" + (hours + 100)).substr(1),
                ("" + (minutes + 100)).substr(1),
                ("" + (seconds + 100)).substr(1));
    };



    return txq;
})(txq)
