using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using AccesoDatos;
using System.Data;
using System.Data.SqlClient;

namespace LogicaNegocio
{
    public class TecnologiaLogica
    {
        public static dbArtekWebDataContext dc = new dbArtekWebDataContext();

        Consultas contecno = new Consultas();
        public static List<Tecnologia> obtenerTecnologia()
        {
            var Lista = dc.Tecnologia.Where(tec => tec.Tec_Estado == 'A');
            return Lista.ToList();
        }

        public static Tecnologia ObtenerTecnologiaID(int idTecnologia)
        {
            var tecnologia = dc.Tecnologia.FirstOrDefault(tec => tec.Tec_Estado == 'A' & tec.Id_Tecnologia.Equals(idTecnologia));
            return tecnologia;
        }

        public static int Sq_tecnologia()
        {
            try
            {
                return dc.Tecnologia.Max(cod => cod.Id_Operadora + 1);
            }
            catch (Exception)
            {
                return 1;
            }
        }

        public static void Save(Tecnologia tecnologia)
        {
            try
            {
                tecnologia.Tec_Estado = 'A';
                dc.Tecnologia.InsertOnSubmit(tecnologia);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los Datos No han sido Guardados </br>" + ex.Message);
            }
        }

        public static void Modify(Tecnologia tecnologia, int cat_id, int ope_id)
        {
            try
            {

                Tecnologia table = dc.Tecnologia.Single(d => d.Id_Tecnologia == tecnologia.Id_Tecnologia);
                if (!table.Tipo_Categoria.Equals(null) || table.Tipo_Categoria.Id_TipoCategoria > 0)
                    table.Tipo_Categoria.Tecnologia.Remove(table);
                table.Tipo_Categoria = dc.Tipo_Categoria.Single(d => d.Id_TipoCategoria == cat_id);

                Tecnologia table1 = dc.Tecnologia.Single(d => d.Id_Tecnologia == tecnologia.Id_Tecnologia);
                if (!table1.Operadora.Equals(null) || table1.Operadora.Id_Operadora > 0)
                    table1.Operadora.Tecnologia.Remove(table1);
                table1.Operadora = dc.Operadora.Single(d => d.Id_Operadora == ope_id);

                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los Datos No han sido Modificados </br>" + ex.Message);
            }
        }

        public static void Delete(Tecnologia tecnologia)
        {
            try
            {
                tecnologia.Tec_Estado = 'E';
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("los datos no han sido eliminados" + ex.Message);
            }
        }

        public DataTable mostrar ()
        {
            try
            {
                return contecno.MostarDatos();
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public bool Insertar(string Tec_Nombre, string Tec_Descripcion, string Tec_Estado, string Id_TipoCategoria, string Id_Operadora)
        {
            try
            {
                return contecno.InsertarDatos(Tec_Nombre, Tec_Descripcion, Tec_Estado, Id_TipoCategoria, Id_Operadora);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

    }
}
