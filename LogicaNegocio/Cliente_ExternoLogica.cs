using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AccesoDatos;
using System.Data.Linq;

namespace LogicaNegocio
{
    public class Cliente_ExternoLogica
    {
        public static dbArtekWebDataContext dc = new dbArtekWebDataContext();

        public static List<ClienteExterno> obtenerLista()
        {
            var Lista = dc.ClienteExterno.Where(cli => cli.CExt_Estado == 'A');
            return Lista.ToList();
        }
    }
}
