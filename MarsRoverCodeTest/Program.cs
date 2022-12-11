// Assumptions: 1) The Rovers do not occupy space larger than a single grid coordinate.
//              2) Rovers can only move 1 gridpoint per move and only in oriented direction 
//              3) Rovers can not occupy same grid coordinate
//              4) If directed to go out-of-bounds, Rovers will turn in the direction with the most room and execute move in that direction
//              5) If rover's next move is blocked by other rover, it will safely (see above) pass around it before executing move. 

// Objects:    Rover
//             Grid
//             
// Sample Inputs:   1) Grid size------------------------[5 5]
//                  2) Rover1 postion and orientation---[1 2 N]
//                  3) Commands for Rover1--------------[LMLMLMLMM]
//                  4) Rover2 position and orientation--[3 3 E]
//                  5) Comamnds for Rover2--------------[MMRMMRMRRM]


using System.ComponentModel.Design;
using System.Text;

namespace MarsRoverCodeTest
{
    public class Program
    {
        static void Main(string[] args)
        {

            string[] input = File.ReadLines("C:\\Users\\Partakers\\source\\repos\\MarsRoverCodeTest\\MarsRoverCodeTest\\input.txt").ToArray();
            
            if (input.Length<5) {
                throw new Exception();
            }
           
            var stringBoundaries = input[0].Split(' ');
            var position_one = input[1];
            var commands_one = input[2];
            var position_two = input[3];
            var commands_two = input[4];

            int[] boundaries = new Int32[2] {Int32.Parse(stringBoundaries[0]), Int32.Parse(stringBoundaries[0]) };

            var grid = new Grid(boundaries);
            var roverOne = new Rover(position_one.Split(' '));
            var roverTwo = new Rover(position_two.Split(' '));

            roverOne.Move(commands_one, grid, roverTwo);
            roverTwo.Move(commands_two, grid, roverOne);
            Console.WriteLine(roverOne.X + " " +  roverOne.Y + " " +  roverOne.Direction);
            Console.WriteLine(roverTwo.X + " " + roverTwo.Y + " " +  roverTwo.Direction);

           

        }

    }
}







