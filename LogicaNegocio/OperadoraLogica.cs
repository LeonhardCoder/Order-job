using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using System.Data.Linq;

namespace LogicaNegocio
{
    public class OperadoraLogica
    {
        public static dbArtekWebDataContext dc = new dbArtekWebDataContext();
        public static List<Operadora> obtenerOperadora()
        {
            var Lista = dc.Operadora.Where(ope => ope.Ope_Estado == 'A');
            return Lista.ToList();
        }

        public static Operadora ObtenerOperadoraID(int idOperadora)
        {
            var operadora = dc.Operadora.FirstOrDefault(ope => ope.Ope_Estado == 'A' & ope.Id_Operadora.Equals(idOperadora));
            return operadora;
        }

        public static void Save(Operadora operadora)
        {
            try
            {
                operadora.Ope_Estado = 'A';
                dc.Operadora.InsertOnSubmit(operadora);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los Datos No han sido Guardados </br>" + ex.Message);
            }
        }

        public static void Modify(Operadora operadora)
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

        public static void Delete(Operadora operadora)
        {
            try
            {
                operadora.Ope_Estado = 'E';
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("los datos no han sido eliminados" + ex.Message);
            }
        }
    }
}
