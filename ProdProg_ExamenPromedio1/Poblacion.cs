using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdProg_ExamenPromedio1
{
    class Poblacion
    {
        public int Dinero;

        public int desarrolloEducacion;
        public int desarrolloAgricultura;
        public int desarrolloSalud;
        public int desarrolloSeguridad;

        public Poblacion(int dinero, int desarrolloEducacion, int desarrolloAgricultura, int desarrolloSalud, int desarrolloSeguridad)
        {
            Dinero = dinero;
            this.desarrolloEducacion = desarrolloEducacion;
            this.desarrolloAgricultura = desarrolloAgricultura;
            this.desarrolloSalud = desarrolloSalud;
            this.desarrolloSeguridad = desarrolloSeguridad;
        }

        public void GenerarDinero()
        {
            int desarrolloTotal = desarrolloEducacion + desarrolloAgricultura + desarrolloSalud + desarrolloSeguridad;
            Dinero += desarrolloTotal;
        }
    }
}
