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
        public List<Predmet> PredmetiSelectAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PredmetSelectAll";
                command.Connection = Connection;

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return PredmetFromDataSet(ds);
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

        public List<Predmet> PredmetNasokaPredmetJoinByNasokaId(int NasokaId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PredmetNasokaPredmetJoinByNasokaId";
                command.Connection = Connection;

                SqlParameter parameter = new SqlParameter();
                parameter.Direction = ParameterDirection.Input;
                parameter.SqlDbType = SqlDbType.Int;
                parameter.ParameterName = "@NasokaId";
                parameter.Value = NasokaId;
                command.Parameters.Add(parameter);

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return PredmetFromDataSet(ds);
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

        

        public List<Predmet> PredmetFromDataSet(DataSet ds)
        {
            List<Predmet> items = new List<Predmet>();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    items.Add(PredmetFromDataRow(row));
                }
            }
            return items;
        }

        public Predmet PredmetFromDataRow(DataRow row)
        {
            Predmet item = new Predmet();

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
            if (!row.IsNull("Fond"))
            {
                item.Fond = row["Fond"].ToString();
            }
            if (!row.IsNull("Krediti"))
            {
                item.Krediti = Convert.ToInt32(row["Krediti"]);
            }
            if (!row.IsNull("Programa"))
            {
                item.Programa = row["Programa"].ToString();
            }

            return item;
        }
        public Predmet PredmetSelectByKey(int Id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PredmetSelectByKey";
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

                return PredmetFromDataRow(ds.Tables[0].Rows[0]);
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
        public int PredmetInsert(string Ime, string Opis, string Fond, object Krediti, string Programa)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PredmetInsert";
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

                SqlParameter pFond = new SqlParameter();
                pFond.Direction = ParameterDirection.Input;
                pFond.SqlDbType = SqlDbType.NVarChar;
                pFond.ParameterName = "@Fond";
                pFond.Value = Fond;
                command.Parameters.Add(pFond);

                SqlParameter pKrediti = new SqlParameter();
                pKrediti.Direction = ParameterDirection.Input;
                pKrediti.SqlDbType = SqlDbType.Int;
                pKrediti.ParameterName = "@Krediti";
                pKrediti.Value = Krediti;
                command.Parameters.Add(pKrediti);

                SqlParameter pPrograma = new SqlParameter();
                pPrograma.Direction = ParameterDirection.Input;
                pPrograma.SqlDbType = SqlDbType.NVarChar;
                pPrograma.ParameterName = "@Programa";
                pPrograma.Value = Programa;
                command.Parameters.Add(pPrograma);



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
        public int PredmetUpdate(int Id, string Ime, string Opis, string Fond, object Krediti, string Programa)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PredmetUpdate";
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

                SqlParameter pFond = new SqlParameter();
                pFond.Direction = ParameterDirection.Input;
                pFond.SqlDbType = SqlDbType.NVarChar;
                pFond.ParameterName = "@Fond";
                pFond.Value = Fond;
                command.Parameters.Add(pFond);

                SqlParameter pKrediti = new SqlParameter();
                pKrediti.Direction = ParameterDirection.Input;
                pKrediti.SqlDbType = SqlDbType.Int;
                pKrediti.ParameterName = "@Krediti";
                pKrediti.Value = Krediti;
                command.Parameters.Add(pKrediti);

                SqlParameter pPrograma = new SqlParameter();
                pPrograma.Direction = ParameterDirection.Input;
                pPrograma.SqlDbType = SqlDbType.NVarChar;
                pPrograma.ParameterName = "@Programa";
                pPrograma.Value = Programa;
                command.Parameters.Add(pPrograma);



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
        public int PredmetDelete(int Id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "PredmetDelete";
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
