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
        // When next move will cause collision, bypass obstical and contunue course.


        [Fact]
        public void TurnLeft()
        {
            //rover will turn left

            string input = "1 2 N";
            string[] startingPosition = input.Split(' ');
            Rover rover = new Rover(startingPosition);
            //act
            rover.TurnLeft();
            //assert
            Assert.True(rover.Direction == 'W');

        }

        [Fact]
        public void TurnRight()
        {
            //rover will turn right

            string input = "1 2 N";
            string[] startingPosition = input.Split(' ');
            Rover rover = new Rover(startingPosition);
            //actions
            rover.TurnRight();
            //assertion
            Assert.True(rover.Direction == 'E');

        }
        [Fact]
        public void MoveForward()
        {
            //rover will move forward

            string input = "1 4 N";
            string[] startingPosition = input.Split(' ');
            Rover rover = new Rover(startingPosition);
            //actions
            rover.MoveForward();
            //assertion
            Assert.True(rover.Y == 5);

        }

        [Fact]
        public void AdvanceSafely()
        {
            //rover will not fall off edge of plane

            int[] boundary = new int[2] { 5, 5 };
            Grid grid = new Grid(boundary);
            string input = "1 5 N";
            string[] startingPosition = input.Split(' ');
            Rover rover = new Rover(startingPosition);
            //actions
            rover.AdvanceSafely(grid);
            //assertion
            Assert.True(rover.Y == 5);

        }
        

        [Fact]
        public void Move()
        {
            //USES TEST DATA PROVIDED IN PROJECT BRIEF

            //Rovers will navigate plane 

            int[] boundary = new int[2] { 5, 5 };
            Grid grid = new Grid(boundary);
            string input1 = "1 2 N";
            string input2 = "3 3 E";
            string[] startingPosition1 = input1.Split(' ');
            string[] startingPosition2 = input2.Split(' ');
            Rover rover1 = new Rover(startingPosition1);
            Rover rover2 = new Rover(startingPosition2);
            string commands1 = "LMLMLMLMM";
            string commands2 = "MMRMMRMRRM";
            //acttions
            rover1.Move(commands1, grid, rover2);
            rover2.Move(commands2, grid, rover1);
            //assertion
            Assert.True(rover1.X == 1 && rover1.Y == 3 && rover1.Direction == 'N' && rover2.X == 5 && rover2.Y == 1 && rover2.Direction == 'E');

        }
        [Fact]
        public void AvertCollisionsAndBoundaries()
        {
            //rover1 will move North from (3,0), steering around rover two (3,3) and executing final move from the next available space (3,4) on the Y axis, ending in (3,5)
            //rover2 will move East from (3,3), turning south (most available space) after encountering the border and landing on (5,2) 

            int[] boundary = new int[2] { 5, 5 };
            Grid grid = new Grid(boundary);
            string input1 = "3 0 N";
            string input2 = "3 3 E";

            string[] startingPosition1 = input1.Split(' ');
            string[] startingPosition2 = input2.Split(' ');

            Rover rover1 = new Rover(startingPosition1);
            Rover rover2 = new Rover(startingPosition2);
            string commands1 = "MMM"; // passes around stationary rover2
            string commands2 = "MMM"; // encounters boundary and turns south as there is the most available space there
            //actions
            rover1.Move(commands1, grid, rover2);
            rover2.Move(commands2, grid, rover1);
            //assertion
            Assert.True(rover1.X == 3 && rover1.Y == 4 && rover1.Direction == 'N' && rover2.X == 5 && rover2.Y == 2 && rover2.Direction == 'S');
        }
    }
   
}