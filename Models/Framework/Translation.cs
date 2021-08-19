namespace Models.Framework
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Translation")]
    public partial class Translation
    {
        public long ID { get; set; }

        public long? WordID { get; set; }

        public long? ToWordID { get; set; }

        [StringLength(250)]
        public string LaungeID { get; set; }

        [StringLength(250)]
        public string ToLaungeID { get; set; }
    }
}
