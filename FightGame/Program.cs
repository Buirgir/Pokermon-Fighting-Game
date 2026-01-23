using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Xml.Serialization;

//PseudoKod
//Jag planerar att skapa ett fighting spel som är lite som en parodi av pokemon. 
//Jag vill att man ska ha flera moves och att spelet ska progressivt bli svårare.

//Skapar ints
int maxPokermonHealth = 100;
int pokermonHealth = 100;
int pokermonDamage = Random.Shared.Next(4, 7);
int maxMP = 100;
int MP = 100;
int enemyMaxHealth = 50;
int enemyHealth = 50;
int baseDamage = 0;
int enemyBaseDamage = 0;
int enemyDamage = Random.Shared.Next(5, 10);
int enemyAction = 0;
int defeatedPokemonCount = 0;



// Introduktion

Console.WriteLine("Welcome to Pokermon!");
Thread.Sleep(1000);
Console.WriteLine("This is a very origional fighting game");
Thread.Sleep(1000);
Console.WriteLine("Whats your name?");
Console.ReadLine();
Console.WriteLine("Enter the number corresponding to the action you wish to take");
Console.WriteLine("Pick your starter pokermon");
Console.WriteLine("1. Pikershoe");
Console.WriteLine("2. Charrymander");
Console.WriteLine("3. Quirtle");

//Naming system after player input
string chosenPokermon = Console.ReadLine();
while (chosenPokermon != "1" && chosenPokermon != "2" && chosenPokermon != "3")
{
    Console.WriteLine("Invalid choice, Please try again");
    chosenPokermon = Console.ReadLine();
}
Int32.TryParse(chosenPokermon, out int PokermonInt);
PokermonInt --;
Thread.Sleep(1000);

//Loading
Console.WriteLine("Do you wish to 1.Load a save 2.Start a new save");
string loadSave = Console.ReadLine();
while (loadSave != "1" && loadSave != "2")
{
    Console.WriteLine("Invalid choice, please try again");
    loadSave = Console.ReadLine();
}
if (loadSave == "1")
{
    if (File.Exists(@"save.txt") == false)
    {
        Console.WriteLine("There is nothing to load");
    }
    else
    {
        int[] intArray = Load(maxPokermonHealth, enemyMaxHealth, pokermonHealth, enemyHealth, baseDamage, enemyBaseDamage, MP, maxMP, defeatedPokemonCount);
        maxPokermonHealth = intArray[0];
        enemyMaxHealth = intArray[1];
        pokermonHealth = intArray[2];
        enemyHealth = intArray[3];
        baseDamage = intArray[4];
        enemyBaseDamage = intArray[5];
        MP = intArray[6];
        maxMP = intArray[7];
        defeatedPokemonCount = intArray[8];
    }
}

Thread.Sleep(1000);
Console.Clear();
List<string> pokermonNames = ["Pikershoe", "Charrymander", "Quirtle"];
chosenPokermon = pokermonNames[PokermonInt];

//==========================================================================================================
// Fight Start
//==========================================================================================================

List<String> enemyNames = ["Bulbusur", "Cardizard", "Purple_Rat", "Raishoe", "Bugtrio", "Mr_clown", "Borelax", "Meetoo", "Unknown", "Whynot"];
List<String> enemyTypes = ["Grass", "Fire", "Dark", "Electric", "Grass", "Dark", "Water", "Dark", "Dark", "Electric"];
int enemy = Random.Shared.Next(enemyNames.Count);
String enemyPokermon = enemyNames[enemy];
string enemyType = enemyTypes[enemy];
List<string> elements = ["Fire", "Water", "Light", "Dark", "Electric"];
string counter = WhatIsEffectiveAgainst(enemyType, elements);

//Loop start andstats

