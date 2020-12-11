using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntities
{
    public class Usuarios_ET
    {
        public int idUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }
        public int idMateria { get; set; }
        public Materia_ET Materia { get; set; }
        public int Nota { get; set; }


        public Usuarios_ET()
        {
            Materia = new Materia_ET();
        }

        
    }
}
