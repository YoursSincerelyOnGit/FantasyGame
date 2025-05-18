Traveler's Journey - Programming Edition
Overview
Traveler's Journey - Programming Edition is an interactive, educational text-based game built in C#. Players embark on a journey from Cape Town to Durban (1600 km), managing health, energy, and resources while learning C# programming concepts. The game teaches variable declaration, conditionals, loops, method calls, string comparison, and object creation through hands-on coding challenges. Players must type C# code to perform actions, craft weapons, and survive random events.
Key Features

Educational Focus: Learn C# by writing code to progress (e.g., int health = 100;, if statements, object instantiation).
Game Mechanics:
Travel 1600 km, managing health (100 max), energy (100 max), and inventory.
Craft a weapon (Sword, Bow, Spear, or Axe) with attack (Damage) and block (Defense) properties.
Encounter random events (combat, items, storms).
Save progress to a JSON file.


Actions: Move, rest, eat, hunt, pick up items (e.g., Dragon Heart), and save.
Combat: Fight enemies (Goblin, Wolf) using your weapon’s Damage, with Defense reducing incoming damage.

Setup Instructions
Prerequisites

.NET SDK: Version 6.0 or later.
IDE: Visual Studio, Visual Studio Code, or any C# compiler.
Newtonsoft.Json: For saving game progress.

Installation

Clone or Download:

Copy the Program.cs file into a new C# project.


Install Newtonsoft.Json:

In Visual Studio, use NuGet Package Manager:Install-Package Newtonsoft.Json


Or via .NET CLI:dotnet add package Newtonsoft.Json




Run the Game:

Open the project in your IDE.
Build and run Program.cs.
The game runs in the console, prompting for code input.



Gameplay
Objective

Travel from Cape Town to Durban (1600 km) by typing C# code to perform actions.
Survive by managing health, energy, and inventory.
Complete programming challenges to progress, including crafting a weapon and handling random events.

Game Flow

Character Creation: Enter your character’s name.
Programming Challenges:
Declare a health variable.
Choose and craft a weapon by completing coding tasks.
Perform actions (move, rest, etc.) by writing method calls.
Fight enemies in combat by coding loops and actions.


Random Events: After moving, face events like combat, finding items, or storms (30% chance).
Win Condition: Reach 1600 km to arrive at Durban.
Lose Condition: Health drops to 0, ending the game.

Actions

Move: Travel 100 km (east toward Durban or north toward Johannesburg).
Rest: Recover 20 energy (max 100).
Eat: Consume meat to restore 20 health (max 100).
Hunt: Spend 10 energy to gain meat.
PickUp: Add a Dragon Heart to inventory.
Save: Save progress to savegame.json.

Inventory

Starting items: Bed (Tool), Meat (Consumable).
Crafted weapon: Sword, Bow, Spear, or Axe (Weapon).
Picked-up items: Dragon Heart (Consumable), Meat (Consumable).

Combat

Enemies: Goblin (50 HP, 15 damage), Wolf (60 HP, 20 damage).
Player uses weapon’s Damage to attack (e.g., Sword: 25).
Weapon’s Defense reduces enemy damage (e.g., Sword: 10).
Code a while loop and Attack() or Run() method calls to fight.

Programming Challenges
Players must type C# code to progress. Below are the challenges and their correct responses.
1. Create Health Variable

Prompt: Declare an integer variable health with value 100.
Format: int variableName = value;
Correct Response:int health = 100;


Notes: Semicolon is optional in validation.

2. Weapon Choice (If Statement)

Prompt: Write an if statement to choose a weapon (1-4).
Format: if (choice == "number")
Example: For choice 1 (Sword):
Correct Response:if (choice == "1")


Notes: Accepts variations like if(choice == "1"). Choose 1 (Sword), 2 (Bow), 3 (Spear), or 4 (Axe).

3. Enter Woods (Method Call)

Prompt: Call the EnterWoods() method to enter the woods.
Format: MethodName();
Correct Response:EnterWoods();


Notes: Semicolon is optional.

4. Search Trees (For Loop)

Prompt: Write a for loop to check 5 trees.
Format: for (int i = 0; i < 5; i++)
Correct Response:for (int i = 0; i < 5; i++)


