using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using System.Data.Linq;
using System.Data;
using System.Data.SqlClient;

namespace LogicaNegocio
{
    public class ClienteFinalLogica
    {
        public static dbArtekWebDataContext dc = new dbArtekWebDataContext();

        Clientes objetoclientes = new Clientes();

        public static List<ClienteFinal> obtenerClienteFinal()
        {
            var Lista = dc.ClienteFinal.Where(cliF => cliF.Cli_Estado == 'A');
            return Lista.ToList();
        }
        public static ClienteFinal ObtenerClienteFinalID(int idClienteFinal)
        {
            var clienteFinal = dc.ClienteFinal.FirstOrDefault(cliF => cliF.Cli_Estado == 'A' & cliF.Id_ClienteFinal.Equals(idClienteFinal));
            return clienteFinal;
        }

        public static void Save(ClienteFinal cliente)
        {
            try
            {
                cliente.Cli_Estado = 'A';
                dc.ClienteFinal.InsertOnSubmit(cliente);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los Datos No han sido Guardados </br>" + ex.Message);
            }
        }

        public static void Modify(ClienteFinal cliente)
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

        public static void Delete(ClienteFinal cliente)
        {
            try
            {
                cliente.Cli_Estado = 'E';
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("los datos no han sido eliminados" + ex.Message);
            }
        }

        public static bool validarClientF(string clientef)
        {
            var lista = dc.ClienteFinal.Any(Cli => Cli.Cli_Estado == 'A' & Cli.Cli_Nombre.Equals(clientef));
            return lista;
        }

        //Clientes por Ciudad

        public static List<Clientes_Ciudad> obtenerClientCiudad()
        {
            var Lista = dc.Clientes_Ciudad.Where(cli => cli.CCiu_Estado == 'A');
            return Lista.ToList();
        }

        public static List<sucursal_clientes> ObtenerClientesCiudadID(int idClientesCiudad)
        {
            //var cliSucursales = dc.View_sucursales.Where(cli => cli.Id_ClienteFinal.Equals(idClientesCiudad));
            var cliSucursales = from sucursal in dc.View_sucursales
                                where sucursal.Id_ClienteFinal == idClientesCiudad
                                select sucursal;
            List<sucursal_clientes> list_sucursal = new List<sucursal_clientes>();
            foreach (var sucursal in cliSucursales)
            {
                sucursal_clientes record = new sucursal_clientes
                {
                    Id_ClientesCiudad = sucursal.Id_ClientesCiudad,
                    Cli_Nombre = sucursal.Cli_Nombre,
                    CCiu_NombreSucursal = sucursal.CCiu_NombreSucursal,
                    CCiu_Direccion = sucursal.CCiu_Direccion,
                    Ciu_Nombre = sucursal.Ciu_Nombre,
                };
                list_sucursal.Add(record);
            }
           return list_sucursal;
        }

        public static List<Clientes_Ciudad> ObtenerClientesxCiudadID(int idClientesCiudad)
        {
            //var cliSucursales = dc.View_sucursales.Where(cli => cli.Id_ClienteFinal.Equals(idClientesCiudad));
            var cliSucursales = from sucursal in dc.Clientes_Ciudad
                                where sucursal.Id_ClienteFinal == idClientesCiudad
                                select sucursal;
            List<Clientes_Ciudad> list_sucursal = new List<Clientes_Ciudad>();
            foreach (var sucursal in cliSucursales)
            {
                Clientes_Ciudad record = new Clientes_Ciudad
                {
                    Id_ClientesCiudad = sucursal.Id_ClientesCiudad,
                    Id_Ciudad = sucursal.Id_Ciudad,
                    Id_ClienteFinal = sucursal.Id_ClienteFinal,
                    CCiu_NombreSucursal = sucursal.CCiu_NombreSucursal,
                    CCiu_Direccion = sucursal.CCiu_Direccion,
                    CCiu_Estado = sucursal.CCiu_Estado,
                };
                list_sucursal.Add(record);
            }
            return list_sucursal;
        }
        
        //Clientes por Operadora

        public static List<Clientes_Operadora> obtenerClienteOperadora()
        {
            var Lista = dc.Clientes_Operadora.Where(cli => cli.CO_Estado == 'A');
            return Lista.ToList();
        }

        public static Clientes_Operadora ObtenerClienteOperadoraID(int idClienteOperadora)
        {
            var clientes = dc.Clientes_Operadora.FirstOrDefault(cli => cli.CO_Estado == 'A' & cli.Id_ClienteOperadora.Equals(idClienteOperadora));
            return clientes;
        }

        public static void SaveCO(Clientes_Operadora clienteoper)
        {
            try
            {
                clienteoper.CO_Estado = 'A';
                dc.Clientes_Operadora.InsertOnSubmit(clienteoper);
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("Los Datos No han sido Guardados </br>" + ex.Message);
            }
        }

        public static void ModifyCO(Clientes_Operadora clienteoper)
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

        public static void DeleteCO(Clientes_Operadora clienteoper)
        {
            try
            {
                clienteoper.CO_Estado = 'E';
                dc.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new ArgumentException("los datos no han sido eliminados" + ex.Message);
            }
        }


        public DataTable clienteoperadora_select()
        {
            try
            {
                return objetoclientes.sp_clientes_oper();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }


    }

    public class sucursal_clientes
    {
        public Int32 Id_ClientesCiudad { get; set; }
        public string Cli_Nombre { get; set; }
        public string CCiu_NombreSucursal { get; set; }
        public string CCiu_Direccion { get; set; }
        public string Ciu_Nombre { get; set; }
    }
}
