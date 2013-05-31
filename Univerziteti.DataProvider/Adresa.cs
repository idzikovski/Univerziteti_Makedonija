using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Univerziteti.BussinesObjects;
using System.Data.SqlClient;
using System.Data;

namespace Univerziteti.DataProvider
{
    public partial class SqlDataAccess
    {
        public List<Adresa> AdresiSelectAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AdresaSelectAll";
                command.Connection = Connection;

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return AdresaFromDataSet(ds);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Adresa> AdresaByKontaktId(int KontaktId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AdresaSelectByKontaktId";
                command.Connection = Connection;

                SqlParameter pId = new SqlParameter();
                pId.Direction = ParameterDirection.Input;
                pId.ParameterName = "@KontaktId";
                pId.Value = KontaktId;
                command.Parameters.Add(pId);

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return AdresaFromDataSet(ds);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Adresa> AdresaFromDataSet(DataSet ds)
        {
            List<Adresa> items = new List<Adresa>();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    items.Add(AdresaFromDataRow(row));
                }
            }
            return items;
        }

        public Adresa AdresaFromDataRow(DataRow row)
        {
            Adresa item = new Adresa();

            if (!row.IsNull("Id"))
            {
                item.Id = Convert.ToInt32(row["Id"]);
            }
            if (!row.IsNull("Ulica"))
            {
                item.Ulica = row["Ulica"].ToString();
            }
           
            if (!row.IsNull("KontaktId"))
            {
                item.KontaktId = Convert.ToInt32(row["KontaktId"]);
            }

            return item;
        }
        public Adresa AdresaSelectByKey(int Id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AdresaSelectByKey";
                command.Connection = Connection;

                SqlParameter parameter = new SqlParameter();
                parameter.Direction = ParameterDirection.Input;
                parameter.SqlDbType = SqlDbType.Int;
                parameter.ParameterName = "@Id";
                parameter.Value = Id;
                command.Parameters.Add(parameter);

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return AdresaFromDataRow(ds.Tables[0].Rows[0]);
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
        public int AdresaInsert(string Ulica, object KontaktId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AdresaInsert";
                command.Connection = Connection;

                SqlParameter pUlica = new SqlParameter();
                pUlica.Direction = ParameterDirection.Input;
                pUlica.SqlDbType = SqlDbType.NVarChar;
                pUlica.ParameterName = "@Ulica";
                pUlica.Value = Ulica;
                command.Parameters.Add(pUlica);


                SqlParameter pKontaktId = new SqlParameter();
                pKontaktId.Direction = ParameterDirection.Input;
                pKontaktId.SqlDbType = SqlDbType.Int;
                pKontaktId.ParameterName = "@KontaktId";
                pKontaktId.Value = KontaktId;
                command.Parameters.Add(pKontaktId);



                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
        public int AdresaUpdate(int Id, string Ulica,  object KontaktId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AdresaUpdate";
                command.Connection = Connection;

                SqlParameter pId = new SqlParameter();
                pId.Direction = ParameterDirection.Input;
                pId.SqlDbType = SqlDbType.Int;
                pId.ParameterName = "@Id";
                pId.Value = Id;
                command.Parameters.Add(pId);

                SqlParameter pUlica = new SqlParameter();
                pUlica.Direction = ParameterDirection.Input;
                pUlica.SqlDbType = SqlDbType.NVarChar;
                pUlica.ParameterName = "@Ulica";
                pUlica.Value = Ulica;
                command.Parameters.Add(pUlica);

                SqlParameter pKontaktId = new SqlParameter();
                pKontaktId.Direction = ParameterDirection.Input;
                pKontaktId.SqlDbType = SqlDbType.Int;
                pKontaktId.ParameterName = "@KontaktId";
                pKontaktId.Value = KontaktId;
                command.Parameters.Add(pKontaktId);



                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }
        }
        public int AdresaDelete(int Id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "AdresaDelete";
                command.Connection = Connection;

                SqlParameter pId = new SqlParameter();
                pId.Direction = ParameterDirection.Input;
                pId.SqlDbType = SqlDbType.Int;
                pId.ParameterName = "@Id";
                pId.Value = Id;
                command.Parameters.Add(pId);

                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {
                connection.Close();
            }

        }
    }
}
