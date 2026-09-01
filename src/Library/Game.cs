using System;
using System.IO;
using System.Reflection;

namespace Ucu.Poo.GameOfLife
{
    /// <summary>
    /// Contiene la lógica del juego para avanzar de generación.
    /// Cumple SRP: Su única razón de cambio es si se modifican las reglas del Juego de la Vida.
    /// Cumple Expert: Es la clase experta en contar los vecinos vivos de cada célula y decidir
    /// su siguiente estado.
    /// </summary>
    public class Game
    {
        public static void NextGen(Board currentBoard)
        {
            int boardWidth = currentBoard.Width;
            int boardHeight = currentBoard.Height;
            bool[,] cloneboard = new bool[boardWidth, boardHeight];

            for (int x = 0; x < boardWidth; x++)
            {
                for (int y = 0; y < boardHeight; y++)
                {
                    int aliveNeighbors = 0;
                    for (int i = x-1; i<=x+1;i++)
                    {
                        for (int j = y-1;j<=y+1;j++)
                        {
                            if(i>=0 && i<boardWidth && j>=0 && j < boardHeight && currentBoard.Content[i,j])
                            {
                                aliveNeighbors++;
                            }
                        }
                    }
                    if(currentBoard.Content[x,y])
                    {
                        aliveNeighbors--;
                    }
                    if (currentBoard.Content[x,y] && aliveNeighbors < 2)
                    {
                        // Célula muere por baja población
                        cloneboard[x,y] = false;
                    }
                    else if (currentBoard.Content[x,y] && aliveNeighbors > 3)
                    {
                        // Célula muere por sobrepoblación
                        cloneboard[x,y] = false;
                    }
                    else if (!currentBoard.Content[x,y] && aliveNeighbors == 3)
                    {
                        // Célula nace por reproducción
                        cloneboard[x,y] = true;
                    }
                    else
                    {
                        // Célula mantiene el estado que tenía
                        cloneboard[x,y] = currentBoard.Content[x,y];
                    }
                }
            }

            currentBoard.Content = cloneboard;
        }
    }
}
