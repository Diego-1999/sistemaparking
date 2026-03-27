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
        //instancia con la clase DMarca de la capa Datos
        DMarca dmarca = new DMarca();
        public List<EMarca> ListarMarca()
        {
            return dmarca.GetTiposDeMarca();
        }
    }
}
