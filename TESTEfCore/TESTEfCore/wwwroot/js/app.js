let CurrentTask = null;

$(document).ready(function () {
    $('.task').on('click', function () { ChangeTask($(this));});

    $('#addTask').on('click', function () {
        $('.modalNewTask').toggleClass('mOff');
    });

    $('#delTask').on('click', function () {
        if (CurrentTask)
            DeleteTask();
    });

    $('#addTaskClose').on('click', function () {
        $('.modalNewTask').toggleClass('mOff');
    });

    $('#addTaskAccept').on('click', function () {
        const task = $('.newTask').find('.input').val();
        if (Boolean(task)) {
            AppendTask(task);
        }
    });
});

/* Преобразование JSON в объект */
function DesirializeJson(data) {
    return JSON.parse(JSON.stringify(data));
}

/* Выбор текущей задачи*/
function ChangeTask(elem) {
    if (elem.hasClass('tActive')) {
        elem.toggleClass('tActive');
        $('.taskDetailed').toggleClass('tDOff');
        CurrentTask = null;
    }
    else {
        $('.task').each(function () {
            if ($(this).hasClass('tActive')) {
                $(this).toggleClass('tActive');
            }
        });
        elem.toggleClass('tActive');
        CurrentTask = elem;
        if (!$('.taskDetailed').hasClass('tDOff')) {
            $('.taskDetailed').toggleClass('tDOff');
        }
    }
}

/* Удаление задачи */
function DeleteTask() {
    $.post('/Request/DelTask', { name: CurrentTask.text() }, function (data) {
        let response = DesirializeJson(data);
        if (response.status) {
            CurrentTask.remove();
            $('.taskDetailed').toggleClass('tDOff');
            CurrentTask = null;
        }
    });
}

/* Добавление задачи */
function AppendTask(tName) {
    $.post('/Request/NewTask', { name: tName }, function (data) {
        let response = DesirializeJson(data);
        if (response.status) {
            $('.taskList').append($('<div class="task">' + tName + '</div>').on('click', function () { ChangeTask($(this)); }));
            $('.modalNewTask').toggleClass('mOff');
            $('.newTask').find('.input').val('');
        }
    });
}