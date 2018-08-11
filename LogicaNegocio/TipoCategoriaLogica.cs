using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using System.Data.Linq;

namespace LogicaNegocio
{
    public class TipoCategoriaLogica
    {
        public static dbArtekWebDataContext dc = new dbArtekWebDataContext();
        public static List<Tipo_Categoria> obtenerTipocategoria()
        {
            var Lista = dc.Tipo_Categoria.Where(tipo => tipo.Tip_Estado == 'A');
            return Lista.ToList();
        }

        public static Tipo_Categoria ObtenerCategoriaID(int idtipo)
        {
            var categoria = dc.Tipo_Categoria.FirstOrDefault(tipo => tipo.Tip_Estado == 'A' & tipo.Id_TipoCategoria.Equals(idtipo));
            return categoria;
        }

        public static void Save(Tipo_Categoria categoria)
        {
            try
            {
                categoria.Tip_Estado = 'A';
                dc.Tipo_Categoria.InsertOnSubmit(categoria);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los Datos No han sido Guardados </br>" + ex.Message);
            }
        }

        public static void Modify(Tipo_Categoria categoria)
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

        public static void Delete(Tipo_Categoria categoria)
        {
            try
            {
                categoria.Tip_Estado = 'E';
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("los datos no han sido eliminados" + ex.Message);
            }
        }
    }
}
