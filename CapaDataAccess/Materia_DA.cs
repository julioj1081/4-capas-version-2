using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CapaEntities;
using System.Data.SqlClient;
using System.Configuration;

namespace CapaDataAccess
{
    public class Materia_DA
    {
        public List<Materia_ET> Listar()
        {
            var materia = new List<Materia_ET>();
            try
            {
                using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BASE"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("SELECT * FROM Materias", con);
                    using(var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            materia.Add(new Materia_ET { 
                                idMateria = Convert.ToInt32(dr["idMateria"]), 
                                Materia = dr["Materia"].ToString() 
                            });
                        }
                    }
                }
            }catch(Exception e) { throw e; }
            return materia;
        }
    }
}
