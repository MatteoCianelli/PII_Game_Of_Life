using System;
using System.IO;
using System.Reflection;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Se encarga de la lectura del archivo.
    /// Cumple SRP: Su única razón de cambio es si modifica el tipo o formato del archivo.
    /// Cumple Expert: Es la clase experta en interpretar los caracteres ('1' y '0') del 
    /// archivo para transformarlos en una matriz.
    /// </summary>
    public class FileReader
    {
        public static bool[,] ReadFile(string filePath)
        {
            string url = filePath;
            string content = File.ReadAllText(url);
            string[] contentLines = content.Split('\n');
            bool[,] board = new bool[contentLines[0].Length, contentLines.Length];
            for (int y = 0; y < contentLines.Length; y++)
            {
                for (int x = 0; x < contentLines[y].Length; x++)
                {
                    if (contentLines[y][x] == '1')
                    {
                        board[x, y] = true;
                    }
                }
            }

            return board;
        }
    }
}
