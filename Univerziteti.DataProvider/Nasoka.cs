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
        public List<Nasoka> NasokiSelectAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "NasokaSelectAll";
                command.Connection = Connection;

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return NasokaFromDataSet(ds);
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

        public DataSet NasokaFakultetJoinAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "NasokaFakultetJoinAll";
                command.Connection = Connection;

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return ds;
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

        public List<Nasoka> NasokaSelectByFakultetId(int Id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "NasokaSelectByFakultetId";
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

                return NasokaFromDataSet(ds);
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

        public List<Nasoka> NasokaFromDataSet(DataSet ds)
        {
            List<Nasoka> items = new List<Nasoka>();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    items.Add(NasokaFromDataRow(row));
                }
            }
            return items;
        }

        public Nasoka NasokaFromDataRow(DataRow row)
        {
            Nasoka item = new Nasoka();

            if (!row.IsNull("Id"))
            {
                item.Id = Convert.ToInt32(row["Id"]);
            }
            if (!row.IsNull("Ime"))
            {
                item.Ime = row["Ime"].ToString();
            }
            if (!row.IsNull("Opis"))
            {
                item.Opis = row["Opis"].ToString();
            }
            if (!row.IsNull("FakultetId"))
            {
                item.FakultetId = Convert.ToInt32(row["FakultetId"]);
            }

            return item;
        }
        public Nasoka NasokaSelectByKey(int Id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "NasokaSelectByKey";
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

                return NasokaFromDataRow(ds.Tables[0].Rows[0]);
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
        public int NasokaInsert(string Ime, string Opis, object FakultetId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "NasokaInsert";
                command.Connection = Connection;

                SqlParameter pIme = new SqlParameter();
                pIme.Direction = ParameterDirection.Input;
                pIme.SqlDbType = SqlDbType.NVarChar;
                pIme.ParameterName = "@Ime";
                pIme.Value = Ime;
                command.Parameters.Add(pIme);

                SqlParameter pOpis = new SqlParameter();
                pOpis.Direction = ParameterDirection.Input;
                pOpis.SqlDbType = SqlDbType.NVarChar;
                pOpis.ParameterName = "@Opis";
                pOpis.Value = Opis;
                command.Parameters.Add(pOpis);

                SqlParameter pFakultetId = new SqlParameter();
                pFakultetId.Direction = ParameterDirection.Input;
                pFakultetId.SqlDbType = SqlDbType.Int;
                pFakultetId.ParameterName = "@FakultetId";
                if (FakultetId != null)
                {
                    pFakultetId.Value = FakultetId;
                }
                else
                {
                    pFakultetId.Value = DBNull.Value;
                }
                command.Parameters.Add(pFakultetId);



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
        public int NasokaUpdate(int Id, string Ime, string Opis, object FakultetId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "NasokaUpdate";
                command.Connection = Connection;

                SqlParameter pId = new SqlParameter();
                pId.Direction = ParameterDirection.Input;
                pId.SqlDbType = SqlDbType.Int;
                pId.ParameterName = "@Id";
                pId.Value = Id;
                command.Parameters.Add(pId);

                SqlParameter pIme = new SqlParameter();
                pIme.Direction = ParameterDirection.Input;
                pIme.SqlDbType = SqlDbType.NVarChar;
                pIme.ParameterName = "@Ime";
                pIme.Value = Ime;
                command.Parameters.Add(pIme);

                SqlParameter pOpis = new SqlParameter();
                pOpis.Direction = ParameterDirection.Input;
                pOpis.SqlDbType = SqlDbType.NVarChar;
                pOpis.ParameterName = "@Opis";
                pOpis.Value = Opis;
                command.Parameters.Add(pOpis);

                SqlParameter pFakultetId = new SqlParameter();
                pFakultetId.Direction = ParameterDirection.Input;
                pFakultetId.SqlDbType = SqlDbType.Int;
                pFakultetId.ParameterName = "@FakultetId";
                if (FakultetId != null)
                {
                    pFakultetId.Value = FakultetId;
                }
                else
                {
                    pFakultetId.Value = DBNull.Value;
                }
                command.Parameters.Add(pFakultetId);



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
        public int NasokaDelete(int Id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "NasokaDelete";
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
