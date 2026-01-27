using SistemaParking.Dato;
using SistemaParking.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Negocio
{
    public class NRol
    {
        DRol drol = new DRol();
        public List<ERol> ListarRol()
        {
            return drol.GetRol();
        }

    }
}
