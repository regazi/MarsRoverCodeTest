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
        //Check X Boundary
        public bool AtEdgeOfGridX(int[] boundary)
        {
          if(X == boundary[0] || X == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Check Y Boundary
        public bool AtEdgeOfGridY(int[] boundary)
        {
            if (Y == boundary[1] || Y == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //Logic to determin what direction to turn when encountering boundary 
        public void CheckBoundariesThenMove(int[] boundary)
        {
            if(Direction == 'N' && AtEdgeOfGridY(boundary) == true)
            {
                if (X > boundary[0]/2)
                {
                    TurnLeft();
                    Advance();
                }
                else
                {
                    TurnRight();
                    Advance();
                }
            }
            else if (Direction == 'S' && AtEdgeOfGridY(boundary) == true)
            {

                if (X > boundary[0] / 2)
                {
                    TurnRight();
                    Advance();
                }
                else
                {
                    TurnLeft();
                    Advance();
                }
            }
            else if (Direction == 'E' && AtEdgeOfGridX(boundary) == true)
            {
                if (Y > boundary[1] / 2)
                {
                    TurnLeft();
                    Advance();
                }
                else
                {
                    TurnRight();
                    Advance();
                }
            }else if (Direction == 'W' && AtEdgeOfGridX(boundary) == true)
            {
                if (Y > boundary[1] / 2)
                {
                    TurnRight();
                    Advance();
                }
                else
                {
                    TurnLeft();
                    Advance();
                }
            }
            else
            {
                Advance();
            }
        }

        /*
        public void ObsticalInPath(int[] obstical)
        {
            if ()
        }
        */
        public void Move(string commandsInput, int[] boundary) 
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
                   CheckBoundariesThenMove(boundary);
                }
                else
                {
                    throw new ArgumentException();
                }
            }

        }
    }
}
