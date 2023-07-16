using EpsaEntities;
using EpsaEntities.ModelDto;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Collections.Generic;
using EpsaEntities.Models;

namespace EpsaDAL
{

    public class ConsumoPorTramoDAL
    {
        private string _context;

        public ConsumoPorTramoDAL()
        {
            _context = DBContext.connectionString;
        }

        #region METODOS PARA CONSULTAR 

        /// <summary>
        /// <br/>Control de Cambios-----------------
        /// <br/>Compania:       
        /// <br/>Creado:         Julio. 16/2023
        /// <br/>Modificado:     
        /// <br/>Version:        1.0
        /// <br/>Autor:          RAOG(mi empresa) - René Alejandro Ortiz Gaviria
        /// <br/>Sistema:        EpsaAPI DALL
        /// <br/>Assemblies:     EpsaAPI.EpsaDAL.Datos
        /// <br/>Description:    Metodo para Obtener Historial por Tramos filtrado por fecha inicial y fecha final
        /// <br/><param name="fecha">Param: objeto FechasDto</param>
        /// <br/><returns>Retorna: List ObtenerHistorialTramosDto</returns>
        /// <br/><exception cref="Exception">Exception: se ejecuta un throw en caso de tener alguna excepción </exception>
        /// <br/> Historial--------------------------
        /// <br/>Julio. 16/2023 - RAOG Version: 1.0. Creación Clase ConsumoPorTramoDAL
        /// <br/><Author>
        /// <br/>René Alejandro Ortiz Gaviria
        /// <br/></Author>
        /// <br/></summary>
        public List<ObtenerHistorialTramosDto> ObtenerHistoria(FechasDto fecha)
        {
           List<ObtenerHistorialTramosDto> oht = new List<ObtenerHistorialTramosDto>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_context))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("ObtenerHistorialTramos", connection))
                    {
                       
                        command.CommandType = CommandType.StoredProcedure;
                        // Agregar parámetros si es necesario
                        command.Parameters.AddWithValue("@FechaInicio", fecha.FechaInicial);
                        command.Parameters.AddWithValue("@FechaFin", fecha.FechaFinal);

                        ObtenerHistorialTramosDto historia = new ObtenerHistorialTramosDto();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                historia.IdTramo  = (int)reader["IdTramo"];
                                historia.Nombre  = Convert.ToString(reader["Nombre"]);
                                historia.Fecha  = Convert.ToDateTime(reader["Fecha"]);
                                historia.Consumo  = Convert.ToInt32(reader["Consumo"]);
                                historia.Perdidas = (double)reader["Perdidas"];
                                historia.Costo = (double)reader["Costo"];

                                oht.Add(historia);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return oht;
        }
        #endregion

    }
}
