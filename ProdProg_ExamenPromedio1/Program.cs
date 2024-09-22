using ProdProg_ExamenPromedio1;

internal class Program
{
    private static void Main(string[] args)
    {
        Juego juego = new Juego();

        juego.IniciarPartida();

        while (!juego.VerificarVictoria() && !juego.VerificarDerrota())
        {
            juego.IniciarTurno();
        }

        Console.WriteLine(juego.VerificarVictoria() ? "¡Has ganado!" : "GAME OVER: Has perdido.");
        Console.WriteLine("------------------------------------------------------------------------------------------------------");
    }
}