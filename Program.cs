using System;

namespace TicTacToe_Program
{
    class TicTacToeGame
    {
        static void Main(string[] args)
        {
            CreateBoard();
            char playerLetter = PlayerInput();
            char computerLetter = PlayerInput();
            Console.WriteLine(playerLetter);
            Console.WriteLine(computerLetter);
        }
        public static void CreateBoard()
        {
            char[] board = new char[10];
            for(int i=1; i<board.Length; i++)
            {
                board[i] = ' ';
            }
            
        }
        public static char PlayerInput()
        {
            char player = 'X';
            char computer = 'O';
            return player;
            return computer;
        }
    }
}
