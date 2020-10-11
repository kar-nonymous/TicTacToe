using System;

namespace TicTacToe_Program
{
    class TicTacToeGame
    {
        public static bool[] positionOccupied = new bool[10];
        public static char[] board = new char[10];
        public static int chances = 0;
        public static char player;
        public static char computer;
        public static int userFirstMove = 1;
        public static int computerFirstMove = 0;
        public static int toss;
        public static int checkIfWin = 1;
        public static int[] corner = { 1, 3, 7, 9 };
        static void Main(string[] args)
        {
            char[] board = CreateBoard();
            ShowBoard();
            player = UserInput();
            computer = ComputerInput();
            TossForTurn();
            StartGame();
            UserMakeMove();
        }
        public static char[] CreateBoard()
        {
            for(int i=0; i<board.Length; i++)
            {
                board[i] = ' ';
            }
            return board;
        }
        public static char UserInput()
        {
            Console.WriteLine("Enter 'X' or 'O'");
            player = Convert.ToChar(Console.ReadLine().ToUpper());
            while(true)
            {
                if (player == 'X' || player == 'O')
                {
                    Console.WriteLine("You'll play with: " + player);
                    return player;
                }
                else
                    Console.WriteLine("Enter a valid input");
            }
        }

        public static char ComputerInput()
        {
            if (player == 'X')
            {
                computer = 'O';
                Console.WriteLine("Computer will play with " + computer);
            }
            else if (player== 'O')
            {
                computer = 'X';
                Console.WriteLine("Computer will play with " + computer);
            }
            return computer;
        }
        public static void ShowBoard()
        {
            Console.WriteLine("  {0}   |   {1}   |   {2}   ", board[1], board[2], board[3]);
            Console.WriteLine("---------------------------");
            Console.WriteLine("  {0}   |   {1}   |   {2}    ",board[4], board[5], board[6]);
            Console.WriteLine("---------------------------");
            Console.WriteLine("  {0}   |   {1}   |   {2}    ", board[7], board[8], board[9]);
        }
        public static void UserMakeMove()
        {
            while (VacantPlace())
            {
                bool flag = true;
                while (flag)
                {
                    Console.WriteLine("Enter the place you want to mark your move ");
                    int userIndex = Convert.ToInt32(Console.ReadLine());
                    if (userIndex >= 1 && userIndex <= 9 && positionOccupied[userIndex])
                    {
                        Console.WriteLine("Position marked is already filled");
                    }
                    else
                    {
                        board[userIndex] = player;
                        positionOccupied[userIndex] = true;
                        chances++;
                        flag = false;
                    }
                    if (chances < 10)
                    {
                        ComputerMakeMove();
                    }
                }
            }
            ShowBoard();
            GetComputerMove(checkIfWin);
            if (Winner())
                Console.WriteLine("Congrats you won the game");
        }
        public static void ComputerMakeMove()
        {
            bool flag = true;
            Random random = new Random();
            while (flag)
            {
                int computerIndex = random.Next(1, 10);
                if (!positionOccupied[computerIndex])
                {
                    board[computerIndex] = computer;
                    positionOccupied[computerIndex] = true;
                    chances++;
                    flag = false;
                }

            }
            ShowBoard();
        }
        public static bool VacantPlace()
        {
            for (int i = 0; i <= 10; i++)
            {
                if (!positionOccupied[i])
                {
                    return true;
                }
            }
            return false;
        }
        public static void TossForTurn()
        {
            Random random = new Random();
            Console.WriteLine("Toss to start the game 1: Haids   2: Tails");
            int userChoice = Convert.ToInt32(Console.ReadLine());
            int tossValue = random.Next(1, 3);
            if (userChoice == tossValue)
            {
                Console.WriteLine("User will go first");
            }
            else
            {
                Console.WriteLine("Computer will go first");
            }
        }
        public static void StartGame()
        {
            if (toss == userFirstMove)
            {
                UserMakeMove();
            }
            else
            {
                ComputerMakeMove();
            }
        }
        public bool IndexIfAvailable(int index)
        {
            //return true if block is empty
            if (board[index] == ' ')
                return true;
            //return false if block is occupied
            return false;
        }
        public static bool Winner()
        {
            //Winning condition for first row 
            if (board[1] == board[2] && board[2] == board[3] && board[3]!= 0)
            {
                if (board[1] == player)
                    return true;
            }
            // Winning condition for second row
            if (board[4] == board[5] && board[5] == board[6] && board[6] != 0)
            {
                return true;
            }
            //Winning condition for third row
            if (board[7] == board[8] && board[8] == board[9] && board[9] != 0)
            {
                return true;
            }
            // Winning condition for first column
            if (board[1] == board[4] && board[4] == board[7] && board[7] != 0)
            {
                return true;
            }
            // Winning condition for second column
            if (board[2] == board[5] && board[5] == board[8] && board[8] != 0)
            {
                return true;
            }
            // Winning condition for third column
            if (board[3] == board[6] && board[6] == board[9] && board[9] != 0)
            {
                return true;
            }
            // Winning condition for first diagonal
            if (board[1] == board[5] && board[5] == board[9] && board[9] != 0)
            {
                return true;
            }
            // Winning condition for second diagonal
            if (board[3] == board[5] && board[5] == board[7] && board[7] != 0)
            {
                return true;
            }
            else
                return false;
        }

        public static int GetComputerMove(int checkIfWin)
        {
            Random random = new Random();
            for (int block = 1; block < 10; block++)
            {
                if (board[block] != 'X' && board[block] != 'O')
                {
                    board[block] = (checkIfWin == 1) ? computer : player;
                    if (Winner())
                    {
                        board[block] = ' ';
                        return block;
                    }
                    board[block] = ' ';
                    checkIfWin++;
                }
            }
            if (checkIfWin <= 2)
                return GetComputerMove(checkIfWin);
            for (int index = 0; index < 4; index++)
            {
                if (board[corner[index]] == ' ')
                    return corner[index];
            }
            return 0;
        }
    }
}
