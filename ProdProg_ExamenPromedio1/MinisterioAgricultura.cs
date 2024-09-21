using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdProg_ExamenPromedio1
{
    internal class MinisterioAgricultura : Ministerio
    {
        public MinisterioAgricultura(string tipo, int nivel, int vida, int costoCreacion, int costoMantenimiento, int cantidadAumentoDesarrollo) : base(tipo, nivel, vida, costoCreacion, costoMantenimiento, cantidadAumentoDesarrollo)
        {
        }

        public override void AumentarDesarrollo(Poblacion poblacion)
        {
            poblacion.desarrolloAgricultura += CantidadAumentoDesarrollo;

            if (poblacion.desarrolloAgricultura > 100)
            {
                poblacion.desarrolloAgricultura = 100;
            }
        }
    }
}
