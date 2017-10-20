$(document).on('change', '#transcodeSelect', function () {
    /* Get the selected value of dropdownlist */
    var option = $(this).val();

    /* Request the partial view with .get request. */
    $.get('/Generador/Containers/' + option, function (data) {
        $('#containers').html(data);
        $('#containers').fadeIn('fast');
        console.log("buuu");
    });
});

$(document).on('change', '#containers', '#containerSelect', function () {
    /* Get the selected value of dropdownlist */
    var option = $(this).find('#containersSelect option:selected').val()
    console.log("option + " + option);
    console.log($(this));

    /* Request the partial view with .get request. */
    $.get('/Generador/VideoCodecs/' + option, function (data) {
        $('#videoCodecs').html(data);
        $('#videoCodecs').fadeIn('fast');
    });

    $.get('/Generador/AudioCodecs/' + option, function (data) {
        $('#audioCodecs').html(data);
        $('#audioCodecs').fadeIn('fast');
    });
});