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
    
    public partial class Specialization
    {
        public int SpecializationId { get; set; }
        public Nullable<int> SubjectId { get; set; }
        public Nullable<int> TeacherId { get; set; }
    
        public virtual Subjects Subjects { get; set; }
        public virtual Teachers Teachers { get; set; }
    }
}
