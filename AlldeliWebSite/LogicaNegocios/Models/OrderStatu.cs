//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Alldeli.BusinessLogic.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderStatu
    {
        public OrderStatu()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public byte Id { get; set; }
        public string Status { get; set; }
    
        public virtual ICollection<Order> Orders { get; set; }
    }
}
