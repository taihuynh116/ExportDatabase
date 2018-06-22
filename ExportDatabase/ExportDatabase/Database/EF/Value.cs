namespace ExportDatabase.Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Value
    {
        public int ID { get; set; }

        public DateTime CreateDate { get; set; }

        public int IDValueBinding { get; set; }

        public int IDUser { get; set; }

        [Column("Value")]
        [Required]
        [StringLength(200)]
        public string Value1 { get; set; }

        public int? Version { get; set; }

        public virtual User User { get; set; }

        public virtual ValueBinding ValueBinding { get; set; }
    }
}
