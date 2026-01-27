using SistemaParking.Dato;
using SistemaParking.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Negocio
{
    public class NMarca
    {
        DMarca dmarca = new DMarca();
        public List<EMarca> ListarMarca()
        {
            return dmarca.GetMarca();
        }
    }
}
