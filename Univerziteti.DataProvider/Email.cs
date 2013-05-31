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
        public List<Email> EmailSelectAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "EmailSelectAll";
                command.Connection = Connection;

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return EmailFromDataSet(ds);
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

        public List<Email> EmailByKontaktId(int KontaktId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "EmailSelectByKontaktId";
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

                return EmailFromDataSet(ds);
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

        public List<Email> EmailFromDataSet(DataSet ds)
        {
            List<Email> items = new List<Email>();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    items.Add(EmailFromDataRow(row));
                }
            }
            return items;
        }

        public Email EmailFromDataRow(DataRow row)
        {
            Email item = new Email();

            if (!row.IsNull("Id"))
            {
                item.Id = Convert.ToInt32(row["Id"]);
            }
            if (!row.IsNull("Adresa"))
            {
                item.Adresa = row["Adresa"].ToString();
            }
            if (!row.IsNull("KontaktId"))
            {
                item.KontaktId = Convert.ToInt32(row["KontaktId"]);
            }

            return item;
        }
        public Email EmailSelectByKey(int Id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "EmailSelectByKey";
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

                return EmailFromDataRow(ds.Tables[0].Rows[0]);
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
        public int EmailInsert(string Adresa, object KontaktId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "EmailInsert";
                command.Connection = Connection;

                SqlParameter pAdresa = new SqlParameter();
                pAdresa.Direction = ParameterDirection.Input;
                pAdresa.SqlDbType = SqlDbType.NVarChar;
                pAdresa.ParameterName = "@Adresa";
                pAdresa.Value = Adresa;
                command.Parameters.Add(pAdresa);

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
        public int EmailUpdate(int Id, string Adresa, object KontaktId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "EmailUpdate";
                command.Connection = Connection;

                SqlParameter pId = new SqlParameter();
                pId.Direction = ParameterDirection.Input;
                pId.SqlDbType = SqlDbType.Int;
                pId.ParameterName = "@Id";
                pId.Value = Id;
                command.Parameters.Add(pId);

                SqlParameter pAdresa = new SqlParameter();
                pAdresa.Direction = ParameterDirection.Input;
                pAdresa.SqlDbType = SqlDbType.NVarChar;
                pAdresa.ParameterName = "@Adresa";
                pAdresa.Value = Adresa;
                command.Parameters.Add(pAdresa);

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
        public int EmailDelete(int Id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "EmailDelete";
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
