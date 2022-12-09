// Assumptions: The Rovers do not occupy space larger than a single grid coordinate.
//             Rovers can only move 1 gridpoint per move and only in oriented direction 
//             Rovers can not occupy same grid coordinate
//             If directed to go out-of-bounds, Rovers will turn in the direction with the most room and execute move in that direction

// Objects:    Rover
//             Grid
//             
// Inputs:     1) Grid size------------------------[5 5]
//             2) Rover1 postion and orientation---[1 2 N]
//             3) Commands for Rover1--------------[LMLMLMLMM]
//             4) Rover2 position and orientation--[3 3 E]
//             5) Comamnds for Rover2--------------[MMRMMRMRRM]


using System.ComponentModel.Design;

namespace MarsRoverCodeTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            /*
            List<string> input = (List<string>) File.ReadLines("input.txt")
            if (input.Length < 5) {
                throw Exception();
            }
             var boundaries = input[0]
             var position_one = input[1]
             var commands_one = input[2]
             var position_two = input[3]
             var commands_two = input[4]

             var grid = new Grid(boundaries[0])
             var roverOne = new Rover(positionOne)
             var roverTwo = new Rover(positionTwo)
             
            roverOne.Move(commands_one, grid, roverTwo)
            roverTwo.Move(commands_two, grid, roverOne)
            Console.WriteLine(roverOne.X, roverOne.Y, roverOne.Direction);
            Console.WriteLine(roverTwo.X, roverTwo.Y, roverTwo.Direction);
            . . .

            
            */

        }

    }
}







