using System;
using Newtonsoft.Json;
using System.IO;
using System.Threading;
using System.Collections.Generic;

class Program
{
    static Random random = new Random();

    static void Main()
    {
        // Prompt the player for their character name
        Console.WriteLine("Welcome to the Traveler's Journey - Programming Edition!");
        Console.WriteLine("In this game, you'll need to write code to perform actions!");
        Console.WriteLine("Before we begin, please enter your character's name:");
        string playerName = Console.ReadLine();

        // Initialize the player with the entered name
        Player player = new Player(playerName);

        // Intro to the Game
        Console.WriteLine($"Hello, {player.Name}! You are a traveler making your way from Cape Town to Durban (1600 km).");
        Console.WriteLine("Your inventory includes a bed, sword, and some meat.");
        Console.WriteLine("First, let's go through a tutorial to prepare you for the journey!");

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
        Console.WriteLine("In this tutorial, you'll learn how to craft a weapon for your journey.");
        Console.WriteLine("To choose your weapon, you must complete an if statement!");
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
                player.Health = Math.Max(0, player.Health - 10);
                Console.WriteLine("✗ Incorrect if statement. Try again!");
                Console.WriteLine("Format: if (choice == \"" + choiceNumber + "\")");
                Console.WriteLine($"Health penalty: -10 HP. Current health: {player.Health} HP");
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
                        player.Health = Math.Max(0, player.Health - 10);
                        Console.WriteLine("✗ Incorrect loop. Try again!");
                        Console.WriteLine("Format: for (int i = 0; i < 5; i++)");
                        Console.WriteLine($"Health penalty: -10 HP. Current health: {player.Health} HP");
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
                                objectCreated = true;
                                weaponCrafted = true;
                                correctTreeFound = true;
                            }
                            else
                            {
                                player.Health = Math.Max(0, player.Health - 10);
                                Console.WriteLine($"✗ Incorrect. Try again! Expected: {expectedCode}");
                                Console.WriteLine($"Make sure Name = \"{weaponChoice}\", Damage = {expectedDamage}, Defense = {expectedDefense}");
                                Console.WriteLine($"Health penalty: -10 HP. Current health: {player.Health} HP");
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
                        player.Health = Math.Max(0, player.Health - 10);
                        Console.WriteLine("✗ Incorrect string comparison. Try again!");
                        Console.WriteLine($"Format: if (treeType == \"{requiredWood}\")");
                        Console.WriteLine($"Health penalty: -10 HP. Current health: {player.Health} HP");
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
                player.Health = Math.Max(0, player.Health - 10);
                Console.WriteLine("✗ Incorrect method call. Try again!");
                Console.WriteLine("Format: EnterWoods();");
                Console.WriteLine($"Health penalty: -10 HP. Current health: {player.Health} HP");
                if (player.Health <= 0)
                {
                    Console.WriteLine("Game Over! You have died due to low health.");
                    return;
                }
            }
        }

        Console.WriteLine("\n=== JOURNEY BEGINS ===");
        Console.WriteLine("With your weapon crafted, the tutorial is over. Your goal is to survive the journey while managing your health, energy, and resources.");
        Console.WriteLine("You'll need to write code for each action!");

        while (player.Health > 0)
        {
            // Display Game Status
            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine($"Your Health: {player.Health} HP | Energy: {player.Energy} | Distance: {player.Distance} km");
            Console.WriteLine($"Weapon: {(player.EquippedWeapon != null ? $"{player.EquippedWeapon.Name} (Damage: {player.EquippedWeapon.Damage}, Defense: {player.EquippedWeapon.Defense})" : "None")}");
            Console.WriteLine($"Inventory: {string.Join(", ", player.Inventory.ConvertAll(item => item.Name))}");
            Console.WriteLine($"You're currently at: {player.CurrentLocation}. Your goal is to reach Durban (1600 km).");
            ShowProgress(player);

            Console.WriteLine("\n=== PROGRAMMING CHALLENGE: ACTION SELECTION ===");
            Console.WriteLine("To perform an action, write a method call:");
            Console.WriteLine("Available methods: Move(), Rest(), Eat(), Hunt(), PickUp(), Save()");
            Console.WriteLine("Format: MethodName();");

            // Player action input through programming
            Console.Write("Your code: ");
            string actionCode = Console.ReadLine().ToLower().Trim();

            if (actionCode == "move();" || actionCode == "move()")
            {
                // Movement challenge with Walk/Run variations
                Console.WriteLine("\n=== PROGRAMMING CHALLENGE: CHOOSE MOVEMENT TYPE ===");
                Console.WriteLine("You can move east toward Durban in two ways:");
                Console.WriteLine("- Walk: Costs 10 energy, progresses 100 km (~6%)");
                Console.WriteLine("- Run: Costs 25 energy, progresses 150 km (~9%)");
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
                            player.Distance += 100;
                            player.CurrentLocation = "En route to Durban";
                            Console.WriteLine("You walk east toward Durban, covering 100 km.");
                            Console.WriteLine("Energy cost: -10. Current energy: " + player.Energy);
                            RandomEvent(player);
                        }
                        else
                        {
                            Console.WriteLine("You don't have enough energy to walk! Need at least 10 energy.");
                        }
                    }
                    else if (moveType == "run")
                    {
                        if (player.Energy >= 25)
                        {
                            player.Energy -= 25;
                            player.Distance += 150;
                            player.CurrentLocation = "En route to Durban";
                            Console.WriteLine("You run east toward Durban, covering 150 km.");
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

                    if (player.Distance >= 1600)
                    {
                        Console.WriteLine("Congratulations! You've reached Durban!");
                        break;
                    }
                }
                else
                {
                    player.Health = Math.Max(0, player.Health - 10);
                    Console.WriteLine("✗ Incorrect move statement. Try again next time!");
                    Console.WriteLine($"Format: if (moveType == \"{moveType}\")");
                    Console.WriteLine($"Health penalty: -10 HP. Current health: {player.Health} HP");
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
            else
            {
                player.Health = Math.Max(0, player.Health - 10);
                Console.WriteLine("✗ Invalid method call. Try again!");
                Console.WriteLine("Remember: MethodName(); (like Move(), Rest(), etc.)");
                Console.WriteLine($"Health penalty: -10 HP. Current health: {player.Health} HP");
                if (player.Health <= 0)
                {
                    Console.WriteLine("Game Over! You have died due to low health.");
                    return;
                }
            }
        }

        if (player.Health <= 0)
        {
            Console.WriteLine("Game Over! You have died.");
        }
        Console.ReadLine();
    }

    static void RandomEvent(Player player)
    {
        int eventChance = random.Next(1, 101);
        if (eventChance <= 30) // 30% chance for combat
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
            Console.WriteLine("A storm hits! You lose 10 health.");
            player.Health -= 10;
        }
        else // 30% chance for nothing
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

            // Combat loop: the player and the enemy take turns
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

                    // Enemy's counterattack
                    Console.WriteLine($"The {enemy.Name} attacks you!");
                    int damage = Math.Max(0, enemy.Attack() - (player.EquippedWeapon?.Defense ?? 0));
                    player.Health -= damage;
                    Console.WriteLine($"Your {player.EquippedWeapon.Name} blocks {player.EquippedWeapon.Defense} damage!");
                    Console.WriteLine($"You take {damage} damage. Your health: {player.Health} HP");
                }
                else if (combatCode == "run();" || combatCode == "run()")
                {
                    Console.WriteLine("✓ Correct method call!");
                    Console.WriteLine("You attempt to run away!");
                    break;
                }
                else
                {
                    player.Health = Math.Max(0, player.Health - 10);
                    Console.WriteLine("✗ Invalid method call. You hesitate!");
                    Console.WriteLine("The enemy gets a free attack!");
                    int damage = Math.Max(0, enemy.Attack() - (player.EquippedWeapon?.Defense ?? 0));
                    player.Health -= damage;
                    Console.WriteLine($"Your {(player.EquippedWeapon != null ? player.EquippedWeapon.Name : "lack of weapon")} blocks {player.EquippedWeapon?.Defense ?? 0} damage!");
                    Console.WriteLine($"You take {damage} damage. Your health: {player.Health} HP");
                    Console.WriteLine($"Health penalty: -10 HP. Current health: {player.Health} HP");
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
            player.Health = Math.Max(0, player.Health - 10);
            Console.WriteLine("✗ Incorrect while loop. You're caught off-guard!");
            Console.WriteLine("The enemy gets a free attack!");
            int damage = Math.Max(0, enemy.Attack() - (player.EquippedWeapon?.Defense ?? 0));
            player.Health -= damage;
            Console.WriteLine($"Your {(player.EquippedWeapon != null ? player.EquippedWeapon.Name : "lack of weapon")} blocks {player.EquippedWeapon?.Defense ?? 0} damage!");
            Console.WriteLine($"You take {damage} damage. Your health: {player.Health} HP");
            Console.WriteLine($"Health penalty: -10 HP. Current health: {player.Health} HP");
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
}

class Player
{
    public string Name { get; set; }
    public int Health { get; set; } = 100;
    public int Energy { get; set; } = 100;
    public int Distance { get; set; } = 0;
    public string ChosenWeapon { get; set; } = "";
    public Weapon EquippedWeapon { get; set; }
    public string CurrentLocation { get; set; } = "Cape Town";
    public List<Item> Inventory { get; set; } = new List<Item>
    {
        new Item { Name = "Bed", Type = ItemType.Tool },
        new Item { Name = "Meat", Type = ItemType.Consumable }
    };

    public Player(string name)
    {
        Name = name;
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

    public void Rest()
    {
        Energy = Math.Min(Energy + 20, 100);
        Console.WriteLine("You rested and regained 20 energy.");
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
        return Type == EnemyType.Goblin ? 15 : 20;
    }
}

enum EnemyType
{
    Goblin,
    Wolf
}