'Stash' 

————
i.
————
Created by:
Scott Beale, sbeale3@gatech.edu, sbeale3 - most of the code, audio editing, variable adjustment
Olivia LaHay, olahay3@gatech.edu, olahay3 - menus, additional coding, npc models
Jeffrey Hsu, jhsu44@gatech.edu, jhsu44 - presentation, testing, npc models
Stephanie Dykes, - level set up and design, asset acquisition, 

————
ii.
————
Features

'It must be a 3D game'
----------------------
Select "start" in the start menu to begin playing.
Steal 20 pieces of loot and then escape the store to win the game. A checkout sound will play.
Gain too much suspicion and the guard will chase you. If he catches you, you are knocked over and lose. 
Win or lose, you are taken to the start menu for an attempt to try again.

'Precursors to Fun Gameplay'
----------------------------
Your loot and suspicion status are displayed in bars on the right of the UI.
Loot you can steal is highlighted and auditory feedback is given when you steal.
If you are caught stealing, you will hear the NPC who caught you announce that.
If you gain too much attention and the guard chases you, he will repeatedly call as he pursues. 
If you steal enough loot to fill up the bar, a sound effect will play, and you will be prompted to escape.
As you start to steal loot, your suspicion meter will increase over time, growing faster the more loot you have.
This means as you approach your goal, time becomes more and more valuable, and prevents you from cheesing the system.
Before stealing anything you can take time to be very careful, but care vs. speed quickly becomes a dilemma.
An additional dilemma is created by the fact that sprinting causes you to drop items. 
You have to chose between move speed, and holding on to your loot, which becomes especially crucial when being chased.
Feedback is given in the form of physically dropping representations of loot.
Randomly distributed items provides an additional metric to reward players for taking the time to plan their route through the store.
Closer enemies provide harsher penalties when catching the player stealing.
The sound of an approaching Guard in pursuit is one example of a threat of punishment, as well as the climbing suspicion bar.

Known issues:
If you escape the store while being chased without enough loot to win,
the guard can't get to you, but you have no way of succeeding. 

'Animated Character with RT Control'
------------------------------------
Player always has direct control during gameplay, with standard movement/interaction controls
Movement is controlled via root motion and uses a 2 dimensional blend tree to control forward/backward movement and strafing.
The player can run for a dynamic range of control.

Known issues:
Rapidly changing strafe direction results in animation stutter. 
You are unable to strafe while sprinting, which can feel constraining.
The camera can clip behind walls and obstacles.

'3D World/Spatial Simulation'
-----------------------------
HIGH TECH(tm) revolving door.
Clipping is rare.
Shopping carts can be pushed to roll around the level. 
NPCs will path around stationary objects.
Loot that is dropped becomes phsyics objects in the world.

Known issues:
Vertical jitter common when colliding with NPCs or physics objects. 
Shunting ontop of shelves once common but not observed recently.

'RT NPC Steering/AI'
--------------------
AI with states of idle, patrol, pursue, and suspicious.
Transition to suspicious state is communicated with a voice clip and the NPC turning to keep the player in sight.
The guard will repeatedly communicate while in the pursuit state with vocal clips, also giving the player an idea his location.
Movement is controlled via root motion and smoothly transitioned between.
NPCs will steer around physics obstacles, other NPCs, and the player.
Different NPCs have different behaviours, such as civilians being less observant or the manager continually checking isles.
Patrol routes placed to ensure that no areas of the map stay unobserved for too long, but there will always be areas out of sight.

Known issues:
The Guard will often overshoot the player during pursuit.
The Guard can not make it through the revolving doors.
Can be difficult to tell when in LOS of NPCs (inclusion UI indicator made game trivial).

'Polish'
--------
Assets including models and sounds chosen to match an exaggeratedly mundane aesthetic.
Ambient noise and music with roll off to evoke a sense of space. 
Consistent color scheme of red, white, tan, and grey.
NPCs steer around dynamic obstacles.
Large amount of auditory feedback given to the player.
Interactable loot is highlighted.
Footstep sound changes per surface.

Known issues:
Game can not be exited at any time.

————
iii. 
————
Assets:
Player created with Mixamo
Sounds
http://www.freesound.org/people/SunnySideSound/sounds/67093/
http://www.freesound.org/people/mlteenie/sounds/189653/
http://www.freesound.org/people/Zott820/sounds/209578/
http://www.freesound.org/people/kiddpark/sounds/201159/
http://www.freesound.org/people/LeMudCrab/sounds/163451/
http://www.freesound.org/people/Adam_N/sounds/166129/
http://www.freesound.org/people/davdud101/sounds/150505/
http://www.freesound.org/people/dauser/sounds/328842/
https://www.freesound.org/people/lwdickens/sounds/269411/
Royskopp - Remind Me

————
iv. 
————
Developed in windows.


————
v. 
————
Press start.
Walk into store. 
Observe patrol routes of NPCs and where loot (soda cans) are clustered.
Push a shopping cart. 
Stand in front of an NPC. 
Steal an item while in front of an NPC. 
Repeat until suspicion bar is full. 
Run from guard.
Let the guard catch you.
Repeat previous instructions, but do not steal while in line of sight of NPCs.
When loot bar is filled, walk out the door.

————
vi. Which scene file is the main file that should be opened first in Unity
————
StartScene.
