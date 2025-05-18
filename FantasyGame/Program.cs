using System;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Collections.Generic;

class Program
{
    public static Random random = new Random();
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
        Console.WriteLine("Welcome to the Traveler's Journey - Programming Edition!");
        Console.WriteLine("Embark on an epic quest from Cape Town to Durban, mastering the art of coding!");
        Console.WriteLine("Before we begin, please enter your character's name:");
        string playerName = Console.ReadLine();

        Player player = new Player(playerName);

        Console.WriteLine($"\nGreetings, {player.Name}! You are a brave traveler on a quest from Cape Town to Durban (1600 km).");
        Console.WriteLine("Your journey will test your coding skills as you face challenges and foes.");
        Console.WriteLine("Your inventory contains a bed, a sword, some meat, and new potions. More treasures await!");
        Console.WriteLine("The sun rises as you begin your journey. Be mindful of day and night!");
        Console.WriteLine("Daytime lasts for 3 actions, and night lasts for 3 actions.");
        Console.WriteLine("Traveling at night doubles your distance but increases danger.");
        Console.WriteLine("Resting at night will advance time to morning, adding remaining night turns to your day!");
        Console.WriteLine("First, let's prepare you with a tutorial.");

        Console.WriteLine("\n=== TUTORIAL: CREATE YOUR HEALTH VARIABLE ===");
        Console.WriteLine("To start your journey, you need to declare your health variable!");
        Console.WriteLine("Write the code to declare an integer variable called 'health' with value 100:");
        Console.WriteLine("Example format: int variableName = value;");

        bool healthCreated = false;
        while (!healthCreated)
        {
            Console.Write("Your code: ");
            string healthCode = Console.ReadLine().Trim();

            if (healthCode.ToLower() == "int health = 100;" || healthCode.ToLower() == "int health=100;")
            {
                Console.WriteLine("✓ Correct! Your health is now set to 100!");
                healthCreated = true;
            }
            else
            {
                player.Health = Math.Max(0, player.Health - 10);
                Console.WriteLine("✗ Incorrect. Try again! Format: int health = 100;");
                Console.WriteLine($"Health penalty: -10 HP. Current health: {player.Health} HP");
                if (player.Health <= 0) { Console.WriteLine("Game Over! You have died due to low health."); return; }
            }
        }

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

        while (!validChoice)
        {
            Console.WriteLine($"Now write the if statement for choice {choiceNumber}:");
            Console.Write("Your code: ");
            string ifStatement = Console.ReadLine().Trim();

            string expectedIf = $"if (choice == \"{choiceNumber}\")";
            string expectedIf2 = $"if(choice == \"{choiceNumber}\")";
            string expectedIf3 = $"if (choice==\"{choiceNumber}\")";
            string expectedIf4 = $"if(choice==\"{choiceNumber}\")";

            if (ifStatement.ToLower().Contains(expectedIf.ToLower()) || ifStatement.ToLower().Contains(expectedIf2.ToLower()) ||
                ifStatement.ToLower().Contains(expectedIf3.ToLower()) || ifStatement.ToLower().Contains(expectedIf4.ToLower()))
            {
                Console.WriteLine("✓ Correct if statement structure!");
                if (choiceNumber == "1") { weaponChoice = "Sword"; requiredWood = "Oak"; validChoice = true; Console.WriteLine("Nice choice! A sword is a versatile weapon."); }
                else if (choiceNumber == "2") { weaponChoice = "Bow"; requiredWood = "Pine"; validChoice = true; Console.WriteLine("Excellent! A bow allows for ranged attacks."); }
                else if (choiceNumber == "3") { weaponChoice = "Spear"; requiredWood = "Birch"; validChoice = true; Console.WriteLine("Great choice! A spear has good reach and power."); }
                else if (choiceNumber == "4") { weaponChoice = "Axe"; requiredWood = "Maple"; validChoice = true; Console.WriteLine("Powerful choice! An axe deals heavy damage."); }
                else { Console.WriteLine("Invalid choice number! Please choose 1-4."); Console.WriteLine("What's your choice number (1-4)?"); choiceNumber = Console.ReadLine(); }
            }
            else
            {
                int penalty = player.TimeOfDay == TimeOfDay.Night ? 15 : 10;
                player.Health = Math.Max(0, player.Health - penalty);
                Console.WriteLine("✗ Incorrect if statement. Try again!");
                Console.WriteLine("Format: if (choice == \"" + choiceNumber + "\")");
                Console.WriteLine($"Health penalty: -{penalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
                if (player.Health <= 0) { Console.WriteLine("Game Over! You have died due to low health."); return; }
            }
        }

        Console.WriteLine($"For that you will need {requiredWood} Wood!");
        Console.WriteLine("To go to the woods, you need to write a method call!");
        Console.WriteLine("Let's continue the tutorial by gathering the wood.");

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
                        Console.WriteLine("Executing your loop...");
                        for (int i = 0; i < 5; i++) { Console.WriteLine($"Checking tree {i + 1}..."); Thread.Sleep(500); }
                    }
                    else
                    {
                        int penalty = player.TimeOfDay == TimeOfDay.Night ? 15 : 10;
                        player.Health = Math.Max(0, player.Health - penalty);
                        Console.WriteLine("✗ Incorrect loop. Try again!");
                        Console.WriteLine("Format: for (int i = 0; i < 5; i++)");
                        Console.WriteLine($"Health penalty: -{penalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
                        if (player.Health <= 0) { Console.WriteLine("Game Over! You have died due to low health."); return; }
                    }
                }

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

