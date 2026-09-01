using System;
using System.Text;
using System.IO;
using System.Reflection;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Se encarga de mostrar el tablero en la consola.
    /// Cumple SRP: Su única razón de cambio es si cambia la forma de imprimir o el formato 
    /// visual en la pantalla.
    /// Cumple Expert: Es la experta en transformar los valores booleanos en caracteres visuales 
    /// ("|X|" y "___").
    /// </summary>
    public class ConsolePrinter
    {
        public static void Print(Board board)
        {
            Console.Clear();
            StringBuilder s = new StringBuilder();
            for (int y = 0; y<board.Height;y++)
            {
                for (int x = 0; x<board.Width; x++)
                {
                    if(board.Content[x,y])
                    {
                        s.Append("|X|");
                    }
                    else
                    {
                        s.Append("___");
                    }
                }
                s.Append("\n");
            }
            Console.WriteLine(s.ToString());
        }
    }
}
