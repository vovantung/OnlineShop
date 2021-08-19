namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Word")]
    public partial class Word
    {
        public long ID { get; set; }

        public long? LaungeID { get; set; }

        [Column("Word")]
        [StringLength(250)]
        public string Word1 { get; set; }
    }
}
