window.onload = () => {
    const newTask = document.getElementById("addTask");
    newTask.addEventListener("click", () => {
        const modal = document.querySelector(".modalNewTask");
        console.log(modal);
        modal.classList.toggle('mOff');
    });

    const newTaskClose = document.getElementById("addTaskClose");
    newTaskClose.addEventListener("click", () => {
        const modal = document.querySelector(".modalNewTask");
        console.log(modal);
        modal.classList.toggle('mOff');
    });
};