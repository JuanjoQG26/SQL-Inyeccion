
using Microsoft.Data.SqlClient;

// Cambia este valor por el nombre de tu servidor SQL Server.
string servidor = @"(localdb)\MSSQLLocalDB";

// Cadena de conexión a nuestra base de datos de práctica.
string cadenaConexion =
    $"Server={servidor};Database=LaboratorioSQLi;Integrated Security=True;TrustServerCertificate=True;";

// Abrir la conexión con SQL Server.
using SqlConnection conexion = new SqlConnection(cadenaConexion);

try
{
    conexion.Open();

    Console.WriteLine("¡Conexión exitosa!");

    // Crear una consulta de lectura.
    string consulta = @"
        SELECT Id, Nombre, Correo
        FROM Usuarios;
    ";

    // Preparar el comando SQL.
    using SqlCommand comando = new SqlCommand(consulta, conexion);

    // Ejecutar la consulta y leer los resultados.
    using SqlDataReader lector = comando.ExecuteReader();

    while (lector.Read())
    {
        Console.WriteLine(
            $"{lector["Id"]} - {lector["Nombre"]} - {lector["Correo"]}"
        );
    }
}
catch (SqlException ex)
{
    Console.WriteLine("Error de SQL Server: " + ex.Message);
}
catch (Exception ex)
{
    Console.WriteLine("Error: " + ex.Message);
}

