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
        public List<ProRektor> ProRektorSelectAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ProRektorSelectAll";
                command.Connection = Connection;

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return ProRektorFromDataSet(ds);
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

        public DataSet ProRektorJoinAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ProRektorJoinAll";
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

        public List<ProRektor> ProRektorFromDataSet(DataSet ds)
        {
            List<ProRektor> items = new List<ProRektor>();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    items.Add(ProRektorFromDataRow(row));
                }
            }
            return items;
        }
        public ProRektor ProRektorFromDataRow(DataRow row)
        {
            ProRektor item = new ProRektor();

            if (!row.IsNull("UniverzitetId"))
            {
                item.UniverzitetId = Convert.ToInt32(row["UniverzitetId"]);
            }
            if (!row.IsNull("VrabotenId"))
            {
                item.VrabotenId = Convert.ToInt32(row["VrabotenId"]);
            }
            return item;
        }
        public ProRektor ProRektorSelectByKey(int UniverzitetId, int VrabotenId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ProRektorSelectByKey";
                command.Connection = Connection;

                SqlParameter pUniverzitetId = new SqlParameter();
                pUniverzitetId.Direction = ParameterDirection.Input;
                pUniverzitetId.SqlDbType = SqlDbType.Int;
                pUniverzitetId.ParameterName = "@UniverzitettId";
                pUniverzitetId.Value = UniverzitetId;
                command.Parameters.Add(pUniverzitetId);

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

                return ProRektorFromDataRow(ds.Tables[0].Rows[0]);
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
        public int ProRektorInsert(object UniverzitetId, object VrabotenId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ProRektorInsert";
                command.Connection = Connection;

                SqlParameter pUniverzitetId = new SqlParameter();
                pUniverzitetId.Direction = ParameterDirection.Input;
                pUniverzitetId.SqlDbType = SqlDbType.NVarChar;
                pUniverzitetId.ParameterName = "@UniverzitetId";
                pUniverzitetId.Value = UniverzitetId;
                command.Parameters.Add(pUniverzitetId);

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
        public int ProRektorUpdate(int UniverzitetId, int VrabotenId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ProRektorUpdate";
                command.Connection = Connection;

                SqlParameter pUniverzitetId = new SqlParameter();
                pUniverzitetId.Direction = ParameterDirection.Input;
                pUniverzitetId.SqlDbType = SqlDbType.NVarChar;
                pUniverzitetId.ParameterName = "@UniverzitetId";
                pUniverzitetId.Value = UniverzitetId;
                command.Parameters.Add(pUniverzitetId);

                SqlParameter pVrabotenId = new SqlParameter();
                pVrabotenId.Direction = ParameterDirection.Input;
                pVrabotenId.SqlDbType = SqlDbType.NVarChar;
                pVrabotenId.ParameterName = "@VrabotenId";
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
        public int ProRektorDelete(int UniverzitetId, int VrabotenId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "ProRektorDelete";
                command.Connection = Connection;

                SqlParameter pUniverzitetId = new SqlParameter();
                pUniverzitetId.Direction = ParameterDirection.Input;
                pUniverzitetId.SqlDbType = SqlDbType.NVarChar;
                pUniverzitetId.ParameterName = "@UniverzitetId";
                pUniverzitetId.Value = UniverzitetId;
                command.Parameters.Add(pUniverzitetId);

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
