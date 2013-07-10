using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Data.SqlClient;
using System.Data;
using System.ComponentModel;

namespace Alldeli.BusinessLogic.DbLayer
{
   public abstract class AccesSqlBase : IDisposable
    {
        private bool _disposed;
        private SqlConnection _cn;

        protected bool siPaginador { get; set; }
        protected int noItemsPagina { get; set; }
        protected int noPagina { get; set; }
        public int numeroPaginas { get; set; }

        protected SqlConnection Conexion
        {
            get
            {
                return _cn;
            }
        }

        public AccesSqlBase()
        {
            _cn = FunctionsSql.GetConnection();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_cn != null)
                    {
                        if (_cn.State == System.Data.ConnectionState.Open)
                        {
                            _cn.Close();
                        }
                        _cn.Dispose();
                    }
                }
                _cn = null;
                _disposed = true;
            }
        }


        protected List<T> GetListBaseFromReader<T>(SqlDataReader reader) where T :  new()
        {
            List<T> lista = new List<T>();
            if (!siPaginador)
            {
                while (reader.Read())
                {
                    lista.Add(ToObject<T>(reader));
                }
            }
            else
            {
                ProcesarPagina<T>(reader, lista);
            }
            return lista;
        }

        private void ProcesarPagina<T>(SqlDataReader reader, List<T> lista) where T :  new()
        {
            if (noItemsPagina > 0)
            {
                int contador = 0;
                int itemInicio = (noPagina - 1) * noItemsPagina;
                int contP = 0;
                while (reader.Read())
                {
                    if (contador >= itemInicio && contP < noItemsPagina)
                    {
                        lista.Add(ToObject<T>(reader));
                        contP++;
                        if (contP > noItemsPagina) break;
                    }
                    contador++;
                }
                numeroPaginas = contador / noItemsPagina + ((contador % noItemsPagina == 0) ? 0 : 1);
            }
        }

        protected T GetSingleBaseFromReader<T>(SqlDataReader reader) where T :  new()
        {
            T obj = new T();
            while (reader.Read())
            {
                obj = ToObject<T>(reader);
            }
            return obj;
        }






        public T GetSingleBase<T>(string storeProceduer, SqlParameter[] listaParametros = null, SqlParameter parametro = null) where T :  new()
        {
            T obj = new T();
            using (SqlCommand cmd = new SqlCommand(storeProceduer, this.Conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (listaParametros != null)
                {
                    cmd.Parameters.AddRange(listaParametros);
                }
                if (parametro != null)
                {
                    cmd.Parameters.Add(parametro);
                }

                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
                {
                    obj = GetSingleBaseFromReader<T>(reader);
                }
            }
            return obj;
        }


        public List<T> GetListBase<T>(string storeProceduer, SqlParameter[] listaParametros = null, SqlParameter parametro = null) where T :  new()
        {
            List<T> lista = new List<T>();
            using (SqlCommand cmd = new SqlCommand(storeProceduer, this.Conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if (listaParametros != null)
                {
                    if(listaParametros.Count() > 0)
                        cmd.Parameters.AddRange(listaParametros);
                }
                if (parametro != null)
                {
                    cmd.Parameters.Add(parametro);
                }

                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.SingleResult))
                {
                    lista = GetListBaseFromReader<T>(reader);
                }
            }
            return lista;
        }






        public T ExecuteScalar<T>(string storeProceduer, SqlParameter[] parametros = null, SqlParameter parametro = null)
        {
            T resultado;
            using (SqlCommand cmd = new SqlCommand(storeProceduer, this.Conexion))
            {
                cmd.CommandType = CommandType.StoredProcedure;

                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);

                if (parametro != null)
                    cmd.Parameters.Add(parametro);


                var objR = cmd.ExecuteScalar();

                Type t = Nullable.GetUnderlyingType(typeof(T)) ?? (typeof(T));
                object safeValue = (objR == null) ? null : Convert.ChangeType(objR, t);

                resultado = (T)Convert.ChangeType(safeValue, typeof(T));
            }
            return resultado;
        }



        public int executeNonQuery(string storeProcedure, SqlParameter[] parametros = null, SqlParameter parametro=null)
        {
            int resultado = 0;
            using (SqlCommand cmd = new SqlCommand(storeProcedure, this.Conexion))
            {
                if (parametros != null)
                    cmd.Parameters.AddRange(parametros);

                if (parametro != null)
                    cmd.Parameters.Add(parametro);

                cmd.CommandType = CommandType.StoredProcedure;
                resultado = cmd.ExecuteNonQuery();
            }
            return resultado;
        }



        protected SqlParameter[] getParams(string[] nombres, SqlDbType[] tipos, object[] objetos)
        {
            SqlParameter[] parametros = new SqlParameter[nombres.Length];
            for (int i = 0; i < nombres.Length; i++)
            {
                parametros[i] = getParam(nombres[i], tipos[i], objetos[i]);
            }
            return parametros;
        }

        protected static SqlParameter getParam(string nombre, SqlDbType tipo, object valor)
        {
            SqlParameter parametro = new SqlParameter(nombre, tipo);
            if (valor is string)
            {
                if (string.IsNullOrWhiteSpace(valor.ToString()))
                {
                    valor = null;
                }
            }
            parametro.Value = valor;
            return parametro;
        }





        protected List<T> GetListFromReader<T>(SqlDataReader reader) where T : new()
        {
            List<T> lista = new List<T>();
            PropertyInfo[] arrPropiedades = typeof(T).GetProperties();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    if (!reader.IsDBNull(i))
                    {
                        T obj = new T();
                        PropertyInfo property = arrPropiedades.SingleOrDefault(p => p.Name.ToLower() == reader.GetName(i).ToLower());
                        if (null != property)
                        {
                            Type t = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                            object safeValue = Convert.ChangeType(reader[i], t);
                            property.SetValue(obj, safeValue, null);
                        }
                    }
                }
            }
            return lista;
        }

        protected List<T> GetListFromReader<T>(SqlDataReader reader, String[] campos) where T : new()
        {
            List<T> lista = new List<T>();
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string campo = campos.SingleOrDefault(c => c.ToLower() == reader.GetName(i));
                    if (null == campo) continue;
                    if (reader.IsDBNull(i)) continue;
                    T obj = new T();
                    obj.GetType().GetProperty(campo, BindingFlags.IgnoreCase).SetValue(obj, reader[i], null);
                    lista.Add(obj);
                }
            }
            return lista;
        }





        protected SqlCommand GetCommand<T>(string storeProcedure, string[] listaParametros, T objeto)
        {
            SqlCommand cmd = new SqlCommand(storeProcedure, this.Conexion);
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (string nameParam in listaParametros)
            {
                SqlParameter parametro = new SqlParameter();
                parametro.Value = objeto.GetType().GetProperty(nameParam, BindingFlags.IgnoreCase).GetValue(objeto, null);
                parametro.ParameterName = "@" + nameParam;
                parametro.SqlDbType = GetTypeSql(objeto.GetType().GetProperty(nameParam, BindingFlags.IgnoreCase).GetValue(objeto, null).GetType());
                cmd.Parameters.Add(parametro);
            }
            return cmd;
        }


        protected T ToObject<T>(IDataRecord r) where T : new()
        {
            T obj = new T();
            //PropertyInfo[] arrPro = typeof(T).GetProperties(BindingFlags.GetProperty | BindingFlags.SetField);
            for (int i = 0; i < r.FieldCount; i++)
            {
                var p = typeof(T).GetProperty(r.GetName(i));
                //var p = arrPro.SingleOrDefault(po => po.Name == r.GetName(i).ToLower());
                if (p != null)
                {
                    if (p.PropertyType == r[i].GetType())
                        p.SetValue(obj, r[i], null);
                    else
                    {
                        var c = TypeDescriptor.GetConverter(r[i]);
                        if (c.CanConvertTo(p.PropertyType))
                            p.SetValue(obj, c.ConvertTo(r[i], p.PropertyType), null);
                    }
                }
            }
            return obj;
        }

        protected IEnumerable<T> GetObjects<T>(IDbCommand c) where T : new()
        {
            using (IDataReader r = c.ExecuteReader())
            {
                while (r.Read())
                {
                    yield return ToObject<T>(r);
                }
            }
        }

        private SqlDbType GetTypeSql(Type tipoDato)
        {
            if (tipoDato == typeof(int))
            {
                return SqlDbType.Int;
            }
            if (tipoDato == typeof(string))
            {
                return SqlDbType.VarChar;
            }
            if (tipoDato == typeof(DateTime))
            {
                return SqlDbType.SmallDateTime;
            }
            if (tipoDato == typeof(bool))
            {
                return SqlDbType.Bit;
            }
            if (tipoDato == typeof(decimal))
            {
                return SqlDbType.SmallMoney;
            }
            if (tipoDato == typeof(Int16))
            {
                return SqlDbType.TinyInt;
            }
            throw (new Exception("Tipo de dato no definidio"));
        }




    }
}
