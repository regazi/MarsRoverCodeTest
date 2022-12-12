# MarsRoverCodeTest
Task:
Write an application that takes the test input (instructions from NASA) and provides the expected output
(the feedback from the rovers to NASA). Each rover will move in series, i.e. the next rover will not start moving until
the one preceding it finishes.

Assumptions: 
1) The Rovers do not occupy space larger than a single grid coordinate.
2) Rovers can only move 1 gridpoint per move and only in oriented direction 
3) Rovers can not occupy same grid coordinate
4) If directed to go out-of-bounds, Rovers will turn in the direction with the most room and execute move in that direction
5) If rover's next move is blocked by other rover, it will safely (see above) pass around it before executing move. 

Commands: L (turn left 90*), R (turn right 90*), M (move forward one grid point)

TEST INPUT
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM

EXPECTED OUTPUT

1 3 N
5 1 E
