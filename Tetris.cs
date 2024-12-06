using System;
using System.Threading;

namespace Tetris
{
    class Program
    {
        static readonly int Width = 10;
        static readonly int Height = 20;
        static readonly char Block = '■';
        static readonly char Empty = ' ';

        static int[,] field = new int[Height, Width];
        static (int X, int Y) currentPiecePosition;
        static int[,] currentPiece;
        static bool gameOver = false;

        static readonly int[][,] pieces = new int[][,]
        {
            new int[,] { { 1, 1, 1, 1 } }, // I
            new int[,] { { 1, 1 }, { 1, 1 } }, // O
            new int[,] { { 0, 1, 0 }, { 1, 1, 1 } }, // T
            new int[,] { { 1, 1, 0 }, { 0, 1, 1 } }, // Z
            new int[,] { { 0, 1, 1 }, { 1, 1, 0 } }, // S
            new int[,] { { 1, 0, 0 }, { 1, 1, 1 } }, // L
            new int[,] { { 0, 0, 1 }, { 1, 1, 1 } }  // J
        };

        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            StartGame();

            while (!gameOver)
            {
                DrawField();
                HandleInput();
                MovePieceDown();
                Thread.Sleep(500);
            }

            Console.Clear();
            Console.WriteLine("Game Over!");
        }

        static void StartGame()
        {
            field = new int[Height, Width];
            SpawnPiece();
        }

        static void SpawnPiece()
        {
            var random = new Random();
            currentPiece = pieces[random.Next(pieces.Length)];
            currentPiecePosition = (Width / 2 - currentPiece.GetLength(1) / 2, 0);

            if (!IsValidPosition(currentPiecePosition.X, currentPiecePosition.Y))
                gameOver = true;
        }

        static void DrawField()
        {
            Console.Clear();
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (IsInPiece(x, y))
                        Console.Write(Block);
                    else
                        Console.Write(field[y, x] == 1 ? Block : Empty);
                }
                Console.WriteLine();
            }
        }

        static bool IsInPiece(int x, int y)
        {
            int pieceX = x - currentPiecePosition.X;
            int pieceY = y - currentPiecePosition.Y;
            return pieceY >= 0 && pieceY < currentPiece.GetLength(0) &&
                   pieceX >= 0 && pieceX < currentPiece.GetLength(1) &&
                   currentPiece[pieceY, pieceX] == 1;
        }

        static void HandleInput()
        {
            if (!Console.KeyAvailable) return;
            var key = Console.ReadKey(true).Key;
            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    if (IsValidPosition(currentPiecePosition.X - 1, currentPiecePosition.Y))
                        currentPiecePosition.X--;
                    break;
                case ConsoleKey.RightArrow:
                    if (IsValidPosition(currentPiecePosition.X + 1, currentPiecePosition.Y))
                        currentPiecePosition.X++;
                    break;
                case ConsoleKey.DownArrow:
                    MovePieceDown();
                    break;
                case ConsoleKey.Spacebar:
                    RotatePiece();
                    break;
            }
        }

        static void MovePieceDown()
        {
            if (IsValidPosition(currentPiecePosition.X, currentPiecePosition.Y + 1))
            {
                currentPiecePosition.Y++;
            }
            else
            {
                MergePiece();
                ClearLines();
                SpawnPiece();
            }
        }

        static void RotatePiece()
        {
            int[,] rotated = new int[currentPiece.GetLength(1), currentPiece.GetLength(0)];
            for (int y = 0; y < currentPiece.GetLength(0); y++)
                for (int x = 0; x < currentPiece.GetLength(1); x++)
                    rotated[x, currentPiece.GetLength(0) - 1 - y] = currentPiece[y, x];

            if (IsValidPosition(currentPiecePosition.X, currentPiecePosition.Y, rotated))
                currentPiece = rotated;
        }

        static bool IsValidPosition(int x, int y, int[,] piece = null)
        {
            piece ??= currentPiece;
            for (int py = 0; py < piece.GetLength(0); py++)
            {
                for (int px = 0; px < piece.GetLength(1); px++)
                {
                    if (piece[py, px] == 0) continue;

                    int fx = x + px;
                    int fy = y + py;

                    if (fx < 0 || fx >= Width || fy < 0 || fy >= Height)
                        return false;

                    if (fy >= 0 && field[fy, fx] == 1)
                        return false;
                }
            }
            return true;
        }

        static void MergePiece()
        {
            for (int y = 0; y < currentPiece.GetLength(0); y++)
                for (int x = 0; x < currentPiece.GetLength(1); x++)
                    if (currentPiece[y, x] == 1)
                        field[currentPiecePosition.Y + y, currentPiecePosition.X + x] = 1;
        }

        static void ClearLines()
        {
            for (int y = 0; y < Height; y++)
            {
                bool fullLine = true;
                for (int x = 0; x < Width; x++)
                {
                    if (field[y, x] == 0)
                    {
                        fullLine = false;
                        break;
                    }
                }
                if (fullLine)
                {
                    for (int moveY = y; moveY > 0; moveY--)
                        for (int moveX = 0; moveX < Width; moveX++)
                            field[moveY, moveX] = field[moveY - 1, moveX];
                }
            }
        }
    }
}
