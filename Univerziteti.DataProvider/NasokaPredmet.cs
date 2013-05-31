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
        public List<NasokaPredmet> NasokaPredmetSelectAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "NasokaPredmetSelectAll";
                command.Connection = Connection;

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return NasokaPredmetFromDataSet(ds);
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

        public DataSet NasokaPredmetJoinAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "NasokaPredmetJoinAll";
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

        public List<NasokaPredmet> NasokaPredmetFromDataSet(DataSet ds)
        {
            List<NasokaPredmet> items = new List<NasokaPredmet>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    items.Add(NasokaPredmetFromDataRow(row));
                }
            }
            return items;
        }
        public NasokaPredmet NasokaPredmetFromDataRow(DataRow row)
        {
            NasokaPredmet item = new NasokaPredmet();

            if (!row.IsNull("PredmetId"))
            {
                item.PredmetId = Convert.ToInt32(row["PredmetId"]);
            }
            if (!row.IsNull("NasokaId"))
            {
                item.NasokaId = Convert.ToInt32(row["NasokaId"]);
            }
            return item;
        }
        public NasokaPredmet NasokaPredmetSelectByKey(int PredmetId, int NasokaId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "NasokaPredmetSelectByKey";
                command.Connection = Connection;

                SqlParameter pparameter = new SqlParameter();
                pparameter.Direction = ParameterDirection.Input;
                pparameter.SqlDbType = SqlDbType.Int;
                pparameter.ParameterName = "@PredmetId";
                pparameter.Value = PredmetId;
                command.Parameters.Add(pparameter);

                SqlParameter nparameter = new SqlParameter();
                nparameter.Direction = ParameterDirection.Input;
                nparameter.SqlDbType = SqlDbType.Int;
                nparameter.ParameterName = "@NasokaId";
                nparameter.Value = NasokaId;
                command.Parameters.Add(nparameter);

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return NasokaPredmetFromDataRow(ds.Tables[0].Rows[0]);
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
        public int NasokaPredmetInsert(object PredmetId, object NasokaId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "NasokaPredmetInsert";
                command.Connection = Connection;

                SqlParameter pPredmetId = new SqlParameter();
                pPredmetId.Direction = ParameterDirection.Input;
                pPredmetId.SqlDbType = SqlDbType.NVarChar;
                pPredmetId.ParameterName = "@PredmetId";
                pPredmetId.Value = PredmetId;
                command.Parameters.Add(pPredmetId);

                SqlParameter pNasokaId = new SqlParameter();
                pNasokaId.Direction = ParameterDirection.Input;
                pNasokaId.SqlDbType = SqlDbType.NVarChar;
                pNasokaId.ParameterName = "@NasokaId";
                pNasokaId.Value = NasokaId;
                command.Parameters.Add(pNasokaId);

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
        public int NasokaPredmetDelete(int PredmetId, int NasokaId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "NasokaPredmetDelete";
                command.Connection = Connection;

                SqlParameter pPredmetId = new SqlParameter();
                pPredmetId.Direction = ParameterDirection.Input;
                pPredmetId.SqlDbType = SqlDbType.Int;
                pPredmetId.ParameterName = "@PredmetId";
                pPredmetId.Value = PredmetId;
                command.Parameters.Add(pPredmetId);

                SqlParameter pNasokaId = new SqlParameter();
                pNasokaId.Direction = ParameterDirection.Input;
                pNasokaId.SqlDbType = SqlDbType.Int;
                pNasokaId.ParameterName = "@NasokaId";
                pNasokaId.Value = NasokaId;
                command.Parameters.Add(pNasokaId);

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
