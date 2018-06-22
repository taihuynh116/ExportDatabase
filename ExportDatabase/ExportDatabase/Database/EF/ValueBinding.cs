namespace ExportDatabase.Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ValueBinding
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ValueBinding()
        {
            Values = new HashSet<Value>();
        }

        public int ID { get; set; }

        public DateTime CreateDate { get; set; }

        public int IDElement { get; set; }

        public int IDParameterBinding { get; set; }

        public int Version { get; set; }

        public DateTime LastUpdate { get; set; }

        public virtual Element Element { get; set; }

        public virtual ParameterBinding ParameterBinding { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Value> Values { get; set; }
    }
}
