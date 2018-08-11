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
    public class ClienteExternoLogica
    {
        public static dbArtekWebDataContext dc = new dbArtekWebDataContext();
        Consultas consultacli = new Consultas();
        public static List<ClienteExterno> obtenerLista()
        {
            var Lista = dc.ClienteExterno.Where(Cli => Cli.CExt_Estado == 'A');
            return Lista.ToList();
        }

        public static ClienteExterno ObtenerClienteExternolID(int idClienteExterno)
        {
            var clienteFinalexterno = dc.ClienteExterno.FirstOrDefault(Cli => Cli.CExt_Estado == 'A' & Cli.Id_ClienteExterno.Equals(idClienteExterno));
            return clienteFinalexterno;
        }

        public static void Save(ClienteExterno cliente)
        {
            try
            {
                cliente.CExt_Estado = 'A';
                dc.ClienteExterno.InsertOnSubmit(cliente);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los Datos No han sido Guardados </br>" + ex.Message);
            }
        }

        public static void Modify(ClienteExterno cliente)
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

        public static void Delete(ClienteExterno cliente)
        {
            try
            {
                cliente.CExt_Estado = 'E';
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("los datos no han sido eliminados" + ex.Message);
            }
        }

        public DataTable MostrarClientes()
        {
            try
            {
                return consultacli.MostarDatosClientes();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public static bool validarCliente(string cliente)
        {
            var lista = dc.ClienteExterno.Any(Cli => Cli.CExt_Estado == 'A' & Cli.CExt_Nombre.Equals(cliente));
            return lista;
        }
    }
}
