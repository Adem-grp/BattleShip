About The Game
This game is an online implementation of a battleship game. The battleship game is a war-themed board game. The game is played online by two players and the goal of the game is to locate and sink the opponent’s fleet with a minimum number of shots or at least before the opponent. 
First, each player places his or her fleet of ten ships in their 10x10 grid of squares. Each ship has different sizes and the players can place their ships horizontally or vertically across the below given number of squares. Players cannot see the location of their opponent’s ships. 
After setting up their ships on the grid, the players try to guess the location of their opponent’s warships and sink all ships of his or her opponent by shooting the opponent’s grid in turns. The players continue to take turns selecting and shooting the squares occupied by the ships until one player completely destroys the other’s fleet.  
When the player shoots the opponent’s ship, that is if it is a hit, the square shot turns red. If the player misses the ship, then the square shot at turns navy blue. The first player who sinks all ten of the opponent's ships wins the game. 
As stated above, each player has a fleet of ten (10) ships, the number and the type of these ships, and their sizes are as below:

1 battleship, which fills 4 squares on the grid 
2 cruisers, which fill 3 squares on the grid 
3 destroyers, which fill 2 squares on the grid 
4 submarines, which fill 1 square on the grid 



Classes 

ShipRelated: ShipRelated class is used to store the grids of the players and stores the placed ships count.

Cell: Cell class keeps  occupation status(empty or a ship is placed) of the placing positions in the grid.

Player: This class makes the connection between players. One of the players acts like a host and other acts like a client. TCP/IP protocole is used to provide the comminication between the players.


Windows Forms 

StartPage: This page enables players to connect to an opponent and start the game 
PlacingShipsPage: This page enables players to place their ships 
PlacingErrorPage: This is an error pahe which pops up when two ships collide with each other during placing process.
ShootingPage: This page allows players to shoot each others ships  
AlreadyHitErrorPage: This is an error which pops up if a player shoots the same place more than once 
YouWonPage: This page appears if the player wins the game 
YouLostPage: This page appears if the player loses the game 