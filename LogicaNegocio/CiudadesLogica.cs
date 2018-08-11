using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using System.Data.Linq;

namespace LogicaNegocio
{
    public class CiudadesLogica
    {
        public static dbArtekWebDataContext dc = new dbArtekWebDataContext();
        public static List<Ciudad> obtenerCiudades()
        {
            var Lista = dc.Ciudad.Where(ciu => ciu.Ciu_Estado == 'A');
            return Lista.ToList();
        }
        public static Ciudad ObtenerCiudadID(int idCiudad)
        {
            var ciuda = dc.Ciudad.FirstOrDefault(ciu => ciu.Ciu_Estado == 'A' & ciu.Id_Ciudad.Equals(idCiudad));
            return ciuda;
        }

        public static void Save(Ciudad ciuda)
        {
            try
            {
                ciuda.Ciu_Estado = 'A';
                dc.Ciudad.InsertOnSubmit(ciuda);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los Datos No han sido Guardados </br>" + ex.Message);
            }
        }

        public static void Modify(Ciudad ciudad)
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

        public static void Delete(Ciudad ciudad)
        {
            try
            {
                ciudad.Ciu_Estado = 'E';
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("los datos no han sido eliminados" + ex.Message);
            }
        }

        public static bool validarCiudad(string ciudades)
        {
            var lista = dc.Ciudad.Any(ciu => ciu.Ciu_Estado == 'A' & ciu.Ciu_Nombre.Equals(ciudades));
            return lista;
        }
    }
}
