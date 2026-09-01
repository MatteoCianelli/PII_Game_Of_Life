using System;
using System.IO;
using System.Reflection;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Representa el estado actual del tablero.
    /// 
    /// Cumple SRP: Su única razón de cambio es la forma en que se almacena o consulta el estado
    ///  del tablero.
    /// Cumple Expert: Es la clase experta en conocer las dimensiones y el contenido del tablero.
    /// </summary>
    public class Board
    {
        public bool[,] Content { get; set; }

        public int Height { get; private set; }

        public int Width { get; private set; }

        public Board(bool[,] content)
        {
            this.Content = content;
            this.Height = content.GetLength(1);
            this.Width = content.GetLength(0);
        }

        public bool CellIsAlive(int x, int y)
        {
            return this.Content[x, y];
        }

        public void ChangeCellValue(int x, int y, bool value)
        {
            this.Content[x, y] = value;
        }
    }
}
