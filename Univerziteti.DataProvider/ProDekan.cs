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
        public List<ProDekan> ProDekanSelectAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ProDekanSelectAll";
                command.Connection = Connection;

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return ProDekanFromDataSet(ds);
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

        public DataSet ProDekanJoinAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ProDekanJoinAll";
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

        public List<ProDekan> ProDekanFromDataSet(DataSet ds)
        {
            List<ProDekan> items = new List<ProDekan>();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    items.Add(ProDekanFromDataRow(row));
                }
            }
            return items;
        }
        public ProDekan ProDekanFromDataRow(DataRow row)
        {
            ProDekan item = new ProDekan();

            if (!row.IsNull("FakultetId"))
            {
                item.FakultetId = Convert.ToInt32(row["FakultetId"]);
            }
            if (!row.IsNull("VrabotenId"))
            {
                item.VrabotenId = Convert.ToInt32(row["VrabotenId"]);
            }
            return item;
        }
        public ProDekan ProDekanSelectByKey(int FakultetId, int VrabotenId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ProDekanSelectByKey";
                command.Connection = Connection;

                SqlParameter pFakultetId = new SqlParameter();
                pFakultetId.Direction = ParameterDirection.Input;
                pFakultetId.SqlDbType = SqlDbType.Int;
                pFakultetId.ParameterName = "@FakultetId";
                pFakultetId.Value = FakultetId;
                command.Parameters.Add(pFakultetId);

                SqlParameter pVrabotenId = new SqlParameter();
                pVrabotenId.Direction = ParameterDirection.Input;
                pVrabotenId.SqlDbType = SqlDbType.Int;
                pVrabotenId.ParameterName = "@VrabotenId";
                pVrabotenId.Value = VrabotenId;
                command.Parameters.Add(pVrabotenId);

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return ProDekanFromDataRow(ds.Tables[0].Rows[0]);
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
        public int ProDekanInsert(object FakultetId, object VrabotenId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ProDekanInsert";
                command.Connection = Connection;

                SqlParameter pFakultetId = new SqlParameter();
                pFakultetId.Direction = ParameterDirection.Input;
                pFakultetId.SqlDbType = SqlDbType.NVarChar;
                pFakultetId.ParameterName = "@FakultetId";
                pFakultetId.Value = FakultetId;
                command.Parameters.Add(pFakultetId);

                SqlParameter pVrabotenId = new SqlParameter();
                pVrabotenId.Direction = ParameterDirection.Input;
                pVrabotenId.SqlDbType = SqlDbType.NVarChar;
                pVrabotenId.ParameterName = "@VrabotenId";
                pVrabotenId.Value = VrabotenId;
                command.Parameters.Add(pVrabotenId);

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
        public int ProDekanUpdate(object FakultetId, object VrabotenId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ProDekanUpdate";
                command.Connection = Connection;

                SqlParameter pFakultetId = new SqlParameter();
                pFakultetId.Direction = ParameterDirection.Input;
                pFakultetId.SqlDbType = SqlDbType.NVarChar;
                pFakultetId.ParameterName = "@FakultetId";
                pFakultetId.Value = FakultetId;
                command.Parameters.Add(pFakultetId);

                SqlParameter pVrabotenId = new SqlParameter();
                pVrabotenId.Direction = ParameterDirection.Input;
                pVrabotenId.SqlDbType = SqlDbType.NVarChar;
                pVrabotenId.ParameterName = "@VrabotenId";
                pVrabotenId.Value = VrabotenId;
                command.Parameters.Add(pVrabotenId);

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
        public int ProDekanDelete(int FakultetId, int VrabotenId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ProDekanDelete";
                command.Connection = Connection;

                SqlParameter pFakultetId = new SqlParameter();
                pFakultetId.Direction = ParameterDirection.Input;
                pFakultetId.SqlDbType = SqlDbType.NVarChar;
                pFakultetId.ParameterName = "@FakultetId";
                pFakultetId.Value = FakultetId;
                command.Parameters.Add(pFakultetId);

                SqlParameter pVrabotenId = new SqlParameter();
                pVrabotenId.Direction = ParameterDirection.Input;
                pVrabotenId.SqlDbType = SqlDbType.NVarChar;
                pVrabotenId.ParameterName = "@VrabotenId";
                pVrabotenId.Value = VrabotenId;
                command.Parameters.Add(pVrabotenId);

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
