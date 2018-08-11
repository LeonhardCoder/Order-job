using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using System.Data.Linq;

namespace LogicaNegocio
{
    public class TipoTrabajoLogica
    {
        public static dbArtekWebDataContext dc = new dbArtekWebDataContext();
        public static List<TipoTrabajo> obtenerTipotrabajo()
        {
            var Lista = dc.TipoTrabajo.Where(tip => tip.Ttrab_Estado == 'A');
            return Lista.ToList();
        }

        public static TipoTrabajo ObtenerTipoTrabajoID(int idTipo)
        {
            var tipo = dc.TipoTrabajo.FirstOrDefault(tip => tip.Ttrab_Estado == 'A' & tip.Id_TipoTrabajo.Equals(idTipo));
            return tipo;
        }

        public static void Save(TipoTrabajo tipo)
        {
            try
            {
                tipo.Ttrab_Estado = 'A';
                dc.TipoTrabajo.InsertOnSubmit(tipo);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los Datos No han sido Guardados </br>" + ex.Message);
            }
        }

        public static void Modify(TipoTrabajo tipo)
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

        public static void Delete(TipoTrabajo tipo)
        {
            try
            {
                tipo.Ttrab_Estado = 'E';
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("los datos no han sido eliminados" + ex.Message);
            }
        }
    }
}
