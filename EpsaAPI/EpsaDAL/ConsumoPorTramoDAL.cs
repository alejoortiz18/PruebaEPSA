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
        /// <br/>Description:    Metodo para Obtener Historial de consumo de todos los tramos filtrado por fecha inicial y fecha final
        /// <br/><param name="fecha">Param: objeto FechasDto</param>
        /// <br/><returns>Retorna: List ObtenerHistoriaConsumoDto</returns>
        /// <br/><exception cref="Exception">Exception: se ejecuta un throw en caso de tener alguna excepción </exception>
        /// <br/> Historial--------------------------
        /// <br/>Julio. 16/2023 - RAOG Version: 1.0. Creación Clase ConsumoPorTramoDAL
        /// <br/><Author>
        /// <br/>René Alejandro Ortiz Gaviria
        /// <br/></Author>
        /// <br/></summary>
        public List<ObtenerHistoriaConsumoDto> ObtenerHistoriaConsumo(FechasDto fecha)
        {
           List<ObtenerHistoriaConsumoDto> ohc = new List<ObtenerHistoriaConsumoDto>();

            try
            {
                using (SqlConnection connection = new SqlConnection(_context))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("ObtenerHistoriaConsumo", connection))
                    {
                       
                        command.CommandType = CommandType.StoredProcedure;
                        // Agregar parámetros si es necesario
                        command.Parameters.AddWithValue("@FechaInicio", fecha.FechaInicial);
                        command.Parameters.AddWithValue("@FechaFin", fecha.FechaFinal);

                        ObtenerHistoriaConsumoDto historiaConsumo = new ObtenerHistoriaConsumoDto();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {

                                historiaConsumo.Tramo  = reader["Tramo"].ToString();
                                historiaConsumo.Fecha  = Convert.ToDateTime(reader["Fecha"]);
                                historiaConsumo.Consumo_Residencial  = Convert.ToInt32(reader["Consumo_Residencial"]);
                                historiaConsumo.Consumo_Comercial  = Convert.ToInt32(reader["Consumo_Comercial"]);
                                historiaConsumo.Consumo_Industrial = (int)reader["Consumo_Industrial"];
                                historiaConsumo.Perdida_Residencial = (double)reader["Perdidas_Residencial"];
                                historiaConsumo.Perdida_Comercial = (double)reader["Perdidas_Comercial"];
                                historiaConsumo.Perdida_Industrial = Convert.ToDouble(reader["Perdidas_Industrial"]);
                                historiaConsumo.Costo_Consumo_Residencial = (double)reader["Costo_Consumo_Residencial"];
                                historiaConsumo.Costo_Consumo_Comercial = (double)reader["Costo_Consumo_Comercial"];
                                historiaConsumo.Costo_Consumo_Industrial = (double)reader["Costo_Consumo_Industrial"];

                                ohc.Add(historiaConsumo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return ohc;
        }
        #endregion

    }
}
