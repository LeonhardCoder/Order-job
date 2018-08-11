using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using System.Data.Linq;

namespace LogicaNegocio
{
    public class TipoMaterialLogica
    {
        public static dbArtekWebDataContext dc = new dbArtekWebDataContext();

        public static List<TipoMaterial> obtenertipo()
        {
            var Lista = dc.TipoMaterial.Where(tip => tip.TMat_Estado == 'A');
            return Lista.ToList();
        }

        public static TipoMaterial ObtenertipoID(int idtipo)
        {
            var tipo = dc.TipoMaterial.FirstOrDefault(tip => tip.TMat_Estado == 'A' && tip.Id_TipoMaterial.Equals(idtipo));
            return tipo;
        }

        public static void Save(TipoMaterial tipo)
        {
            try
            {
                tipo.TMat_Estado = 'A';
                dc.TipoMaterial.InsertOnSubmit(tipo);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los Datos No han sido Guardados </br>" + ex.Message);
            }
        }

        public static void Modify(TipoMaterial tipo)
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

        public static void Delete(TipoMaterial tipo)
        {
            try
            {
                tipo.TMat_Estado = 'E';
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("los datos no han sido eliminados" + ex.Message);
            }
        }
    }
}
