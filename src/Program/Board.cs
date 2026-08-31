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
        public int Height 
        { 
            get { return this.Content.GetLength(1); } 
        }
        public int Width
        {
            get { return this.Content.GetLength(0); }
        }

        public Board(bool[,] content)
        {
            this.Content = content;
        }
    }
}
