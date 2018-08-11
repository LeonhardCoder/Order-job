using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using System.Data.Linq;

namespace LogicaNegocio
{
    public class PerfilLogica
    {
        public static dbArtekWebDataContext dc = new dbArtekWebDataContext();
        public static List<Perfil> obtenerPerfil()
        {
            var Lista = dc.Perfil.Where(per => per.Per_Estado == 'A');
            return Lista.ToList();
        }
        public static Perfil ObtenerPerfilID(int idPerfil)
        {
            var perfil = dc.Perfil.FirstOrDefault(per => per.Per_Estado == 'A' & per.Id_Perfil.Equals(idPerfil));
            return perfil;
        }

        public static void Save(Perfil perfiles)
        {
            try
            {
                perfiles.Per_Estado = 'A';
                dc.Perfil.InsertOnSubmit(perfiles);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los Datos No han sido Guardados </br>" + ex.Message);
            }
        }

        public static void Modify(Perfil perfiles)
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

        public static void Delete(Perfil perfiles)
        {
            try
            {
                perfiles.Per_Estado = 'E';
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("los datos no han sido eliminados" + ex.Message);
            }
        }

        public static bool validarPerfil(string perfiles)
        {
            var lista = dc.Perfil.Any(per => per.Per_Estado == 'A' & per.Per_Nombre.Equals(perfiles));
            return lista;
        }
    }
}
