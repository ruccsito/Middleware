$(document).on('change', '#transcodeSelect', function () {
    var option = $(this).val();
    $.get('/Generador/Containers/' + option, function (data) {
        $('#containers').html(data);
        $('#containers').fadeIn('fast');
    });
});

$(document).on('change', '#containers', '#containerSelect', function () {
    var option = $(this).find('#containersSelect option:selected').val()

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
    var option = $('#audioCodecs option:selected').val()
    $.get('/Generador/GetChannels/' + option, function (data) {
        $('#channels').html(data);
        $('#channels').fadeIn('fast');
    });

    $.get('/Generador/GetAudioBitrate/' + option, function (data) {
        $('#audioBitrate').html(data);
        $('#audioBitrate').fadeIn('fast');
    });
});

//$(document).on('change', '#audioCodecs', function () {
//    /* Get the selected value of dropdownlist */
//    var transcoder = $('#transcodeSelect option:selected').val()
//    var container = $('#containers').find('#containersSelect option:selected').val()
//    var codec = $('#audioCodecs option:selected').val()

//    if (transcoder == "FFmpeg" && container == "MP4" && codec == "MP3") {
//        console.log("La mezcla magica");
//        $.get('/Generador/GetAudioBitrate/FMM', function (data) {
//            $('#audioBitrate').html(data);
//            $('#audioBitrate').fadeIn('fast');
//        });
//    }

//    else {
//        var option = $('#audioCodecs option:selected').val()
//        $.get('/Generador/GetAudioBitrate/' + option, function (data) {
//            $('#audioBitrate').html(data);
//            $('#audioBitrate').fadeIn('fast');
//        });
//    }
//});