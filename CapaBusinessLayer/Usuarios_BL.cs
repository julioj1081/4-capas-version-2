using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntities;
using CapaDataAccess;

namespace CapaBusinessLayer
{
    public class Usuarios_BL
    {
        private Usuarios_DA userDA = new Usuarios_DA();

        public List<Usuarios_ET> ListaUsuarios()
        {
            return userDA.Listado();
        }
        public bool Registrar(Usuarios_ET cls)
        {
            return userDA.RegistroNuevo(cls);
        }

        public object Obtener(int id)
        {
            return userDA.Obtener(Convert.ToInt32(id));
        }

        public Usuarios_ET Actualizar(Usuarios_ET cls)
        {
            return userDA.Modificar(cls);
        }

        public bool Eliminar(int id)
        {
            return userDA.Eliminar(id);
        }
    }
}
