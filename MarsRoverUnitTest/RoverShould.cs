using MarsRoverCodeTest;
namespace MarsRoverUnitTest   
{
    public class RoverShould
    {


        //Expected Behaviors
        // Rovers Should move forward
        // Rovers Should turn left
        // Rovers should turn right
        // When encountering boundaries, Rovers should turn to direction with greatest available space


        [Fact]
        public void TurnLeft()
        {
            string input = "1 2 N";
            string[] startingPosition = input.Split(' ');
            //arange
            Rover rover = new Rover(startingPosition);
            //act
            rover.TurnLeft();
            //assert
            Assert.True(rover.Direction == 'W');

        }

        [Fact]
        public void TurnRight()
        {
            string input = "1 2 N";
            string[] startingPosition = input.Split(' ');
            //arange
            Rover rover = new Rover(startingPosition);
            //act
            rover.TurnRight();
            //assert
            Assert.True(rover.Direction == 'E');

        }
       
        [Fact]
        public void Advance()
        {
            string input = "1 2 N";
            string[] startingPosition = input.Split(' ');
            //arange
            Rover rover = new Rover(startingPosition);
            //act
            rover.Advance();
            //assert
            Assert.True(rover.Y == 3);

        }

        [Fact]
        public void Move()
        {
            int[] boundary = new int[2] { 5, 5 };
            Grid grid = new Grid(boundary);
            string input1 = "1 2 N";
            string input2 = "3 3 E";

            string[] startingPosition1 = input1.Split(' ');
            string[] startingPosition2 = input2.Split(' ');
            
            //arange
            
            Rover rover1 = new Rover(startingPosition1);
            Rover rover2 = new Rover(startingPosition2);
            string commands1 = "LMLMLMLMM";
            string commands2 = "MMRMMRMRRM";
            //act
            rover1.Move(commands1, grid, rover2);
            rover2.Move(commands2, grid, rover1);
            //assert
            Assert.True(rover1.X == 1 && rover1.Y == 3 && rover1.Direction == 'N' && rover2.X == 5 && rover2.Y == 1 && rover2.Direction == 'E');

        }
    }
}