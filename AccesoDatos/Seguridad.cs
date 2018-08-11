using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AccesoDatos
{
    public class Seguridad
    {
        public string conexion()
        {
            return global::AccesoDatos.Properties.Settings.Default.newpruebasConnectionString;
        }
    }
}
