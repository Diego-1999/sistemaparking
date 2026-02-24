using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infraestructura
{
    public static class ContadorHelper
    {
        private static string ruta = "contador.txt";

        //Contador para los tiquetes de entrada
        public static int ObtenerSiguienteCodigo()
        {
            int ultimo = 0;
            if (File.Exists(ruta))
                ultimo = int.Parse(File.ReadAllText(ruta));

            int siguiente = ultimo + 1;
            File.WriteAllText(ruta, siguiente.ToString());
            return siguiente;
        }

        //Contador para los tiquetes de salida
        public static int ObtenerCodigoSalida()
        {
            int ultimo = 0;
            if (File.Exists(ruta))
                ultimo = int.Parse(File.ReadAllText(ruta));

            int siguiente = ultimo + 1;
            File.WriteAllText(ruta, siguiente.ToString());
            return siguiente;
        }
    }

}

