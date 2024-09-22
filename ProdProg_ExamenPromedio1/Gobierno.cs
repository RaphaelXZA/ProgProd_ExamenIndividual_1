using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdProg_ExamenPromedio1
{
    internal class Gobierno
    {
        public int Dinero;
        public MinisterioEducacion? MinisterioEducacion;
        public MinisterioSalud? MinisterioSalud;
        public MinisterioSeguridad? MinisterioSeguridad;
        public MinisterioAgricultura? MinisterioAgricultura;

        public Gobierno(int dinero)
        {
            Dinero = dinero;
        }

        public void CobrarImpuestos(Poblacion poblacion)
        {
            //El impuesto automatico de cada turno que se cobra un 10%
            int impuestos = (int)(poblacion.Dinero * 0.1f);
            Dinero += impuestos;
            poblacion.Dinero -= impuestos;
            Console.WriteLine($"Haz cobrado {impuestos} en impuestos regulares a tu pueblo\n");
        }

        public bool CobrarImpuestosAdicionales(Poblacion poblacion)
        {
            //El impuesto adicional que cobra un 5%
            int impuestosAdicionales = (int)(poblacion.Dinero * 0.05f);
            Dinero += impuestosAdicionales;
            poblacion.Dinero -= impuestosAdicionales;

            Console.WriteLine($"Haz cobrado {impuestosAdicionales} en impuestos adicionales a tu pueblo. ¡No abuses!\n");

            //10% de probabilidad de REVOLUCION
            Random rnd = new Random();
            return rnd.Next(100) < 10;
        }

        public bool ConstruirMinisterio(Ministerio ministerio)
        {
            if (Dinero < ministerio.CostoCreacion)
                return false;

            switch (ministerio)
            {
                case MinisterioEducacion m when MinisterioEducacion == null:
                    MinisterioEducacion = m;
                    break;
                case MinisterioSalud m when MinisterioSalud == null:
                    MinisterioSalud = m;
                    break;
                case MinisterioSeguridad m when MinisterioSeguridad == null:
                    MinisterioSeguridad = m;
                    break;
                case MinisterioAgricultura m when MinisterioAgricultura == null:
                    MinisterioAgricultura = m;
                    break;
                default:
                    return false;
            }

            Dinero -= ministerio.CostoCreacion;
            return true;
        }

        public bool InvertirEnMinisterio(Ministerio ministerio)
        {
            if (ministerio == null)
            {
                Console.WriteLine("Ese ministerio aun no esta construido.");
                return false;
            }

            if (Dinero < ministerio.CostoMinimoInversion)
            {
                Console.WriteLine($"Te falta dinero. Necesitas {ministerio.CostoMinimoInversion} para invertir en este ministerio.");
                return false;
            }

            ministerio.AumentarNivel();
            Dinero -= ministerio.CostoMinimoInversion;
            return true;
        }

        public IEnumerable<Ministerio> ObtenerMinisteriosActivos()
        {
            if (MinisterioEducacion != null) yield return MinisterioEducacion;
            if (MinisterioSalud != null) yield return MinisterioSalud;
            if (MinisterioSeguridad != null) yield return MinisterioSeguridad;
            if (MinisterioAgricultura != null) yield return MinisterioAgricultura;
        }

        public void DestruirMinisterio(Ministerio ministerio)
        {
            ministerio?.Destruir(this);
        }

    }
}