                    if (comparison.ToLower() == expectedComparison || comparison.ToLower() == expectedComparison2 ||
                        comparison.ToLower() == expectedComparison3 || comparison.ToLower().Contains($"treetype == \"{requiredWood.ToLower()}\""))
                    {
                        Console.WriteLine("✓ Correct string comparison!");
                        Console.WriteLine($"Perfect! You found the {requiredWood} tree!");
                        Console.WriteLine("*CHOP* *CHOP* *CHOP*");
                        Console.WriteLine($"You successfully cut down the {requiredWood} tree and collected {requiredWood} Wood!");
                        player.Inventory.Add(new Item { Name = requiredWood + " Wood", Type = ItemType.Material });

                        Console.WriteLine("\n=== TUTORIAL: CREATE WEAPON OBJECT ===");
                        Console.WriteLine($"Now craft your {weaponChoice} by creating a Weapon object!");
                        Console.WriteLine("The Weapon class has properties: Name (string), Damage (int), Defense (int).");
                        Console.WriteLine($"Write code to create a {weaponChoice} with appropriate values:");
                        Console.WriteLine($"Example: Weapon sword = new Weapon {{ Name = \"Sword\", Damage = 25, Defense = 10 }};");
                        Console.WriteLine($"Suggested values for {weaponChoice}:");
                        string expectedCode = ""; int expectedDamage = 0; int expectedDefense = 0;
                        switch (weaponChoice)
                        {
                            case "Sword": Console.WriteLine("Damage: 25, Defense: 10"); expectedCode = $"weapon sword = new weapon {{ name = \"sword\", damage = 25, defense = 10 }}"; expectedDamage = 25; expectedDefense = 10; break;
                            case "Bow": Console.WriteLine("Damage: 20, Defense: 5"); expectedCode = $"weapon bow = new weapon {{ name = \"bow\", damage = 20, defense = 5 }}"; expectedDamage = 20; expectedDefense = 5; break;
                            case "Spear": Console.WriteLine("Damage: 22, Defense: 8"); expectedCode = $"weapon spear = new weapon {{ name = \"spear\", damage = 22, defense = 8 }}"; expectedDamage = 22; expectedDefense = 8; break;
                            case "Axe": Console.WriteLine("Damage: 30, Defense: 12"); expectedCode = $"weapon axe = new weapon {{ name = \"axe\", damage = 30, defense = 12 }}"; expectedDamage = 30; expectedDefense = 12; break;
                        }

                        bool objectCreated = false;
                        while (!objectCreated)
                        {
                            Console.Write("Your code: ");
                            string objectCode = Console.ReadLine().Trim().ToLower();
                            string normalizedInput = objectCode.Replace(" ", "").Replace("{", " { ").Replace("}", " } ");
                            string normalizedExpected = expectedCode.Replace(" ", "").Replace("{", " { ").Replace("}", " } ");

                            if (normalizedInput.Contains($"newweapon{{name=\"{weaponChoice.ToLower()}\",damage={expectedDamage},defense={expectedDefense}}}") ||
                                normalizedInput.Contains($"newweapon{{name=\"{weaponChoice.ToLower()}\",defense={expectedDefense},damage={expectedDamage}}}"))
                            {
                                Console.WriteLine("✓ Correct! You created your weapon!");
                                player.CraftWeapon(new Weapon { Name = weaponChoice, Damage = expectedDamage, Defense = expectedDefense });
                                Console.WriteLine($"\n=== TUTORIAL: CRAFTING {weaponChoice.ToUpper()} ===");
                                Console.WriteLine("Crafting in progress...");
                                for (int i = 1; i <= 3; i++) { Console.WriteLine($"Crafting... {i}/3"); Thread.Sleep(1000); }
                                Console.WriteLine($"SUCCESS! You have crafted a {weaponChoice}!");
                                Console.WriteLine("Tutorial complete! You're now ready to begin your journey.");
                                player.Inventory.Add(new Item { Name = "Health Potion", Type = ItemType.Consumable });
                                player.Inventory.Add(new Item { Name = "Map Scroll", Type = ItemType.Tool });
                                player.Inventory.Add(new Item { Name = "Health Regen Potion", Type = ItemType.Consumable });
                                player.Inventory.Add(new Item { Name = "Instant Kill Potion", Type = ItemType.Consumable });
                                player.Inventory.Add(new Item { Name = "Defense Boost Potion", Type = ItemType.Consumable });
                                player.Inventory.Add(new Item { Name = "Revival Potion", Type = ItemType.Consumable });
                                Console.WriteLine("You also find a Health Potion, Map Scroll, and new potions in your bag!");
                                objectCreated = true; weaponCrafted = true; correctTreeFound = true;
                            }
                            else
                            {
                                int penalty = player.TimeOfDay == TimeOfDay.Night ? 15 : 10;
                                player.Health = Math.Max(0, player.Health - penalty);
                                Console.WriteLine($"✗ Incorrect. Try again! Expected: {expectedCode}");
                                Console.WriteLine($"Make sure Name = \"{weaponChoice}\", Damage = {expectedDamage}, Defense = {expectedDefense}");
                                Console.WriteLine($"Health penalty: -{penalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
                                if (player.Health <= 0) { Console.WriteLine("Game Over! You have died due to low health."); return; }
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
                        if (player.Health <= 0) { Console.WriteLine("Game Over! You have died due to low health."); return; }
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
                if (player.Health <= 0) { Console.WriteLine("Game Over! You have died due to low health."); return; }
            }
            player.AdvanceTime();
        }

        Console.WriteLine("\n=== JOURNEY BEGINS ===");
        Console.WriteLine("With your weapon crafted, the tutorial is over. Your goal is to reach Durban and prove your coding skills!");
        Console.WriteLine("You'll face mighty foes and discover legendary locations along the way.");

        while (player.Health > 0 || player.RevivalUsed)
        {
            UpdateLocation(player);

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

            Console.Write("Your code: ");
            string actionCode = Console.ReadLine().ToLower().Trim();

            if (actionCode == "move();" || actionCode == "move()")
            {
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

                if (moveCode.ToLower().Contains("if") && moveCode.ToLower().Contains($"moveType == \"{moveType}\""))
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
                        else { Console.WriteLine("You don't have enough energy to run! Need at least 25 energy."); }
                    }
                    else { Console.WriteLine("Invalid movement type! Use 'walk' or 'run'."); }
                }
                else
                {
                    int penalty = player.TimeOfDay == TimeOfDay.Night ? 15 : 10;
                    player.Health = Math.Max(0, player.Health - penalty);
                    Console.WriteLine("✗ Incorrect move statement. Try again next time!");
                    Console.WriteLine($"Format: if (moveType == \"{moveType}\")");
                    Console.WriteLine($"Health penalty: -{penalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
                    if (player.Health <= 0) { Console.WriteLine("Game Over! You have died due to low health."); return; }
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
                Console.WriteLine("You find a Stealth Potion and add it to your inventory.");
                player.PickUp(new Item { Name = "Stealth Potion", Type = ItemType.Consumable });
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
                if (player.Health <= 0) { Console.WriteLine("Game Over! You have died due to low health."); return; }
            }

            player.AdvanceTime();

            if (player.Distance >= 600 && player.Distance < 800 && !player.HasMetTrader)
            {
                Console.WriteLine("\n=== ENCOUNTER: WANDERING TRADER ===");
                Console.WriteLine("A cheerful trader approaches you on the path.");
                Console.WriteLine("'Greetings, traveler! I can teach you a trick for a price.'");
                Console.WriteLine("'Write a loop to count my 4 wares, and I’ll give you a Frostbite Potion!'");
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
                        player.PickUp(new Item { Name = "Frostbite Potion", Type = ItemType.Consumable });
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
                        if (player.Health <= 0) { Console.WriteLine("Game Over! The trader’s disappointment was too much."); return; }
                    }
                }
                player.AdvanceTime();
            }
        }

