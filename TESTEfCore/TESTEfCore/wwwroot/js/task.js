window.onload = () => {
    const tasks = document.querySelectorAll('.task');
    tasks.forEach((elem) => {
        elem.addEventListener('click', (t) => {
            if (elem.classList.contains('tActive')) {
                elem.classList.toggle('tActive');
                const tDetailed = document.querySelector('.taskDetailed');
                tDetailed.classList.toggle('tDOff');
            } else {
                tasks.forEach((tk) => {
                    if (tk.classList.contains('tActive')) {
                        tk.classList.toggle('tActive');
                    }
                });
                elem.classList.toggle('tActive');
                const tDetailed = document.querySelector('.taskDetailed');
                if (!tDetailed.classList.contains('tDOff')) {
                    tDetailed.classList.toggle('tDOff');
                }
            }
        })
    });
};