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
    
    public partial class Lessons
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Lessons()
        {
            this.Ratings = new HashSet<Ratings>();
        }
    
        public Nullable<int> TeacherId { get; set; }
        public Nullable<int> SubjectId { get; set; }
        public int LessonId { get; set; }
        public string timeLesson { get; set; }
        public Nullable<System.DateTime> dateLesson { get; set; }
    
        public virtual Subjects Subjects { get; set; }
        public virtual Teachers Teachers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ratings> Ratings { get; set; }
    }
}