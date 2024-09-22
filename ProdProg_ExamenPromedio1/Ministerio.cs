using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdProg_ExamenPromedio1
{
    abstract class Ministerio
    {
        public string Tipo;
        public int Nivel;
        public int Vida;
        public int CostoCreacion;
        public int CostoMantenimiento;
        public int CantidadAumentoDesarrollo;
        public int CostoMinimoInversion;

        protected Ministerio(string tipo, int nivel, int vida, int costoCreacion, int costoMantenimiento, int cantidadAumentoDesarrollo, int costoMinimoInversion)
        {
            Tipo = tipo;
            Nivel = nivel;
            Vida = vida;
            CostoCreacion = costoCreacion;
            CostoMantenimiento = costoMantenimiento;
            CantidadAumentoDesarrollo = cantidadAumentoDesarrollo;
            CostoMinimoInversion = costoMinimoInversion;
        }

        public virtual void AumentarNivel()
        {
            Nivel++;
            CantidadAumentoDesarrollo += 5;
            CostoMantenimiento += 100;
            CostoMinimoInversion += 200;
        }

        public abstract void Destruir(Gobierno gobierno);

        public abstract void AumentarDesarrollo(Poblacion poblacion);
    }
}
