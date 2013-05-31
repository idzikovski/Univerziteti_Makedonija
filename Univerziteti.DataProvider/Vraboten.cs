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
        
        public List<Vraboten> VraboteniSelectAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "VrabotenSelectAll";
                command.Connection = Connection;

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return VrabotenFromDataSet(ds);
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

        public List<Vraboten> VrabotenProRektorJoinByUniId(int UniverzitetId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "VrabotenProRektorJoinByUniId";
                command.Connection = Connection;

                SqlParameter parameter = new SqlParameter();
                parameter.Direction = ParameterDirection.Input;
                parameter.SqlDbType = SqlDbType.Int;
                parameter.ParameterName = "@UniverzitetId";
                parameter.Value = UniverzitetId;
                command.Parameters.Add(parameter);

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return VrabotenFromDataSet(ds);
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

        public List<Vraboten> VrabotenProDekanJoinByUniId(int FakultetId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "VrabotenProDekanJoinByUniId";
                command.Connection = Connection;

                SqlParameter parameter = new SqlParameter();
                parameter.Direction = ParameterDirection.Input;
                parameter.SqlDbType = SqlDbType.Int;
                parameter.ParameterName = "@FakultetId";
                parameter.Value = FakultetId;
                command.Parameters.Add(parameter);

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return VrabotenFromDataSet(ds);
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

        public DataSet VraboteniSelectImePrezime()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "VrabotenSelectImePrezime";
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

        public List<Vraboten> VrabotenFromDataSet(DataSet ds)
        {
            List<Vraboten> items = new List<Vraboten>();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    items.Add(VrabotenFromDataRow(row));
                }
            }
            return items;
        }
        public Vraboten VrabotenFromDataRow(DataRow row)
        {
            Vraboten item = new Vraboten();

            if (!row.IsNull("Id"))
            {
                item.Id = Convert.ToInt32(row["Id"]);
            }
            if (!row.IsNull("Ime"))
            {
                item.Ime = row["Ime"].ToString();
            }
            if (!row.IsNull("Prezime"))
            {
                item.Prezime = row["Prezime"].ToString();
            }
            if (!row.IsNull("Opis"))
            {
                item.Opis = row["Opis"].ToString();
            }
            if (!row.IsNull("Slika"))
            {
                item.Slika = row["Slika"].ToString();
            }
            if (!row.IsNull("KontaktId"))
            {
                item.KontaktId = Convert.ToInt32(row["KontaktId"]);
            }

            return item;
        }
        public Vraboten VrabotenSelectByKey(int Id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "VrabotenSelectByKey";
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

                return VrabotenFromDataRow(ds.Tables[0].Rows[0]);
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
        public int VrabotenInsert(string Ime, string Prezime, string Opis, string Slika, object KontaktId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "VrabotenInsert";
                command.Connection = Connection;

                SqlParameter pIme = new SqlParameter();
                pIme.Direction = ParameterDirection.Input;
                pIme.SqlDbType = SqlDbType.NVarChar;
                pIme.ParameterName = "@Ime";
                pIme.Value = Ime;
                command.Parameters.Add(pIme);

                SqlParameter pPrezime = new SqlParameter();
                pPrezime.Direction = ParameterDirection.Input;
                pPrezime.SqlDbType = SqlDbType.NVarChar;
                pPrezime.ParameterName = "@Prezime";
                pPrezime.Value = Prezime;
                command.Parameters.Add(pPrezime);

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
        public int VrabotenUpdate(int Id, string Ime, string Prezime, string Opis, string Slika, object KontaktId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "VrabotenUpdate";
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

                SqlParameter pPrezime = new SqlParameter();
                pPrezime.Direction = ParameterDirection.Input;
                pPrezime.SqlDbType = SqlDbType.NVarChar;
                pPrezime.ParameterName = "@Prezime";
                pPrezime.Value = Prezime;
                command.Parameters.Add(pPrezime);

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
        public int VrabotenDelete(int Id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "VrabotenDelete";
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
