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

        //CODIGO DE GUS
        public City GetCitiesById(int id)
        {
            return this.GetSingleBase<City>("GetCities",
                parametro: getParam("@id", System.Data.SqlDbType.Int, id));
        }

        public List<City> GetCites(int StateId)
        {
            SqlParameter parametro = null;
            if (StateId > 0)
            {
                parametro = new SqlParameter("@StateId", SqlDbType.Int);
                parametro.Value = StateId;
            }
            return this.GetListBase<City>("GetCities", parametro: parametro);
        }

        public void InsertCities(City objCity)
        {
            string[] nombres = { "@StateId", "@City", "@ZipCode", "@Abbr" };
            SqlDbType[] tipos = { SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };
            object[] valores = { objCity.StateId, objCity.City1, objCity.ZipCode, objCity.Abbr };

            SqlParameter parametro = null;
            if (objCity.Id > 0)
            {
                parametro = new SqlParameter("@id", SqlDbType.Int);
                parametro.Value = objCity.Id;
            }


            objCity.Id = this.ExecuteScalar<int>("InsertCities", parametros: getParams(nombres, tipos, valores), parametro: parametro);


        }


        public void DeleteCities(int id)
        {
            this.executeNonQuery("DeleteCities", parametro: getParam("@id", SqlDbType.Int, id));
        }
        //-------------[Contacts]-----------------
        public Contact GetContactsById(int Id)
        {
            return this.GetSingleBase<Contact>("GetContacts",
                parametro: getParam("@Id", System.Data.SqlDbType.Int, Id));
        }

        public List<Contact> GetContacts(int Id)
        {
            SqlParameter parametro = null;
            if (Id > 0)
            {
                parametro = new SqlParameter("@Id", SqlDbType.Int);
                parametro.Value = Id;
            }
            return this.GetListBase<Contact>("GetContacts", parametro: parametro);
        }

        public void InsertContacts(Contact objContacts)
        {
            string[] nombres = { "@Name", "@FirstName", "@SecondName", "@CellPhone", "@HomePhone", "@Email" };
            SqlDbType[] tipos = { SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };
            object[] valores = { objContacts.Name, objContacts.FirstName, objContacts.SecondName, objContacts.CellPhone, objContacts.HomePhone, objContacts.Email };

            SqlParameter parametro = null;
            if (objContacts.Id > 0)
            {
                parametro = new SqlParameter("@Id", SqlDbType.Int);
                parametro.Value = objContacts.Id;
            }


            objContacts.Id = this.ExecuteScalar<int>("InsertContacts", parametros: getParams(nombres, tipos, valores), parametro: parametro);


        }


        public void DeleteContacts(int Id)
        {
            this.executeNonQuery("DeleteContacts", parametro: getParam("@Id", SqlDbType.Int, Id));
        }
        //-------------[Countries]-----------------
        public Country GetCountriesById(int Id)
        {
            return this.GetSingleBase<Country>("GetCountries",
                parametro: getParam("@Id", System.Data.SqlDbType.Int, Id));
        }

        public List<Country> GetCountries(int Id)
        {
            SqlParameter parametro = null;
            if (Id > 0)
            {
                parametro = new SqlParameter("@Id", SqlDbType.Int);
                parametro.Value = Id;
            }
            return this.GetListBase<Country>("GetCountries", parametro: parametro);
        }

        public void InsertCountries(Country objCountries)
        {
            string[] nombres = { "@Name", "@Abreviation" };
            SqlDbType[] tipos = { SqlDbType.VarChar, SqlDbType.VarChar };
            object[] valores = { objCountries.Name, objCountries.Abreviation };

            SqlParameter parametro = null;
            if (objCountries.Id > 0)
            {
                parametro = new SqlParameter("@Id", SqlDbType.Int);
                parametro.Value = objCountries.Id;
            }


            objCountries.Id = this.ExecuteScalar<int>("InsertCountries", parametros: getParams(nombres, tipos, valores), parametro: parametro);


        }


        public void DeleteCountries(int Id)
        {
            this.executeNonQuery("DeleteCountries", parametro: getParam("@Id", SqlDbType.Int, Id));
        }
        //-------------[DeliveryAddress]-----------------
        public DeliveryAddress GetDeliveryAddressById(int Id)
        {
            return this.GetSingleBase<DeliveryAddress>("GetDeliveryAddress",
                parametro: getParam("@Id", System.Data.SqlDbType.Int, Id));
        }

        public List<DeliveryAddress> GetDeliveryAddress(int OrderId, int CityId)
        {
            SqlParameter parametro = null;
            if (OrderId > 0)
            {
                parametro = new SqlParameter("@OrderId", SqlDbType.Int);
                parametro.Value = OrderId;
            }
            else
            {
                parametro = new SqlParameter("@CityId", SqlDbType.Int);
                parametro.Value = CityId;
            }
            return this.GetListBase<DeliveryAddress>("GetDeliveryAddress", parametro: parametro);
        }

        public void InsertDeliveryAddress(DeliveryAddress objDeliveryAddress)
        {
            string[] nombres = { "@OrderId", "@CityId", "@ZipCode", "@Street", "@Number", "@Departament", "@StreetRef", "@Instructions" };
            SqlDbType[] tipos = { SqlDbType.Int, SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.VarChar };
            object[] valores = { objDeliveryAddress.OrderId, objDeliveryAddress.CityId, objDeliveryAddress.ZipCode, objDeliveryAddress.Street, objDeliveryAddress.Number, objDeliveryAddress.Departament, objDeliveryAddress.StreetRef, objDeliveryAddress.Instructions };

            SqlParameter parametro = null;
            if (objDeliveryAddress.Id > 0)
            {
                parametro = new SqlParameter("@Id", SqlDbType.Int);
                parametro.Value = objDeliveryAddress.Id;
            }


            objDeliveryAddress.Id = this.ExecuteScalar<int>("InsertDeliveryAddress", parametros: getParams(nombres, tipos, valores), parametro: parametro);


        }


        public void DeleteDeliveryAddress(int Id)
        {
            this.executeNonQuery("DeleteDeliveryAddress", parametro: getParam("@Id", SqlDbType.Int, Id));
        }
        //-------------[ItemsMenu]-----------------
        public ItemsMenu GetItemsMenuById(int Id)
        {
            return this.GetSingleBase<ItemsMenu>("GetDeliveryAddress",
                parametro: getParam("@Id", System.Data.SqlDbType.Int, Id));
        }

        public List<ItemsMenu> GetItemsMenu(int IdMenu)
        {
            SqlParameter parametro = null;
            if (IdMenu > 0)
            {
                parametro = new SqlParameter("@IdMenu", SqlDbType.Int);
                parametro.Value = IdMenu;
            }
            return this.GetListBase<ItemsMenu>("GetItemsMenu", parametro: parametro);
        }
        public void InsertItemsMenu(ItemsMenu objItemsMenu)
        {
            string[] nombres = { "@IdMenu", "@Name", "@Description", "@OptionalTypeId", "@Price", "@OrderBy", "@CountOption" };
            SqlDbType[] tipos = { SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.TinyInt, SqlDbType.SmallMoney, SqlDbType.Int, SqlDbType.TinyInt };
            object[] valores = { objItemsMenu.IdMenu, objItemsMenu.Name, objItemsMenu.Description, objItemsMenu.OptionalTypeId, objItemsMenu.Price, objItemsMenu.OrderBy, objItemsMenu.CountOption };

            SqlParameter parametro = null;
            if (objItemsMenu.Id > 0)
            {
                parametro = new SqlParameter("@Id", SqlDbType.Int);
                parametro.Value = objItemsMenu.Id;
            }


            objItemsMenu.Id = this.ExecuteScalar<int>("InsertItemsMenu", parametros: getParams(nombres, tipos, valores), parametro: parametro);


        }


        public void DeleteItemsMenu(int Id)
        {
            this.executeNonQuery("DeleteItemsMenu", parametro: getParam("@Id", SqlDbType.Int, Id));
        }
        //-------------[Menus]-----------------
        public Menu GetMenusById(int Id)
        {
            return this.GetSingleBase<Menu>("GetMenus",
                parametro: getParam("@Id", System.Data.SqlDbType.Int, Id));
        }

        public List<Menu> GetMenus(int PartnerId, int CategoryId)
        {
            SqlParameter parametro = null;
            if (PartnerId > 0)
            {
                parametro = new SqlParameter("@PartnerId", SqlDbType.Int);
                parametro.Value = PartnerId;
            }
            else
            {
                parametro = new SqlParameter("@CategoryId", SqlDbType.Int);
                parametro.Value = CategoryId;
            }

            return this.GetListBase<Menu>("GetMenus", parametro: parametro);
        }
        public void InsertMenus(Menu objMenus)
        {
            string[] nombres = { "@PartnerId", "@CategoryId", "@Name", "@Description", "@Portions", "@Price" };
            SqlDbType[] tipos = { SqlDbType.Int, SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.SmallInt, SqlDbType.SmallMoney };
            object[] valores = { objMenus.PartnerId, objMenus.CategoryId, objMenus.Name, objMenus.Description, objMenus.Portions, objMenus.Price };

            SqlParameter parametro = null;
            if (objMenus.Id > 0)
            {
                parametro = new SqlParameter("@Id", SqlDbType.Int);
                parametro.Value = objMenus.Id;
            }


            objMenus.Id = this.ExecuteScalar<int>("InsertMenus", parametros: getParams(nombres, tipos, valores), parametro: parametro);


        }


        public void DeleteMenus(int Id)
        {
            this.executeNonQuery("DeleteMenus", parametro: getParam("@Id", SqlDbType.Int, Id));
        }
        //-------------[OpeningHours]-----------------
        public OpeningHour GetOpeningHoursById(int Id)
        {
            return this.GetSingleBase<OpeningHour>("GetOpeningHours",
                parametro: getParam("@Id", System.Data.SqlDbType.Int, Id));
        }

        public List<OpeningHour> GetOpeningHours(int RestaurantId)
        {
            SqlParameter parametro = null;
            if (RestaurantId > 0)
            {
                parametro = new SqlParameter("@RestaurantId", SqlDbType.Int);
                parametro.Value = RestaurantId;
            }

            return this.GetListBase<OpeningHour>("GetOpeningHours", parametro: parametro);
        }
        public void InsertOpeningHours(OpeningHour objOpeningHours)
        {
            string[] nombres = { "@RestaurantId", "@InitialTime", "@FinalTime", "@WeekDay", "@AllDays" };
            SqlDbType[] tipos = { SqlDbType.Int, SqlDbType.VarChar, SqlDbType.VarChar, SqlDbType.Int, SqlDbType.Bit };
            object[] valores = { objOpeningHours.RestaurantId, objOpeningHours.InitialTime, objOpeningHours.FinalTime, objOpeningHours.WeekDay, objOpeningHours.AllDays };

            SqlParameter parametro = null;
            if (objOpeningHours.Id > 0)
            {
                parametro = new SqlParameter("@Id", SqlDbType.Int);
                parametro.Value = objOpeningHours.Id;
            }


            objOpeningHours.Id = this.ExecuteScalar<int>("InsertOpeningHours", parametros: getParams(nombres, tipos, valores), parametro: parametro);


        }


        public void DeleteOpeningHours(int Id)
        {
            this.executeNonQuery("DeleteOpeningHours", parametro: getParam("@Id", SqlDbType.Int, Id));
        }
        //-------------[OptionalTypes]-----------------
        public OptionalType GetOptionalTypesById(int Id)
        {
            return this.GetSingleBase<OptionalType>("GetOptionalTypes",
                parametro: getParam("@Id", System.Data.SqlDbType.TinyInt, Id));
        }

        public List<OptionalType> GetOptionalTypes(int Id)
        {
            SqlParameter parametro = null;
            if (Id > 0)
            {
                parametro = new SqlParameter("@Id", SqlDbType.TinyInt);
                parametro.Value = Id;
            }

            return this.GetListBase<OptionalType>("GetOptionalTypes", parametro: parametro);
        }
        public void InsertOptionalTypes(OptionalType objOptionalTypes)
        {
            string[] nombres = { "@OptionType", "@Enabled" };
            SqlDbType[] tipos = { SqlDbType.VarChar, SqlDbType.Bit };
            object[] valores = { objOptionalTypes.OptionType, objOptionalTypes.Enabled };

            SqlParameter parametro = null;
            if (objOptionalTypes.Id > 0)
            {
                parametro = new SqlParameter("@Id", SqlDbType.TinyInt);
                parametro.Value = objOptionalTypes.Id;
            }
            this.executeNonQuery("InsertOptionalTypes", getParams(nombres, tipos, valores), parametro: getParam("@Id", SqlDbType.TinyInt, objOptionalTypes.Id));

        }


        public void DeleteOptionalTypes(int Id)
        {
            this.executeNonQuery("DeleteOptionalTypes", parametro: getParam("@Id", SqlDbType.TinyInt, Id));
        }
        //-------------[OrderDetails]-----------------
        public OrderDetail GetOrderDetailsById(int Id)
        {
            return this.GetSingleBase<OrderDetail>("GetOrderDetails",
                parametro: getParam("@Id", System.Data.SqlDbType.Int, Id));
        }

        public List<OrderDetail> GetOrderDetails(int OrderId, int MenuId)
        {
            SqlParameter parametro = null;
            if (OrderId > 0)
            {
                parametro = new SqlParameter("@OrderId", SqlDbType.Int);
                parametro.Value = OrderId;
            }
            else
            {
                parametro = new SqlParameter("@MenuId", SqlDbType.Int);
                parametro.Value = MenuId;
            }

            return this.GetListBase<OrderDetail>("GetOrderDetails", parametro: parametro);
        }
        public void InsertOrderDetails(OrderDetail objOpeningHours)
        {
            string[] nombres = { "@OrderId", "@MenuId", "@Quantity", "@Price" };
            SqlDbType[] tipos = { SqlDbType.Int, SqlDbType.Int, SqlDbType.Int, SqlDbType.SmallMoney };
            object[] valores = { objOpeningHours.OrderId, objOpeningHours.MenuId, objOpeningHours.Quantity, objOpeningHours.Price };

            SqlParameter parametro = null;
            if (objOpeningHours.Id > 0)
            {
                parametro = new SqlParameter("@Id", SqlDbType.Int);
                parametro.Value = objOpeningHours.Id;
            }


            objOpeningHours.Id = this.ExecuteScalar<int>("InsertOrderDetails", parametros: getParams(nombres, tipos, valores), parametro: parametro);


        }


        public void DeleteOrderDetails(int Id)
        {
            this.executeNonQuery("DeleteOrderDetails", parametro: getParam("@Id", SqlDbType.Int, Id));
        }
        //-------------[OrderDetailsItemMenu]-----------------
        public OrderDetailsItemMenu GetOrderDetailsItemMenuById(int Id)
        {
            return this.GetSingleBase<OrderDetailsItemMenu>("GetOrderDetailsItemMenu",
                parametro: getParam("@Id", System.Data.SqlDbType.Int, Id));
        }

        public List<OrderDetailsItemMenu> GetOrderDetailsItemMenu(int ItemMenuId)
        {
            SqlParameter parametro = null;
            if (ItemMenuId > 0)
            {
                parametro = new SqlParameter("@OrderId", SqlDbType.Int);
                parametro.Value = ItemMenuId;
            }

            return this.GetListBase<OrderDetailsItemMenu>("GetOrderDetailsItemMenu", parametro: parametro);
        }
        public void InsertOrderDetailsItemMenu(OrderDetailsItemMenu objOrderDetailsItemMenu)
        {
            string[] nombres = { "@ItemMenuId", "@Price" };
            SqlDbType[] tipos = { SqlDbType.Int, SqlDbType.SmallMoney };
            object[] valores = { objOrderDetailsItemMenu.ItemMenuId, objOrderDetailsItemMenu.Price };

            SqlParameter parametro = null;
            if (objOrderDetailsItemMenu.Id > 0)
            {
                parametro = new SqlParameter("@Id", SqlDbType.Int);
                parametro.Value = objOrderDetailsItemMenu.Id;
            }


            objOrderDetailsItemMenu.Id = this.ExecuteScalar<int>("InsertOrderDetailsItemMenu", parametros: getParams(nombres, tipos, valores), parametro: parametro);


        }


        public void DeleteOrderDetailsItemMenu(int Id)
        {
            this.executeNonQuery("DeleteOrderDetailsItemMenu", parametro: getParam("@Id", SqlDbType.Int, Id));
        }

        //CODIGO DE GUS

    }
}
