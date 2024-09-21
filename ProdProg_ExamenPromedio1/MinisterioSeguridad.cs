using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdProg_ExamenPromedio1
{
    internal class MinisterioSeguridad : Ministerio
    {
        public MinisterioSeguridad(string tipo, int nivel, int vida, int costoCreacion, int costoMantenimiento, int cantidadAumentoDesarrollo) : base(tipo, nivel, vida, costoCreacion, costoMantenimiento, cantidadAumentoDesarrollo)
        {
        }

        public override void AumentarDesarrollo(Poblacion poblacion)
        {
            poblacion.desarrolloSeguridad += CantidadAumentoDesarrollo;

            if (poblacion.desarrolloSeguridad > 100)
            {
                poblacion.desarrolloSeguridad = 100;
            }
        }
    }
}
