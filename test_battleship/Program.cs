using System;
using System.Collections.Generic;

public class Board
{
    public string[,] gameBoard = new string[10, 10]
    {
      {"e", "e", "e", "e", "e", "e", "e", "e" ,"e", "e"},
      {"e", "e", "e", "e", "e", "e", "e", "e" ,"e", "e"},
      {"e", "e", "e", "e", "e", "e", "e", "e" ,"e", "e"},
      {"e", "e", "e", "e", "e", "e", "e", "e" ,"e", "e"},
      {"e", "e", "e", "e", "e", "e", "e", "e" ,"e", "e"},
      {"e", "e", "e", "e", "e", "e", "e", "e" ,"e", "e"},
      {"e", "e", "e", "e", "e", "e", "e", "e" ,"e", "e"},
      {"e", "e", "e", "e", "e", "e", "e", "e" ,"e", "e"},
      {"e", "e", "e", "e", "e", "e", "e", "e" ,"e", "e"},
      {"e", "e", "e", "e", "e", "e", "e", "e" ,"e", "e"},
    };

    public void printBoard()
    {
        for (int i = 0; i < gameBoard.GetLength(0); i++)
        {
            for (int j = 0; j < gameBoard.GetLength(1); j++)
            {
                Console.Write("{0} ", gameBoard[i, j]);
            }
            Console.WriteLine();
        }
    }

    public bool tryPlaceShip(Ship ship, int start, int place, int direction)
    {
        bool test = true;
        for (int i = 0; i < gameBoard.GetLength(0); i++)
        {
            for (int j = 0; j < gameBoard.GetLength(1); j++)
            {
                if (direction == 0)
                {
                    if (i >= start && i < start + ship.lives && j == place)
                    {
                        if (gameBoard[i, j] != "e")
                        {
                            test = false;
                        }
                    }            
                }
                if (direction == 1)
                {
                    if (j >= start && j < start + ship.lives && i == place)
                    {
                        if (gameBoard[i, j] != "e")
                        {
                            test = false;
                        }
                    }
                }

            }
        }
        return test;
    }
    public void placeShip(Ship ship, int start, int place, int direction)
    {
        for (int i = 0; i < gameBoard.GetLength(0); i++)
        {
            for (int j = 0; j < gameBoard.GetLength(1); j++)
            {
                if (direction == 0)
                {
                    if (i >= start && i < start + ship.lives && j == place)
                    {
                        if (gameBoard[i, j] == "e")
                        {
                            gameBoard[i, j] = ship.symbol;
                        }
                    }
                }
                if (direction == 1)
                {
                    if (j >= start && j < start + ship.lives && i == place)
                    {
                        if (gameBoard[i, j] == "e")
                        {
                            gameBoard[i, j] = ship.symbol;
                        }
                    }
                }

            }
        }
    }
}

public class Ship
{
    public String name;
    public string symbol;
    public int lives;
    public bool isDestroyed = false;

    public Ship(String name, String symbol, int lives)
    {
        this.name = name;
        this.symbol = symbol;
        this.lives = lives;
    }

    public void setState()
    {
        isDestroyed = !isDestroyed;
    }
    public bool checkState()
    {
        return isDestroyed;
    }

    public void hit()
    {
        if (!checkState())
        {
            lives--;
            Console.WriteLine(name + " hit! Remaning lives:" + lives);
            if (lives == 0)
            {
                Console.WriteLine(name + " sunk!");
                setState();
            }
        }
    }
}
public class Game 
{ 
    public bool checkShips(Ship c1, Ship b1, Ship d1, Ship s1, Ship p1)
    {
        if(c1.isDestroyed && b1.isDestroyed && d1.isDestroyed && s1.isDestroyed && p1.isDestroyed)
        {
            return false;
        }
        return true;
    }
}

