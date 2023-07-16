using System;
using System.Data;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;


namespace CopiarExcelTOSqlServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ruta del archivo de Excel
            string excelFilePath = @"C:\Users\Alejandro\Desktop\PruebaTecnica\PeakU\EPSA_Listado_Costos.xlsx";

            // Cadena de conexión a SQL Server
            string connectionString = "Data Source=DESKTOP-PK3SEMO\\SQLEXPRESS;Initial Catalog=EPSA;Integrated Security=True";

            // Crear una aplicación de Excel
            Excel.Application excelApp = new Excel.Application();

            // Abrir el archivo de Excel
            Excel.Workbook workbook = excelApp.Workbooks.Open(excelFilePath);

            // Seleccionar la primera hoja de Excel
            Excel.Worksheet worksheet = workbook.Sheets[3];

            // Obtener el rango de datos utilizado en la hoja
            Excel.Range range = worksheet.UsedRange;

            // Obtener el número total de filas y columnas
            int rowCount = range.Rows.Count;
            int colCount = range.Columns.Count;

            // Crear una tabla en memoria para almacenar los datos
            DataTable dataTable = new DataTable();

            // Agregar columnas a la tabla según los encabezados en la primera fila
            for (int col = 1; col <= colCount; col++)
            {
                string columnName = (range.Cells[1, col] as Excel.Range).Value2.ToString();
                dataTable.Columns.Add(columnName, typeof(string));
            }

            // Leer cada fila y columna de Excel y agregar los datos a la tabla
            for (int row = 2; row <= rowCount; row++) // Empezamos en la segunda fila para omitir los encabezados
            {
                DataRow dataRow = dataTable.NewRow();

                for (int col = 1; col <= colCount; col++)
                {
                    var data = (range.Cells[row, col] as Excel.Range).Value;
                    var spl = data.GetType();
                    if (spl.Name != "DateTime" && spl.Name != "Int" && spl.Name != "Double")
                    {
                        if (data == "Tramo 1" || data == "Tramo 2" || data == "Tramo 3" || data == "Tramo 4" || data == "Tramo 5")
                        {
                            switch (data)
                            {
                                case "Tramo 1":
                                    data = 1;
                                    break;
                                case "Tramo 2":
                                    data = 2;
                                    break;
                                case "Tramo 3":
                                    data = 3;
                                    break;
                                case "Tramo 4":
                                    data = 4;
                                    break;
                                case "Tramo 5":
                                    data = 5;
                                    break;
                            }
                        }
                    }

                    dataRow[col - 1] = data;
                }

                dataTable.Rows.Add(dataRow);
            }

            // Cerrar el archivo de Excel y liberar los recursos
            workbook.Close();
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);

            // Guardar los datos en la tabla de SQL Server
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Abrir la conexión a SQL Server
                connection.Open();

                // Crear un adaptador de datos para realizar la operación de inserción
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "PerdiaPorTramo"; // Nombre de la tabla en SQL Server
                    bulkCopy.WriteToServer(dataTable);
                }

                // Cerrar la conexión a SQL Server
                connection.Close();
            }

            Console.WriteLine("Los datos se han importado correctamente en la tabla de SQL Server.");
            Console.ReadLine();
        }
    }
}
