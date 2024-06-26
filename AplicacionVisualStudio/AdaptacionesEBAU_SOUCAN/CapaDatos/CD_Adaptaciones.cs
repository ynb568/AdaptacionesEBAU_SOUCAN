﻿using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class CD_Adaptaciones
    {
        public List<Adaptacion> listaAdaptaciones()
        {
            List<Adaptacion> listaAdaptaciones = new List<Adaptacion>();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_listaAdaptaciones", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaAdaptaciones.Add(
                                new Adaptacion()
                                {
                                    IdAdaptacion = Convert.ToInt32(dr["idAdaptacion"]),
                                    NombreAdaptacion = dr["nombreAdaptacion"].ToString(),
                                    Activo = Convert.ToBoolean(dr["activo"]),
                                    Descripcion = dr["descripcion"].ToString(),
                                    Excepcional = Convert.ToBoolean(dr["excepcional"]),
                                    DescripcionExcepcional = dr["descripcionExcepcional"].ToString()
                                }
                            );
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Adaptaciones.listaAdaptaciones: " + ex.Message);
            }
            return listaAdaptaciones;
        }

        public Adaptacion obtenAdaptacion (int idAdaptacion)
        {
            Adaptacion a = null;

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_obtenAdaptacion", con);
                    cmd.Parameters.AddWithValue("idA", idAdaptacion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    // Parámetros de salida
                    SqlParameter mensajeParameter = new SqlParameter("@Mensaje", SqlDbType.VarChar, 50);
                    mensajeParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(mensajeParameter);

                    SqlParameter modificadoParameter = new SqlParameter("@Completado", SqlDbType.Bit);
                    modificadoParameter.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(modificadoParameter);

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            a = new Adaptacion()
                            {
                                IdAdaptacion = Convert.ToInt32(dr["idAdaptacion"]),
                                NombreAdaptacion = dr["nombreAdaptacion"].ToString(),
                                Activo = Convert.ToBoolean(dr["activo"]),
                                Descripcion = dr["descripcion"].ToString(),
                                Excepcional = Convert.ToBoolean(dr["excepcional"]),
                                DescripcionExcepcional = dr["descripcionExcepcional"].ToString()
                            };
                        }
                    }

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Adaptaciones.obtenAdaptacion: " + ex.Message);
            }
            return a;
        }

        public List<Adaptacion> listaAdaptacionesDiagnostico(int idDiagnostico)
        {
            List<Adaptacion> listaAdaptaciones = new List<Adaptacion>();

            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_listaAdaptacionesDiagnostico", con);
                    cmd.Parameters.AddWithValue("idD", idDiagnostico);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            listaAdaptaciones.Add(
                                new Adaptacion()
                                {
                                    IdAdaptacion = Convert.ToInt32(dr["idAdaptacion"]),
                                    NombreAdaptacion = dr["nombreAdaptacion"].ToString(),
                                    Activo = Convert.ToBoolean(dr["activo"]),
                                    Descripcion = dr["descripcion"].ToString(),
                                    Excepcional = Convert.ToBoolean(dr["excepcional"]),
                                    DescripcionExcepcional = dr["descripcionExcepcional"].ToString()
                                }
                            );
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error en CD_Adaptaciones.listaAdaptacionesDiagnostico: " + ex.Message);
            }
            return listaAdaptaciones;
        }

    }
}
