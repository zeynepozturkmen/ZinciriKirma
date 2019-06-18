namespace ZinciriKirma.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class aspnet_WebEvent_Events
    {
        [Key]
        [StringLength(32)]
        public string EventId { get; set; }

        public DateTime EventTimeUtc { get; set; }

        public DateTime EventTime { get; set; }

        [Required]
        [StringLength(256)]
        public string EventType { get; set; }

        public decimal EventSequence { get; set; }

        public decimal EventOccurrence { get; set; }

        public int EventCode { get; set; }

        public int EventDetailCode { get; set; }

        [StringLength(1024)]
        public string Message { get; set; }

        [StringLength(256)]
        public string ApplicationPath { get; set; }

        [StringLength(256)]
        public string ApplicationVirtualPath { get; set; }

        [Required]
        [StringLength(256)]
        public string MachineName { get; set; }

        [StringLength(1024)]
        public string RequestUrl { get; set; }

        [StringLength(256)]
        public string ExceptionType { get; set; }

        [Column(TypeName = "ntext")]
        public string Details { get; set; }
    }
}
