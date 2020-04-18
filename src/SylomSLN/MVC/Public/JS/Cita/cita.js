(() => {

    const calendarIl = gI('calendar-items');

    const arr = ['Event 1', 'Event 2'];
    (() => {
        arr.forEach(o => {
            const div = ndom();
            div.setAttribute('class', 'fc-event');
            div.appendChild(ntn(o));
            calendarIl.appendChild(div);
        });
    })();

    document.addEventListener('DOMContentLoaded', function () {
        const Calendar = FullCalendar.Calendar;
        const Draggable = FullCalendarInteraction.Draggable;

        const containerEl = gI('calendar-evt');
        const calendarEl = gI('calendar-con');


        // initialize the external events
        // -----------------------------------------------------------------

        new Draggable(containerEl, {
            itemSelector: '.fc-event',
            eventData: function (eventEl) {
                return {
                    title: eventEl.innerText
                };
            }
        });

        // initialize the calendar
        // -----------------------------------------------------------------

        var calendar = new Calendar(calendarEl, {
            plugins: ['interaction', 'dayGrid', 'timeGrid'],
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'dayGridMonth'
            },
            locale: 'es',
            editable: false,
            droppable: true,
            drop: function (info) {
                info.allDay = false;
                console.log(info);
            }
        });

        calendar.render();
    });

})();