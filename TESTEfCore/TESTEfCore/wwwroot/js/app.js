$(document).ready(function () {
    $('.task').on('click', function () {
        if ($(this).hasClass('tActive')) {
            $(this).toggleClass('tActive');
            $('.taskDetailed').toggleClass('tDOff');
        }
        else
        {
            $('.task').each(function (elem) {
                if ($(this).hasClass('tActive')) {
                    $(this).toggleClass('tActive');
                }
            });
            $(this).toggleClass('tActive');
            if (!$('.taskDetailed').hasClass('.taskDetailed')) {
                $('.taskDetailed').toggleClass('tDOff');
            }
        }
    });

    $('#addTask').on('click', function () {
        $('.modalNewTask').toggleClass('mOff');
    });

    $('#addTaskClose').on('click', function () {
        $('.modalNewTask').toggleClass('mOff');
    });
});