namespace ZinciriKirma.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chain")]
    public partial class Chain
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Chain()
        {
            ChainDetails = new HashSet<ChainDetail>();
        }

        public int ChainID { get; set; }

        [Required]
        [StringLength(50)]
        public string ChainName { get; set; }

        [Column(TypeName = "date")]
        public DateTime StartingDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime EndDate { get; set; }

        public Guid UserId { get; set; }

        [Required]
        [StringLength(50)]
        public string Frequency { get; set; }

        public virtual aspnet_Users aspnet_Users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChainDetail> ChainDetails { get; set; }
    }
}
