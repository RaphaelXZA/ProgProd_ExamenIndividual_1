using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdProg_ExamenPromedio1
{
    internal class MinisterioEducacion : Ministerio
    {
        public MinisterioEducacion(string tipo, int nivel, int vida, int costoCreacion, int costoMantenimiento, int cantidadAumentoDesarrollo) : base(tipo, nivel, vida, costoCreacion, costoMantenimiento, cantidadAumentoDesarrollo)
        {
        }

        public override void AumentarDesarrollo(Poblacion poblacion)
        {
            poblacion.desarrolloEducacion += CantidadAumentoDesarrollo;

            if (poblacion.desarrolloEducacion > 100)
            {
                poblacion.desarrolloEducacion = 100;
            }
        }
    }
}
