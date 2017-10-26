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

$(document).on('change', '#audioCodecs', function () {
    /* Get the selected value of dropdownlist */
    var option = $('#audioCodecs option:selected').val()
    $.get('/Generador/GetChannels/' + option, function (data) {
        $('#channels').html(data);
        $('#channels').fadeIn('fast');
    });
});

$(document).on('change', '#audioCodecs', function () {
    /* Get the selected value of dropdownlist */
    var transcoder = $('#transcodeSelect option:selected').val()
    var container = $('#containerSelect option:selected').val()
    var videoCode = $('#transcodeSelect option:selected').val()
    if (true) {

    }
    var option = $('#audioCodecs option:selected').val() + $('#audioCodecs option:selected').val()
    $.get('/Generador/GetAudioBitrate/' + option, function (data) {
        $('#audioBitrate').html(data);
        $('#audioBitrate').fadeIn('fast');
    });
});