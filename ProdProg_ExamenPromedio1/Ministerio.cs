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

        protected Ministerio(string tipo, int nivel, int vida, int costoCreacion, int costoMantenimiento, int cantidadAumentoDesarrollo)
        {
            Tipo = tipo;
            Nivel = nivel;
            Vida = vida;
            CostoCreacion = costoCreacion;
            CostoMantenimiento = costoMantenimiento;
            CantidadAumentoDesarrollo = cantidadAumentoDesarrollo;
        }

        public virtual void AumentarNivel(int dineroInversion)
        {
            Nivel++;
            CantidadAumentoDesarrollo += 5;
            CostoMantenimiento += 100;
        }

        public abstract void AumentarDesarrollo();
    }
}
