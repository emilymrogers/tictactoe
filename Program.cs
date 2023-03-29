namespace TicTacToe
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //create 2D string
            string[,] board = new string[3, 3] { { "*", "*", "*" }, { "*", "*", "*" }, { "*", "*", "*" } };
            
            //call to play
            PlaceMarker(board);
            






        }//end main
            static void DispBoard(string[,] board) //creating the board
            {
                Console.Clear();
                Console.WriteLine("\tTic Tac Toe\n\n");
                Console.WriteLine("as presented by: \n\n");
                Console.WriteLine("         0         1        2    ");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("0       {0}   |   {1}   |   {2}   ", board[0, 0], board[0, 1], board[0, 2]);
                Console.WriteLine("---------------------------------");
                Console.WriteLine("1       {0}   |   {1}   |   {2}   ", board[1, 0], board[1, 1], board[1, 2]);
                Console.WriteLine("---------------------------------");
                Console.WriteLine("2       {0}   |   {1}   |   {2}    ", board[2, 0], board[2, 1], board[2, 2]);
                Console.WriteLine("---------------------------------");
                Console.WriteLine();
                Console.WriteLine();


        }
        static string[,] PlaceMarker(string[,] board) //creating player input
        {
            bool check = false;
            int playerTurn = 1;
            int x_coord;
            int y_coord;

            for (int i = 0; i < 9; i++)
            {
                DispBoard(board);

                Console.WriteLine("\nPlayer {0}, please enter a row number: ", playerTurn);
                x_coord = int.Parse(Console.ReadLine().ToUpper());
               
                //check for valid input
                if (x_coord < 0 || x_coord > 2)
                {
                    Console.WriteLine("Sorry, that is not an available location. Please select another.");
                    x_coord = int.Parse(Console.ReadLine().ToUpper());
                }
                Console.WriteLine("Now, enter the column number: ");
                y_coord = int.Parse(Console.ReadLine().ToUpper());
                
                //check for valid input
                if (y_coord < 0 || y_coord > 2)
                {
                    Console.WriteLine("Sorry, that is not an available location. Please select another.");
                    y_coord = int.Parse(Console.ReadLine().ToUpper());
                }

                //check for previous markings
                if (board[x_coord, y_coord] != "*")
                {
                    Console.WriteLine("You can't steal positions, bub!");
                    Console.WriteLine("Now let's try again, all nice like.");
                    
                    Console.Write("Row Number: ");
                    x_coord = int.Parse(Console.ReadLine());
                    //validate input
                    if (x_coord < 0 || x_coord > 2)
                    {
                        Console.WriteLine("Sorry, that is not an available location. Please select another.");
                        x_coord = int.Parse(Console.ReadLine().ToUpper());
                    }
                    
                    Console.Write("Column Number: ");
                    y_coord = int.Parse(Console.ReadLine());
                    //validate input
                    if (y_coord < 0 || y_coord > 2)
                    {
                        Console.WriteLine("Sorry, that is not an available location. Please select another.");
                        y_coord = int.Parse(Console.ReadLine().ToUpper());
                    }
                }

                //swap player turns
                if (playerTurn == 1)
                {
                    board[x_coord, y_coord] = "X";
                    playerTurn = 2;
                }
                else if (playerTurn == 2)
                {
                    board[x_coord, y_coord] = "O";
                    playerTurn = 1;
                }



                check = CheckWin(board);
                if (check)
                {
                    break;
                }
                
            }

            if (!check)
            {
                Console.WriteLine("Sorry, it's a tie!");
            }
            
            return board;
            
        }

        static bool CheckWin(string[,] board)
        {
            //check horizontal
            if (board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2] && board[0, 0] != "*")
            {
                Console.WriteLine(board[0, 0] + " wins!");
                Console.ReadKey();
                return true;

            }
            else if (board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2] && board[1, 0] != "*")
            {
                Console.WriteLine(board[1, 0] + " wins!");
                return true;
            }
            else if (board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2] && board[2, 0] != "*")
            {
                Console.WriteLine(board[2, 0] + " wins!");
                return true;
            }
            
            //check vertical
            else if (board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0] && board[0, 0] != "*")
            {
                Console.WriteLine(board[0, 0] + " wins!");
                return true;
            }
            else if (board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1] && board[0, 1] != "*")
            {
                Console.WriteLine(board[0, 1] + " wins!");
                return true;
            }
            else if (board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2] && board[0, 2] != "*")
            {
                Console.WriteLine(board[0, 2] + " wins!");
                return true;
            }
            
            //check diagonal
            else if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2] && board[0, 0] != "*")
            {
                Console.WriteLine(board[0, 0] + " wins!");
                return true;
            }
            else if (board[0, 2] == board[1, 1] && board[0, 1] == board[2, 0] && board[0, 2] != "*")
            {
                Console.WriteLine(board[0, 2] + " wins!");
                return true;
            }



            return false;


        }//end WinCheck
    }//end class
}//end namespace