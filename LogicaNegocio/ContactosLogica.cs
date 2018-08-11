using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using System.Data.Linq;

namespace LogicaNegocio
{
    public class ContactosLogica
    {
        public static dbArtekWebDataContext dc = new dbArtekWebDataContext();
        public static List<Contacto> obtenerContacto()
        {
            var Lista = dc.Contacto.Where(con => con.Cont_Estado == 'A');
            return Lista.ToList();
        }

        public static Contacto ObtenerContactoID(int idContacto)
        {
            var contacto = dc.Contacto.FirstOrDefault(con => con.Cont_Estado == 'A' & con.Id_Contacto.Equals(idContacto));
            return contacto;
        }

        public static void Save(Contacto contacto)
        {
            try
            {
                contacto.Cont_Estado = 'A';
                dc.Contacto.InsertOnSubmit(contacto);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los Datos No han sido Guardados </br>" + ex.Message);
            }
        }

        public static void Modify(Contacto contacto)
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

        public static void Delete(Contacto contacto)
        {
            try
            {
                contacto.Cont_Estado = 'E';
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("los datos no han sido eliminados" + ex.Message);
            }
        }

    }
}
