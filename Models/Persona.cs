using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC2.Models
{
    public class Persona
    {
        private int id;
        private string nombre;
        private string apellido;
        private int edad;

        public Persona(int id, string nombre, string apellido, int edad)
        {
            this.Id = id;
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.Edad = edad;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Apellido { get => apellido; set => apellido = value; }
        public int Edad { get => edad; set => edad = value; }

        public string toString()
        {
            return "id: " + id + " nombre: " + nombre;
        }
    }
}