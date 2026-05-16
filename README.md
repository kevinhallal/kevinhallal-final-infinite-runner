Kevin Hallal
20234796

# Metro Mashalla

Metro Mashalla is an infinite runner game inspired by Subway Surfers but with an Arab-inspired aesthetic and gameplay style. The player runs endlessly through streamed chunks while avoiding obstacles, collecting coins, and using powerups to survive longer and beat their high score.



---

# Features

## Infinite Runner Gameplay
- Endless streamed level generation
- Smooth lane switching
- Jumping system
- Ability to run on top of obstacles/trains
- Three powerups including magnet , speedboost, invincibilty with timers!
- Increasing game speed over time
- Collision and game over system

---

# Procedural Chunk System
The level is built using reusable chunk prefabs that are streamed ahead of the player and recycled behind the camera.

The project uses:
- procedural chunk spawning
- lane connection logic
- object pooling for optimization

This allows the game to run continuously without loading screens while keeping performance stable.

---

# Player Systems
The player controller includes:
- smooth lane movement
- jumping and gravity
- collision handling
- obstacle interaction
- safe landing on top of larger obstacles

---

# Score and Progression
The game tracks:
- current score
- high score
- coins collected during the run
- total saved coins

The high score is saved permanently using PlayerPrefs.

A special animated popup appears when beating the previous high score.

---

# Coin System
Coins spawn throughout the level and can be collected by the player.

Coins are:
- counted during runs
- saved permanently
- used as currency in the shop

---

# Powerup Systems

## Speed Boost
- temporary speed increase
- speed line screen effect
- dynamic camera FOV effect
- animated HUD feedback
- sound effects

## Magnet
- attracts nearby coins automatically
- radius-based collection system
- in-world magnet visual effect
- HUD timer and inventory system

## Invincibility Shield
- temporary collision immunity
- visible shield effect around the player
- HUD timer system
- gameplay feedback effects

---

# Shop System
A complete shop system was implemented where players can:
- spend saved coins
- buy powerups
- store purchased inventory permanently

The shop includes:
- purchase validation
- sound effects
- persistent saving
- UI integration

---

# UI Systems

## Main Menu
- Play button
- Shop panel
- Settings panel
- Quit button

## HUD
Displays:
- score
- high score
- run coins
- total coins
- powerup inventory
- active powerup timers

Powerup banners animate when activated.

## Pause Menu
- pause using ESC
- restart game
- return to main menu

## Game Over Screen
Displays:
- final score
- collected coins
- restart options

---

# Audio System
The project includes:
- background music
- SFX manager
- Audio Mixer integration
- separate Music and SFX sliders

Implemented sounds include:
- coin collection
- speed boost
- magnet activation
- invincibility activation
- death sound
- shop interaction sounds
- game start sound

---

# Visual Polish
Additional polish features include:
- animated powerup banners
- speed line overlays
- dynamic camera FOV effects
- shield visual effects
- magnet visual effects
- button hover/click animations
- animated new high score popup

---

# Technical Features
The project uses:
- Unity Input System
- Object Pooling
- Scriptable Objects
- PlayerPrefs saving
- Audio Mixers
- Animator systems
- UI animation systems
- procedural chunk streaming

---

# GitHub and Version Control
The project was developed using GitHub with regular commits during development.

A Unity `.gitignore` file was used to avoid uploading unnecessary generated files.

---

# Challenges
Some of the main challenges during development were:
- balancing gameplay speed
- procedural chunk spawning
- collision handling
- integrating multiple powerup systems together
- UI polish and feedback systems
- persistent save systems

A lot of iteration and testing went into improving the overall game feel and responsiveness.

---

# Extra Features Beyond Requirements
The project goes beyond the basic infinite runner requirements by including:
- multiple powerup systems
- persistent shop economy
- animated UI systems
- advanced HUD feedback
- audio settings
- visual effects
- in-world gameplay feedback
- reusable modular systems
- object pooling optimization

---

# Final Result
The final result is a polished infinite runner experience with procedural gameplay systems, progression mechanics, visual polish, powerups, audio systems, persistent saving, and optimized endless gameplay.
