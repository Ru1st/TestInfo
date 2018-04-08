$(function () {
    $("#cityName").autocomplete({
        source: function (request, response) {
            $.ajax({
                url: '/Home/GetCities',
                data: "{ 'prefix': '" + request.term + "'}",
                dataType: "json",
                type: "POST",
                contentType: "application/json; charset=utf-8",
                success: function (data) {
                    response(data);
                }
            });
        },
        select: function (e, i) {
            $("#cityId").val(i.item.cityId);
        },
        minLength: 1
    });
});
