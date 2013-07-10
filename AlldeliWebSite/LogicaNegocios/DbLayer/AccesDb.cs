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
        //Empiezan metodos para ValuesItem

        public ValuesItem GetValuesItemById(int id)
        {
            return this.GetSingleBase<ValuesItem>("GetValuesItem",
                parametro: getParam("@Id",System.Data.SqlDbType.Int,id));
        }

        public List<ValuesItem> GetCategories(int id)
        {
            SqlParameter parametro = null;

            if (id > 0)
            {
                parametro = new SqlParameter("@Id", SqlDbType.Int);
                parametro.Value = id;
            }
            else
            {
                parametro = new SqlParameter("@Id", SqlDbType.Int);
                parametro.Value = id;
            }
            return this.GetListBase<ValuesItem>("", parametro: parametro);
        }

        public void InsertValuesItem(ValuesItem objValuesItem)
        {
            string[] nombres = { "@ItemMenuId ", "@ItemMenuId ", "@Value ", "@OrderBy " };
            SqlDbType[] tipos = { SqlDbType.Int, SqlDbType.VarChar, SqlDbType.TinyInt };
            object[] valores = { objValuesItem.ItemMenuId, objValuesItem.Value, objValuesItem.OrderBy };

            SqlParameter parametro = null;

            if (objValuesItem.Id > 0)
            {
                parametro = new SqlParameter("@Id", SqlDbType.Int);
            }
            objValuesItem.Id = this.ExecuteScalar<int>("InsertValuesItem", parametros: getParams(nombres, tipos, valores), parametro: parametro);
        }
        public void DeleteValuesItem(int id)
        {
            this.executeNonQuery("DeleteValuesItem", parametro: getParam("@id", SqlDbType.Int, id));
        }

        //Terminan metodos para ValuesItem

        //Empiezan metodos para usuarios
        public User GetUserById(int id)
        {
            return this.GetSingleBase<User>("GetUsers",
                parametro: getParam("Id",System.Data.SqlDbType.Int, id));
        }

        public List<User> GetUser(int id)
        {
            SqlParameter parametro = null;
            if(id>0)
            {
                parametro = new SqlParameter("@Id",System.Data.SqlDbType.Int);
                parametro.Value = id;
            }
            else
            {
                parametro = new SqlParameter("@Id", System.Data.SqlDbType.Int);
                parametro.Value = id;
            }
            return this.GetListBase<User>("GetUsers",parametro:parametro);
        }

        public void InsertUser(User objUser)
        {
            string[] nombres = { "@UserName ", "@Password ", "@Enabled ", "@Block ", "@LastLogin ", "@CreatedDate ", "@UpdatedDate " };
            SqlDbType[] tipos = { SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.Bit,SqlDbType.Bit,SqlDbType.SmallDateTime,SqlDbType.SmallDateTime,SqlDbType.SmallDateTime};
            object []valores = {objUser.UserName,objUser.Password,objUser.Enabled,objUser.Block,objUser.LastLogin,objUser.CreatedDate,objUser.UpdatedDate };

            SqlParameter parametro = null;
            if(objUser.Id>0)
            {
                parametro = new SqlParameter("@Id",SqlDbType.Int);
                parametro.Value = objUser.Id;
            }
            else
            {
                parametro = new SqlParameter("@Id", SqlDbType.Int);
                parametro.Value = objUser.Id;
            }
            objUser.Id = this.ExecuteScalar<int>("InsertUsers", parametros: getParams(nombres,tipos,valores),parametro:parametro);
        }
        public void DeleteUser(int id)
        {
            this.executeNonQuery("DeleteUsers", parametro: getParam("@Id",SqlDbType.Int,id));
        }
        //Terminan metodos para usuarios
        
        //empiezan metodos de estados states
        public State GetStateById(int id)
        {
            return this.GetSingleBase<State>("GetStates",
                parametro : getParam ("@Id",System.Data.SqlDbType.Int,id));

        }

        public List<State> GetState(int id)
        {
            SqlParameter parametro = null;
            if (id > 0)
            {
                parametro = new SqlParameter("@Id",SqlDbType.Int);
                parametro.Value = id;
            }
            {
                parametro = new SqlParameter("@Id", SqlDbType.Int);
                parametro.Value = id;
            }
            return this.GetListBase<State>("GetStates",parametro:parametro);
        }

        public void InsertState(State objState)
        {
            string[] nombres = { "@IdCountry", "@State" };
            SqlDbType[] tipos = { SqlDbType.Int, SqlDbType.VarChar};
            object[] valores = { objState.IdCountry,objState.State1 };

            SqlParameter parametro = null;
            if(objState.Id>0)
            {
                parametro = new SqlParameter("@Id",SqlDbType.Int);
            }
            objState.Id = this.ExecuteScalar<int>("InsertStates",parametros: getParams(nombres,tipos,valores),parametro:parametro);
        }

        public void DeleteStates(int id)
        {
            this.executeNonQuery("DeleteStates",parametro: getParam("@Id",SqlDbType.Int,id));
        }
        //terminan metodos de estados states

        //empiezan metodos costos de compra shopping  cost
        public ShippingCost GetShipingCostById(int id)
        {
            return this.GetSingleBase<ShippingCost>("GetShippingCosts",
                parametro: getParam("@Id", System.Data.SqlDbType.Int, id));
        }

        public List<ShippingCost> GetShipingCost(int OrderId, int PartnerId)
        {
            SqlParameter parametro = null;
            if(OrderId >0)
            {
                parametro = new SqlParameter("@OrderId", SqlDbType.Int);
                parametro.Value = OrderId;
            }
            else
            {
                parametro = new SqlParameter("@PartnerId", SqlDbType.Int);
                parametro.Value = PartnerId;
            }
            return this.GetListBase<ShippingCost>("GetShippingCosts",parametro:parametro);
        }

        public void InsertShippingCost(ShippingCost objShipingCost)
        {
            string[] nombres = { "@OrderId ", "@PartnerId ", "@Cost " };
            SqlDbType[] tipos = { SqlDbType.Int,SqlDbType.Int,SqlDbType.SmallMoney };
            object[] valores = { objShipingCost.OrderId,objShipingCost.PartnerId,objShipingCost.Cost };

            SqlParameter parametro = null;
            if(objShipingCost.Id>0)
            {
                parametro = new SqlParameter("@Id",SqlDbType.Int);
                parametro.Value = objShipingCost.Id;
            }
            objShipingCost.Id = this.ExecuteScalar<int>("InsertShippingCosts",parametros: getParams(nombres,tipos,valores),parametro:parametro);

        }

        public void DeleteShipingCost(int id)
        {
            this.executeNonQuery("DeleteShippingCosts", parametro: getParam("@Id",SqlDbType.Int,id));
        }
        //terminan metodos costos de compra shopping  cost

        //Empiezan metodos de Sellers

        public Seller GetSellerById(int id)
        {
            return this.GetSingleBase<Seller>("",
                parametro: getParam("GetSellers", System.Data.SqlDbType.Int, id));
        }

        public List<Seller> GetSeller( int ParentId, int UserId)
    {
        SqlParameter parametro = null;

        if(ParentId > 0)
    {
        parametro = new SqlParameter("@ParentId", SqlDbType.Int);
        parametro.Value = ParentId;
    }
        else
    {
        parametro = new SqlParameter("@UserId", SqlDbType.Int);
        parametro.Value = UserId;
    }
        return this.GetListBase<Seller>("GetSellers", parametro: parametro);
      
    }

        public void InsertSeller(Seller objSeller)
        {
            string[] nombres = { "@ParentId ", "@UserId ", "@SocialNumbre ", "@Name ", "@FirstName ", "@SecondName ", "@CreatedUser ", "@CreatedDate " };
            SqlDbType[] tipos = { SqlDbType.Int,SqlDbType.Int ,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.SmallDateTime};
            object[] valores = { objSeller.ParentId,objSeller.UserId,objSeller.SocialNumbre,objSeller.Name,objSeller.FirstName,objSeller.SocialNumbre,objSeller.CreatedUser,objSeller.CreatedDate};

            SqlParameter parametro = null;

            if(objSeller.Id>0)
            {
                parametro = new SqlParameter("@Id", SqlDbType.Int);
                parametro.Value = objSeller.Id;
            }
            objSeller.Id = this.ExecuteScalar<int>("InsertSellers", parametros: getParams (nombres,tipos,valores ),parametro:parametro);
        }
        public void DeleteSeller(int id)
        {
            this.executeNonQuery("DeleteSellers", parametro: getParam("@id", SqlDbType.Int, id));
        }

        //Terminan metodos de Sellers

        //Empiezan metodos para Roles
        public Role GetRolesById(int Id)
        {
            return this.GetSingleBase <Role>("GetRoles",
                parametro: getParam("@id",System.Data.SqlDbType.Int,Id));
        }

        public List<Role> GetRoles(int id)
        {
            SqlParameter parametro = null;
            if(id>0)
            {
                parametro = new SqlParameter("@Id",SqlDbType.Int);
                parametro.Value = id;
            }
            else
            {
                parametro = new SqlParameter("@Id", SqlDbType.Int);
                parametro.Value = id;
            }
            return this.GetListBase<Role>("GetRoles",parametro:parametro);
        }


        public void InsertCategory(Role objRoles)
        {
            string[] nombres = { "@RolName","@Enabled" };
            SqlDbType[] tipos = { SqlDbType.Int, SqlDbType.Bit };
            object[] valores = { objRoles.RolName,objRoles.Enabled };

            SqlParameter parametro = null;
            if (objRoles.Id > 0)
            {
                parametro = new SqlParameter("@id", SqlDbType.Int);
                parametro.Value = objRoles.Id;
            }


            objRoles.Id = this.ExecuteScalar<int>("InsertRoles", parametros: getParams(nombres, tipos, valores), parametro: parametro);
        }

        public void DeleteRol(int id)
        {
            this.executeNonQuery("DeleteRoles", parametro: getParam("@Id", SqlDbType.Int, id));
        }
        //Terminan metodos para Roles



        //Epiezan Metodos para Perfil de usuario ProfileUser
        public ProfileUser GetProfileUserById(int id)
        {
            return this.GetSingleBase<ProfileUser>("GetProfileUsers",
                parametro: getParam("@Id", System.Data.SqlDbType.Int, id));
        }

        public List<ProfileUser> getProfileUser(int id , int IdUser)
        {
            SqlParameter parametro = null;
            if(id > 0)
            {
                parametro = new SqlParameter ("@Id",SqlDbType.Int);
                parametro.Value = id;
            }
            else
            {
                parametro = new SqlParameter("@IdUser", SqlDbType.Int);
                parametro.Value = IdUser;
            }
            return this.GetListBase<ProfileUser>("GetProfileUsers",parametro:parametro );
        }

        public void InsertProfileUser(ProfileUser objProfileUser)
        {
            string   [] nombres = { "@IdUser",     "@Name ",        "@FirstName ",    "@LastName ",     "@Email ",        "@DateOfBirth ",        "@IdCountry ","@CreatedDate ",        "@UpdatedDate " };
            SqlDbType[] tipos   = {  SqlDbType.Int,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.SmallDateTime,SqlDbType.Int,SqlDbType.SmallDateTime,SqlDbType.SmallDateTime};
            object   [] valores = {  objProfileUser.IdUser,objProfileUser.Name,objProfileUser.FirstName,objProfileUser.LastName,objProfileUser.Email,objProfileUser.DateOfBirth,objProfileUser.IdCountry,objProfileUser.CreatedDate,objProfileUser.UpdatedDate};

            SqlParameter parametro = null;
            if(objProfileUser.Id > 0)
            {
                parametro = new SqlParameter("@Id",SqlDbType.Int);
                parametro.Value = objProfileUser.Id;
            }

            objProfileUser.Id = this.ExecuteScalar<int>("InsertProfileUsers", parametros: getParams(nombres, tipos, valores), parametro: parametro);
        }

        public void DeleteProfileUser(int id)
        {
            this.executeNonQuery("DeleteProfileUsers", parametro: getParam("@Id", SqlDbType.Int, id));
        }

        //Terminan metodos para perfil de usuarios ProfileUser

        public Restaurant GetRestaurantById(int id)
        {
            return this.GetSingleBase<Restaurant>("GetRestaurants",
                parametro : getParam ("",System.Data.SqlDbType.Int,id ));
        }

        public List<Restaurant> GetRestaurant(int id, int PartnerId)
        {
            SqlParameter parametro = null;
            if(id > 0)
            {
                parametro = new SqlParameter("@Id", SqlDbType.Int);
                parametro.Value = id;

            }
            else
            {
                parametro = new SqlParameter("@PartnerId", SqlDbType.Int);
                parametro.Value = PartnerId;
            }
            return this.GetListBase<Restaurant>("GetRestaurants", parametro: parametro);
        }

        public void InsertRestaurant(Restaurant objRestaurant)
        {
            string   [] nombres = {  "@PartnerId ", "@PrincipalContact ", "@Name ", "@CityId ", "@StreetPrincipal ", "@StreetRef1 ", "@ZipCode ", "@CoorX ", "@CoorY ", "@CreatedDate ", "@UpdatedDate ", "@CreatedUser ", "@UpdatedUser " };
            SqlDbType[] tipos   = {SqlDbType.Int,SqlDbType.Int,SqlDbType.VarChar,SqlDbType.Int,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.VarChar,SqlDbType.SmallDateTime,SqlDbType.SmallDateTime,SqlDbType.VarChar,SqlDbType.VarChar };
            object   [] valores = { objRestaurant.PartnerId,objRestaurant.PrincipalContact,objRestaurant.Name,objRestaurant.CityId,objRestaurant.StreetPrincipal,objRestaurant.StreetRef1,objRestaurant.ZipCode,objRestaurant.CoorX,objRestaurant.CoorY,objRestaurant.CreatedDate,objRestaurant.UpdatedDate,objRestaurant.CreatedUser,objRestaurant.UpdatedUser };

            SqlParameter parametro = null;
            if(objRestaurant.Id >0)
            {
                parametro = new SqlParameter("@Id",SqlDbType.Int);
                parametro.Value = objRestaurant.Id;
            }

            objRestaurant.Id = this.ExecuteScalar<int>("InsertRestaurants", parametros: getParams(nombres, tipos, valores), parametro: parametro);

        }
        public void DeleteRestaurants(int id)
        {
            this.executeNonQuery("DeleteRestaurants", parametro: getParam("@id", SqlDbType.Int, id));
        }



        //Empiezan metodos para Restaurantes Restaurants




        //Terminan Metodos para Restaurantes Restaurants

        //primer metodo
        public Category GetCategoryById(int id)
        {
            return this.GetSingleBase<Category>("GetCategories", 
                parametro: getParam("@id", System.Data.SqlDbType.Int, id));
            //Y es todo
        }

        public List<Category> GetCategories(int parentId, int partnerId)
        {
            SqlParameter parametro = null;
            if (parentId > 0)
            {
                parametro = new SqlParameter("@parentId", SqlDbType.Int);
                parametro.Value = parentId;
            }
            else
            {
                parametro = new SqlParameter("@partnerId", SqlDbType.Int);
                parametro.Value = partnerId;
            }
            return this.GetListBase<Category>("GetCategories", parametro:parametro);
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
