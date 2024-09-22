using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdProg_ExamenPromedio1
{
    internal class MinisterioSalud : Ministerio
    {
        public MinisterioSalud(string tipo, int nivel, int vida, int costoCreacion, int costoMantenimiento, int cantidadAumentoDesarrollo, int costoMinimoInversion) : base(tipo, nivel, vida, costoCreacion, costoMantenimiento, cantidadAumentoDesarrollo, costoMinimoInversion)
        {
        }

        public override void AumentarDesarrollo(Poblacion poblacion)
        {
            poblacion.DesarrolloSalud += CantidadAumentoDesarrollo;

            if (poblacion.DesarrolloSalud > 100)
            {
                poblacion.DesarrolloSalud = 100;
            }
        }

        public override void Destruir(Gobierno gobierno)
        {
            gobierno.MinisterioSalud = null;
        }
    }
}
