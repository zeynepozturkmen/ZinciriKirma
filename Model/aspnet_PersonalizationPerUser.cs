namespace ZinciriKirma.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class aspnet_PersonalizationPerUser
    {
        public Guid Id { get; set; }

        public Guid? PathId { get; set; }

        public Guid? UserId { get; set; }

        [Column(TypeName = "image")]
        [Required]
        public byte[] PageSettings { get; set; }

        public DateTime LastUpdatedDate { get; set; }

        public virtual aspnet_Paths aspnet_Paths { get; set; }

        public virtual aspnet_Users aspnet_Users { get; set; }
    }
}
