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
    public class Usuarios_DA
    {
        public List<Usuarios_ET> Listado()
        {
            var ls = new List<Usuarios_ET>();
            try
            {
                using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BASE"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("SELECT * FROM Usuarios", con);
                    using(var dr = query.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            var u = new Usuarios_ET
                            {
                                idUsuario = Convert.ToInt32(dr["idUsuario"]),
                                Nombre = dr["Nombre"].ToString(),
                                Apellido = dr["Apellido"].ToString(),
                                Edad = Convert.ToInt32(dr["Edad"]),
                                idMateria = Convert.ToInt32(dr["idMateria"]),
                                Nota = Convert.ToInt32(dr["Nota"]),
                            };
                            ls.Add(u);
                        }
                    }
                    //queremos las materias
                    foreach(var m in ls)
                    {
                        query = new SqlCommand("SELECT * FROM Materias WHERE idMateria = @idMateria", con);
                        query.Parameters.AddWithValue("@idMateria", m.idMateria);
                        using(var dr = query.ExecuteReader())
                        {
                            dr.Read();
                            if (dr.HasRows)
                            {
                                m.Materia.idMateria = Convert.ToInt32(dr["idMateria"]);
                                m.Materia.Materia = dr["Materia"].ToString();
                            }
                        }
                    }
                }
            }catch(Exception e) { throw e; }
            return ls;
        }

        

        public bool RegistroNuevo(Usuarios_ET cls)
        {
            bool resp = false;
            try
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BASE"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("INSERT INTO Usuarios(Nombre, Apellido, Edad, idMateria, Nota) VALUES(@p0, @p1, @p2, @p3, @p4)", con);
                    query.Parameters.AddWithValue("@p0", cls.Nombre);
                    query.Parameters.AddWithValue("@p1", cls.Apellido);
                    query.Parameters.AddWithValue("@p2", cls.Edad);
                    query.Parameters.AddWithValue("@p3", cls.idMateria);
                    query.Parameters.AddWithValue("@p4", cls.Nota);
                    query.ExecuteNonQuery();
                    resp = true;
                }
            }catch(Exception e) { throw e; }
            return resp;
        }

        public Usuarios_ET Obtener(int? idUsuario)
        {
            var list = new Usuarios_ET();
            try
            {
                using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BASE"].ToString()))
                {
                    con.Open();
                    var QUERY = new SqlCommand("SELECT * FROM Usuarios WHERE idUsuario = @idUsuario", con);
                    QUERY.Parameters.AddWithValue("@idUsuario", idUsuario);
                    using (var dr = QUERY.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            list.idUsuario = Convert.ToInt32(dr["idUsuario"]);
                            list.Nombre = dr["Nombre"].ToString();
                            list.Apellido = dr["Apellido"].ToString();
                            list.Edad = Convert.ToInt32(dr["Edad"]);
                            list.idMateria = Convert.ToInt32(dr["idMateria"]);
                            list.Nota = Convert.ToInt32(dr["Nota"]);
                        }
                    }
                }
            }catch(Exception e) { throw e; }
            return list;
        }
  
        public Usuarios_ET Modificar(Usuarios_ET cls)
        {
            try
            {
                using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BASE"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("UPDATE Usuarios SET Nombre = @p1, Apellido = @p2, Edad = @p3, idMateria = @p4, Nota = @p5 WHERE idUsuario = @p0", con);
                    query.Parameters.AddWithValue("@p1", cls.Nombre);
                    query.Parameters.AddWithValue("@p2", cls.Apellido);
                    query.Parameters.AddWithValue("@p3", cls.Edad);
                    query.Parameters.AddWithValue("@p4", cls.idMateria);
                    query.Parameters.AddWithValue("@p5", cls.Nota);
                    query.Parameters.AddWithValue("@p0", cls.idUsuario);
                    query.ExecuteNonQuery();
                }
            }catch(Exception e) { throw e; }
            return cls;
        }
    
        public bool Eliminar(int id)
        {
            bool resp = false;
            try
            {
                using(var con = new SqlConnection(ConfigurationManager.ConnectionStrings["BASE"].ToString()))
                {
                    con.Open();
                    var query = new SqlCommand("DELETE FROM Usuarios WHERE idUsuario = @p0", con);
                    query.Parameters.AddWithValue("@p0", id);
                    query.ExecuteNonQuery();
                    resp = true;
                }
            }catch(Exception e) { throw e; }
            return resp;
        }
    }
}
