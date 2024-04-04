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
    public class CD_Documentos
    {
        public List<Documento> listaDocumentosEstudiante(int idEstudiante)
        {
            List<Documento> documentos = new List<Documento>();
            try
            {
                using (SqlConnection con = new SqlConnection(Conexion.cadenaCon))
                {
                    SqlCommand cmd = new SqlCommand("sp_listaDocumentosEstudiante", con);
                    cmd.Parameters.AddWithValue("idE", idEstudiante);
                    cmd.CommandType = CommandType.StoredProcedure;

                    con.Open();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        //Para leer múltiples filas
                        while (dr.Read())
                        {
                            documentos.Add(
                                new Documento()
                                {
                                    IdDocumento = Convert.ToInt32(dr["idDocumento"]),
                                    NombreDocumento = dr["nombreDocumento"].ToString(),
                                    RutaDocumento = dr["rutaDocumento"].ToString(),
                                    Validado = dr["validado"] == DBNull.Value ? (bool?)null : Convert.ToBoolean(dr["validado"])
                                }
                            );
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                documentos = new List<Documento>();
                Console.WriteLine("Error al obtener los documentos: " + ex.Message);
            }
            return documentos;
        }
    }
}