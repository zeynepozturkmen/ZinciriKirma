namespace ZinciriKirma.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class aspnet_SchemaVersions
    {
        [Key]
        [Column(Order = 0)]
        public string Feature { get; set; }

        [Key]
        [Column(Order = 1)]
        public string CompatibleSchemaVersion { get; set; }

        public bool IsCurrentVersion { get; set; }
    }
}
