using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;




namespace ZinciriKirma.Model
{
    public class CalendarEvent
    {
        //[Key, DatabaseGenerated(DatabaseGeneratedOption.None)]

        [KeyAttribute()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
        public string title { get; set; }
        public string start { get; set; }
        public string end { get; set; }
        public string color { get; set; }
        public bool allday { get; set; }



       

    }
}