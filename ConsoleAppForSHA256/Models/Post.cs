//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ConsoleAppForSHA256.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Post
    {
        public int ID_Post { get; set; }
        public int ID_User { get; set; }
        public string Name { get; set; }
    
        public virtual User User { get; set; }
    }
}