Thread.Sleep(1000);
Console.WriteLine($"Your enemy is a {enemyPokermon}");
Console.WriteLine($"Its type is {enemyType}");
Thread.Sleep(1000);
Console.WriteLine("To fight, press the number corresponding to the action you wish to take");
Thread.Sleep(1000);
while (pokermonHealth >= 0)
{
    if (pokermonHealth >= 0)
    {
        Console.WriteLine("");
        Console.WriteLine("Its your turn");
        Console.WriteLine("You have " + MP + " mana left");
        Console.WriteLine(chosenPokermon + " has " + pokermonHealth + " hp left");
        Console.WriteLine(enemyPokermon + " has " + enemyHealth + " hp left");
        Console.WriteLine("");
        Console.WriteLine("Which action do you wish to take?");
        Console.WriteLine("1.Attack, 2.Power attack (-20mp), 3.Heal 10-25hp (-20mp), 4.Regen mana (+20mp), 5.Check counter");
        string action = Console.ReadLine();
        while (action != "1" && action != "2" && action != "3" && action != "4" && action != "67" && action != "Die" && action != "5")
        {
            Console.WriteLine("Invalid choice, Please try again");
            action = Console.ReadLine();
        }
        Thread.Sleep(1000);
        //========================================================================================================
        // Your Moves
        //========================================================================================================

        //Normal attack
        if (action == "1")
        {
            Console.WriteLine("Which element would you like to use?");
            for (int i = 0; i < elements.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {elements[i]}");
            }
            action = Console.ReadLine();
            int actionInt = 0;
            while(int.TryParse(action, out actionInt) == false || actionInt > elements.Count || actionInt < 1)
            {
                Console.WriteLine("Invalid choice, please try again");
                action = Console.ReadLine();
            }
            actionInt --;
            pokermonDamage = Random.Shared.Next(4, 7);
            pokermonDamage += baseDamage;
            if(elements[actionInt] == counter)
            {
                pokermonDamage += 5;
                Console.WriteLine("Your attack was super effective!");
            }
            Console.WriteLine($"{chosenPokermon} attacks for {pokermonDamage} hp");
            enemyHealth = enemyHealth - pokermonDamage;
            Thread.Sleep(500);
            Console.WriteLine(enemyPokermon + " has " + enemyHealth + " hp left");
        }
        // Power attack
        else if (action == "2" && MP >= 20)
        {
            Console.WriteLine($"{chosenPokermon} attacks {enemyPokermon} for {10 + baseDamage}");
            enemyHealth -= 10 + baseDamage;
            MP -= 20;
        }
        else if (action == "2" && MP == MP - 20)
        {
            Console.WriteLine("You could not afford to power attack and instead regenerate mana");
            MP += 20;
            if (MP >= maxMP)
            {
                MP = maxMP;
            }
        }
        //Heal
        else if (action == "3" && MP >= 15)
        {
            pokermonHealth += Random.Shared.Next(10, 25);
            if (pokermonHealth >= maxPokermonHealth)
            {
                pokermonHealth = maxPokermonHealth;
            }
            Console.WriteLine($"You heal {chosenPokermon} to {pokermonHealth}hp");
        }
        else if (action == "3" && MP <= 15)
        {
            Console.WriteLine("You could not afford to heal and instead regenerate mana");
            MP += 20;
            if (MP >= maxMP)
            {
                MP = maxMP;
            }
        }
        //Mana Regen
        else if (action == "4")
        {
            Console.WriteLine("You regenerate mana");
            MP += 20;
            if (MP > maxMP)
            {
                MP = maxMP;
            }
        }
        else if (action == "5")
        {
            Console.WriteLine($"{counter} is effective against {enemyPokermon}");
            Thread.Sleep(1000);
        }
        else if (action == "67")
        {
            pokermonHealth = 0;
        }
        else if (action == "Die")
        {
            enemyHealth -= 999999999;
        }
    }
    Thread.Sleep(1000);

    //Enemy move
    if (enemyHealth >= 0)
    {
        Console.WriteLine("");
        enemyAction = Random.Shared.Next(1, 3);
        if (enemyHealth >= enemyHealth / 3)
        {
            enemyDamage = Random.Shared.Next(5, 10);
            enemyDamage += enemyBaseDamage;
            Console.WriteLine($"{enemyPokermon} attacks {chosenPokermon} for {enemyDamage}");
            pokermonHealth -= enemyDamage;
        }
        if (enemyHealth <= enemyHealth / 3)
        {
            if (enemyAction == 1)
            {
                enemyHealth += Random.Shared.Next(5, 15);
                if (enemyHealth >= enemyMaxHealth)
                {
                    enemyHealth = enemyMaxHealth;
                }
                Console.WriteLine($"{enemyPokermon} Heals to {enemyHealth}hp");
            }
            if (enemyAction > 1)
            {
                enemyDamage = Random.Shared.Next(5, 10);
                enemyDamage += enemyBaseDamage;
                Console.WriteLine($"{enemyPokermon} attacks {chosenPokermon} for {enemyDamage}");
                pokermonHealth -= enemyDamage;
            }
        }
    }
    Thread.Sleep(1000);
    Console.Clear();
    if (pokermonHealth <= 0)
    {
        Console.WriteLine($"You lost after defeating {defeatedPokemonCount} pokermons");
        Console.WriteLine(@"
             _       __           _   
            | |     / _|         | |  
          __| | ___| |_ ___  __ _| |_ 
         / _` |/ _ \  _/ _ \/ _` | __|
        | (_| |  __/ ||  __/ (_| | |_ 
        \__,_|\___|_| \___|\__,_|\__|
        ");
        if (File.Exists(@"save.txt"))
        {
            File.Delete(@"save.txt");
        }
        Console.ReadLine();
        System.Environment.Exit(0);
    }
    if (enemyHealth <= 0)
    {
        Console.WriteLine("");
        Console.WriteLine($"You defeated {enemyPokermon}!");
        //Enemy Re-Randomizer
        enemyPokermon = enemyNames[Random.Shared.Next(enemyNames.Count)];
        Thread.Sleep(2000);
        //Choose upgrade
        Thread.Sleep(1000);
        Console.WriteLine("Which upgrade do you wish to pick?");
        Console.WriteLine("1.Max HP +20 - 40 2.Max damage + 2-4 3.Max MP + 20-40");
        Console.WriteLine("(Yourstatswill be regenerated at the start of the next fight)");
        string UpgradeChoice = Console.ReadLine();
        while (UpgradeChoice != "1" && UpgradeChoice != "2" && UpgradeChoice != "3")
        {
            Console.WriteLine("invalid choice, try again");
            UpgradeChoice = Console.ReadLine();
        }
        Thread.Sleep(1000);
        if (UpgradeChoice == "1")
        {
            maxPokermonHealth += Random.Shared.Next(20, 40);
            Console.WriteLine($"{chosenPokermon} Max HP was upgraded to {maxPokermonHealth}");
        }
        if (UpgradeChoice == "2")
        {
            baseDamage += Random.Shared.Next(2, 4);
            Console.WriteLine($"{chosenPokermon} Bonus damage was upgraded to +{baseDamage}");
        }
        if (UpgradeChoice == "3")
        {
            maxMP += Random.Shared.Next(20, 40);
            Console.WriteLine($"{chosenPokermon} max MP was upgraded to {maxMP}");
        }


        //Enemy Powerup
        enemyMaxHealth += Random.Shared.Next(10, 20);
        enemyBaseDamage += Random.Shared.Next(1, 3);

        //Restoringstats
        enemyHealth = enemyMaxHealth;
        pokermonHealth = maxPokermonHealth;
        MP = maxMP;
        Thread.Sleep(1000);
        Console.WriteLine("Do you wish to: 1.Save, 2.Continue without saving");
        string wannasave = Console.ReadLine();
        while (wannasave != "1" && wannasave != "2")
        {
            Console.WriteLine("invalid choice, try again");
            wannasave = Console.ReadLine();
        }
        if (wannasave == "1")
        {
            Save(maxPokermonHealth, enemyMaxHealth, pokermonHealth, enemyHealth, baseDamage, enemyBaseDamage, MP, maxMP, defeatedPokemonCount);
            Console.WriteLine("You saved the game");
        }
        Console.WriteLine($"Your next enemy will be a {enemyPokermon}");
        Console.WriteLine("");
        Console.WriteLine("LET THE BATTLE BEGIN!");
        Thread.Sleep(1000);

    }
}


static void Save(int maxPokermonHealth, int enemyMaxHealth, int pokermonHealth, int enemyHealth, int baseDamage, int enemyBaseDamage, int MP, int maxMP, int defeatedPokemonCount)
{
    string[] saveStats= { maxPokermonHealth.ToString(), enemyMaxHealth.ToString(), pokermonHealth.ToString(), enemyHealth.ToString(), baseDamage.ToString(), enemyBaseDamage.ToString(), MP.ToString(), maxMP.ToString(), defeatedPokemonCount.ToString() };
    if (File.Exists(@"save.txt"))
    {
        File.WriteAllLines(@"save.txt", saveStats);
    }
    else
    {
        var saveFile = File.Create(@"save.txt");
        saveFile.Close();
        File.WriteAllLines(@"save.txt", saveStats);
    }
}
static int[] Load(int maxPokermonHealth, int enemyMaxHealth, int pokermonHealth, int enemyHealth, int baseDamage, int enemyBaseDamage, int MP, int maxMP, int defeatedPokemonCount)
{
    String[]stats= File.ReadAllLines(@"save.txt");
    string[] intStats= {stats[0],stats[1],stats[2],stats[3],stats[4],stats[5],stats[6],stats[7],stats[8] };
    int[] intArray = Array.ConvertAll(intStats, int.Parse);
    return intArray;
}
static string WhatIsEffectiveAgainst(String enemyType, List<string> elements)
{
    
    string counter = "None";
    if(enemyType == "Grass")
    {
        counter = elements[0];
    }
    else if(enemyType == "Fire")
    {
        counter = elements[1];
    }
    else if(enemyType == "Dark")
    {
        counter = elements[2];
    }
    else if(enemyType == "Electric")
    {
        counter = elements[3];
    }
    else if(enemyType == "Water")
    {
        counter = elements[4];
    }
    return counter;
}