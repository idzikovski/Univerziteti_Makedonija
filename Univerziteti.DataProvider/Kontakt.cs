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
        public List<Kontakt> KontaktSelectAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "KontaktSelectAll";
                command.Connection = Connection;

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return KontaktFromDataSet(ds);
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
        public List<Kontakt> KontaktFromDataSet(DataSet ds)
        {
            List<Kontakt> items = new List<Kontakt>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    items.Add(KontaktFromDataRow(row));
                }
            }
            return items;
        }
        public Kontakt KontaktFromDataRow(DataRow row)
        {
            Kontakt item = new Kontakt();

            if (!row.IsNull("Id"))
            {
                item.Id = Convert.ToInt32(row["Id"]);
            }
            if (!row.IsNull("Opis"))
            {
                item.Opis = row["Opis"].ToString();
            }
            return item;
        }
        public Kontakt KontaktSelectByKey(int Id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "KontaktSelectByKey";
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

                return KontaktFromDataRow(ds.Tables[0].Rows[0]);
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
        public int KontaktInsert(string Opis)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "KontaktInsert";
                command.Connection = Connection;

                SqlParameter pOpis = new SqlParameter();
                pOpis.Direction = ParameterDirection.Input;
                pOpis.SqlDbType = SqlDbType.NVarChar;
                pOpis.ParameterName = "@Opis";
                pOpis.Value = Opis;
                command.Parameters.Add(pOpis);

                command.ExecuteNonQuery();

                SqlCommand comm = new SqlCommand();
                comm.CommandType = CommandType.StoredProcedure;
                comm.CommandText = "GetLastKontakt";
                comm.Connection = Connection;

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = comm;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return 0;

                return Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);

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
        public int KontaktUpdate(int Id, string Opis)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "FakultetUpdate";
                command.Connection = Connection;

                SqlParameter pOpis = new SqlParameter();
                pOpis.Direction = ParameterDirection.Input;
                pOpis.SqlDbType = SqlDbType.NVarChar;
                pOpis.ParameterName = "@Opis";
                pOpis.Value = Opis;
                command.Parameters.Add(pOpis);

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
        public int KontaktDelete(int Id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "FakultetDelete";
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
