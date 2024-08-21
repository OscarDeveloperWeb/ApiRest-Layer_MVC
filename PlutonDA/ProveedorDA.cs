using PlutonBE;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Libreria;

namespace PlutonDA
{
    public class ProveedorDA : ConfigDataAccess
    {

        public const string UpProveedorSelectById = "UpProveedorSelectById";
        public const string UpProveedorInsert = "UpProveedorInsert";
        public const string UpProveedorDelete = "UpProveedorDelete";
        public const string UpProveedorUpdate = "UpProveedorUpdate";



        public Proveedor SelectById(int idProveedor)
        {
            Proveedor beProveedor = null;
            var conn = Configuration.GetConnectionString("dbMercurio");
            SqlDataReader dr = null;

            using (var sqlCon = new SqlConnection(conn)) // Conecta a la base de datos
            {
                sqlCon.Open();
                using (var sqlCmd = new SqlCommand())// Conectará al procedure
                {
                    try
                    {
                        sqlCmd.Connection = sqlCon;// Cadena de conexión con los datos:servidor, base de datos, usuario, contraseña
                        sqlCmd.CommandText = UpProveedorSelectById;
                        sqlCmd.CommandType = CommandType.StoredProcedure;// Indicarle que es un stored procedure

                        sqlCmd.Parameters.Add("@ProveedorId", SqlDbType.Int).Value = idProveedor;
                        dr = sqlCmd.ExecuteReader();
                        while (dr.Read())
                        {
                            beProveedor = new Proveedor();
                            beProveedor.ProveedorId = idProveedor;
                            beProveedor.Nombre = Convert.ToString(dr["Nombre"]);// Convertir de objeto a string
                            beProveedor.Ruc = Convert.ToString(dr["Ruc"]);
                            beProveedor.ContactoId = int.Parse(dr["ContactoId"].ToString()!);// Ignorar cualquier posible null
                            beProveedor.Direccion = Convert.ToString(dr["Dirección"]);
                            beProveedor.Ciudad = Convert.ToString(dr["Ciudad"]);
                            beProveedor.Region = Convert.ToString(dr["Región"]);
                            beProveedor.CodPostal = Convert.ToString(dr["CodPostal"]);
                            beProveedor.Pais = Convert.ToString(dr["Pais"]);
                            beProveedor.Telefono = Convert.ToString(dr["Telefono"]);
                            beProveedor.Fax = Convert.ToString(dr["Fax"]);
                            beProveedor.PaginaPrincipal = Convert.ToString(dr["PaginaPrincipal"]);
                        }

                        return beProveedor;
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        dr?.Close();// ?: Si no es null el objeto, cerrarlo
                        dr?.Dispose(); // ?: Si no es null, descargarlo de memoria
                    }
                }
            }
        }

        public void Insert(Proveedor beProveedor)
        {
            var conn = Configuration.GetConnectionString("dbMercurio");

            using (var sqlCon = new SqlConnection(conn))
            {
                sqlCon.Open();
                using (var sqlCmd = new SqlCommand())
                {
                    using (var sqlTran = sqlCon.BeginTransaction())
                    {
                        try
                        {
                            sqlCmd.Connection = sqlCon;
                            sqlCmd.CommandText = UpProveedorInsert;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = beProveedor.Nombre;
                            sqlCmd.Parameters.Add("@Ruc", SqlDbType.Char).Value = beProveedor.Ruc;
                            sqlCmd.Parameters.Add("@ContactoId", SqlDbType.Int).Value = beProveedor.ContactoId;
                            sqlCmd.Parameters.Add("@Dirección", SqlDbType.NVarChar).Value = beProveedor.Direccion;
                            sqlCmd.Parameters.Add("@Ciudad", SqlDbType.NVarChar).Value = beProveedor.Ciudad;
                            sqlCmd.Parameters.Add("@Región", SqlDbType.NVarChar).Value = beProveedor.Region;
                            sqlCmd.Parameters.Add("@CodPostal", SqlDbType.NVarChar).Value = beProveedor.CodPostal;
                            sqlCmd.Parameters.Add("@Pais", SqlDbType.NVarChar).Value = beProveedor.Pais;
                            sqlCmd.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = beProveedor.Telefono;
                            sqlCmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = beProveedor.Fax;
                            sqlCmd.Parameters.Add("@PaginaPrincipal", SqlDbType.NVarChar).Value = beProveedor.PaginaPrincipal;

                            sqlCmd.ExecuteNonQuery();
                            sqlTran.Commit();

                        }
                        catch (Exception ex)
                        {
                            sqlTran?.Rollback();
                            throw ex;
                        }

                    }
                }
            }

        }

