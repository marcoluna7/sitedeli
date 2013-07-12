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
    using Alldeli.BusinessLogic.DbLayer;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Category
    {
        public Category()
        {
            this.Menus = new HashSet<Menu>();
        }
    
        public int Id { get; set; }
        public int PartnerId { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Enabled { get; set; }
        public int OrderBy { get; set; }
        public System.DateTime CreatedDate { get; set; }

        [Required]        
        public string CreatedUser { get; set; }
    
        public virtual Partner Partner { get; set; }
        public virtual ICollection<Menu> Menus { get; set; }

        public static List<Category> GetCategories(int partnerId, int parentId)
        {
            List<Category> listaCategorias = null;
            using (DbLayer.AccessDataBase acceso = new DbLayer.AccessDataBase())
            {
                listaCategorias = acceso.GetCategories(parentId, partnerId);
            }
            return listaCategorias;
        }

        public static void CreatedCategory(Category objCategory)
        {
            using (AccessDataBase acceso = new AccessDataBase())
            {
                acceso.InsertCategory(objCategory);
            }
        }


    }
}
