namespace ExportDatabase.Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ParameterBinding
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ParameterBinding()
        {
            ValueBindings = new HashSet<ValueBinding>();
        }

        public int ID { get; set; }

        public DateTime CreateDate { get; set; }

        public int IDCategory { get; set; }

        public int IDParameterName { get; set; }

        public int IDTask { get; set; }

        public virtual Category Category { get; set; }

        public virtual ParameterName ParameterName { get; set; }

        public virtual Task Task { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ValueBinding> ValueBindings { get; set; }
    }
}
