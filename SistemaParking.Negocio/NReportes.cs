using SistemaParking.Dato;
using SistemaParking.Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SistemaParking.Negocio.NReportes;

namespace SistemaParking.Negocio
{
    public class NReportes
    {
        private readonly DReportes _dal = new DReportes();

        public List<EReportes> GenerarReporte(DateTime fechaInicial, DateTime fechaFinal)
        {
            return _dal.ObtenerReporte(fechaInicial, fechaFinal);
        }

    }
}