Notes: Must include for, int i, i < 5, and i++.

5. Tree Selection (String Comparison)

Prompt: Check if treeType equals the required wood (e.g., Oak).
Format: if (treeType == "TreeName")
Example: For Oak Wood:
Correct Response:if (treeType == "Oak")


Notes: Case-insensitive. Depends on weapon (Oak, Pine, Birch, Maple).

6. Create Weapon Object

Prompt: Create a Weapon object with Name, Damage, and Defense.
Format: Weapon name = new Weapon { Name = "WeaponName", Damage = value, Defense = value };
Correct Responses (based on weapon choice):
Sword:Weapon sword = new Weapon { Name = "Sword", Damage = 25, Defense = 10 };


Bow:Weapon bow = new Weapon { Name = "Bow", Damage = 20, Defense = 5 };


Spear:Weapon spear = new Weapon { Name = "Spear", Damage = 22, Defense = 8 };


Axe:Weapon axe = new Weapon { Name = "Axe", Damage = 30, Defense = 12 };




Notes: Case-insensitive, flexible spacing. Must match exact Name, Damage, and Defense. Semicolon is optional.

7. Action Selection (Method Call)

Prompt: Call a method to perform an action (Move, Rest, Eat, Hunt, PickUp, Save).
Format: MethodName();
Correct Responses:Move();
Rest();
Eat();
Hunt();
PickUp();
Save();


Notes: Semicolon is optional.

8. Conditional Movement (If Statement)

Prompt: Write an if statement for movement direction (east/north).
Format: if (direction == "direction")
Example: For east:
Correct Response:if (direction == "east")


Notes: Accepts variations like if(direction == "east").

9. Combat Loop (While Loop)

Prompt: Write a while loop for combat.
Format: while (enemy.Health > 0 && player.Health > 0)
Correct Response:while (enemy.Health > 0 && player.Health > 0)


Notes: Must include while, enemy.Health > 0, and player.Health > 0.

10. Combat Action (Method Call)

Prompt: Call Attack() or Run() in combat.
Format: MethodName();
Correct Responses:Attack();
Run();


Notes: Semicolon is optional.

Random Events

Trigger: 30% chance after Move().
Events:
Combat (30%): Fight a Goblin or Wolf.
Find Item (20%): Gain Meat.
Storm (20%): Lose 10 health.
Nothing (30%): No effect.



Technical Details

Language: C#.
Dependencies: Newtonsoft.Json for serialization.
File: Program.cs.
Save File: savegame.json (created on save).
Classes:
Player: Manages name, health, energy, distance, weapon, inventory.
Weapon: Defines Name, Damage, Defense for attacking and blocking.
Item: Represents inventory items (Consumable, Weapon, Tool, Material).
Enemy: Defines enemies (Goblin, Wolf) with health and attack.



Running the Game

Open Program.cs in your IDE.
Ensure Newtonsoft.Json is installed.
Build and run.
Follow prompts, typing the correct C# code for each challenge (see above).
Example combat:A wild Goblin appears!
=== PROGRAMMING CHALLENGE: COMBAT LOOP ===
Your code: while (enemy.Health > 0 && player.Health > 0)
? Correct while loop! Combat begins!
Your Health: 100 HP | Goblin Health: 50 HP
Your Weapon: Sword (Damage: 25, Defense: 10)
Your code: Attack();
You attack the Goblin with your Sword!
Goblin's health: 25 HP
The Goblin attacks you!
Your Sword blocks 10 damage!
You take 5 damage. Your health: 95 HP



Notes

Educational Goal: Teaches C# basics through interactive gameplay.
Extensibility: Add more random events, items, or challenges by modifying RandomEvent or adding classes.
Limitations: Console-based UI; no load game feature (save only).
Future Enhancements:
Add diverse random encounters (e.g., traders, moral dilemmas) with coding challenges.
Implement a load game feature.
Add more weapon properties (e.g., durability).



Troubleshooting

Newtonsoft.Json Error: Ensure the package is installed.
Invalid Code: Check the correct responses above; input must match format exactly.
Game Over: If health reaches 0, restart the game.

License
This project is for educational purposes and not licensed for commercial use. Property of Eunoia

Created for Bandile Sithole
