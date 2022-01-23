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

    $('#addPurposeClose').on('click', function () {
        $('.modalNewPurspose').toggleClass('mOff');
    });

    $('#addTaskAccept').on('click', function () {
        const task = $('.newTask').find('.input').val();
        if (Boolean(task)) {
            AppendTask(task);
        }
    });

    $('#addPurposeAccept').on('click', function () {
        const name = $('.newPurspose').find('.inputName').val();
        const text = $('.newPurspose').find('.inputDesc').val();
        const date = $('.newPurspose').find('.inputTime').val();
        AppendPurpose(name, text, date);
    });

    $('.purposeHeader').on('click', function () { OpenPurpose($(this).parent()); });

    $('#addPurpose').on('click', function () {
        $('.modalNewPurspose').toggleClass('mOff');
    });

    setInterval(function () {
        CheckPurpose();
    }, 1000);
});

function ViewTasks() {
    if ($('.taskList').find('task').length < 1) {
        location.reload();
    }
}

function CheckPurpose() {
    $('.currentTask').find('.purpose').find('li').each(function () {
        const purpose = $(this);
        const pHeader = purpose.find('.purposeHeader');
        const endTime = new Date(pHeader.find('.purposeEndTime').text());
        const idPurpose = pHeader.find('.idPurpose').text();
        if (endTime < new Date()) {
            $.post('/Request/OverduePurpose', { id: idPurpose }, function (data) {
                const response = DesirializeJson(data);
                if (response.status) {
                    purpose.remove();
                    response.response.forEach(function (item) {
                        CreatePurpose(item);
                    });
                }
            });
        }
    });
}

//Раскрытие цели
function OpenPurpose(elem) {
    elem.find('.purposeDesc').toggleClass('pDescOff');
}

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
        $('.taskDetailed').find('.taskName').find('.header').text(CurrentTask.text());
        GetPurposes(CurrentTask.text());
        if (!$('.taskDetailed').hasClass('tDOff')) {
            $('.taskDetailed').toggleClass('tDOff');
        }
    }
}

/* Удаление задачи */
function DeleteTask() {
    $.post('/Request/DelTask', { name: CurrentTask.text() }, function (data) {
        const response = DesirializeJson(data);
        if (response.status) {
            ViewTasks();
        }
    });
}

/* Добавление задачи */
function AppendTask(tName) {
    $.post('/Request/NewTask', { name: tName }, function (data) {
        const response = DesirializeJson(data);
        if (response.status) {
            ViewTasks();
        }
    });
}

/* Получение целей для задания */
function GetPurposes(tName) {
    $.post('/Request/GetPurposes', { name: tName }, function (data) {
        const response = DesirializeJson(data);
        if (response.status) {
            $('.currentTask').find('.purpose').empty();
            $('.overdueTask').find('.purpose').empty();
            $('.completedTask').find('.purpose').empty();
            response.response.forEach(function (item) {
                CreatePurpose(item);
            });
        }
    });
}

function CreatePurpose(elem) {
    /* Удаление цели */
    const deleteBlock = $('<span class="actBtn">-</span>').on('click', function () {
        const idPurpose = $(this).parent().find('.idPurpose').text();
        $.post('/Request/DelPurpose', { id: idPurpose }, function (data) {
            const response = DesirializeJson(data);
            if (response.status) {
                deleteBlock.parent().parent().remove();
            }
        });
    });

    /* Выполнение цели */
    const completedBlock = $('<span class="actBtn">&#10004;</span>').on('click', function () {
        const idPurpose = $(this).parent().find('.idPurpose').text();
        $.post('/Request/CompletedPurpose', { id: idPurpose }, function (data) {
            const response = DesirializeJson(data);
            if (response.status) {
                deleteBlock.parent().parent().remove();
                response.response.forEach(function (item) {
                    CreatePurpose(item);
                });
            }
        });
    });

    let block = $('<li><div class="purposeHeader"><span class="idPurpose">' + elem.id + '</span><span class="purposeEndTime" style="display:none;">' + elem.endTime + '</span><span class="grow">' + elem.header + '</span><span class="green">' + new Date(elem.createTime).toLocaleDateString() + '</span><span class="brown">' + new Date(elem.endTime).toLocaleString() + '</span></div><div class="purposeDesc pDescOff">' + elem.text + '</div></li>').on('click', function () { OpenPurpose($(this)); });
    block.find('.purposeHeader').append(deleteBlock);
    if (elem.status == 0) {
        block.find('.purposeHeader').append(completedBlock);
        $('.currentTask').find('.purpose').append(block);
    }
    else if (elem.status == 1)
        $('.overdueTask').find('.purpose').append(block);
    else if (elem.status == 2)
        $('.completedTask').find('.purpose').append(block);
}

/* Добавление цели */
function AppendPurpose(pName, pText, pDate) {
    $.post('/Request/AddPurpose', { name: pName, taskName: CurrentTask.text(), endTime: pDate, text: pText }, function (data) {
        const response = DesirializeJson(data);
        if (response.status) {
            response.response.forEach(function (item) {
                CreatePurpose(item);
            });
            $('.modalNewPurspose').toggleClass('mOff');
            $('.modalNewPurspose').find('.newPurspose').find('.inputTime').val('');
            $('.modalNewPurspose').find('.newPurspose').find('.inputName').val('');
            $('.modalNewPurspose').find('.newPurspose').find('.inputDesc').val('');
        }
    });
}