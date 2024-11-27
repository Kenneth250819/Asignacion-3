using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Asignacion_3.Clases
{
    public class Persona
    {
        private int Id;
        private string nombre;
        private int edad;

        public int ID
        {
            get { return Id; }
            set { Id = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public int Edad
        {
            get { return edad; }
            set { edad = value; }
        }

        public Persona()
        {

        }
    }
}