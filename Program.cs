using System;

namespace TicTacToe_Program
{
    class TicTacToeGame
    {
        static void Main(string[] args)
        {
            CreateBoard();
            PlayerInput();
           
        }
        public static void CreateBoard()
        {
            char[] board = new char[10];
            for(int i=1; i<board.Length; i++)
            {
                board[i] = ' ';
            }
            
        }
        public static void PlayerInput()
        {
            char player = Convert.ToChar(Console.ReadLine());
            char computer;
            if (player == 'X')
            {
                computer = 'O';
            }
            else if (player == 'O')
            {
                computer = 'X';
            }
        }
    }
}
