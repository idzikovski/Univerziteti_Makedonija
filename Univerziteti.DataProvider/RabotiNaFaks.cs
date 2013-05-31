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
        public List<RabotiNaFaks> RabotiNaFaksSelectAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RabotiNaFaksSelectAll";
                command.Connection = Connection;

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return RabotiNaFaksFromDataSet(ds);
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

        public DataSet RabotiNaFaksJoinAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RabotiNaFaksJoinAll";
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

        public DataSet RabotiNaFaksByFaksId(int id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RabotiNaFaksByFaksId";
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

        public List<RabotiNaFaks> RabotiNaFaksFromDataSet(DataSet ds)
        {
            List<RabotiNaFaks> items = new List<RabotiNaFaks>();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    items.Add(RabotiNaFaksFromDataRow(row));
                }
            }
            return items;
        }
        public RabotiNaFaks RabotiNaFaksFromDataRow(DataRow row)
        {
            RabotiNaFaks item = new RabotiNaFaks();

            if (!row.IsNull("FakultetId"))
            {
                item.FakultetId = Convert.ToInt32(row["FakultetId"]);
            }
            if (!row.IsNull("VrabotenId"))
            {
                item.VrabotenId = Convert.ToInt32(row["VrabotenId"]);
            }
            if (!row.IsNull("Institut"))
            {
                item.Institut = row["Institut"].ToString();
            }
            if (!row.IsNull("Pozicija"))
            {
                item.Pozicija = row["Pozicija"].ToString();
            }
            return item;
        }
        public RabotiNaFaks RabotiNaFaksSelectByKey(object FakultetId, object VrabotenId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RabotiNaFaksSelectByKey";
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

                return RabotiNaFaksFromDataRow(ds.Tables[0].Rows[0]);
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
        public int RabotiNaFaksInsert(object FakultetId, object VrabotenId, string Institut, string Pozicija)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RabotiNaFaksInsert";
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

                SqlParameter pInstitut = new SqlParameter();
                pInstitut.Direction = ParameterDirection.Input;
                pInstitut.SqlDbType = SqlDbType.NVarChar;
                pInstitut.ParameterName = "@Institut";
                pInstitut.Value = Institut;
                command.Parameters.Add(pInstitut);

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
        public int RabotiNaFaksUpdate(object FakultetId, object VrabotenId, string Institut, string Pozicija)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RabotiNaFaksUpdate";
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

                SqlParameter pInstitut = new SqlParameter();
                pInstitut.Direction = ParameterDirection.Input;
                pInstitut.SqlDbType = SqlDbType.NVarChar;
                pInstitut.ParameterName = "@Institut";
                pInstitut.Value = Institut;
                command.Parameters.Add(pInstitut);

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
        public int RabotiNaFaksDelete(int FakultetId, int VrabotenId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "RabotiNaFaksDelete";
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
