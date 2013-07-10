using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Alldeli.BusinessLogic.Models;
using System.Data;
using System.Data.SqlClient;

namespace Alldeli.BusinessLogic.DbLayer
{
    public class AccessDataBase : AccesSqlBase // Heredamos de esta clase
    {

        //primer metodo
        public Category GetCategoryById(int id)
        {
            return this.GetSingleBase<Category>("GetCategories", 
                parametro: getParam("@id", System.Data.SqlDbType.Int, id));
            //Y es todo
        }

        public List<Category> GetCategories(int parentId, int partnerId)
        {
            List<SqlParameter> lista = new List<SqlParameter>();
            if (parentId > 0)
            {
                SqlParameter parametro = new SqlParameter("@parentId", SqlDbType.Int);
                parametro.Value = parentId;
                lista.Add(parametro);
            }
            if(partnerId >0)
            {
                SqlParameter parametro = new SqlParameter("@partnerId", SqlDbType.Int);
                parametro.Value = partnerId;
                lista.Add(parametro);
            }
            return this.GetListBase<Category>("GetCategories", listaParametros:lista.ToArray());
        }

        public void InsertCategory(Category objCategory)
        {
            string[] nombres = { "@PartnerId", "@ParentId", "@Name", "@Description", "@Enabled", "@OrderBy", "@CreatedDate", "@CreatedUser" };
            SqlDbType[] tipos = { SqlDbType.Int, SqlDbType.Int , SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Bit, SqlDbType.Int,SqlDbType.SmallDateTime, SqlDbType.VarChar    };
            object[] valores = { objCategory.PartnerId, objCategory.ParentId, objCategory.Name, objCategory.Description, objCategory.Enabled, objCategory.OrderBy, objCategory.CreatedDate, objCategory.CreatedUser};

            SqlParameter parametro = null;
            if(objCategory.Id > 0)
            {
                 parametro = new SqlParameter("@id", SqlDbType.Int);
                parametro.Value = objCategory.Id;
            }


            objCategory.Id = this.ExecuteScalar<int>("InsertCategories", parametros: getParams(nombres, tipos, valores), parametro: parametro);


       }


        public void DeleteCategory(int id)
        {
            this.executeNonQuery("DeleteCategories", parametro: getParam("@id", SqlDbType.Int, id));
        }




    }
}
