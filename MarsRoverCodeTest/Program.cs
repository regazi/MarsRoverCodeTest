// assumptions: The Rovers do not occupy space larger than a single grid coordinate.
//             Rovers can only move 1 gridpoint per move and only in oriented direction 
//             Rovers can not occupy same grid coordinate
//             If directed to go out-of-bounds, Rovers will turn in the direction with the most room and execute move in that direction

//objects:     Rover
//             Grid
//             Message
//             Inputs: 1) Grid sizw------------------------[5 5]
//                     2) Rover1 postion and orientation---[1 2 N]
//                     3) Commands for Rover1--------------[LMLMLMLMM] 
//                     4) Rover2 position and orientation--[3 3 E]
//                     5) Comamnds for Rover2--------------[MMRMMRMRRM]


using System.ComponentModel.Design;

namespace MarsRoverCodeTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            //test code bellow. this wil be redone. 
            Console.WriteLine("Starting Postion");
            string input = Console.ReadLine();
            string[] startingPosition = input.Split(' ');
            Console.WriteLine("enter grid size");
            string[] boundInput = Console.ReadLine().Split(' ');
            int[] boundary = new int [2];
            boundary[0] = Int32.Parse(boundInput[0]) / 10;
            boundary[1] = Int32.Parse(boundInput[1]) % 10;
            Console.WriteLine("enter commands");
            string commands = Console.ReadLine();

            Rover rover = new(startingPosition);
            rover.Move(commands, boundary);

            Console.WriteLine(rover.X);
            Console.WriteLine(rover.Y);
            Console.WriteLine(rover.Direction);



        }

    }
}