class Program
{
    public static void Main(string[] args)
    {
        Random random = new Random();
        Game game = new();
        List<Ship> playerOneShips = new List<Ship> {
            new("Carrier", "c", 5),
            new("Battleship", "b", 4),
            new("Destroyer", "d", 3),
            new("Submarine", "s", 3),
            new("Patrol Boat", "p", 2),
        };

        Ship c2 = new("Carrier", "c", 5);
        Ship b2 = new("Battleship", "b", 4);
        Ship d2 = new("Destroyer", "d", 3);
        Ship s2 = new("Submarine", "s", 3);
        Ship p2 = new("Patrol Boat", "p", 2);
        Board board = new();
        Board board2 = new();
        int time = 0;
        List<int> listNumbers = new List<int>();
        int number;
        for (int i = 0; i < 6; i++)
        {
            do
            {
                number = random.Next(10);
            } while (listNumbers.Contains(number));
            listNumbers.Add(number);
        }
        int index = 0;
        foreach(var ship in playerOneShips)
        {
            do
            {
                number = random.Next(2);
            } while (!board.tryPlaceShip(ship, 1, listNumbers[index], number));
            board.placeShip(ship, 1, listNumbers[index], number);
            index++;
        }

        listNumbers.Clear();
        for (int i = 0; i < 6; i++)
        {
            do
            {
                number = random.Next(10);
            } while (listNumbers.Contains(number));
            listNumbers.Add(number);
        }
        do
        {
            number = random.Next(2);
        } while (!board2.tryPlaceShip(c2, 1, listNumbers[0], number));
        board2.placeShip(c2, 1, listNumbers[0], number);
        do
        {
            number = random.Next(2);
        } while (!board2.tryPlaceShip(b2, 1, listNumbers[1], number));
        board2.placeShip(b2, 1, listNumbers[1], number);
        do
        {
            number = random.Next(2);
        } while (!board2.tryPlaceShip(d2, 1, listNumbers[2], number));
        board2.placeShip(d2, 1, listNumbers[2], number);
        do
        {
            number = random.Next(2);
        } while (!board2.tryPlaceShip(s2, 1, listNumbers[3], number));
        board2.placeShip(s2, 1, listNumbers[3], number);
        do
        {
            number = random.Next(2);
        } while (!board2.tryPlaceShip(p2, 1, listNumbers[4], number));
        board2.placeShip(p2, 1, listNumbers[4], number);

        Console.Clear();
        board.printBoard();
        Console.WriteLine("time: " + time);
        board2.printBoard();

        do
        {

            Console.Clear();
            board.printBoard();
            Console.WriteLine("time: " + time);
            board2.printBoard();

            int col = random.Next(10);
            int rows = random.Next(10);
            do
            {
                col = random.Next(10);
                rows = random.Next(10);
            } while (board.gameBoard[col, rows] == "m" || board.gameBoard[col, rows] == "t");

            foreach (var ship in playerOneShips)
            {
                if (board.gameBoard[col, rows] == ship.symbol)
                {
                    ship.hit();
                    board.gameBoard[col, rows] = "t";
                }
            }
            if (board.gameBoard[col, rows] == "t")
            {
                board.gameBoard[col, rows] = "t";
            }
            else
            {
                board.gameBoard[col, rows] = "m";
            }


            System.Threading.Thread.Sleep(100);
            time++;

            int col2 = random.Next(10);
            int rows2 = random.Next(10);
            do
            {
                col2 = random.Next(10);
                rows2 = random.Next(10);
            } while (board2.gameBoard[col2, rows2] == "m" || board2.gameBoard[col2, rows2] == "t");
            if (board2.gameBoard[col2, rows2] == "c")
            {
                c2.hit();
                board2.gameBoard[col2, rows2] = "t";
            }
            if (board2.gameBoard[col2, rows2] == "b")
            {
                b2.hit();
                board2.gameBoard[col2, rows2] = "t";
            }
            if (board2.gameBoard[col2, rows2] == "d")
            {
                d2.hit();
                board2.gameBoard[col2, rows2] = "t";
            }
            if (board2.gameBoard[col2, rows2] == "s")
            {
                s2.hit();
                board2.gameBoard[col2, rows2] = "t";
            }
            if (board2.gameBoard[col2, rows2] == "p")
            {
                p2.hit();
                board2.gameBoard[col2, rows2] = "t";
            }
            if (board2.gameBoard[col2, rows2] == "t")
            {
                board2.gameBoard[col2, rows2] = "t";
            }
            else
            {
                board2.gameBoard[col2, rows2] = "m";
            }
            System.Threading.Thread.Sleep(100);
            time++;
            if (!game.checkShips(playerOneShips[0], playerOneShips[1], playerOneShips[2], playerOneShips[3], playerOneShips[4]))
            {
                Console.WriteLine("Player 2 Won!");
            }
            if (!game.checkShips(c2, b2, d2, s2, p2))
            {
                Console.WriteLine("Player 1 Won!");
            }
        } while (game.checkShips(playerOneShips[0], playerOneShips[1], playerOneShips[2], playerOneShips[3], playerOneShips[4]) && game.checkShips(c2, b2, d2, s2, p2));
    }
}
        