using System;

namespace TicTacToe_Program
{
    class TicTacToeGame
    {
        static void Main(string[] args)
        {
            TossForTurn();
            char[] board = CreateBoard();
            char player = PlayerInput();
            ShowBoard(board);
            MakeMove(board, player);
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
        public static void ShowBoard(char [] board)
        {
            Console.WriteLine("  {0}   |   {1}   |   {2}   ", board[1], board[2], board[3]);
            Console.WriteLine("---------------------------");
            Console.WriteLine("  {0}   |   {1}   |   {2}    ",board[4], board[5], board[6]);
            Console.WriteLine("---------------------------");
            Console.WriteLine("  {0}   |   {1}   |   {2}    ", board[7], board[8], board[9]);
        }
        public static void MakeMove(char[] board, char player)
        {
            Random random = new Random();
            int computerIndex = random.Next(1, 10);
            Console.WriteLine("Enter the place you want to mark your move from 1 to 9");
            int userIndex = Convert.ToInt32(Console.ReadLine());
            
            if (board[userIndex] == ' ')
            {
                board[userIndex] = player;
            }
            else
                Console.WriteLine("Place already occupied");
            ShowBoard(board);
        }
        public static void TossForTurn()
        {
            Console.WriteLine("Enter your choice for coin toss 1:Heads 2:tails");
            int choice = Convert.ToInt32(Console.ReadLine());
            Random random = new Random();
            if (choice == random.Next(2))
                Console.WriteLine("Player won the toss and starts the game");
            else
                Console.WriteLine("Computer starts game");

        }
    }
}
