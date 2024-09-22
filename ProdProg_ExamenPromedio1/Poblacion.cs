using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdProg_ExamenPromedio1
{
    internal class Poblacion
    {
        public int Dinero;
        public int DesarrolloEducacion;
        public int DesarrolloAgricultura;
        public int DesarrolloSalud;
        public int DesarrolloSeguridad;

        public Poblacion(int dinero, int desarrolloEducacion, int desarrolloAgricultura, int desarrolloSalud, int desarrolloSeguridad)
        {
            Dinero = dinero;
            DesarrolloEducacion = desarrolloEducacion;
            DesarrolloAgricultura = desarrolloAgricultura;
            DesarrolloSalud = desarrolloSalud;
            DesarrolloSeguridad = desarrolloSeguridad;
        }

        public void GenerarDinero()
        {
            //Genera dinero para la poblacion en base a cuanto desarrollo haya
            int desarrolloTotal = DesarrolloEducacion + DesarrolloAgricultura + DesarrolloSalud + DesarrolloSeguridad;
            Dinero += desarrolloTotal;

            Console.WriteLine($"¡La poblacion ha generado {desarrolloTotal} en beneficios!\n");
        }
    }
}
