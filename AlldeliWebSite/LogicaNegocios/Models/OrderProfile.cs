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
    
    public partial class OrderProfile
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CityId { get; set; }
        public string ZipCode { get; set; }
        public string Name { get; set; }
        public string FirstnName { get; set; }
        public string SecondName { get; set; }
        public bool IsHomeDelivery { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
    
        public virtual Order Order { get; set; }
    }
}
