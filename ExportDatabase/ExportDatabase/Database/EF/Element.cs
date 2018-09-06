namespace ExportDatabase.Database.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Element
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Element()
        {
            ValueBindings = new HashSet<ValueBinding>();
        }

        public int ID { get; set; }

        public DateTime CreateDate { get; set; }

        public int IDCategory { get; set; }

        public int IDProject { get; set; }

        [StringLength(200)]
        public string GUID { get; set; }

        public DateTime LastUpdate { get; set; }

        public bool IsValidated { get; set; }

        public virtual Category Category { get; set; }

        public virtual Project Project { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ValueBinding> ValueBindings { get; set; }
    }
}
