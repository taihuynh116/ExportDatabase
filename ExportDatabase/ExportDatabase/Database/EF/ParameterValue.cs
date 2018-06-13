namespace ExportDatabase.Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ParameterValue
    {
        public int ID { get; set; }

        public DateTime CreateDate { get; set; }

        public int IDElement { get; set; }

        public int IDParameterBinding { get; set; }

        [StringLength(200)]
        public string Value { get; set; }

        public virtual Element Element { get; set; }

        public virtual ParameterBinding ParameterBinding { get; set; }
    }
}
