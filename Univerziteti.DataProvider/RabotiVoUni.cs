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
        public List<RabotiVoUni> RabotiVoUniSelectAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RabotiVoUniSelectAll";
                command.Connection = Connection;

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return RabotiVoUniFromDataSet(ds);
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

        public DataSet RabotiNaUniverzitetByUniverzitetId(int id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RabotiNaUniverzitetByUniverzitetId";
                command.Connection = Connection;

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                SqlParameter pUniverzitetId = new SqlParameter();
                pUniverzitetId.Direction = ParameterDirection.Input;
                pUniverzitetId.SqlDbType = SqlDbType.Int;
                pUniverzitetId.ParameterName = "@Id";
                pUniverzitetId.Value = id;
                command.Parameters.Add(pUniverzitetId);

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

        public DataSet RabotiVoUniJoinAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RabotiVoUniJoinAll";
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

        public List<RabotiVoUni> RabotiVoUniFromDataSet(DataSet ds)
        {
            List<RabotiVoUni> items = new List<RabotiVoUni>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    items.Add(RabotiVoUniFromDataRow(row));
                }
            }
            return items;
        }
        public RabotiVoUni RabotiVoUniFromDataRow(DataRow row)
        {
            RabotiVoUni item = new RabotiVoUni();

            if (!row.IsNull("UniverzitetId"))
            {
                item.UniverzitetId = Convert.ToInt32(row["UniverzitetId"]);
            }
            if (!row.IsNull("VrabotenID"))
            {
                item.VrabotenID = Convert.ToInt32(row["VrabotenID"]);
            }
            if (!row.IsNull("Pozicija"))
            {
                item.Pozicija = row["Pozicija"].ToString();
            }

            return item;
        }
        public RabotiVoUni RabotiVoUniSelectByKey(int UniverzitetId, int VrabotenID)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RabotiVoUniSelectByKey";
                command.Connection = Connection;

                SqlParameter uparameter = new SqlParameter();
                uparameter.Direction = ParameterDirection.Input;
                uparameter.SqlDbType = SqlDbType.Int;
                uparameter.ParameterName = "@UniverzitetId";
                uparameter.Value = UniverzitetId;
                command.Parameters.Add(uparameter);

                SqlParameter vparameter = new SqlParameter();
                vparameter.Direction = ParameterDirection.Input;
                vparameter.SqlDbType = SqlDbType.Int;
                vparameter.ParameterName = "@VrabotenID";
                vparameter.Value = VrabotenID;
                command.Parameters.Add(vparameter);

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return RabotiVoUniFromDataRow(ds.Tables[0].Rows[0]);
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
        public int RabotiVoUniInsert(object UniverzitetId, object VrabotenID, string Pozicija)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RabotiVoUniInsert";
                command.Connection = Connection;

                SqlParameter pUniverzitetId = new SqlParameter();
                pUniverzitetId.Direction = ParameterDirection.Input;
                pUniverzitetId.SqlDbType = SqlDbType.NVarChar;
                pUniverzitetId.ParameterName = "@UniverzitetId";
                pUniverzitetId.Value = UniverzitetId;
                command.Parameters.Add(pUniverzitetId);

                SqlParameter pVrabotenID = new SqlParameter();
                pVrabotenID.Direction = ParameterDirection.Input;
                pVrabotenID.SqlDbType = SqlDbType.NVarChar;
                pVrabotenID.ParameterName = "@VrabotenID";
                pVrabotenID.Value = VrabotenID;
                command.Parameters.Add(pVrabotenID);

                SqlParameter pPozicija = new SqlParameter();
                pPozicija.Direction = ParameterDirection.Input;
                pPozicija.SqlDbType = SqlDbType.NVarChar;
                pPozicija.ParameterName = "@Pozicija";
                pPozicija.Value = Pozicija;
                command.Parameters.Add(pPozicija);

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
        public int RabotiVoUniDelete(int UniverzitetId, int VrabotenID)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RabotiVoUniDelete";
                command.Connection = Connection;

                SqlParameter pUniverzitetId = new SqlParameter();
                pUniverzitetId.Direction = ParameterDirection.Input;
                pUniverzitetId.SqlDbType = SqlDbType.Int;
                pUniverzitetId.ParameterName = "@UniverzitetId";
                pUniverzitetId.Value = UniverzitetId;
                command.Parameters.Add(pUniverzitetId);

                SqlParameter pVrabotenID = new SqlParameter();
                pVrabotenID.Direction = ParameterDirection.Input;
                pVrabotenID.SqlDbType = SqlDbType.Int;
                pVrabotenID.ParameterName = "@VrabotenID";
                pVrabotenID.Value = VrabotenID;
                command.Parameters.Add(pVrabotenID);

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
