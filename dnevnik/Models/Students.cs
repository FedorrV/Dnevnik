//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace dnevnik.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Students
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Students()
        {
            this.Ratings = new HashSet<Ratings>();
        }
    
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string patronymic { get; set; }
        public Nullable<System.DateTime> dateBirth { get; set; }
        public string address { get; set; }
        public int StudentId { get; set; }
        public Nullable<int> ShoolId { get; set; }
        public Nullable<int> GradeId { get; set; }
        public string gender { get; set; }
    
        public virtual Grades Grades { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ratings> Ratings { get; set; }
        public virtual Shools Shools { get; set; }
    }
}
