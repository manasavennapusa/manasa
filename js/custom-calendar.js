// Calendar
$(document).ready(function () {

    var date = new Date();
    var d = date.getDate();
    var m = date.getMonth();
    var y = date.getFullYear();

    var calendar = $('#calendar').fullCalendar({
        header: {
            left: 'prev,next today',
            center: 'title',
            right: 'month,agendaWeek,agendaDay'
        },
        selectable: true,
        selectHelper: true,
        select: function (start, end, allDay) {
            var title = prompt('Event Title:');
            if (title) {
                calendar.fullCalendar('renderEvent',
                    {
                        title: title,
                        start: start,
                        end: end,
                        allDay: allDay
                    },
                    true // make the event "stick"
                );
            }
            calendar.fullCalendar('unselect');
        },
        editable: true,
        events: [
        {
            title: 'P',
            start: new Date(y, m, 1),
            color: '#3AB093'
        },
        {
            title: 'CL',
            start: new Date(y, m, 2),
            color: '#DA4747'
        },
         {
             title: 'P',
             start: new Date(y, m, 7),
             color: '#3AB093'
         },
          {
              title: 'P',
              start: new Date(y, m, 8),
              color: '#3AB093'
          },
           {
               title: 'W',
               start: new Date(y, m, 5),
               color: '#8D8D86'
           },
            {
                title: 'P',
                start: new Date(y, m, 6),
                color: '#3AB093'
            },
             {
                 title: 'P',
                 start: new Date(y, m, 9),
                 color: '#3AB093'
             },
             {
                 title: 'P',
                 color: '#3AB093'
             },
      {
          title: 'Dussehra',
          start: new Date(y, m, d - 7),
          end: new Date(y, m, d -6),
          color: '#47A3FF'
      },
      {
          id: 999,
          title: 'Repeating Event',
          start: new Date(y, m, d - 3, 16, 0),
          allDay: false
      },
     
      {
          title: 'Meeting',
          start: new Date(y, m, d, 10, 30),
          allDay: false
      },
      {
          title: 'Lunch',
          start: new Date(y, m, d, 12, 0),
          end: new Date(y, m, d, 14, 0),
          allDay: false
      },
      {
          title: 'Birthday Party',
          start: new Date(y, m, d + 1, 19, 0),
          end: new Date(y, m, d + 1, 22, 30),
          allDay: false,
          color: '#f3cf59'

      }
     
        ]
    });
});