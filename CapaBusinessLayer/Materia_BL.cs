using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaDataAccess;
using CapaEntities;

namespace CapaBusinessLayer
{
    public class Materia_BL
    {
        private Materia_DA materiaDL = new Materia_DA();

        public List<Materia_ET> Listar()
        {
            return materiaDL.Listar();
        }

        
    }
}
