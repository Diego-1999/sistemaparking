using SistemaParking.Dato;
using SistemaParking.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Negocio
{
    public class NColor
    {
        DColor dcolor = new DColor();
        public List<EColor> ListarColor()
        {
            return dcolor.GetColor();
        }
    }
}
