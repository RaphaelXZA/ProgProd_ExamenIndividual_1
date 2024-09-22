using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdProg_ExamenPromedio1
{
    internal class MinisterioSeguridad : Ministerio
    {
        public MinisterioSeguridad(string tipo, int nivel, int vida, int costoCreacion, int costoMantenimiento, int cantidadAumentoDesarrollo, int costoMinimoInversion) : base(tipo, nivel, vida, costoCreacion, costoMantenimiento, cantidadAumentoDesarrollo, costoMinimoInversion)
        {
        }

        public override void AumentarDesarrollo(Poblacion poblacion)
        {
            poblacion.DesarrolloSeguridad += CantidadAumentoDesarrollo;

            if (poblacion.DesarrolloSeguridad > 100)
            {
                poblacion.DesarrolloSeguridad = 100;
            }
        }

        public override void Destruir(Gobierno gobierno)
        {
            gobierno.MinisterioSeguridad = null;
        }
    }
}
