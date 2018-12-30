This is a clone of the original SuperMario game with some new game design decisions.

Notable differences:
 fire projectiles shoot flowers as Mario is peaceful. Mario can only shoot three at a time, with a short delay in between them.
 They also despawn when they hit an enemy or wall or after 3 seconds. Mario does not slide down the flagpole, he crouches on it, he's tired.

GAME Design Decisions: Score has been refactored into a singleton the idea being to encourage the player to cooperate with other players
in multiplayer instead of competing against one another. All players add to a centralized score system called the score keeper. Also a
centralized life system has been implemented so that all players share lives and thus further need to work together in order to win.

We have given our game a winter theme. We also have multiplayer with seperate viewports. The game ends when the centralized lives runs 
out and both players die.  

Controls: Mario (on the left) is controlled by WASD with X for ability and Luigi (on the right) is controlled by the arrow keys with 
the right alt key to use the ability
