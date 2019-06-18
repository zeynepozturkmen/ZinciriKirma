namespace ZinciriKirma.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ChainDetail
    {
        public int ChainDetailID { get; set; }

        [Column(TypeName = "date")]
        public DateTime ChainRingDate { get; set; }

        public bool ChainRingArchieved { get; set; }

        public int ChainID { get; set; }

        public virtual Chain Chain { get; set; }
    }
}
