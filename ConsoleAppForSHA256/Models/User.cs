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
    
    public partial class User
    {
        public int ID_User { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string E_mail { get; set; }
        public string Сonfirmed { get; set; }
        public int ID_Staff { get; set; }
    
        public virtual Staff Staff { get; set; }
    }
}
