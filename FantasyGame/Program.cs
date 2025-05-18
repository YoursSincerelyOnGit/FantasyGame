using System;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Collections.Generic;

class Program
{
    static Random random = new Random();
    // Make MapLocations public static to allow access from other classes
    public static readonly Dictionary<int, string> MapLocations = new Dictionary<int, string>
    {
        { 0, "Cape Town: The Starting Shores" },
        { 400, "Forest of Echoes" },
        { 800, "Bridge of Valor" },
        { 1200, "Mystic Crossroads" },
        { 1600, "Durban: The Code Master's Domain" }
    };

    static void Main()
    {
        // Prompt the player for their character name
        Console.WriteLine("Welcome to the Traveler's Journey - Programming Edition!");
        Console.WriteLine("Embark on an epic quest from Cape Town to Durban, mastering the art of coding!");
        Console.WriteLine("Before we begin, please enter your character's name:");
        string playerName = Console.ReadLine();

        // Initialize the player with the entered name
        Player player = new Player(playerName);

        // Intro to the Game
        Console.WriteLine($"\nGreetings, {player.Name}! You are a brave traveler on a quest from Cape Town to Durban (1600 km).");
        Console.WriteLine("Your journey will test your coding skills as you face challenges and foes.");
        Console.WriteLine("Your inventory contains a bed, a sword, and some meat. More treasures await!");
        Console.WriteLine("The sun rises as you begin your journey. Be mindful of day and night!");
        Console.WriteLine("Daytime lasts for 3 actions, and night lasts for 3 actions.");
        Console.WriteLine("Traveling at night doubles your distance but increases danger.");
        Console.WriteLine("Resting at night will advance time to morning, adding remaining night turns to your day!");
        Console.WriteLine("First, let's prepare you with a tutorial.");

        // Programming Challenge: Variable Declaration
        Console.WriteLine("\n=== TUTORIAL: CREATE YOUR HEALTH VARIABLE ===");
        Console.WriteLine("To start your journey, you need to declare your health variable!");
        Console.WriteLine("Write the code to declare an integer variable called 'health' with value 100:");
        Console.WriteLine("Example format: int variableName = value;");

        bool healthCreated = false;
        while (!healthCreated)
        {
            Console.Write("Your code: ");
            string healthCode = Console.ReadLine().Trim();

            if (healthCode.ToLower() == "int health = 100;" ||
                healthCode.ToLower() == "int health=100;")
            {
                Console.WriteLine("✓ Correct! Your health is now set to 100!");
                healthCreated = true;
            }
            else
            {
                player.Health = Math.Max(0, player.Health - 10);
                Console.WriteLine("✗ Incorrect. Try again! Format: int health = 100;");
                Console.WriteLine($"Health penalty: -10 HP. Current health: {player.Health} HP");
                if (player.Health <= 0)
                {
                    Console.WriteLine("Game Over! You have died due to low health.");
                    return;
                }
            }
        }

        // Weapon Selection and Crafting Tutorial
        Console.WriteLine("\n=== TUTORIAL: WEAPON CRAFTING - IF STATEMENT CHALLENGE ===");
        Console.WriteLine("In this tutorial, you'll craft a weapon for your journey.");
        Console.WriteLine("Choose your weapon type by writing an if statement:");
        Console.WriteLine("Available weapons:");
        Console.WriteLine("1. Sword (requires Oak Wood)");
        Console.WriteLine("2. Bow (requires Pine Wood)");
        Console.WriteLine("3. Spear (requires Birch Wood)");
        Console.WriteLine("4. Axe (requires Maple Wood)");

        string weaponChoice = "";
        string requiredWood = "";
        bool validChoice = false;

        Console.WriteLine("\nWrite an if statement to check weapon choice:");
        Console.WriteLine("Example: if (choice == \"1\") { weapon = \"Sword\"; }");
        Console.WriteLine("First, what's your choice number (1-4)?");
        string choiceNumber = Console.ReadLine();

        // Challenge: Write if statement
        while (!validChoice)
        {
            Console.WriteLine($"Now write the if statement for choice {choiceNumber}:");
            Console.Write("Your code: ");
            string ifStatement = Console.ReadLine().Trim();

            string expectedIf = $"if (choice == \"{choiceNumber}\")";
            string expectedIf2 = $"if(choice == \"{choiceNumber}\")";
            string expectedIf3 = $"if (choice==\"{choiceNumber}\")";
            string expectedIf4 = $"if(choice==\"{choiceNumber}\")";

            if (ifStatement.ToLower().Contains(expectedIf.ToLower()) ||
                ifStatement.ToLower().Contains(expectedIf2.ToLower()) ||
                ifStatement.ToLower().Contains(expectedIf3.ToLower()) ||
                ifStatement.ToLower().Contains(expectedIf4.ToLower()))
            {
                Console.WriteLine("✓ Correct if statement structure!");

                // Set weapon based on choice
                if (choiceNumber == "1")
                {
                    weaponChoice = "Sword";
                    requiredWood = "Oak";
                    validChoice = true;
                    Console.WriteLine("Nice choice! A sword is a versatile weapon.");
                }
                else if (choiceNumber == "2")
                {
                    weaponChoice = "Bow";
                    requiredWood = "Pine";
                    validChoice = true;
                    Console.WriteLine("Excellent! A bow allows for ranged attacks.");
                }
                else if (choiceNumber == "3")
                {
                    weaponChoice = "Spear";
                    requiredWood = "Birch";
                    validChoice = true;
                    Console.WriteLine("Great choice! A spear has good reach and power.");
                }
                else if (choiceNumber == "4")
                {
                    weaponChoice = "Axe";
                    requiredWood = "Maple";
                    validChoice = true;
                    Console.WriteLine("Powerful choice! An axe deals heavy damage.");
                }
                else
                {
                    Console.WriteLine("Invalid choice number! Please choose 1-4.");
                    Console.WriteLine("What's your choice number (1-4)?");
                    choiceNumber = Console.ReadLine();
                }
            }
            else
            {
                int penalty = player.TimeOfDay == TimeOfDay.Night ? 15 : 10; // Night penalty
                player.Health = Math.Max(0, player.Health - penalty);
                Console.WriteLine("✗ Incorrect if statement. Try again!");
                Console.WriteLine("Format: if (choice == \"" + choiceNumber + "\")");
                Console.WriteLine($"Health penalty: -{penalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
                if (player.Health <= 0)
                {
                    Console.WriteLine("Game Over! You have died due to low health.");
                    return;
                }
            }
        }

        Console.WriteLine($"For that you will need {requiredWood} Wood!");
        Console.WriteLine("To go to the woods, you need to write a method call!");
        Console.WriteLine("Let's continue the tutorial by gathering the wood.");

        // Woods crafting sequence with programming challenges
        bool weaponCrafted = false;
        while (!weaponCrafted)
        {
            Console.WriteLine("\n=== TUTORIAL: METHOD CALL TO ENTER THE WOODS ===");
            Console.WriteLine("To enter the woods, write a method call:");
            Console.WriteLine("Method name: EnterWoods()");
            Console.WriteLine("Format: MethodName();");

            Console.Write("Your code: ");
            string methodCall = Console.ReadLine().Trim();

            if (methodCall.ToLower() == "enterwoods();" || methodCall.ToLower() == "enterwoods()")
            {
                Console.WriteLine("✓ Correct method call!");
                Console.WriteLine("\n=== TUTORIAL: ENTERING THE WOODS ===");
                Console.WriteLine("You head into the woods...");
                Console.WriteLine("There are lots of trees here but we want " + requiredWood + " Wood!");
                Console.WriteLine("You see different types of trees:");
                Console.WriteLine("- Oak trees (strong and dark)");
                Console.WriteLine("- Pine trees (tall with needles)");
                Console.WriteLine("- Birch trees (white bark)");
                Console.WriteLine("- Maple trees (broad leaves)");
                Console.WriteLine("- Willow trees (drooping branches)");

                // Loop Challenge
                Console.WriteLine("\n=== TUTORIAL: FOR LOOP TO SEARCH TREES ===");
                Console.WriteLine("You need to search through trees. Write a for loop to check 5 trees:");
                Console.WriteLine("Format: for (int i = 0; i < 5; i++)");

                bool loopCorrect = false;
                while (!loopCorrect)
                {
                    Console.Write("Your code: ");
                    string forLoop = Console.ReadLine().Trim();

                    if (forLoop.ToLower().Contains("for") && forLoop.ToLower().Contains("int i") &&
                        forLoop.ToLower().Contains("i < 5") && forLoop.ToLower().Contains("i++"))
                    {
                        Console.WriteLine("✓ Correct for loop!");
                        loopCorrect = true;

                        // Simulate the loop
                        Console.WriteLine("Executing your loop...");
                        for (int i = 0; i < 5; i++)
                        {
                            Console.WriteLine($"Checking tree {i + 1}...");
                            Thread.Sleep(500);
                        }
                    }
                    else
                    {
                        int penalty = player.TimeOfDay == TimeOfDay.Night ? 15 : 10;
                        player.Health = Math.Max(0, player.Health - penalty);
                        Console.WriteLine("✗ Incorrect loop. Try again!");
                        Console.WriteLine("Format: for (int i = 0; i < 5; i++)");
                        Console.WriteLine($"Health penalty: -{penalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
                        if (player.Health <= 0)
                        {
                            Console.WriteLine("Game Over! You have died due to low health.");
                            return;
                        }
                    }
                }

                // Tree selection with string comparison challenge
                bool correctTreeFound = false;
                while (!correctTreeFound)
                {
                    Console.WriteLine("\n=== TUTORIAL: STRING COMPARISON TO FIND THE RIGHT TREE ===");
                    Console.WriteLine($"Write code to check if a tree type equals \"{requiredWood}\":");
                    Console.WriteLine("Format: if (treeType == \"TreeName\")");
                    Console.WriteLine($"You need {requiredWood} Wood!");

                    Console.Write("Your code: ");
                    string comparison = Console.ReadLine().Trim();

                    string expectedComparison = $"if (treetype == \"{requiredWood.ToLower()}\")";
                    string expectedComparison2 = $"if(treetype == \"{requiredWood.ToLower()}\")";
                    string expectedComparison3 = $"if (treetype==\"{requiredWood.ToLower()}\")";

                    if (comparison.ToLower() == expectedComparison ||
                        comparison.ToLower() == expectedComparison2 ||
                        comparison.ToLower() == expectedComparison3 ||
                        comparison.ToLower().Contains($"treetype == \"{requiredWood.ToLower()}\""))
                    {
                        Console.WriteLine("✓ Correct string comparison!");
                        Console.WriteLine($"Perfect! You found the {requiredWood} tree!");
                        Console.WriteLine("*CHOP* *CHOP* *CHOP*");
                        Console.WriteLine($"You successfully cut down the {requiredWood} tree and collected {requiredWood} Wood!");

                        // Add wood to inventory
                        player.Inventory.Add(new Item { Name = requiredWood + " Wood", Type = ItemType.Material });

                        // Object Creation Challenge
                        Console.WriteLine("\n=== TUTORIAL: CREATE WEAPON OBJECT ===");
                        Console.WriteLine($"Now craft your {weaponChoice} by creating a Weapon object!");
                        Console.WriteLine("The Weapon class has properties: Name (string), Damage (int), Defense (int).");
                        Console.WriteLine($"Write code to create a {weaponChoice} with appropriate values:");
                        Console.WriteLine($"Example: Weapon sword = new Weapon {{ Name = \"Sword\", Damage = 25, Defense = 10 }};");
                        Console.WriteLine($"Suggested values for {weaponChoice}:");
                        string expectedCode = "";
                        int expectedDamage = 0;
                        int expectedDefense = 0;
                        switch (weaponChoice)
                        {
                            case "Sword":
                                Console.WriteLine("Damage: 25, Defense: 10");
                                expectedCode = $"weapon sword = new weapon {{ name = \"sword\", damage = 25, defense = 10 }}";
                                expectedDamage = 25;
                                expectedDefense = 10;
                                break;
                            case "Bow":
                                Console.WriteLine("Damage: 20, Defense: 5");
                                expectedCode = $"weapon bow = new weapon {{ name = \"bow\", damage = 20, defense = 5 }}";
                                expectedDamage = 20;
                                expectedDefense = 5;
                                break;
                            case "Spear":
                                Console.WriteLine("Damage: 22, Defense: 8");
                                expectedCode = $"weapon spear = new weapon {{ name = \"spear\", damage = 22, defense = 8 }}";
                                expectedDamage = 22;
                                expectedDefense = 8;
                                break;
                            case "Axe":
                                Console.WriteLine("Damage: 30, Defense: 12");
                                expectedCode = $"weapon axe = new weapon {{ name = \"axe\", damage = 30, defense = 12 }}";
                                expectedDamage = 30;
                                expectedDefense = 12;
                                break;
                        }

                        bool objectCreated = false;
                        while (!objectCreated)
                        {
                            Console.Write("Your code: ");
                            string objectCode = Console.ReadLine().Trim().ToLower();

                            // Normalize input for comparison
                            string normalizedInput = objectCode.Replace(" ", "").Replace("{", " { ").Replace("}", " } ");
                            string normalizedExpected = expectedCode.Replace(" ", "").Replace("{", " { ").Replace("}", " } ");

                            if (normalizedInput.Contains($"newweapon{{name=\"{weaponChoice.ToLower()}\",damage={expectedDamage},defense={expectedDefense}}}") ||
                                normalizedInput.Contains($"newweapon{{name=\"{weaponChoice.ToLower()}\",defense={expectedDefense},damage={expectedDamage}}}"))
                            {
                                Console.WriteLine("✓ Correct! You created your weapon!");
                                player.CraftWeapon(new Weapon
                                {
                                    Name = weaponChoice,
                                    Damage = expectedDamage,
                                    Defense = expectedDefense
                                });
                                Console.WriteLine($"\n=== TUTORIAL: CRAFTING {weaponChoice.ToUpper()} ===");
                                Console.WriteLine("Crafting in progress...");
                                for (int i = 1; i <= 3; i++)
                                {
                                    Console.WriteLine($"Crafting... {i}/3");
                                    Thread.Sleep(1000);
                                }
                                Console.WriteLine($"SUCCESS! You have crafted a {weaponChoice}!");
                                Console.WriteLine("Tutorial complete! You're now ready to begin your journey.");
                                // Add initial usable items after tutorial
                                player.Inventory.Add(new Item { Name = "Health Potion", Type = ItemType.Consumable });
                                player.Inventory.Add(new Item { Name = "Map Scroll", Type = ItemType.Tool });
                                Console.WriteLine("You also find a Health Potion and a Map Scroll in your bag!");
                                objectCreated = true;
                                weaponCrafted = true;
                                correctTreeFound = true;
                            }
                            else
                            {
                                int penalty = player.TimeOfDay == TimeOfDay.Night ? 15 : 10;
                                player.Health = Math.Max(0, player.Health - penalty);
                                Console.WriteLine($"✗ Incorrect. Try again! Expected: {expectedCode}");
                                Console.WriteLine($"Make sure Name = \"{weaponChoice}\", Damage = {expectedDamage}, Defense = {expectedDefense}");
                                Console.WriteLine($"Health penalty: -{penalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
                                if (player.Health <= 0)
                                {
                                    Console.WriteLine("Game Over! You have died due to low health.");
                                    return;
                                }
                            }
                        }
                    }
                    else
                    {
                        int penalty = player.TimeOfDay == TimeOfDay.Night ? 15 : 10;
                        player.Health = Math.Max(0, player.Health - penalty);
                        Console.WriteLine("✗ Incorrect string comparison. Try again!");
                        Console.WriteLine($"Format: if (treeType == \"{requiredWood}\")");
                        Console.WriteLine($"Health penalty: -{penalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
                        if (player.Health <= 0)
                        {
                            Console.WriteLine("Game Over! You have died due to low health.");
                            return;
                        }
                    }
                }
            }
            else
            {
                int penalty = player.TimeOfDay == TimeOfDay.Night ? 15 : 10;
                player.Health = Math.Max(0, player.Health - penalty);
                Console.WriteLine("✗ Incorrect method call. Try again!");
                Console.WriteLine("Format: EnterWoods();");
                Console.WriteLine($"Health penalty: -{penalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
                if (player.Health <= 0)
                {
                    Console.WriteLine("Game Over! You have died due to low health.");
                    return;
                }
            }
            // Advance time after each tutorial interaction
            player.AdvanceTime();
        }

        Console.WriteLine("\n=== JOURNEY BEGINS ===");
        Console.WriteLine("With your weapon crafted, the tutorial is over. Your goal is to reach Durban and prove your coding skills!");
        Console.WriteLine("You'll face mighty foes and discover legendary locations along the way.");

        while (player.Health > 0)
        {
            // Update current location based on distance
            UpdateLocation(player);

            // Display Game Status with color
            Console.WriteLine("\n-------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Your Health: {player.Health} HP");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Energy: {player.Energy}");
            Console.ResetColor();
            Console.WriteLine($"Distance: {player.Distance} km");
            Console.WriteLine($"Weapon: {(player.EquippedWeapon != null ? $"{player.EquippedWeapon.Name} (Damage: {player.EquippedWeapon.Damage}, Defense: {player.EquippedWeapon.Defense})" : "None")}");
            Console.WriteLine($"Inventory: {string.Join(", ", player.Inventory.ConvertAll(item => item.Name))}");
            Console.WriteLine($"You're currently at: {player.CurrentLocation}. Your goal is to reach Durban (1600 km).");
            Console.ForegroundColor = player.TimeOfDay == TimeOfDay.Day ? ConsoleColor.Yellow : ConsoleColor.Blue;
            Console.WriteLine($"Time: {player.TimeOfDay} (Actions remaining in this phase: {player.MaxInteractionsInPhase - player.InteractionsInPhase})");
            Console.ResetColor();
            ShowProgress(player);

            Console.WriteLine("\n=== PROGRAMMING CHALLENGE: ACTION SELECTION ===");
            Console.WriteLine("To perform an action, write a method call:");
            Console.WriteLine("Available methods: Move(), Rest(), Eat(), Hunt(), PickUp(), Save(), UseItem()");
            Console.WriteLine("Format: MethodName();");

            // Player action input through programming
            Console.Write("Your code: ");
            string actionCode = Console.ReadLine().ToLower().Trim();

            if (actionCode == "move();" || actionCode == "move()")
            {
                // Movement challenge with Walk/Run variations
                Console.WriteLine("\n=== PROGRAMMING CHALLENGE: CHOOSE MOVEMENT TYPE ===");
                Console.WriteLine("You can move east toward Durban in two ways:");
                if (player.TimeOfDay == TimeOfDay.Day)
                {
                    Console.WriteLine("- Walk: Costs 10 energy, progresses 100 km (~6%)");
                    Console.WriteLine("- Run: Costs 25 energy, progresses 150 km (~9%)");
                }
                else
                {
                    Console.WriteLine("- Walk: Costs 10 energy, progresses 200 km (~12%) (Night bonus)");
                    Console.WriteLine("- Run: Costs 25 energy, progresses 300 km (~18%) (Night bonus)");
                    Console.WriteLine("Beware: Traveling at night increases enemy encounters!");
                }
                Console.WriteLine("Write an if statement to specify your movement type:");
                Console.WriteLine("Format: if (moveType == \"walk\") or if (moveType == \"run\")");
                Console.WriteLine("First, how do you want to move? (walk/run):");
                string moveType = Console.ReadLine().ToLower();

                Console.WriteLine($"Now write the if statement for moveType \"{moveType}\":");
                Console.Write("Your code: ");
                string moveCode = Console.ReadLine().Trim();

                if (moveCode.ToLower().Contains("if") &&
                    moveCode.ToLower().Contains($"moveType == \"{moveType}\""))
                {
                    Console.WriteLine("✓ Correct conditional statement!");

                    if (moveType == "walk")
                    {
                        if (player.Energy >= 10)
                        {
                            player.Energy -= 10;
                            int distanceGain = player.TimeOfDay == TimeOfDay.Day ? 100 : 200;
                            player.Distance += distanceGain;
                            Console.WriteLine($"You walk east toward Durban, covering {distanceGain} km.");
                            Console.WriteLine("Energy cost: -10. Current energy: " + player.Energy);
                            RandomEvent(player);

                            // Enhanced Mini-Boss Encounters with ASCII art
                            if (player.Distance >= 400 && player.Distance < 800 && !player.HasDefeatedGoblinKing)
                            {
                                UpdateLocation(player);
                                Console.WriteLine("\nAs you enter the Forest of Echoes, a chilling presence emerges...");
                                DisplayAsciiArt("Goblin");
                                Console.WriteLine("\n=== MINI-BOSS: MIRROR GOBLIN (400 km) ===");
                                Console.WriteLine("A hideous Goblin blocks your path! But wait... it's terrified of its own reflection!");
                                Console.WriteLine("Legend says goblins are so ugly they flee when they see themselves.");
                                Console.WriteLine("You need to create a magic mirror grid to trap its reflection!");
                                Console.WriteLine("The mirror must be a 3x3 grid to capture the goblin's essence.");
                                Console.WriteLine("\nCODING CHALLENGE: Create a 3x3 mirror grid (2D array)");
                                Console.WriteLine("Hint: A mirror reflects in all directions - you need a grid!");
                                Console.WriteLine("Format: string[,] mirror = new string[3,3];");

                                bool mirrorCreated = false;
                                while (!mirrorCreated)
                                {
                                    Console.Write("Your code: ");
                                    string arrayCode = Console.ReadLine().Trim();
                                    if (arrayCode.ToLower().Contains("string[,]") && arrayCode.ToLower().Contains("new string[3,3]"))
                                    {
                                        Console.WriteLine("✓ Perfect! The magic mirror grid forms!");
                                        Console.WriteLine("The goblin sees its reflection in all 9 mirror sections and flees in terror!");
                                        Console.WriteLine("'NOOO! MY HIDEOUS FACE!' *The goblin runs away screaming*");
                                        mirrorCreated = true;
                                        player.HasDefeatedGoblinKing = true;
                                        Console.WriteLine("Victory! You've learned to create 2D arrays - the foundation of game boards!");
                                    }
                                    else
                                    {
                                        int penalty = player.TimeOfDay == TimeOfDay.Night ? 15 : 10;
                                        player.Health = Math.Max(0, player.Health - penalty);
                                        Console.WriteLine("✗ The mirror cracks! The goblin attacks while you're distracted!");
                                        Console.WriteLine("Format: string[,] mirror = new string[3,3];");
                                        Console.WriteLine($"Health penalty: -{penalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
                                        if (player.Health <= 0)
                                        {
                                            Console.WriteLine("Game Over! The goblin's ugly face was the last thing you saw.");
                                            return;
                                        }
                                    }
                                }
                            }
                            else if (player.Distance >= 800 && player.Distance < 1200 && !player.HasDefeatedWolfPackLeader)
                            {
                                UpdateLocation(player);
                                Console.WriteLine("\nYou approach the Bridge of Valor, guarded by a stern figure...");
                                DisplayAsciiArt("Captain");
                                Console.WriteLine("\n=== MINI-BOSS: THE PATROL CAPTAIN (800 km) ===");
                                Console.WriteLine("A heavily armored Patrol Captain blocks the bridge!");
                                Console.WriteLine("'HALT! To pass, you must inspect every section of my guard tower!'");
                                Console.WriteLine("The tower is a 3x3 structure. You must check each room systematically.");
                                Console.WriteLine("The Captain won't let you pass until you prove you can search thoroughly!");
                                Console.WriteLine("\nCODING CHALLENGE: Search every room of the 3x3 tower");
                                Console.WriteLine("Hint: You need to go through each floor (row) and each room (column)!");
                                Console.WriteLine("Format: for (int floor = 0; floor < 3; floor++) { for (int room = 0; room < 3; room++) { } }");

                                bool searchCompleted = false;
                                while (!searchCompleted)
                                {
                                    Console.Write("Your code: ");
                                    string loopCode = Console.ReadLine().Trim();
                                    if (loopCode.ToLower().Contains("for") && loopCode.ToLower().Contains("int") &&
                                        loopCode.ToLower().Contains("< 3") && loopCode.ToLower().Contains("for") &&
                                        loopCode.Count(c => c == '{') >= 2)
                                    {
                                        Console.WriteLine("✓ Excellent! You systematically search every room!");
                                        Console.WriteLine("The Captain watches as you methodically check:");
                                        Console.WriteLine("Floor 0: Room 0, Room 1, Room 2");
                                        Console.WriteLine("Floor 1: Room 0, Room 1, Room 2");
                                        Console.WriteLine("Floor 2: Room 0, Room 1, Room 2");
                                        Console.WriteLine("'Impressive! You understand systematic searching. You may pass!'");
                                        searchCompleted = true;
                                        player.HasDefeatedWolfPackLeader = true;
                                        Console.WriteLine("Victory! You've mastered nested loops - essential for checking game boards!");
                                    }
                                    else
                                    {
                                        int penalty = player.TimeOfDay == TimeOfDay.Night ? 15 : 10;
                                        player.Health = Math.Max(0, player.Health - penalty);
                                        Console.WriteLine("✗ Your search is chaotic! The Captain attacks your sloppy technique!");
                                        Console.WriteLine("Format: for (int floor = 0; floor < 3; floor++) { for (int room = 0; room < 3; room++) { } }");
                                        Console.WriteLine($"Health penalty: -{penalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
                                        if (player.Health <= 0)
                                        {
                                            Console.WriteLine("Game Over! The Captain's discipline was too much for you.");
                                            return;
                                        }
                                    }
                                }
                            }
                            else if (player.Distance >= 1200 && player.Distance < 1600 && !player.HasDefeatedDragonApprentice)
                            {
                                UpdateLocation(player);
                                Console.WriteLine("\nAt the Mystic Crossroads, a cloaked figure awaits...");
                                DisplayAsciiArt("FortuneTeller");
                                Console.WriteLine("\n=== MINI-BOSS: THE MYSTIC FORTUNE TELLER (1200 km) ===");
                                Console.WriteLine("A mysterious Fortune Teller sits at a crossroads with a crystal grid.");
                                Console.WriteLine("'Traveler! To pass, you must divine the secret of victory!'");
                                Console.WriteLine("She points to her mystical 3x3 crystal array:");
                                Console.WriteLine("[ X ][ X ][ X ]");
                                Console.WriteLine("[ O ][ ? ][ O ]");
                                Console.WriteLine("[ X ][ O ][ X ]");
                                Console.WriteLine("'Tell me, when do three crystals align in mystical harmony?'");
                                Console.WriteLine("You realize - she's asking about winning conditions!");
                                Console.WriteLine("\nCODING CHALLENGE: Detect when three X's align in the top row");
                                Console.WriteLine("Format: if (crystals[0,0] == \"X\" && crystals[0,1] == \"X\" && crystals[0,2] == \"X\")");

                                bool divination = false;
                                while (!divination)
                                {
                                    Console.Write("Your code: ");
                                    string winCode = Console.ReadLine().Trim();
                                    if (winCode.ToLower().Contains("if") && winCode.ToLower().Contains("crystals[0,0]") &&
                                        winCode.ToLower().Contains("crystals[0,1]") && winCode.ToLower().Contains("crystals[0,2]") &&
                                        winCode.ToLower().Contains("== \"x\"") && winCode.ToLower().Contains("&&"))
                                    {
                                        Console.WriteLine("✓ Brilliant! You understand the mystical pattern!");
                                        Console.WriteLine("The Fortune Teller's eyes glow: 'You see the truth of alignment!'");
                                        Console.WriteLine("'Three elements in harmony spell victory - in crystals or code!'");
                                        Console.WriteLine("She waves her hand and vanishes: 'The path to Durban is clear!'");
                                        divination = true;
                                        player.HasDefeatedDragonApprentice = true;
                                        Console.WriteLine("Victory! You've learned win condition checking - the heart of any game!");
                                    }
                                    else
                                    {
                                        int penalty = player.TimeOfDay == TimeOfDay.Night ? 15 : 10;
                                        player.Health = Math.Max(0, player.Health - penalty);
                                        Console.WriteLine("✗ The crystals crack from your confusion! Dark energy lashes out!");
                                        Console.WriteLine("Format: if (crystals[0,0] == \"X\" && crystals[0,1] == \"X\" && crystals[0,2] == \"X\")");
                                        Console.WriteLine($"Health penalty: -{penalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
                                        if (player.Health <= 0)
                                        {
                                            Console.WriteLine("Game Over! The mystical energies consumed you.");
                                            return;
                                        }
                                    }
                                }
                            }
                            else if (player.Distance >= 1600 && !player.HasDefeatedDragonMaster)
                            {
                                UpdateLocation(player);
                                Console.WriteLine("\nYou arrive at Durban, where a towering figure stands...");
                                DisplayAsciiArt("CodeMaster");
                                Console.WriteLine("\n=== FINAL SHOWDOWN: THE GRAND CODE MASTER OF DURBAN ===");
                                Console.WriteLine("You arrive in Durban to find the legendary Grand Code Master!");
                                Console.WriteLine("'Welcome, traveler! I've been watching your journey.'");
                                Console.WriteLine("'You've learned about grids, systematic searching, and victory conditions.'");
                                Console.WriteLine("'Now... create the ultimate game board - a place where players battle!'");
                                Console.WriteLine("'Show me you can create a method to place a mark on any position!'");
                                Console.WriteLine("\nFINAL CHALLENGE: Create a method to place a mark on the game board");
                                Console.WriteLine("This will let players take turns and make their moves!");
                                Console.WriteLine("Format: public void PlaceMove(string[,] board, int row, int col, string player) { board[row,col] = player; }");

                                bool masterChallenge = false;
                                while (!masterChallenge)
                                {
                                    Console.Write("Your code: ");
                                    string masterCode = Console.ReadLine().Trim();
                                    if (masterCode.ToLower().Contains("public void") && masterCode.ToLower().Contains("placemove") &&
                                        masterCode.ToLower().Contains("string[,] board") && masterCode.ToLower().Contains("int row") &&
                                        masterCode.ToLower().Contains("int col") && masterCode.ToLower().Contains("string player") &&
                                        masterCode.ToLower().Contains("board[row,col] = player"))
                                    {
                                        Console.WriteLine("✓ MAGNIFICENT! You are truly a Code Master!");
                                        Console.WriteLine("The Grand Code Master smiles proudly:");
                                        Console.WriteLine("'You understand the essence of interactive games!'");
                                        Console.WriteLine("'With grids, loops, conditions, and player actions...'");
                                        Console.WriteLine("'You can create Tic Tac Toe - or any board game!'");
                                        masterChallenge = true;
                                        player.HasDefeatedDragonMaster = true;

                                        Console.WriteLine("\n🎉 ULTIMATE VICTORY! 🎉");
                                        Console.WriteLine("You have completed the Traveler's Journey!");
                                        Console.WriteLine("You now possess all the skills needed to code Tic Tac Toe:");
                                        Console.WriteLine("✓ 2D Arrays for the game board");
                                        Console.WriteLine("✓ Nested loops to check positions");
                                        Console.WriteLine("✓ Conditional logic for win detection");
                                        Console.WriteLine("✓ Methods for player actions");
                                        Console.WriteLine("\nGo forth and create amazing games, Code Master!");
                                        return;
                                    }
                                    else
                                    {
                                        int penalty = player.TimeOfDay == TimeOfDay.Night ? 15 : 10;
                                        player.Health = Math.Max(0, player.Health - penalty);
                                        Console.WriteLine("✗ The Code Master shakes his head: 'Not quite right, young one.'");
                                        Console.WriteLine("Format: public void PlaceMove(string[,] board, int row, int col, string player) { board[row,col] = player; }");
                                        Console.WriteLine($"Health penalty: -{penalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
                                        if (player.Health <= 0)
                                        {
                                            Console.WriteLine("Game Over! You weren't ready for the final challenge.");
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (moveType == "run")
                    {
                        if (player.Energy >= 25)
                        {
                            player.Energy -= 25;
                            int distanceGain = player.TimeOfDay == TimeOfDay.Day ? 150 : 300;
                            player.Distance += distanceGain;
                            Console.WriteLine($"You run east toward Durban, covering {distanceGain} km.");
                            Console.WriteLine("Energy cost: -25. Current energy: " + player.Energy);
                            RandomEvent(player);
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough energy to run! Need at least 25 energy.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid movement type! Use 'walk' or 'run'.");
                    }
                }
                else
                {
                    int penalty = player.TimeOfDay == TimeOfDay.Night ? 15 : 10;
                    player.Health = Math.Max(0, player.Health - penalty);
                    Console.WriteLine("✗ Incorrect move statement. Try again next time!");
                    Console.WriteLine($"Format: if (moveType == \"{moveType}\")");
                    Console.WriteLine($"Health penalty: -{penalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
                    if (player.Health <= 0)
                    {
                        Console.WriteLine("Game Over! You have died due to low health.");
                        return;
                    }
                }
            }
            else if (actionCode == "rest();" || actionCode == "rest()")
            {
                Console.WriteLine("✓ Correct method call!");
                Console.WriteLine("You lie down and rest to recover energy.");
                player.Rest();
            }
            else if (actionCode == "eat();" || actionCode == "eat()")
            {
                Console.WriteLine("✓ Correct method call!");
                Console.WriteLine("You eat some meat to recover health.");
                player.Eat();
            }
            else if (actionCode == "hunt();" || actionCode == "hunt()")
            {
                Console.WriteLine("✓ Correct method call!");
                Console.WriteLine("You go hunting to gather more food.");
                player.Hunt();
            }
            else if (actionCode == "pickup();" || actionCode == "pickup()")
            {
                Console.WriteLine("✓ Correct method call!");
                Console.WriteLine("You find a Dragon Heart and add it to your inventory.");
                player.PickUp(new Item { Name = "Dragon Heart", Type = ItemType.Consumable });
            }
            else if (actionCode == "save();" || actionCode == "save()")
            {
                Console.WriteLine("✓ Correct method call!");
                Console.WriteLine("Saving your progress...");
                SaveGame(player);
            }
            else if (actionCode == "useitem();" || actionCode == "useitem()")
            {
                Console.WriteLine("✓ Correct method call!");
                player.UseItem();
            }
            else
            {
                int penalty = player.TimeOfDay == TimeOfDay.Night ? 15 : 10;
                player.Health = Math.Max(0, player.Health - penalty);
                Console.WriteLine("✗ Invalid method call. Try again!");
                Console.WriteLine("Remember: MethodName(); (like Move(), Rest(), etc.)");
                Console.WriteLine($"Health penalty: -{penalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
                if (player.Health <= 0)
                {
                    Console.WriteLine("Game Over! You have died due to low health.");
                    return;
                }
            }

            // Advance time after each action
            player.AdvanceTime();

            // Check for NPC encounter (Wandering Trader at 600 km)
            if (player.Distance >= 600 && player.Distance < 800 && !player.HasMetTrader)
            {
                Console.WriteLine("\n=== ENCOUNTER: WANDERING TRADER ===");
                Console.WriteLine("A cheerful trader approaches you on the path.");
                Console.WriteLine("'Greetings, traveler! I can teach you a trick for a price.'");
                Console.WriteLine("'Write a loop to count my 4 wares, and I’ll give you a Health Potion!'");
                Console.WriteLine("Format: for (int i = 0; i < 4; i++)");

                bool traderChallenge = false;
                while (!traderChallenge)
                {
                    Console.Write("Your code: ");
                    string traderCode = Console.ReadLine().Trim();
                    if (traderCode.ToLower().Contains("for") && traderCode.ToLower().Contains("int i") &&
                        traderCode.ToLower().Contains("i < 4") && traderCode.ToLower().Contains("i++"))
                    {
                        Console.WriteLine("✓ Well done! The trader claps in delight.");
                        Console.WriteLine("'Here’s your reward, brave coder!'");
                        player.PickUp(new Item { Name = "Health Potion", Type = ItemType.Consumable });
                        traderChallenge = true;
                        player.HasMetTrader = true;
                    }
                    else
                    {
                        int penalty = player.TimeOfDay == TimeOfDay.Night ? 10 : 5;
                        player.Health = Math.Max(0, player.Health - penalty);
                        Console.WriteLine("✗ The trader sighs. 'Not quite! Try again.'");
                        Console.WriteLine("Format: for (int i = 0; i < 4; i++)");
                        Console.WriteLine($"Health penalty: -{penalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
                        if (player.Health <= 0)
                        {
                            Console.WriteLine("Game Over! The trader’s disappointment was too much.");
                            return;
                        }
                    }
                }
                player.AdvanceTime();
            }
        }

        if (player.Health <= 0)
        {
            Console.WriteLine("Game Over! You have died.");
        }
        Console.ReadLine();
    }

    static void UpdateLocation(Player player)
    {
        foreach (var location in MapLocations)
        {
            if (player.Distance >= location.Key)
            {
                player.CurrentLocation = location.Value;
            }
            else
            {
                break;
            }
        }
        if (!MapLocations.ContainsKey(player.Distance) && player.Distance < 1600)
        {
            player.CurrentLocation = "En route to " + MapLocations[GetNextLandmark(player.Distance)];
        }
    }

    // Make GetNextLandmark public static to allow access from other classes
    public static int GetNextLandmark(int distance)
    {
        foreach (var location in MapLocations.Keys)
        {
            if (location > distance)
            {
                return location;
            }
        }
        return 1600;
    }

    static void RandomEvent(Player player)
    {
        int enemyChance = player.TimeOfDay == TimeOfDay.Day ? 30 : 50; // Higher chance at night
        int eventChance = random.Next(1, 101);
        if (eventChance <= enemyChance) // Combat chance
        {
            Enemy enemy = random.Next(2) == 0
                ? new Enemy { Health = 50, Name = "Goblin", Type = EnemyType.Goblin }
                : new Enemy { Health = 60, Name = "Wolf", Type = EnemyType.Wolf };
            Console.WriteLine($"A wild {enemy.Name} appears!");
            EncounterCombat(player, enemy);
        }
        else if (eventChance <= 50) // 20% chance to find an item
        {
            Item item = new Item { Name = "Meat", Type = ItemType.Consumable };
            Console.WriteLine($"You found a {item.Name}!");
            player.PickUp(item);
        }
        else if (eventChance <= 70) // 20% chance for a storm
        {
            int stormDamage = player.TimeOfDay == TimeOfDay.Night ? 15 : 10;
            Console.WriteLine($"A storm hits! You lose {stormDamage} health.");
            player.Health -= stormDamage;
            if (player.TimeOfDay == TimeOfDay.Night)
            {
                Console.WriteLine("(Night penalty: +5 damage)");
            }
        }
        else if (eventChance <= 85) // 15% chance for a stranded traveler event
        {
            Console.WriteLine("You encounter a stranded traveler begging for help!");
            Console.WriteLine("Option 1: Help them by writing a loop to gather 3 pieces of wood (gain a Health Potion).");
            Console.WriteLine("Option 2: Ignore them and move on (no penalty).");
            Console.WriteLine("Choose (1 or 2):");
            string choice = Console.ReadLine().Trim();

            if (choice == "1")
            {
                Console.WriteLine("Write a loop to gather 3 pieces of wood:");
                Console.WriteLine("Format: for (int i = 0; i < 3; i++)");
                Console.Write("Your code: ");
                string loopCode = Console.ReadLine().Trim();
                if (loopCode.ToLower().Contains("for") && loopCode.ToLower().Contains("int i") &&
                    loopCode.ToLower().Contains("i < 3") && loopCode.ToLower().Contains("i++"))
                {
                    Console.WriteLine("✓ You gather the wood and help the traveler!");
                    Console.WriteLine("The traveler thanks you and gives you a Health Potion.");
                    player.PickUp(new Item { Name = "Health Potion", Type = ItemType.Consumable });
                }
                else
                {
                    int penalty = player.TimeOfDay == TimeOfDay.Night ? 10 : 5;
                    player.Health = Math.Max(0, player.Health - penalty);
                    Console.WriteLine("✗ You fail to gather the wood properly. The traveler leaves disappointed.");
                    Console.WriteLine($"Health penalty: -{penalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
                }
            }
            else
            {
                Console.WriteLine("You ignore the traveler and continue your journey.");
            }
        }
        else // 15% chance for nothing
        {
            Console.WriteLine("The journey is uneventful.");
        }
    }

    static void EncounterCombat(Player player, Enemy enemy)
    {
        Console.WriteLine("\n=== PROGRAMMING CHALLENGE: COMBAT LOOP ===");
        Console.WriteLine("To fight, you need to write a while loop!");
        Console.WriteLine("Format: while (enemy.Health > 0 && player.Health > 0)");

        Console.Write("Your code: ");
        string whileLoop = Console.ReadLine().Trim();

        if (whileLoop.ToLower().Contains("while") &&
            whileLoop.ToLower().Contains("enemy.health > 0") &&
            whileLoop.ToLower().Contains("player.health > 0"))
        {
            Console.WriteLine("✓ Correct while loop! Combat begins!");

            while (enemy.Health > 0 && player.Health > 0)
            {
                Console.WriteLine("\n--- Combat Mode ---");
                Console.WriteLine($"Your Health: {player.Health} HP | {enemy.Name} Health: {enemy.Health} HP");
                Console.WriteLine($"Your Weapon: {(player.EquippedWeapon != null ? $"{player.EquippedWeapon.Name} (Damage: {player.EquippedWeapon.Damage}, Defense: {player.EquippedWeapon.Defense})" : "None")}");

                Console.WriteLine("\n=== PROGRAMMING CHALLENGE: COMBAT ACTION ===");
                Console.WriteLine("Choose your action by writing a method call:");
                Console.WriteLine("Attack() or Run()");

                Console.Write("Your code: ");
                string combatCode = Console.ReadLine().ToLower().Trim();

                if (combatCode == "attack();" || combatCode == "attack()")
                {
                    Console.WriteLine("✓ Correct method call!");
                    Console.WriteLine($"You attack the {enemy.Name} with your {player.EquippedWeapon.Name}!");
                    player.Attack(enemy);
                    Console.WriteLine($"{enemy.Name}'s health: {enemy.Health} HP");

                    if (enemy.Health <= 0)
                    {
                        Console.WriteLine($"You defeated the {enemy.Name}! Well done.");
                        break;
                    }

                    Console.WriteLine($"The {enemy.Name} attacks you!");
                    int baseDamage = Math.Max(0, enemy.Attack() - (player.EquippedWeapon?.Defense ?? 0));
                    int nightPenalty = player.TimeOfDay == TimeOfDay.Night ? 5 : 0;
                    int totalDamage = baseDamage + nightPenalty;
                    player.Health -= totalDamage;
                    Console.WriteLine($"Your {player.EquippedWeapon.Name} blocks {player.EquippedWeapon.Defense} damage!");
                    Console.WriteLine($"You take {totalDamage} damage{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Your health: {player.Health} HP");
                }
                else if (combatCode == "run();" || combatCode == "run()")
                {
                    Console.WriteLine("✓ Correct method call!");
                    Console.WriteLine("You attempt to run away!");
                    break;
                }
                else
                {
                    int basePenalty = 10;
                    int nightPenalty = player.TimeOfDay == TimeOfDay.Night ? 5 : 0;
                    int totalPenalty = basePenalty + nightPenalty;
                    player.Health = Math.Max(0, player.Health - totalPenalty);
                    Console.WriteLine("✗ Invalid method call. You hesitate!");
                    Console.WriteLine("The enemy gets a free attack!");
                    int damage = Math.Max(0, enemy.Attack() - (player.EquippedWeapon?.Defense ?? 0)) + nightPenalty;
                    player.Health -= damage;
                    Console.WriteLine($"Your {(player.EquippedWeapon != null ? player.EquippedWeapon.Name : "lack of weapon")} blocks {player.EquippedWeapon?.Defense ?? 0} damage!");
                    Console.WriteLine($"You take {damage} damage{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Your health: {player.Health} HP");
                    Console.WriteLine($"Health penalty: -{totalPenalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
                    if (player.Health <= 0)
                    {
                        break;
                    }
                }

                if (player.Health <= 0)
                {
                    break;
                }
            }
        }
        else
        {
            int basePenalty = 10;
            int nightPenalty = player.TimeOfDay == TimeOfDay.Night ? 5 : 0;
            int totalPenalty = basePenalty + nightPenalty;
            player.Health = Math.Max(0, player.Health - totalPenalty);
            Console.WriteLine("✗ Incorrect while loop. You're caught off-guard!");
            Console.WriteLine("The enemy gets a free attack!");
            int damage = Math.Max(0, enemy.Attack() - (player.EquippedWeapon?.Defense ?? 0)) + nightPenalty;
            player.Health -= damage;
            Console.WriteLine($"Your {(player.EquippedWeapon != null ? player.EquippedWeapon.Name : "lack of weapon")} blocks {player.EquippedWeapon?.Defense ?? 0} damage!");
            Console.WriteLine($"You take {damage} damage{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Your health: {player.Health} HP");
            Console.WriteLine($"Health penalty: -{totalPenalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
            if (player.Health <= 0)
            {
                Console.WriteLine("Game Over! You have died due to low health.");
                return;
            }
        }
    }

    static void ShowProgress(Player player)
    {
        int percentage = (int)((player.Distance / 1600.0) * 100);
        int bars = percentage / 10;
        string progressBar = "[" + new string('#', bars) + new string('-', 10 - bars) + "]";
        Console.WriteLine($"Progress to Durban: {progressBar} ({percentage}%)");
    }

    static void SaveGame(Player player)
    {
        string json = JsonConvert.SerializeObject(player);
        File.WriteAllText("savegame.json", json);
        Console.WriteLine("Your progress has been saved.");
    }

    static void DisplayAsciiArt(string character)
    {
        switch (character)
        {
            case "Goblin":
                Console.WriteLine(@"   ___
  /`   `\
 /_______\
 |  ***  | 
 |_______|");
                break;
            case "Captain":
                Console.WriteLine(@"   ___
  /| |\
  /| |\
 /_|_|_\
 |  ^  | 
 |_____|");
                break;
            case "FortuneTeller":
                Console.WriteLine(@"   ___
  / * * \
 /_______\
 |  ~  | 
 |_____|");
                break;
            case "CodeMaster":
                Console.WriteLine(@"   ___
  /| |\
  /| |\
 /_|_|_\
 |  O  | 
 |_____|");
                break;
        }
    }
}

enum TimeOfDay
{
    Day,
    Night
}

class Player
{
    public string Name { get; set; }
    public int Health { get; set; } = 100;
    public int Energy { get; set; } = 100;
    public int Distance { get; set; } = 0;
    public string ChosenWeapon { get; set; } = "";
    public Weapon EquippedWeapon { get; set; }
    public string CurrentLocation { get; set; } = "Cape Town: The Starting Shores";
    public List<Item> Inventory { get; set; } = new List<Item>
    {
        new Item { Name = "Bed", Type = ItemType.Tool },
        new Item { Name = "Meat", Type = ItemType.Consumable }
    };
    public bool HasDefeatedGoblinKing { get; set; } = false;
    public bool HasDefeatedWolfPackLeader { get; set; } = false;
    public bool HasDefeatedDragonApprentice { get; set; } = false;
    public bool HasDefeatedDragonMaster { get; set; } = false;
    public bool HasMetTrader { get; set; } = false;
    // Day/Night system properties
    public TimeOfDay TimeOfDay { get; set; } = TimeOfDay.Day;
    public int InteractionsInPhase { get; set; } = 0;
    public int MaxInteractionsInPhase { get; set; } = 3; // Default 3 for day/night

    public Player(string name)
    {
        Name = name;
    }

    public void AdvanceTime()
    {
        InteractionsInPhase++;
        if (InteractionsInPhase >= MaxInteractionsInPhase)
        {
            // Switch between day and night
            if (TimeOfDay == TimeOfDay.Day)
            {
                TimeOfDay = TimeOfDay.Night;
                MaxInteractionsInPhase = 3; // Reset to default for night
                Console.WriteLine("\nThe sun sets, and darkness falls. Night has begun.");
                Console.WriteLine("Traveling at night doubles your distance but increases danger!");
            }
            else
            {
                TimeOfDay = TimeOfDay.Day;
                MaxInteractionsInPhase = 3; // Reset to default for day
                Console.WriteLine("\nThe sun rises, bringing a new day. Morning has arrived.");
            }
            InteractionsInPhase = 0;
        }
    }

    public void Rest()
    {
        Energy = Math.Min(Energy + 20, 100);
        Console.WriteLine("You rested and regained 20 energy.");
        if (TimeOfDay == TimeOfDay.Night)
        {
            int remainingNightTurns = MaxInteractionsInPhase - InteractionsInPhase;
            TimeOfDay = TimeOfDay.Day;
            InteractionsInPhase = 0;
            MaxInteractionsInPhase = 3 + remainingNightTurns; // Extend day phase
            Console.WriteLine($"You wake up to a new morning! The remaining {remainingNightTurns} night actions extend your day.");
            Console.WriteLine($"Day phase now has {MaxInteractionsInPhase} actions.");
        }
    }

    public void CraftWeapon(Weapon weapon)
    {
        EquippedWeapon = weapon;
        Inventory.Add(new Item { Name = weapon.Name, Type = ItemType.Weapon });
    }

    public void Attack(Enemy enemy)
    {
        if (EquippedWeapon != null)
        {
            enemy.Health -= EquippedWeapon.Damage;
        }
    }

    public void Eat()
    {
        Item meat = Inventory.Find(item => item.Name == "Meat");
        if (meat != null)
        {
            Health = Math.Min(Health + 20, 100);
            Inventory.Remove(meat);
            Console.WriteLine("You ate meat and regained 20 health.");
        }
        else
        {
            Console.WriteLine("You don't have any meat to eat.");
        }
    }

    public void Hunt()
    {
        if (Energy >= 10)
        {
            Energy -= 10;
            Console.WriteLine("You hunted successfully and gained meat.");
            Inventory.Add(new Item { Name = "Meat", Type = ItemType.Consumable });
        }
        else
        {
            Console.WriteLine("You don't have enough energy to hunt.");
        }
    }

    public void PickUp(Item item)
    {
        Inventory.Add(item);
        Console.WriteLine($"Added {item.Name} to your inventory.");
    }

    public void UseItem()
    {
        Console.WriteLine("Which item would you like to use? (Enter the name, e.g., 'Health Potion'):");
        string itemName = Console.ReadLine().Trim();
        Item item = Inventory.Find(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));

        if (item == null)
        {
            Console.WriteLine("You don't have that item in your inventory.");
            return;
        }

        switch (item.Name.ToLower())
        {
            case "health potion":
                Health = Math.Min(Health + 30, 100);
                Inventory.Remove(item);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("You drink the Health Potion and regain 30 HP!");
                Console.ResetColor();
                break;
            case "map scroll":
                int nextLandmark = Program.GetNextLandmark(Distance); // Now accessible
                Console.WriteLine($"You unroll the Map Scroll and see the next landmark: {Program.MapLocations[nextLandmark]} at {nextLandmark} km.");
                Inventory.Remove(item);
                break;
            default:
                Console.WriteLine("That item cannot be used right now.");
                break;
        }
    }
}

class Weapon
{
    public string Name { get; set; }
    public int Damage { get; set; }
    public int Defense { get; set; }
}

class Item
{
    public string Name { get; set; }
    public ItemType Type { get; set; }
}

enum ItemType
{
    Consumable,
    Weapon,
    Tool,
    Material
}

class Enemy
{
    public int Health { get; set; }
    public string Name { get; set; }
    public EnemyType Type { get; set; }

    public int Attack()
    {
        switch (Type)
        {
            case EnemyType.Goblin: return 15;
            case EnemyType.Wolf: return 20;
            case EnemyType.Dragon: return 25;
            default: return 10;
        }
    }
}

enum EnemyType
{
    Goblin,
    Wolf,
    Dragon
}