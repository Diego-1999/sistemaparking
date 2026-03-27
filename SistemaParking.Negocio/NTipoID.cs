using SistemaParking.Dato;
using SistemaParking.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaParking.Negocio
{
    public class NTipoID
    {
        //instancia con la clase DTipoID de la capa Datos
        DTipoID dtipoid = new DTipoID();
        public List<ETipoId> ListarTipoId()
        {
            return dtipoid.GetTipoId();
        }
    }
}
