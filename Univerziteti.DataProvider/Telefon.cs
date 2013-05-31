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
        public List<Telefon> TelefoniSelectAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "TelefonSelectAll";
                command.Connection = Connection;

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return TelefonFromDataSet(ds);
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

        public List<Telefon> TelefoniByKontaktId(int KontaktId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "TelefonSelectByKontaktId";
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

                return TelefonFromDataSet(ds);
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

        public List<Telefon> TelefonFromDataSet(DataSet ds)
        {
            List<Telefon> items = new List<Telefon>();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    items.Add(TelefonFromDataRow(row));
                }
            }
            return items;
        }

        public Telefon TelefonFromDataRow(DataRow row)
        {
            Telefon item = new Telefon();

            if (!row.IsNull("Id"))
            {
                item.Id = Convert.ToInt32(row["Id"]);
            }
            if (!row.IsNull("Opis"))
            {
                item.Opis = row["Opis"].ToString();
            }
            if (!row.IsNull("Broj"))
            {
                item.Broj = row["Broj"].ToString();
            }
            if (!row.IsNull("KontaktId"))
            {
                item.KontaktId = Convert.ToInt32(row["KontaktId"]);
            }

            return item;
        }
        public Telefon TelefonSelectByKey(int Id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "TelefonSelectByKey";
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

                return TelefonFromDataRow(ds.Tables[0].Rows[0]);
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
        public int TelefonInsert(string Opis, string Broj, object KontaktId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "TelefonInsert";
                command.Connection = Connection;

                SqlParameter pOpis = new SqlParameter();
                pOpis.Direction = ParameterDirection.Input;
                pOpis.SqlDbType = SqlDbType.NVarChar;
                pOpis.ParameterName = "@Opis";
                pOpis.Value = Opis;
                command.Parameters.Add(pOpis);

                SqlParameter pBroj = new SqlParameter();
                pBroj.Direction = ParameterDirection.Input;
                pBroj.SqlDbType = SqlDbType.NVarChar;
                pBroj.ParameterName = "@Broj";
                pBroj.Value = Broj;
                command.Parameters.Add(pBroj);

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
        public int TelefonUpdate(int Id, string Opis, string Broj, object KontaktId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "TelefonUpdate";
                command.Connection = Connection;

                SqlParameter pId = new SqlParameter();
                pId.Direction = ParameterDirection.Input;
                pId.SqlDbType = SqlDbType.Int;
                pId.ParameterName = "@Id";
                pId.Value = Id;
                command.Parameters.Add(pId);

                SqlParameter pOpis = new SqlParameter();
                pOpis.Direction = ParameterDirection.Input;
                pOpis.SqlDbType = SqlDbType.NVarChar;
                pOpis.ParameterName = "@Opis";
                pOpis.Value = Opis;
                command.Parameters.Add(pOpis);

                SqlParameter pBroj = new SqlParameter();
                pBroj.Direction = ParameterDirection.Input;
                pBroj.SqlDbType = SqlDbType.NVarChar;
                pBroj.ParameterName = "@Broj";
                pBroj.Value = Broj;
                command.Parameters.Add(pBroj);

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
        public int TelefonDelete(int Id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "TelefonDelete";
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
