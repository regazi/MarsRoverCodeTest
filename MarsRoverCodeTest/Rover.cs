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
        public void Advance()
        {
            switch (Direction)
            {
                case 'N':
                    Y ++;
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
        //EDGE CASE---- Rovers should not be able to pass through oneanother, "WillNotCollide" shoudl handle that by passing on the right side
        //      // EDGE CASE---- this creates another edge case if one rover is at edge of grid. 
        //Currently Not working. Will fix either after food, or tomorrow morning
        public bool WillNotCollide(Grid grid, Rover rover)
        {
            if(Direction == 'N' && Y + 1 == rover.Y)
            {
                TurnRight();
                Advance();
                TurnLeft();
                Advance();
                TurnLeft();
                Advance();
                TurnRight();
                return true;

            }
            else if (Direction == 'E' && X + 1 == rover.Y)
            {
                TurnLeft();
                Advance();
                TurnRight();
                Advance();
                TurnRight();
                Advance();
                TurnLeft();
                return true;

            }
            else if (Direction == 'S' && Y - 1 == rover.Y)
            {
                TurnRight();
                Advance();
                TurnLeft();
                Advance();
                TurnLeft();
                Advance();
                TurnRight();
                return true;

            }
            else if (Direction == 'W' && X - 1 == rover.Y)
            {
                TurnLeft();
                Advance();
                TurnRight();
                Advance();
                TurnRight();
                Advance();
                TurnLeft();
                return true;

            }
            else
            {
                return true;
            }
        }  
        private bool IsInBounds(Grid grid, Rover rover)
        {
            if (Direction == 'N')
            {
                if(Y == grid.Y)
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
                if (X  == grid.X)
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
                if (Y  == 0)
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
                if (X  == 0)
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
                if (IsInBounds(grid, rover))
                    {
                        Advance();
                    }
                    else
                    {
                        throw new ArgumentException();
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
