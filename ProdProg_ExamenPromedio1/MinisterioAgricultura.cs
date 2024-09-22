using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdProg_ExamenPromedio1
{
    internal class MinisterioAgricultura : Ministerio
    {
        public MinisterioAgricultura(string tipo, int nivel, int vida, int costoCreacion, int costoMantenimiento, int cantidadAumentoDesarrollo, int costoMinimoInversion) : base(tipo, nivel, vida, costoCreacion, costoMantenimiento, cantidadAumentoDesarrollo, costoMinimoInversion)
        {
        }

        public override void AumentarDesarrollo(Poblacion poblacion)
        {
            poblacion.DesarrolloAgricultura += CantidadAumentoDesarrollo;

            if (poblacion.DesarrolloAgricultura > 100)
            {
                poblacion.DesarrolloAgricultura = 100;
            }
        }

        public override void Destruir(Gobierno gobierno)
        {
            gobierno.MinisterioAgricultura = null;
        }
    }
}
