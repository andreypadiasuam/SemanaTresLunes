using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioUno.Model
{
    public class Tarea
    {
        public string Descripcion { get; set; } //Titulo de la tarea

        public bool Estado { get; set; }// Completada (true) o Pendiente (False)

        public Tarea(string descripcion)
        {
            Descripcion = descripcion;
            Estado = false;
        }

    }
}
