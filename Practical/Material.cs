//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Practical
{
    using System;
    using System.Collections.Generic;
    
    public partial class Material
    {
        public int MaterialID { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
        public string FilePath { get; set; }
        public int LectureID { get; set; }
    
        public virtual Lecture Lecture { get; set; }
    }
}
