using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdProg_ExamenPromedio1
{
    internal class Juego
    {
        public Gobierno Gobierno;
        public Poblacion Poblacion;
        public int Turno;
        public bool PasoElTurno = false;

        public Juego()
        {
            Gobierno = new Gobierno(3000);
            Poblacion = new Poblacion(2000, 5, 5, 5, 5);
            Turno = 1;
        }

        public void IniciarPartida()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine("JUEGO DE CIVILIZACION POR TURNOS\n");
            Console.WriteLine("Administra tu dinero, construye ministerios y lleva al máximo las áreas de desarrollo de tu población.");
            Console.WriteLine("------------------------------------------------------------------------------------------------------\n");
        }
        
        public void IniciarTurno()
        {
            PasoElTurno = false;
            
            MostrarEstadisticas();

            while (!PasoElTurno)
            {
                RealizarAccionJugador();

                if (PasoElTurno)
                    break;
            }
            RealizarAccionesAutomaticas();
            OcurrirEvento();
            Turno++;
        }

        private void MostrarEstadisticas()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine($"[TURNO: {Turno}] \n");
            Console.WriteLine($"Dinero del Gobierno: {Gobierno.Dinero}");
            Console.WriteLine($"Dinero de la Población: {Poblacion.Dinero}\n");
            Console.WriteLine("Ministerios:\n");
            foreach (var ministerio in Gobierno.ObtenerMinisteriosActivos())
            {
                Console.WriteLine($"- {ministerio.Tipo}: Nivel {ministerio.Nivel}, Vida {ministerio.Vida}");
            }
            Console.WriteLine(); //LINEA VACIA PARA ESPACIO
            Console.WriteLine("Desarrollo de tu Poblacion: \n");
            Console.WriteLine($"Educacion: {Poblacion.DesarrolloEducacion}/100");
            Console.WriteLine($"Seguridad: {Poblacion.DesarrolloSeguridad}/100");
            Console.WriteLine($"Agricultura: {Poblacion.DesarrolloAgricultura}/100");
            Console.WriteLine($"Salud: {Poblacion.DesarrolloSalud}/100\n");
        }

        private void RealizarAccionesAutomaticas()
        {
            Poblacion.GenerarDinero();
            Gobierno.CobrarImpuestos(Poblacion);
            foreach (var ministerio in Gobierno.ObtenerMinisteriosActivos().ToList())
            {
                if (Gobierno.Dinero >= ministerio.CostoMantenimiento)
                {
                    Gobierno.Dinero -= ministerio.CostoMantenimiento;
                    Console.WriteLine($"Se te han descontado {ministerio.CostoMantenimiento} por costo de mantenimiento del Ministero de {ministerio.Tipo}");
                }
                else
                {
                    ministerio.Vida -= 1;
                    Console.WriteLine($"No has podido pagar la cuota de {ministerio.CostoMantenimiento} por el mantenimiento de {ministerio.Tipo}. El ministerio de{ministerio.Tipo} pierde 1 punto de vida.\n");
                    if (ministerio.Vida <= 0)
                    {
                        Gobierno.DestruirMinisterio(ministerio);
                        Console.WriteLine($"El ministerio de {ministerio.Tipo} se ha caido a pedazos por falta de mantenimiento.\n");
                    }
                }

                ministerio.AumentarDesarrollo(Poblacion);
                Console.WriteLine($"El desarrollo en {ministerio.Tipo} de tu poblacion ha aumentado gracias a su ministerio.\n");
            }
        }

        private void RealizarAccionJugador()
        {
            Console.WriteLine("Elige una acción:\n");
            Console.WriteLine("1. Cobrar impuestos adicionales");
            Console.WriteLine("2. Construir ministerio");
            Console.WriteLine("3. Invertir en ministerio");
            Console.WriteLine("4. Acabar turno\n");

            int accion;
            while (!int.TryParse(Console.ReadLine(), out accion) || accion < 1 || accion > 4)
            {
                Console.WriteLine("Opcion inválida. Por favor, ingrese un número que se encuentre en la lista de opciones.\n");
            }

            switch (accion)
            {
                case 1:
                    if (Gobierno.CobrarImpuestosAdicionales(Poblacion))
                    {
                        Console.WriteLine("¡La población se cansó de que le cobres tantos impuestos y se ha revelado contra ti!. GAME OVER.");
                        Environment.Exit(0);
                    }
                    MostrarEstadisticas();
                    break;
                case 2:
                    OpcionConstruirMinisterio();
                    MostrarEstadisticas();
                    break;
                case 3:
                    OpcionInvertirEnMinisterio();
                    MostrarEstadisticas();
                    break;
                case 4:
                    Console.WriteLine("[TURNO TERMINADO.]");
                    Console.WriteLine("------------------------------------------------------------------------------------------------------\n");
                    PasoElTurno = true;
                    break;
                default:
                    Console.WriteLine("Opción invalida. Intenta de nuevo.\n");
                    break;
            }
        }

        private void OpcionConstruirMinisterio()
        {
            var ministeriosActivos = Gobierno.ObtenerMinisteriosActivos().ToList();
            if (ministeriosActivos.Count == 4)
            {
                Console.WriteLine("Ya no quedan nuevos ministerios por construir.\n");
                return;
            }

            Console.WriteLine("Elige un ministerio para construir:\n");
            Console.WriteLine("1. Educación. Costo: 300");
            Console.WriteLine("2. Salud. Costo: 300");
            Console.WriteLine("3. Seguridad. Costo: 300");
            Console.WriteLine("4. Agricultura. Costo: 300\n");
            Console.WriteLine("5. Volver\n");

            int eleccion;
            while (!int.TryParse(Console.ReadLine(), out eleccion) || eleccion < 1 || eleccion > 5)
            {
                Console.WriteLine("Opcion inválida. Por favor, ingrese un número que se encuentre en la lista de opciones.\n");
            }
            Ministerio? nuevoMinisterio = null;

            switch (eleccion)
            {
                case 1:
                    nuevoMinisterio = new MinisterioEducacion("Educacion", 1, 5, 300, 100, 5, 200);
                    break;
                case 2:
                    nuevoMinisterio = new MinisterioSalud("La Salud", 1, 5, 300, 100, 5, 200);
                    break;
                case 3:
                    nuevoMinisterio = new MinisterioSeguridad("Seguridad Ciudadana", 1, 5, 300, 100, 5, 200);
                    break;
                case 4:
                    nuevoMinisterio = new MinisterioAgricultura("Alimentación y Agricultura", 1, 5, 300, 100, 5, 200);
                    break;
                case 5:
                    break;
            }

            if (nuevoMinisterio != null)
            {
                if (Gobierno.ConstruirMinisterio(nuevoMinisterio))
                {
                    Console.WriteLine($"Has gastado {nuevoMinisterio.CostoCreacion}.");
                    Console.WriteLine($"¡Ministerio de {nuevoMinisterio.Tipo} construido con éxito!.\n");
                }
                else
                {
                    Console.WriteLine("No se pudo construir el ministerio. Verifica si ya existe o si tienes suficiente dinero.\n");
                }
            }
        }

        private void OpcionInvertirEnMinisterio()
        {
            var ministeriosActivos = Gobierno.ObtenerMinisteriosActivos().ToList();
            if (ministeriosActivos.Count == 0)
            {
                Console.WriteLine("No hay ministerios para invertir.\n");
                return;
            }

            Console.WriteLine("Elige un ministerio para invertir:\n");
            for (int i = 0; i < ministeriosActivos.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {ministeriosActivos[i].Tipo}");
            }
            Console.WriteLine(); //LINEA VACIA PARA ESPACIO
            Console.WriteLine("5. Volver\n");

            int eleccion;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out eleccion) && eleccion > 0 && eleccion <= ministeriosActivos.Count)
                {
                    break;
                }
                else if (eleccion == 5)
                {
                    return;
                }
                Console.WriteLine("Opción inválida. Por favor, elige un número de la lista de opciones.\n");
            }

            var ministerioElegido = ministeriosActivos[eleccion - 1];
            Console.WriteLine($"\nEl Ministerio de {ministerioElegido.Tipo} requiere una inversion de {ministerioElegido.CostoMinimoInversion}, ¿aceptas?\n");
            Console.WriteLine("1. Sí");
            Console.WriteLine("2. No");

            int decision;
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out decision) && (decision == 1 || decision == 2))
                {
                    break;
                }
                Console.WriteLine("Opción inválida. Por favor, elige 1 para Sí o 2 para No.");
            }

            if (decision == 1)
            {
                if (Gobierno.InvertirEnMinisterio(ministerioElegido))
                {
                    Console.WriteLine($"Has invertido {ministerioElegido.CostoMinimoInversion} en el Ministerio de {ministerioElegido.Tipo}.");
                    Console.WriteLine($"¡El Ministerio de {ministerioElegido.Tipo} ha subido de nivel!\n");
                }
                else
                {
                    Console.WriteLine("No se pudo realizar la inversión.\n");
                }
            }
            else
            {
                Console.WriteLine("\nHas decidido no invertir en este momento.\n");
            }
        }

        private void OcurrirEvento()
        {
            //30% de probabilidad de que ocurra un evento en cada turno.
            Random rnd = new Random();
            if (rnd.Next(100) < 30)
            {
                //Se elige aleatoriamente dentro de una de las 4 areas de desarrollo para decidir que evento será
                string[] areas = { "Educacion", "Salud", "Seguridad", "Agricultura" };
                string areaAfectada = areas[rnd.Next(areas.Length)];

                int desarrollo = 0;
                switch (areaAfectada)
                {
                    case "Educacion":
                        desarrollo = Poblacion.DesarrolloEducacion;
                        break;
                    case "Salud":
                        desarrollo = Poblacion.DesarrolloSalud;
                        break;
                    case "Seguridad":
                        desarrollo = Poblacion.DesarrolloSeguridad;
                        break;
                    case "Agricultura":
                        desarrollo = Poblacion.DesarrolloAgricultura;
                        break;
                }

                bool eventoPositivo = desarrollo > 50; 

                //La cantidad de dinero que ganara o perdera sera de entre 100 y 300
                int impactoEnLaEconomia = rnd.Next(100, 301);

                if (eventoPositivo)
                {
                    Gobierno.Dinero += impactoEnLaEconomia;
                    Console.WriteLine($"¡Evento positivo gracias al alto desarrollo {areaAfectada}! El gobierno gana {impactoEnLaEconomia} de dinero.\n");
                }
                else
                {
                    Gobierno.Dinero -= impactoEnLaEconomia;
                    Console.WriteLine($"¡Evento negativo debido al bajo desarrollo en {areaAfectada}! El gobierno pierde {impactoEnLaEconomia} de dinero.\n");
                }
            }
        }

        public bool VerificarVictoria()
        {
            return Poblacion.DesarrolloEducacion >= 100 &&
                   Poblacion.DesarrolloSalud >= 100 &&
                   Poblacion.DesarrolloSeguridad >= 100 &&
                   Poblacion.DesarrolloAgricultura >= 100;
        }

        public bool VerificarDerrota()
        {
            return Gobierno.Dinero <= 0;
        }
    }
}