        if (player.Health <= 0 && !player.RevivalUsed) { Console.WriteLine("Game Over! You have died."); }
        Console.ReadLine();
    }

    static void UpdateLocation(Player player)
    {
        foreach (var location in MapLocations)
        {
            if (player.Distance >= location.Key) { player.CurrentLocation = location.Value; }
            else { break; }
        }
        if (!MapLocations.ContainsKey(player.Distance) && player.Distance < 1600)
        {
            player.CurrentLocation = "En route to " + MapLocations[GetNextLandmark(player.Distance)];
        }
    }

    public static int GetNextLandmark(int distance)
    {
        foreach (var location in MapLocations.Keys)
        {
            if (location > distance) { return location; }
        }
        return 1600;
    }

    static void RandomEvent(Player player)
    {
        if (player.StealthActive) { Console.WriteLine("You remain hidden from enemies thanks to stealth!"); return; }

        int enemyChance = player.TimeOfDay == TimeOfDay.Day ? 30 : 50;
        int eventChance = Program.random.Next(1, 101);
        if (eventChance <= enemyChance)
        {
            Enemy enemy = Program.random.Next(2) == 0 ? new Enemy { Health = 50, Name = "Goblin", Type = EnemyType.Goblin } : new Enemy { Health = 60, Name = "Wolf", Type = EnemyType.Wolf };
            Console.WriteLine($"A wild {enemy.Name} appears!");
            StartEncounterCombat(player, enemy); // Fixed: Call the correct method
        }
        else if (eventChance <= 50)
        {
            Item item = new Item { Name = "Meat", Type = ItemType.Consumable };
            Console.WriteLine($"You found a {item.Name}!");
            player.PickUp(item);
        }
        else if (eventChance <= 70)
        {
            int stormDamage = player.TimeOfDay == TimeOfDay.Night ? 15 : 10;
            Console.WriteLine($"A storm hits! You lose {stormDamage} health.");
            player.Health -= stormDamage;
            if (player.TimeOfDay == TimeOfDay.Night) { Console.WriteLine("(Night penalty: +5 damage)"); }
        }
        else if (eventChance <= 85)
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
            else { Console.WriteLine("You ignore the traveler and continue your journey."); }
        }
        else { Console.WriteLine("The journey is uneventful."); }
    }

    static void StartEncounterCombat(Player player, Enemy enemy)
    {
        EncounterCombat.CurrentEnemy = enemy;

        Console.WriteLine("\n=== PROGRAMMING CHALLENGE: COMBAT LOOP ===");
        Console.WriteLine("To fight, you need to write a while loop!");
        Console.WriteLine("Format: while (enemy.Health > 0 && player.Health > 0)");

        Console.Write("Your code: ");
        string whileLoop = Console.ReadLine().Trim();

        if (whileLoop.ToLower().Contains("while") && whileLoop.ToLower().Contains("enemy.health > 0") && whileLoop.ToLower().Contains("player.health > 0"))
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
                        DropRandomPotion(player); // Add potion drop
                        break;
                    }

                    Console.WriteLine($"The {enemy.Name} attacks you!");
                    int baseDamage = Math.Max(0, enemy.Attack() - (player.DefenseBoost > 0 ? (int)(player.EquippedWeapon.Defense * 1.5) : player.EquippedWeapon?.Defense ?? 0));
                    int nightPenalty = player.TimeOfDay == TimeOfDay.Night ? 5 : 0;
                    int totalDamage = baseDamage + nightPenalty;
                    player.Health -= totalDamage;
                    Console.WriteLine($"Your {player.EquippedWeapon.Name} blocks {(player.DefenseBoost > 0 ? (int)(player.EquippedWeapon.Defense * 1.5) : player.EquippedWeapon?.Defense ?? 0)} damage!");
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
                    int damage = Math.Max(0, enemy.Attack() - (player.DefenseBoost > 0 ? (int)(player.EquippedWeapon.Defense * 1.5) : player.EquippedWeapon?.Defense ?? 0)) + nightPenalty;
                    player.Health -= damage;
                    Console.WriteLine($"Your {(player.EquippedWeapon != null ? player.EquippedWeapon.Name : "lack of weapon")} blocks {(player.DefenseBoost > 0 ? (int)(player.EquippedWeapon.Defense * 1.5) : player.EquippedWeapon?.Defense ?? 0)} damage!");
                    Console.WriteLine($"You take {damage} damage{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Your health: {player.Health} HP");
                    Console.WriteLine($"Health penalty: -{totalPenalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
                    if (player.Health <= 0) break;
                }

                if (player.Health <= 0)
                {
                    if (player.RevivalPotion && !player.RevivalUsed)
                    {
                        Console.WriteLine("You feel a surge of energy from the Revival Potion!");
                        player.Revive();
                    }
                    else break;
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
            int damage = Math.Max(0, enemy.Attack() - (player.DefenseBoost > 0 ? (int)(player.EquippedWeapon.Defense * 1.5) : player.EquippedWeapon?.Defense ?? 0)) + nightPenalty;
            player.Health -= damage;
            Console.WriteLine($"Your {(player.EquippedWeapon != null ? player.EquippedWeapon.Name : "lack of weapon")} blocks {(player.DefenseBoost > 0 ? (int)(player.EquippedWeapon.Defense * 1.5) : player.EquippedWeapon?.Defense ?? 0)} damage!");
            Console.WriteLine($"You take {damage} damage{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Your health: {player.Health} HP");
            Console.WriteLine($"Health penalty: -{totalPenalty} HP{(player.TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {player.Health} HP");
            if (player.Health <= 0)
            {
                if (player.RevivalPotion && !player.RevivalUsed)
                {
                    Console.WriteLine("You feel a surge of energy from the Revival Potion!");
                    player.Revive();
                }
                else
                {
                    Console.WriteLine("Game Over! You have died due to low health.");
                    return;
                }
            }
        }

        EncounterCombat.CurrentEnemy = null;
    }

    static void DropRandomPotion(Player player)
    {
        if (Program.random.Next(100) < 50) // 50% chance
        {
            string[] potions = new string[] { /* ... */ };
            string selectedPotion = potions[Program.random.Next(potions.Length)];
            Item potionItem = new Item { Name = selectedPotion, Type = ItemType.Consumable };
            player.PickUp(potionItem);
        }
        else
        {
            Console.WriteLine("The enemy dropped nothing of value.");
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
            case "Goblin": Console.WriteLine(@"   ___  /`   `\ /_______\ |  ***  | |_______|"); break;
            case "Captain": Console.WriteLine(@"   ___  /| |\ /| |\ /_|_|\ |  ^  | |_____|"); break;
            case "FortuneTeller": Console.WriteLine(@"   ___  / * * \/_______\ |  ~  | |_____|"); break;
            case "CodeMaster": Console.WriteLine(@"   ___  /| |\ /| |\ /_|_|\ |  O  | |_____|"); break;
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
    public TimeOfDay TimeOfDay { get; set; } = TimeOfDay.Day;
    public int InteractionsInPhase { get; set; } = 0;
    public int MaxInteractionsInPhase { get; set; } = 3;
    public int DefenseBoost { get; set; } = 0;
    public int DefenseBoostTurns { get; set; } = 0;
    public bool StealthActive { get; set; } = false;
    public int StealthTurns { get; set; } = 0;
    public bool RevivalPotion { get; set; } = true;
    public bool RevivalUsed { get; set; } = false;

    public Player(string name) { Name = name; }

    public void AdvanceTime()
    {
        InteractionsInPhase++;
        if (DefenseBoostTurns > 0) { DefenseBoostTurns--; if (DefenseBoostTurns == 0) { DefenseBoost = 0; Console.WriteLine("Defense boost has worn off."); } }
        if (StealthTurns > 0) { StealthTurns--; if (StealthTurns == 0) { StealthActive = false; Console.WriteLine("Stealth has worn off."); } }
        if (InteractionsInPhase >= MaxInteractionsInPhase)
        {
            if (TimeOfDay == TimeOfDay.Day)
            {
                TimeOfDay = TimeOfDay.Night;
                MaxInteractionsInPhase = 3;
                Console.WriteLine("\nThe sun sets, and darkness falls. Night has begun.");
                Console.WriteLine("Traveling at night doubles your distance but increases danger!");
            }
            else
            {
                TimeOfDay = TimeOfDay.Day;
                MaxInteractionsInPhase = 3;
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
            MaxInteractionsInPhase = 3 + remainingNightTurns;
            Console.WriteLine($"You wake up to a new morning! The remaining {remainingNightTurns} night actions extend your day.");
            Console.WriteLine($"Day phase now has {MaxInteractionsInPhase} actions.");
        }
    }

    public void CraftWeapon(Weapon weapon)
    {
        EquippedWeapon = weapon;
        Inventory.Add(new Item { Name = weapon.Name, Type = ItemType.Weapon });
    }

    public void Attack(Enemy enemy) { if (EquippedWeapon != null) { enemy.Health -= EquippedWeapon.Damage; } }

    public void Eat()
    {
        Item meat = Inventory.Find(item => item.Name == "Meat");
        if (meat != null)
        {
            Health = Math.Min(Health + 20, 100);
            Inventory.Remove(meat);
            Console.WriteLine("You ate meat and regained 20 health.");
        }
        else { Console.WriteLine("You don't have any meat to eat."); }
    }

    public void Hunt()
    {
        if (Energy >= 10)
        {
            Energy -= 10;
            Console.WriteLine("You hunted successfully and gained meat.");
            Inventory.Add(new Item { Name = "Meat", Type = ItemType.Consumable });
        }
        else { Console.WriteLine("You don't have enough energy to hunt."); }
    }

    public void PickUp(Item item)
    {
        Inventory.Add(item);
        Console.WriteLine($"Added {item.Name} to your inventory.");
    }

    public void UseItem()
    {
        Console.WriteLine("Which item would you like to use? (Enter the name, e.g., 'Health Regen Potion'):");
        string itemName = Console.ReadLine().Trim();
        Item item = Inventory.Find(i => i.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));

        if (item == null) { Console.WriteLine("You don't have that item in your inventory."); return; }

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
                int nextLandmark = Program.GetNextLandmark(Distance);
                Console.WriteLine($"You unroll the Map Scroll and see the next landmark: {Program.MapLocations[nextLandmark]} at {nextLandmark} km.");
                Inventory.Remove(item);
                break;
            case "health regen potion":
                Console.WriteLine("\n=== PROGRAMMING CHALLENGE: ACTIVATE HEALTH REGEN ===");
                Console.WriteLine("Write a for loop to apply health regen over 6 intervals (5 HP every 5 seconds):");
                Console.WriteLine("Format: for (int i = 0; i < 6; i++)");
                Console.Write("Your code: ");
                string regenLoop = Console.ReadLine().Trim();
                if (regenLoop.ToLower().Contains("for") && regenLoop.ToLower().Contains("int i") && regenLoop.ToLower().Contains("i < 6") && regenLoop.ToLower().Contains("i++"))
                {
                    Console.WriteLine("✓ Correct loop! Health regeneration begins...");
                    for (int i = 0; i < 6; i++) { Health = Math.Min(Health + 5, 100); Console.WriteLine($"Regenerated 5 HP. Current health: {Health} HP"); Thread.Sleep(5000); }
                    Inventory.Remove(item);
                }
                else
                {
                    int penalty = TimeOfDay == TimeOfDay.Night ? 15 : 10;
                    Health = Math.Max(0, Health - penalty);
                    Console.WriteLine("✗ Incorrect loop. Health regen failed!");
                    Console.WriteLine($"Format: for (int i = 0; i < 6; i++)");
                    Console.WriteLine($"Health penalty: -{penalty} HP{(TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {Health} HP");
                }
                break;
            case "instant kill potion":
                Console.WriteLine("\n=== PROGRAMMING CHALLENGE: ACTIVATE INSTANT KILL ===");
                Console.WriteLine("Write an if statement to confirm the kill:");
                Console.WriteLine("Format: if (enemy.Health > 0)");
                Console.Write("Your code: ");
                string killIf = Console.ReadLine().Trim();
                if (killIf.ToLower().Contains("if") && killIf.ToLower().Contains("enemy.health > 0"))
                {
                    Console.WriteLine("✓ Correct if statement! Instant kill activated!");
                    if (EncounterCombat.CurrentEnemy != null) { EncounterCombat.CurrentEnemy.Health = 0; Console.WriteLine("Enemy defeated instantly!"); }
                    else { Console.WriteLine("No enemy to kill!"); }
                    Inventory.Remove(item);
                }
                else
                {
                    int penalty = TimeOfDay == TimeOfDay.Night ? 15 : 10;
                    Health = Math.Max(0, Health - penalty);
                    Console.WriteLine("✗ Incorrect if statement. Instant kill failed!");
                    Console.WriteLine("Format: if (enemy.Health > 0)");
                    Console.WriteLine($"Health penalty: -{penalty} HP{(TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {Health} HP");
                }
                break;
            case "defense boost potion":
                Console.WriteLine("\n=== PROGRAMMING CHALLENGE: ACTIVATE DEFENSE BOOST ===");
                Console.WriteLine("Write a method to apply a defense boost for 5 turns:");
                Console.WriteLine("Format: public void BoostDefense() { DefenseBoost = 1; DefenseBoostTurns = 5; }");
                Console.Write("Your code: ");
                string boostMethod = Console.ReadLine().Trim();
                if (boostMethod.ToLower().Contains("public void boostdefense") && boostMethod.ToLower().Contains("defenseboost = 1") && boostMethod.ToLower().Contains("defenseboostturns = 5"))
                {
                    Console.WriteLine("✓ Correct method! Defense boost activated!");
                    DefenseBoost = 1;
                    DefenseBoostTurns = 5;
                    Inventory.Remove(item);
                    Console.WriteLine("Your defense is now boosted by 50% for 5 turns.");
                }
                else
                {
                    int penalty = TimeOfDay == TimeOfDay.Night ? 15 : 10;
                    Health = Math.Max(0, Health - penalty);
                    Console.WriteLine("✗ Incorrect method. Defense boost failed!");
                    Console.WriteLine("Format: public void BoostDefense() { DefenseBoost = 1; DefenseBoostTurns = 5; }");
                    Console.WriteLine($"Health penalty: -{penalty} HP{(TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {Health} HP");
                }
                break;
            case "revival potion":
                if (!RevivalUsed)
                {
                    Console.WriteLine("\n=== PROGRAMMING CHALLENGE: ACTIVATE REVIVAL ===");
                    Console.WriteLine("Write a method to prepare for revival:");
                    Console.WriteLine("Format: public void PrepareRevival() { RevivalUsed = false; }");
                    Console.Write("Your code: ");
                    string reviveMethod = Console.ReadLine().Trim();
                    if (reviveMethod.ToLower().Contains("public void preparerevival") && reviveMethod.ToLower().Contains("revivalused = false"))
                    {
                        Console.WriteLine("✓ Correct method! Revival potion prepared!");
                        RevivalUsed = false;
                        Inventory.Remove(item);
                        Console.WriteLine("Revival potion added to your reserves. It will activate on your next death.");
                    }
                    else
                    {
                        int penalty = TimeOfDay == TimeOfDay.Night ? 15 : 10;
                        Health = Math.Max(0, Health - penalty);
                        Console.WriteLine("✗ Incorrect method. Revival preparation failed!");
                        Console.WriteLine("Format: public void PrepareRevival() { RevivalUsed = false; }");
                        Console.WriteLine($"Health penalty: -{penalty} HP{(TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {Health} HP");
                    }
                }
                else { Console.WriteLine("Revival potion has already been used!"); }
                break;
            case "stealth potion":
                Console.WriteLine("\n=== PROGRAMMING CHALLENGE: ACTIVATE STEALTH ===");
                Console.WriteLine("Write a nested loop to check a 2x2 grid for safety:");
                Console.WriteLine("Format: for (int i = 0; i < 2; i++) { for (int j = 0; j < 2; j++) { } }");
                Console.Write("Your code: ");
                string stealthLoop = Console.ReadLine().Trim();
                if (stealthLoop.ToLower().Contains("for") && stealthLoop.ToLower().Contains("int i") && stealthLoop.ToLower().Contains("i < 2") &&
                    stealthLoop.ToLower().Contains("for") && stealthLoop.ToLower().Contains("int j") && stealthLoop.ToLower().Contains("j < 2") && stealthLoop.Count(c => c == '{') >= 2)
                {
                    Console.WriteLine("✓ Correct nested loop! Stealth activated!");
                    StealthActive = true;
                    StealthTurns = 2;
                    Inventory.Remove(item);
                    Console.WriteLine("You are invisible to enemies for 2 turns.");
                }
                else
                {
                    int penalty = TimeOfDay == TimeOfDay.Night ? 15 : 10;
                    Health = Math.Max(0, Health - penalty);
                    Console.WriteLine("✗ Incorrect loop. Stealth failed!");
                    Console.WriteLine("Format: for (int i = 0; i < 2; i++) { for (int j = 0; j < 2; j++) { } }");
                    Console.WriteLine($"Health penalty: -{penalty} HP{(TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {Health} HP");
                }
                break;
            case "frostbite potion":
                Console.WriteLine("\n=== PROGRAMMING CHALLENGE: ACTIVATE FROSTBITE ===");
                Console.WriteLine("Write a 2D array to freeze the enemy grid:");
                Console.WriteLine("Format: int[,] frost = new int[2,2];");
                Console.Write("Your code: ");
                string frostArray = Console.ReadLine().Trim();
                if (frostArray.ToLower().Contains("int[,]") && frostArray.ToLower().Contains("new int[2,2]"))
                {
                    Console.WriteLine("✓ Correct array! Frostbite activated!");
                    if (EncounterCombat.CurrentEnemy != null)
                    {
                        int freezeTurns = Program.random.Next(1, 3);
                        EncounterCombat.CurrentEnemy.FreezeTurns = freezeTurns;
                        Console.WriteLine($"Enemy frozen for {freezeTurns} turn(s)!");
                    }
                    else { Console.WriteLine("No enemy to freeze!"); }
                    Inventory.Remove(item);
                }
                else
                {
                    int penalty = TimeOfDay == TimeOfDay.Night ? 15 : 10;
                    Health = Math.Max(0, Health - penalty);
                    Console.WriteLine("✗ Incorrect array. Frostbite failed!");
                    Console.WriteLine("Format: int[,] frost = new int[2,2];");
                    Console.WriteLine($"Health penalty: -{penalty} HP{(TimeOfDay == TimeOfDay.Night ? " (Night penalty +5)" : "")}. Current health: {Health} HP");
                }
                break;
            default: Console.WriteLine("That item cannot be used right now."); break;
        }
    }

    public void Revive()
    {
        Health = 50;
        RevivalUsed = true;
        RevivalPotion = false;
        Console.WriteLine("Revived with 50 HP! Revival potion consumed.");
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
    public int FreezeTurns { get; set; } = 0;

    public int Attack()
    {
        if (FreezeTurns > 0) { FreezeTurns--; Console.WriteLine("Enemy is frozen and cannot attack!"); return 0; }
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

static class EncounterCombat
{
    public static Enemy CurrentEnemy { get; set; }
}