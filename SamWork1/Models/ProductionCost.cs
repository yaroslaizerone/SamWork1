//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SamWork1.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ProductionCost
    {
        public int ID_ProductionCosts { get; set; }
        public int ID_Model { get; set; }
        public decimal SelfCostModel { get; set; }
        public decimal ProductionCost1 { get; set; }
        public Nullable<decimal> SellCost { get; set; }
    
        public virtual Model Model { get; set; }
    }
}