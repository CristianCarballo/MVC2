using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data; // NO OLVIDARSE DE AGREGAR LAS LIBRERIAS PARA LAS CONECCIONES A LA BASE DE DATOS
using System.Data.SqlClient; //......................

namespace MVC2.Models
{
    public class GestorPersonas
    {
        public void agregarPersona(Persona nueva)
        {
            // Crear la conexion // La cadena de conexion la saco de la pagina www.connectionstrings.com
            SqlConnection conexion = new SqlConnection(@"Server=172.16.140.13;Database=Personas;User Id=alumno1w1;Password=alumno1w1;");
            conexion.Open();
            // Crear un objeto command
            SqlCommand comando = conexion.CreateCommand();
            // Asignar los parametros para luego hacer el insert
            comando.Parameters.Add(new SqlParameter("@nombre", nueva.Nombre));
            comando.Parameters.Add(new SqlParameter("@apellido", nueva.Apellido));
            comando.Parameters.Add(new SqlParameter("@edad", nueva.Edad));
            // Establecer la sentencia SQL
            comando.CommandText = "insert into Personas(nombre,apellido,edad) values(@nombre, @apellido, @edad)";
            // Ejecutar la sentencia
            comando.ExecuteNonQuery();
            // Cerrar todo
            conexion.Close();
        }

        public List<Persona> obtenerPersonas() // LIST ES EL EQUIVALENTE DE ARRAYLIST DE JAVA
        {
            List<Persona> lista = new List<Persona>();
            // Crear la conexion // La cadena de conexion la saco de la pagina www.connectionstrings.com
            SqlConnection conexion = new SqlConnection(@"Server=172.16.140.13;Database=Personas;User Id=alumno1w1;Password=alumno1w1;");
            conexion.Open();
            // Crear un objeto command
            SqlCommand comando = conexion.CreateCommand();
            // Establecer la sentencia SQL
            comando.CommandText = "select * from personas";
            // Ejecutar la sentencia
            SqlDataReader dr = comando.ExecuteReader();
            //Recorrer el conjunto de filas
            while (dr.Read()) // DA UNA VUELTA POR CADA FILA
            {
                int id = dr.GetInt32(0); //Obtengo valores de cada columna
                string nombre = dr.GetString(1);
                string apellido = dr.GetString(2);
                int edad = dr.GetInt32(3);
                Persona p = new Persona(id,nombre,apellido,edad);
                lista.Add(p);
            }
            // Cerrar todo
            dr.Close();
            conexion.Close();
            // Devolver la lista
            return lista;
        }
    }
}