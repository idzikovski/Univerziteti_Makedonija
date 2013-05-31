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
        public List<Fakultet> FakultetSelectAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "FakultetSelectAll";
                command.Connection = Connection;

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return FakultetFromDataSet(ds);
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

        public List<Fakultet> FakultetRabotiNaFaksJoinByVrabId(int VrabotenId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "FakultetRabotiNaFaksJoinByVrabId";
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

                return FakultetFromDataSet(ds);
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

        public DataSet FakultetUniverzitetJoinAll()
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "FakultetUniverzitetJoinAll";
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

        public List<Fakultet> FakultetSelectByUniverzitetId(int Id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "FakultetSelectByUniverzitetId";
                command.Connection = Connection;

                SqlDataAdapter dataadapter = new SqlDataAdapter();
                dataadapter.SelectCommand = command;

                SqlParameter parameter = new SqlParameter();
                parameter.Direction = ParameterDirection.Input;
                parameter.SqlDbType = SqlDbType.Int;
                parameter.ParameterName = "@Id";
                parameter.Value = Id;
                command.Parameters.Add(parameter);

                DataSet ds = new DataSet();
                dataadapter.Fill(ds);

                if (ds.Tables.Count == 0) return null;

                return FakultetFromDataSet(ds);
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
        
        public List<Fakultet> FakultetFromDataSet(DataSet ds)
        {
            List<Fakultet> items = new List<Fakultet>();
            if (ds.Tables.Count > 0)
            {
                foreach (DataRow row in ds.Tables[0].Rows)
                {
                    items.Add(FakultetFromDataRow(row));
                }
            }
            return items;
        }
        public Fakultet FakultetFromDataRow(DataRow row)
        {
            Fakultet item = new Fakultet();

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
            if (!row.IsNull("Dekan"))
            {
                item.Dekan = Convert.ToInt32(row["Dekan"]);
            }
            if (!row.IsNull("KontaktId"))
            {
                item.KontaktId = Convert.ToInt32(row["KontaktId"]);
            }
            if (!row.IsNull("UniverzitetId"))
            {
                item.UniverzitetId = Convert.ToInt32(row["UniverzitetId"]);
            }
            return item;
        }
        public Fakultet FakultetSelectByKey(int Id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "FakultetSelectByKey";
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

                return FakultetFromDataRow(ds.Tables[0].Rows[0]);
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

        public int FakultetInsert(string Ime, string Opis, string Slika, object Dekan, object KontaktId, object UniverzitetId )
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "FakultetInsert";
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

                SqlParameter pDekan = new SqlParameter();
                pDekan.Direction = ParameterDirection.Input;
                pDekan.SqlDbType = SqlDbType.Int;
                pDekan.ParameterName = "@Dekan";
                if (Dekan != null)
                {
                    pDekan.Value = Dekan;
                }
                else
                {
                    pDekan.Value = DBNull.Value;
                }
                command.Parameters.Add(pDekan);

                SqlParameter pUniverzitetId = new SqlParameter();
                pUniverzitetId.Direction = ParameterDirection.Input;
                pUniverzitetId.SqlDbType = SqlDbType.Int;
                pUniverzitetId.ParameterName = "@UniverzitetId";
                if (UniverzitetId != null)
                {
                    pUniverzitetId.Value = UniverzitetId;
                }
                else
                {
                    pUniverzitetId.Value = DBNull.Value;
                }
                command.Parameters.Add(pUniverzitetId);

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
        public int FakultetUpdate(int Id, string Ime, string Opis, string Slika, object Dekan, object KontaktId, object UniverzitetId)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "FakultetUpdate";
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

                SqlParameter pDekan = new SqlParameter();
                pDekan.Direction = ParameterDirection.Input;
                pDekan.SqlDbType = SqlDbType.Int;
                pDekan.ParameterName = "@Dekan";
                if (Dekan != null)
                {
                    pDekan.Value = Dekan;
                }
                else
                {
                    pDekan.Value = DBNull.Value;
                }
                command.Parameters.Add(pDekan);

                SqlParameter pUniverzitetId = new SqlParameter();
                pUniverzitetId.Direction = ParameterDirection.Input;
                pUniverzitetId.SqlDbType = SqlDbType.Int;
                pUniverzitetId.ParameterName = "@UniverzitetId";
                if (UniverzitetId != null)
                {
                    pUniverzitetId.Value = UniverzitetId;
                }
                else
                {
                    pUniverzitetId.Value = DBNull.Value;
                }
                command.Parameters.Add(pUniverzitetId);

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
        public int FakultetDelete(int Id)
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
