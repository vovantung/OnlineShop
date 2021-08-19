namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Launge")]
    public partial class Launge
    {
        public long ID { get; set; }

        [StringLength(250)]
        public string Name { get; set; }
    }
}
