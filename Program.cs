using System;

namespace TicTacToe_Program
{
    class TicTacToeGame
    {
        static void Main(string[] args)
        {
            char[] board = CreateBoard();
            char player = PlayerInput();
            ShowBoard();
        }
        public static char[] CreateBoard()
        {
            char[] board = new char[10];
            for(int i=1; i<board.Length; i++)
            {
                board[i] = ' ';
            }
            return board;
        }
        public static char PlayerInput()
        {
            char player = Convert.ToChar(Console.ReadLine());
            char computer = ' ';
            if (player == 'X' )
            {
                computer = 'O';
            }
            else if (player == 'O')
            {
                computer = 'X';
            }
            return player;
        }
        public static void ShowBoard()
        {
            char[] board = CreateBoard();
            Console.WriteLine("  {0}   |   {1}   |   {2}   ", board[1], board[2], board[3]);
            Console.WriteLine("-----------------------------");
            Console.WriteLine("  {0}   |   {1}   |   {2}    ",board[4], board[5], board[6]);
            Console.WriteLine("-----------------------------");
            Console.WriteLine("  {0}   |   {1}   |   {2}    ", board[7], board[8], board[9]);
        }
    }
}
