using System.ComponentModel;
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

Console.WriteLine(@"
Welcome to Pokermon!
This is a very origional fighting game
Whats your name?");
Console.ReadLine();
Console.WriteLine(@"
Enter the number corresponding to the action you wish to take
Pick your starter pokermon
1. Pikershoe
2. Charrymander
3. Quirtle");

//Naming system after player input
int pokermonInt = ToolBox.CheckAnswer(1, 3);
pokermonInt --;
Thread.Sleep(1000);

//Loading
Console.WriteLine("Do you wish to 1.Load a save 2.Start a new save");
int loadSave = ToolBox.CheckAnswer(1, 2);
if (loadSave == 1)
{
    if (File.Exists(@"save.txt") == false)
    {
        Console.WriteLine("There is nothing to load");
    }
    else
    {
        int[] intArray = ToolBox.Load(maxPokermonHealth, enemyMaxHealth, pokermonHealth, enemyHealth, baseDamage, enemyBaseDamage, MP, maxMP, defeatedPokemonCount);
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
string[] pokermonNames = ["Pikershoe", "Charrymander", "Quirtle"];
string chosenPokermon = pokermonNames[pokermonInt];
//==========================================================================================================
// Fight Start
//==========================================================================================================
//EnemyPokermonPickerAndElement will always have the same length and therefore should be arrays
string[] enemyPokermonAndElement = ToolBox.EnemyPokermonPickerAndElement();
String enemyPokermon = enemyPokermonAndElement[0];
string enemyType = enemyPokermonAndElement[1];
//Array since its a set length
string[] elements = ["Fire", "Water", "Light", "Dark", "Electric"];
string counter = ToolBox.WhatIsEffectiveAgainst(enemyType, elements);

//Loop start andstats

Thread.Sleep(1000);
Console.WriteLine($@"Your enemy is a {enemyPokermon}
Its type is {enemyType}");
Thread.Sleep(1000);
Console.WriteLine("To fight, press the number corresponding to the action you wish to take");
Thread.Sleep(1000);
while (pokermonHealth >= 0)
{
    if (pokermonHealth >= 0)
    {
        ToolBox.StartRound(MP, chosenPokermon, pokermonHealth, enemyPokermon, enemyHealth);
        int action = ToolBox.CheckAnswer(1, 5);
        Thread.Sleep(1000);
        //========================================================================================================
        // Your Moves
        //========================================================================================================

        //Normal attack
        if (action == 1)
        {
            enemyHealth = Actions.Attack(elements, pokermonDamage, baseDamage, counter, chosenPokermon, enemyHealth, enemyPokermon);
        }
        // Power attack
        else if (action == 2)
        {
            if(MP < 15)
            {
                Console.WriteLine("You could not afford to power attack and instead regenerate mana");
                MP += 20;
                if (MP >= maxMP)
                {
                    MP = maxMP;
                }
            }
            else
            {
                //Array because it has a set length
                int[] powerAttack = Actions.PwrAttack(chosenPokermon, enemyPokermon, baseDamage, enemyHealth, MP);
                enemyHealth = powerAttack[0];
                MP = powerAttack[1];                
            }
        }
        //Heal
        else if (action == 3)
        {
            pokermonHealth = Actions.Heal(pokermonHealth, maxPokermonHealth, chosenPokermon);
        }
        //Mana Regen
        else if (action == 4)
        {
            MP = Actions.ManaRegen(MP, maxMP);
        }
        else if (action == 5)
        {
            Console.WriteLine($"{counter} is effective against {enemyPokermon}");
        }
    }
    Thread.Sleep(1000);

    //Enemy move
    int[] healthChange = Actions.EnemyMove(enemyHealth, enemyAction, enemyDamage, enemyBaseDamage, enemyPokermon, chosenPokermon, pokermonHealth, enemyMaxHealth);
    pokermonHealth = healthChange[0];
    enemyHealth = healthChange[1];
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
        enemyPokermonAndElement = ToolBox.EnemyPokermonPickerAndElement();
        enemyPokermon = enemyPokermonAndElement[0];
        enemyType = enemyPokermonAndElement[1];
        Thread.Sleep(2000);
        //Choose upgrade
        Thread.Sleep(1000);
        Console.WriteLine("Which upgrade do you wish to pick?");
        Console.WriteLine("1.Max HP +20 - 40 2.Max damage + 2-4 3.Max MP + 20-40");
        Console.WriteLine("(Yourstatswill be regenerated at the start of the next fight)");
        int upgradeChoice = ToolBox.CheckAnswer(1, 3);
        Thread.Sleep(1000);
        //explained at function
        int[] upgradeCheck = ToolBox.UpgradeCheck(upgradeChoice, maxPokermonHealth, baseDamage, maxMP, chosenPokermon);
        maxPokermonHealth = upgradeCheck[0];
        baseDamage = upgradeCheck[1];
        maxMP = upgradeCheck[2];
        //Enemy Powerup
        enemyMaxHealth += Random.Shared.Next(10, 20);
        enemyBaseDamage += Random.Shared.Next(1, 3);
        

        //Restoringstats
        enemyHealth = enemyMaxHealth;
        pokermonHealth = maxPokermonHealth;
        MP = maxMP;
        Thread.Sleep(1000);
        Console.WriteLine("Do you wish to: 1.Save, 2.Continue without saving");
        int wannasave = ToolBox.CheckAnswer(1, 2);
        if (wannasave == 1)
        {
            ToolBox.Save(maxPokermonHealth, enemyMaxHealth, pokermonHealth, enemyHealth, baseDamage, enemyBaseDamage, MP, maxMP, defeatedPokemonCount);
            Console.WriteLine("You saved the game");
        }
        Console.WriteLine($"Your next enemy will be a {enemyPokermon}");
        Console.WriteLine("");
        Console.WriteLine("LET THE BATTLE BEGIN!");
        Thread.Sleep(1000);
    }
}