using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace MarsRoverCodeTest
{
    public class Rover
    {   //Rover properties
        public int X { get; set; }
        public int Y { get; set; }
        public char Direction { get; set; }
        public Rover(string[] position)
        {
            X = Int32.Parse(position[0]);
            Y = Int32.Parse(position[1]);
            Direction = position[2].ToCharArray()[0];
        }
        public void TurnLeft()
        {
            switch(Direction){
                case 'N':
                    Direction = 'W';
                    break;
                case 'W':
                    Direction = 'S';
                    break;
                case 'S':
                    Direction = 'E';
                    break;
                case 'E':
                    Direction = 'N';
                    break;
                default:
                    throw new ArgumentException();
            }
        }
        public void TurnRight()
        {
            switch (Direction)
            {
                case 'N':
                    Direction = 'E';
                    break;
                case 'E':
                    Direction = 'S';
                    break;
                case 'S':
                    Direction = 'W';
                    break;
                case 'W':
                    Direction = 'N';
                    break;
                default:
                    throw new ArgumentException();
            }
        }
        public void MoveForward()
        {
            switch (Direction)
            {
                case 'N':
                    Y++;
                    break;
                case 'E':
                    X++;
                    break;
                case 'S':
                    Y--;
                    break;
                case 'W':
                    X--;
                    break;
                default:
                    throw new ArgumentException();
            }
        }

        public void AdvanceSafely(Grid grid)
        {
            if(Direction == 'N' && IsInBounds(grid))
            {
                MoveForward();
            }
            else if (Direction == 'E' && IsInBounds(grid))
            {
                MoveForward();
            }
            else if (Direction == 'S' && IsInBounds(grid))
            {
                MoveForward();
            }
            else if (Direction == 'W' && IsInBounds(grid))
            {
                MoveForward();
            }

        }

        //Here I am changing the smarth pathing the return false after navigating around an obstruction
        //before, the "M" would execute after the smart pathing already advance passed the obstruction, adding an extra move
        //now it just "break"s
        public bool WillNotCollide(Grid grid, Rover rover)
        {
            if(Direction == 'N' && X == rover.X && Y + 1 == rover.Y)
            {
              
                TurnRight();
                AdvanceSafely(grid);
                TurnLeft();
                AdvanceSafely(grid);
                AdvanceSafely(grid);
                TurnLeft();
                AdvanceSafely(grid);
                TurnRight();
              
                return false;

            }
            else if (Direction == 'E' && Y == rover.Y && X + 1 == rover.Y)
            {
               
                TurnLeft();
                AdvanceSafely(grid);
                TurnRight();
                AdvanceSafely(grid);
                AdvanceSafely(grid);
                TurnRight();
                AdvanceSafely(grid);
                TurnLeft();
                
                return false;

            }
            else if (Direction == 'S' && X == rover.X && Y - 1 == rover.Y )
            {
               
                TurnRight();
                AdvanceSafely(grid);
                TurnLeft();
                AdvanceSafely(grid);
                AdvanceSafely(grid);
                TurnLeft();
                AdvanceSafely(grid);
                TurnRight();
               
                return false;

            }
            else if (Direction == 'W' && Y == rover.Y && X - 1 == rover.Y)
            {
               
                TurnLeft();
                AdvanceSafely(grid);
                TurnRight();
                AdvanceSafely(grid);
                AdvanceSafely(grid);
                TurnRight();
                AdvanceSafely(grid);
                TurnLeft();
            
                return false;

            }
            else
            {
                return true;
            }
        }  
        private bool IsInBounds(Grid grid)
        {
            if (Direction == 'N')
            {
                if(Y == grid.Y )
                {
                    if(X> grid.X / 2)
                    {
                        TurnLeft();
                        return true;
                    }
                    else
                    {
                        TurnRight();
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else if (Direction == 'E')
            {
                if (X  == grid.X )
                {
                    if (Y < grid.Y / 2)
                    {
                        TurnLeft();
                        return true;
                    }
                    else
                    {
                        TurnRight();
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else if (Direction == 'S')
            {
                if (Y  == 0 )
                {
                    if (X < grid.X / 2)
                    {
                        TurnLeft();
                        return true;
                    }
                    else
                    {
                        TurnRight();
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else if (Direction == 'W')
            {
                if (X  == 0 )
                {
                    if (Y > grid.Y / 2)
                    {
                        TurnLeft();
                        return true;
                    }
                    else
                    {
                        TurnRight();
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }
            else
            {
                throw new ArgumentException();
            }


        }

        public void Move(string commandsInput, Grid grid, Rover rover) 
        {
            //take command input and cast to array
            char[] commands = commandsInput.ToCharArray();
            //loop through array and execute commands
            foreach (char c in commands)
            {
                if (c == 'L')
                {
                    TurnLeft();
                }
                else if (c == 'R')
                {
                    TurnRight();
                }
                else if (c == 'M')
                {
                    if ( WillNotCollide(grid, rover) == true)
                    {
                        AdvanceSafely(grid);
                    }
                    else
                    {
                        break;
                    }

                }
                else
                {
                    throw new ArgumentException();
                }
            }

        }
    }
}
