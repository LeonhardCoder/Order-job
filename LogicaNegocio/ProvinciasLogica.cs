using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using System.Data.Linq;

namespace LogicaNegocio
{
    public class ProvinciasLogica
    {
        public static dbArtekWebDataContext dc = new dbArtekWebDataContext();

        public static List<Provincia> obtenerProvincia()
        {
            var Lista = dc.Provincia.Where(pro => pro.Prov_Estado == 'A');
            return Lista.ToList();
        }

        public static Provincia ObtenerProvinciaID(int idProvincia)
        {
            var prov = dc.Provincia.FirstOrDefault(pro => pro.Prov_Estado == 'A' & pro.Id_Provincia.Equals(idProvincia));
            return prov;
        }

        public static void SaveProv(Provincia prov)
        {
            try
            {
                prov.Prov_Estado = 'A';
                dc.Provincia.InsertOnSubmit(prov);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los Datos No han sido Guardados </br>" + ex.Message);
            }
        }

        public static void ModifyProv(Provincia prov)
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

        public static void DeleteProv(Provincia prov)
        {
            try
            {
                prov.Prov_Estado = 'E';
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("los datos no han sido eliminados" + ex.Message);
            }
        }
    }
}
