using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using System.Data.Linq;
using System.Data;


namespace LogicaNegocio
{
    public class UsuarioLogica
    {
        public static dbArtekWebDataContext dc = new dbArtekWebDataContext();
        public static List<Usuario> obtenerUsuario()
        {
            var Lista = dc.Usuario.Where(usu => usu.Usu_Estado == 'A');
            return Lista.ToList();
        }

        public static Usuario ObtenerUsuarioID(int idUsuario)
        {
            var usuario = dc.Usuario.FirstOrDefault(usu => usu.Usu_Estado == 'A' & usu.Id_Usuario.Equals(idUsuario));
            return usuario;
        }

        public static Usuario ObtenerUsuarioLogin(string login, string password)
        {
            var log = dc.Usuario.Single(usu => usu.Usu_Estado == 'A' & usu.Usu_Clave.Equals(password) & usu.Usu_Username.Equals(login));
            return log;
        }

        public bool AutentificarUsuario(string nombre, string clave)
        {
            var login = dc.Usuario.Any(usu => usu.Usu_Estado == 'A' & usu.Usu_Username.Equals(nombre) & usu.Usu_Clave.Equals(clave));
            return login;
        }

        public static void Save(Usuario usuario)
        {
            try
            {
                usuario.Usu_Estado = 'A';
                dc.Usuario.InsertOnSubmit(usuario);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los Datos No han sido Guardados </br>" + ex.Message);
            }
        }

        public static void Modify(Usuario usuario, int perfil_id)
        {
            try
            {
               /*Al tener un campo forenkey es necesario eliminar la relacion de la tabla.
                 y linkiar con la nueva relacion.*/
                //obtenemos la tabla del usuario segun el id.
                Usuario table = dc.Usuario.Single(d => d.Id_Usuario == usuario.Id_Usuario);
                //eliminamos la relacion con la tabla Perfil.
                if (!table.Perfil.Equals(null) || table.Perfil.Id_Perfil > 0)
                    table.Perfil.Usuario.Remove(table);
                //agregamos la nueva relaccion.
                table.Perfil = dc.Perfil.Single(d => d.Id_Perfil == perfil_id);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los Datos No han sido Modificados </br>" + ex.Message);
            }
        }

        public static void actualizarClave(Usuario usuario)
        {
            try
            {
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                
                throw new ArgumentException("Los Datos No han sido Modificados </br>" + ex.Message);
            }
        }

        public static void Delete(Usuario usuario)
        {
            try
            {
                usuario.Usu_Estado = 'E';
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("los datos no han sido eliminados" + ex.Message);
            }
        }

        ///Validaciones
        ///

        public static bool validarced(string cedula)
        {
            var lista = dc.Usuario.Any(usu => usu.Usu_Estado == 'A' & usu.Usu_Cedula.Equals(cedula));
            return lista;
        }

        public static bool validartelefono(string telefono)
        {
            var lista = dc.Usuario.Any(usu => usu.Usu_Estado == 'A' & usu.Usu_Telefono.Equals(telefono));
            return lista;
        }

        public static bool validarmail(string correo)
        {
            var lista = dc.Usuario.Any(usu => usu.Usu_Estado == 'A' & usu.Usu_Correo.Equals(correo));
            return lista;
        }


    }
}