        public void Update(int idProveedor, Proveedor beProveedor)
        {
            var conn = Configuration.GetConnectionString("dbMercurio");

            using (var sqlCon = new SqlConnection(conn))
            {
                sqlCon.Open();
                using (var sqlCmd = new SqlCommand())
                {
                    using (var sqlTran = sqlCon.BeginTransaction())
                    {
                        try
                        {
                            sqlCmd.Connection = sqlCon;
                            sqlCmd.CommandText = UpProveedorUpdate;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@ProveedorId", SqlDbType.Int).Value = idProveedor;

                            sqlCmd.Parameters.Add("@Nombre", SqlDbType.NVarChar).Value = beProveedor.Nombre;
                            sqlCmd.Parameters.Add("@Ruc", SqlDbType.Char).Value = beProveedor.Ruc;
                            sqlCmd.Parameters.Add("@ContactoId", SqlDbType.Int).Value = beProveedor.ContactoId;
                            sqlCmd.Parameters.Add("@Dirección", SqlDbType.NVarChar).Value = beProveedor.Direccion;
                            sqlCmd.Parameters.Add("@Ciudad", SqlDbType.NVarChar).Value = beProveedor.Ciudad;
                            sqlCmd.Parameters.Add("@Región", SqlDbType.NVarChar).Value = beProveedor.Region;
                            sqlCmd.Parameters.Add("@CodPostal", SqlDbType.NVarChar).Value = beProveedor.CodPostal;
                            sqlCmd.Parameters.Add("@Pais", SqlDbType.NVarChar).Value = beProveedor.Pais;
                            sqlCmd.Parameters.Add("@Telefono", SqlDbType.NVarChar).Value = beProveedor.Telefono;
                            sqlCmd.Parameters.Add("@Fax", SqlDbType.NVarChar).Value = beProveedor.Fax;
                            sqlCmd.Parameters.Add("@PaginaPrincipal", SqlDbType.NVarChar).Value = beProveedor.PaginaPrincipal;

                            sqlCmd.ExecuteNonQuery();
                            sqlTran.Commit();
                        }
                        catch (Exception)
                        {
                            sqlTran?.Rollback();
                            throw;
                        }
                    }
                }
            }
        }

        public void Delete(int idProveedor)
        {
            var conn = Configuration.GetConnectionString("dbMercurio");

            using (var sqlCon = new SqlConnection(conn))
            {
                sqlCon.Open();
                using (var sqlCmd = new SqlCommand())
                {
                    using (var sqlTran = sqlCon.BeginTransaction())
                    {
                        try
                        {
                            sqlCmd.Connection = sqlCon;
                            sqlCmd.CommandText = UpProveedorDelete;
                            sqlCmd.CommandType = CommandType.StoredProcedure;
                            sqlCmd.Transaction = sqlTran;

                            sqlCmd.Parameters.Add("@ProveedorId", SqlDbType.Int).Value = idProveedor;

                            sqlCmd.ExecuteNonQuery();
                            sqlTran.Commit();
                        }
                        catch (Exception)
                        {
                            sqlTran?.Rollback();
                            throw;
                        }
                    }
                }
            }
        }
    }
}
