using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using System.Data.Linq;

namespace LogicaNegocio
{
    public class MaterialesLogica
    {
        public static dbArtekWebDataContext dc = new dbArtekWebDataContext();
        public static List<Materiales> obtenerMateriales()
        {
            var Lista = dc.Materiales.Where(mat => mat.Mat_Estado == 'A');
            return Lista.ToList();
        }

        public static Materiales ObtenerMaterialesID(int idMateriales)
        {
            var material = dc.Materiales.FirstOrDefault(mat => mat.Mat_Estado == 'A' & mat.Id_Materiales.Equals(idMateriales));
            return material;
        }

        public static void Save(Materiales material)
        {
            try
            {
                material.Mat_Estado = 'A';
                dc.Materiales.InsertOnSubmit(material);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los Datos No han sido Guardados </br>" + ex.Message);
            }
        }

        public static void Modify(Materiales material)
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

        public static void Delete(Materiales material)
        {
            try
            {
                material.Mat_Estado = 'E';
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("los datos no han sido eliminados" + ex.Message);
            }
        }
    }
}
