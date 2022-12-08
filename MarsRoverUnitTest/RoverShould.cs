using MarsRoverCodeTest;
namespace MarsRoverUnitTest   
{
    public class RoverShould
    {


        //Expected Behaviors
        // Rover Should move forward
        // Rover Should rotate left
        // Rover should rotate right
        // Rover should traverse around obsticals(other rover)
        // Rover should turn to direction with greatest available space when encountering boundaries


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
            string input = "0 0 N";
            string[] startingPosition = input.Split(' ');
            string commands = "MM";
            int[] boundary = new int[2] { 2, 2 };
            //arange
            Rover rover = new Rover(startingPosition);
            //act
            rover.Move(commands, boundary);
            //assert
            Assert.True(rover.X == 0 && rover.Y == 2 && rover.Direction=='N');

        }
    }
}