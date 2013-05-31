using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Univerziteti.BussinesObjects;

namespace Univerziteti.DataProvider
{
    public partial class SqlDataAccess
    {
        public List<Univerzitet> UniverzitetSelectAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UniverzitetSelectAll";
                command.Connection = Connection;

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return UniverzitetFromDataSet(ds);
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

        public List<Univerzitet> UniverzitetRabotiVoUniJoinByVrabId(int VrabotenId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UniverzitetRabotiVoUniJoinByVrabId";
                command.Connection = Connection;

                SqlParameter parameter = new SqlParameter();
                parameter.Direction = ParameterDirection.Input;
                parameter.SqlDbType = SqlDbType.Int;
                parameter.ParameterName = "@VrabotenId";
                parameter.Value = VrabotenId;
                command.Parameters.Add(parameter);

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return UniverzitetFromDataSet(ds);
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
        

        public List<Univerzitet> UniverzitetFromDataSet(DataSet ds)
        {
            List<Univerzitet> items = new List<Univerzitet>();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    items.Add(UniverzitetFromDataRow(row));
                }
            }
            return items;
        }
        public Univerzitet UniverzitetFromDataRow(DataRow row)
        {
            Univerzitet item = new Univerzitet();

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
            if (!row.IsNull("Slika"))
            {
                item.Slika = row["Slika"].ToString();
            }
            if (!row.IsNull("Rektor"))
            {
                item.Rektor = Convert.ToInt32(row["Rektor"]);
            }
            if (!row.IsNull("KontaktId"))
            {
                item.KontaktId = Convert.ToInt32(row["KontaktId"]);
            }
            return item;
        }
        public Univerzitet UniverzitetSelectByKey(int Id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UniverzitetSelectByKey";
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

                return UniverzitetFromDataRow(ds.Tables[0].Rows[0]);
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
        public int UniverzitetInsert(string Ime, string Opis, string Slika, object Rektor, object KontaktId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UniverzitetInsert";
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

                SqlParameter pSlika = new SqlParameter();
                pSlika.Direction = ParameterDirection.Input;
                pSlika.SqlDbType = SqlDbType.NVarChar;
                pSlika.ParameterName = "@Slika";
                pSlika.Value = Slika;
                command.Parameters.Add(pSlika);

                SqlParameter pRektor = new SqlParameter();
                pRektor.Direction = ParameterDirection.Input;
                pRektor.SqlDbType = SqlDbType.Int;
                pRektor.ParameterName = "@Rektor";
                if (Rektor != null)
                {
                    pRektor.Value = Rektor;
                }
                else
                {
                    pRektor.Value = DBNull.Value;
                }
                command.Parameters.Add(pRektor);

                SqlParameter pKontaktId = new SqlParameter();
                pKontaktId.Direction = ParameterDirection.Input;
                pKontaktId.SqlDbType = SqlDbType.Int;
                pKontaktId.ParameterName = "@KontaktId";
                if (KontaktId != null)
                {
                    pKontaktId.Value = KontaktId;
                }
                else
                {
                    pKontaktId.Value = DBNull.Value;
                }
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
        public int UniverzitetUpdate(int Id, string Ime, string Opis, string Slika, object Rektor, object KontaktId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UniverzitetUpdate";
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

                SqlParameter pSlika = new SqlParameter();
                pSlika.Direction = ParameterDirection.Input;
                pSlika.SqlDbType = SqlDbType.NVarChar;
                pSlika.ParameterName = "@Slika";
                pSlika.Value = Slika;
                command.Parameters.Add(pSlika);

                SqlParameter pRektor = new SqlParameter();
                pRektor.Direction = ParameterDirection.Input;
                pRektor.SqlDbType = SqlDbType.Int;
                pRektor.ParameterName = "@Rektor";
                if (Rektor != null)
                {
                    pRektor.Value = Rektor;
                }
                else
                {
                    pRektor.Value = DBNull.Value;
                }
                command.Parameters.Add(pRektor);

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
        public int UniverzitetDelete(int Id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "UniverzitetDelete";
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
