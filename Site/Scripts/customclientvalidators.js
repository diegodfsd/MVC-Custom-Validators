(function ($) {

    $.validator.addMethod("mvcminage", function (value, element, parameters) {
        var sdate = value.split('/'),
            smindate = parameters['mindate'].split('/'),
            mindate = new Date(smindate[2], smindate[1] - 1, smindate[0]),
            date = new Date(sdate[2], sdate[1] - 1, sdate[0]);

        return (mindate >= date);
    });

    $.validator.unobtrusive.adapters.add("mvcminage",
        ["mindate", "minage", "today"],
        function(options) {
            options.messages['mvcminage'] = options.message;
            options.rules['mvcminage'] = options.params;
        }
    );
    
    $.validator.addMethod("mvcdaterange", function (value, element, parameters) {
        var sdate = value.split('/'),
            smindate = parameters['mindate'].split('/'),
            smaxdate = parameters['maxdate'].split('/'),
            mindate = new Date(smindate[2], smindate[1] - 1, smindate[0]),
            maxdate = new Date(smaxdate[2], smaxdate[1] - 1, smaxdate[0]),
            date = new Date(sdate[2], sdate[1] - 1, sdate[0]);

        return (date >= mindate && date <= maxdate);
    });

    $.validator.unobtrusive.adapters.add("mvcdaterange",
        ["mindate", "maxdate"],
        function (options) {
            options.messages['mvcdaterange'] = options.message;
            options.rules['mvcdaterange'] = options.params;
        }
    );

})(jQuery);