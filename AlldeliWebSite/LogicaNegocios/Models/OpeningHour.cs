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
    
    public partial class OpeningHour
    {
        public int Id { get; set; }
        public int RestaurantId { get; set; }
        public string InitialTime { get; set; }
        public string FinalTime { get; set; }
        public Nullable<int> WeekDay { get; set; }
        public bool AllDays { get; set; }
    
        public virtual Restaurant Restaurant { get; set; }
    }
}
