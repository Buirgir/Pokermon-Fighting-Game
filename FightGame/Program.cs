Console.WriteLine("Welcome to Pokermon!");
Thread.Sleep(1000);
Console.WriteLine("This is a very origional fighting game");
Console.WriteLine("Input a username");
Thread.Sleep(1000);
string Username = Console.ReadLine();
Thread.Sleep(1000);
Console.WriteLine("Pick your starter pokermon");
Console.WriteLine("1. Pikershoe");
Console.WriteLine("2. Charrymander");
Console.WriteLine("3. Quirtle");
Console.WriteLine("Enter the number corresponding to the action you wish to take");
string ChosenPokermon = Console.ReadLine();

while (ChosenPokermon != "1" && ChosenPokermon != "2" && ChosenPokermon != "3")
{
    ChosenPokermon = Console.ReadLine();
    if (ChosenPokermon != "1" && ChosenPokermon != "2" && ChosenPokermon != "3")
    {
        Console.WriteLine("Invalid choice, Please try again");
    }
}


if (ChosenPokermon == "1")
{
    ChosenPokermon = "Pikershoe";
}
if (ChosenPokermon == "2")
{
    ChosenPokermon = "Charrymander";
}
if (ChosenPokermon == "3")
{
    ChosenPokermon = "Quirtle";
}
//==========================================================================================================
// First Fight
//==========================================================================================================
int MaxPokermonHealth = 100;
int PokermonHealth = 100;
int PokermonDamage = Random.Shared.Next(4, 7);
int MaxMP = 100;
int MP = 100;
int EnemyMaxHealth = 50;
int EnemyHealth = 50;
int BaseDamage = 0;
int EnemyBaseDamage = 0;
int EnemyDamage = Random.Shared.Next(5, 10);
int EnemyAction = 0;
int DefeatedPokemonCount = 0;
string EnemyPokermon = "";

// Enemy Name picker
int EnemyRandomizer = Random.Shared.Next(1, 10);
if (EnemyRandomizer == 1)
{
    EnemyPokermon = "Cardizard";
}
if (EnemyRandomizer == 2)
{
    EnemyPokermon = "Purple Rat";
}
if (EnemyRandomizer == 3)
{
    EnemyPokermon = "Bubasaur";
}
if (EnemyRandomizer == 4)
{
    EnemyPokermon = "Raishoe";
}
if (EnemyRandomizer == 5)
{
    EnemyPokermon = "Bugtrio";
}
if (EnemyRandomizer == 6)
{
    EnemyPokermon = "Mr.clown";
}
if (EnemyRandomizer == 7)
{
    EnemyPokermon = "Borelax";
}
if (EnemyRandomizer == 8)
{
    EnemyPokermon = "Metoo";
}
if (EnemyRandomizer == 9)
{
    EnemyPokermon = "Unknown";
}
if (EnemyRandomizer == 10)
{
    EnemyPokermon = "Whynot";
}

//Introduction

Thread.Sleep(1000);
Console.WriteLine($"Your enemy is a {EnemyPokermon}");
Thread.Sleep(1000);
Console.WriteLine("To fight, press the number corresponding to the action you wish to take");
Thread.Sleep(1000);
while (PokermonHealth >= 0)
{
    if (PokermonHealth >= 0)
    {
        Console.WriteLine("");
        Console.WriteLine("Its your turn");
        Console.WriteLine("You have " + MP + " mana left");
        Console.WriteLine(ChosenPokermon + " has " + PokermonHealth + " hp left");
        Console.WriteLine(EnemyPokermon + " has " + EnemyHealth + " hp left");
        Console.WriteLine("");
        Console.WriteLine("Which action do you wish to take?");
        Console.WriteLine("1.Attack, 2.Power attack (-20mp), 3.Heal 10-25hp (-20mp), 4.Regen mana (+20mp)");
        string Action = Console.ReadLine();
        while (Action != "1" && Action != "2" && Action != "3" && Action != "4")
        {
            if (Action != "1" && Action != "2" && Action != "3" && Action != "4")
                Console.WriteLine("Invalid choice, Please try again");
        }
        Thread.Sleep(1000);
        //========================================================================================================
        // Your Moves
        //========================================================================================================

        //Normal attack
        if (Action == "1")
        {
            PokermonDamage = Random.Shared.Next(4, 7);
            PokermonDamage += BaseDamage;
            Console.WriteLine(ChosenPokermon + " attacks for " + PokermonDamage + "hp");
            EnemyHealth = EnemyHealth - PokermonDamage;
            Thread.Sleep(500);
            Console.WriteLine(EnemyPokermon + " has " + EnemyHealth + " hp left");
        }
        // Power attack
        if (Action == "2" && MP >= 20)
        {
            Console.WriteLine($"{ChosenPokermon} attacks {EnemyPokermon} for {10 + BaseDamage}");
            EnemyHealth -= 10 + BaseDamage;
            MP -= 20;
        }
        if (Action == "2" && MP == MP - 20)
        {
            Console.WriteLine("You could not afford to power attack and instead regenerate mana");
            MP += 20;
            if (MP >= MaxMP)
            {
                MP = MaxMP;
            }
        }
        //Heal
        if (Action == "3" && MP >= 15)
        {
            PokermonHealth += Random.Shared.Next(10, 25);
            if (PokermonHealth >= MaxPokermonHealth)
            {
                PokermonHealth = MaxPokermonHealth;
            }
            Console.WriteLine($"You heal {ChosenPokermon} to {PokermonHealth}hp");
        }
        if (Action == "3" && MP <= 15)
        {
            Console.WriteLine("You could not afford to heal and instead regenerate mana");
            MP += 20;
            if (MP >= MaxMP)
            {
                MP = MaxMP;
            }
        }
        //Mana Regen
        if (Action == "4")
        {
            Console.WriteLine("You regenerate mana");
            MP += 20;
            if (MP >= MaxMP)
            {
                MP = MaxMP;
            }
        }
    }
    Thread.Sleep(1000);

    //Enemy move
    if (EnemyHealth >= 0)
    {
        Console.WriteLine("");
        EnemyAction = Random.Shared.Next(1, 3);
        if (EnemyHealth >= EnemyHealth / 3)
        {
            EnemyDamage = Random.Shared.Next(5, 10);
            EnemyDamage += EnemyBaseDamage;
            Console.WriteLine($"{EnemyPokermon} attacks {ChosenPokermon} for {EnemyDamage}");
            PokermonHealth -= EnemyDamage;
        }
        if (EnemyHealth <= EnemyHealth / 3)
        {
            if (EnemyAction == 1)
            {
                EnemyHealth += Random.Shared.Next(5, 15);
                if (EnemyHealth >= EnemyMaxHealth)
                {
                    EnemyHealth = EnemyMaxHealth;
                }
                Console.WriteLine($"{EnemyPokermon} Heals to {EnemyHealth}hp");
            }
            if (EnemyAction == 2 || EnemyAction == 3)
            {
                EnemyDamage = Random.Shared.Next(5, 10);
                EnemyDamage += EnemyBaseDamage;
                Console.WriteLine($"{EnemyPokermon} attacks {ChosenPokermon} for {EnemyDamage}");
                PokermonHealth -= EnemyDamage;
            }
        }
    }
    Thread.Sleep(1000);
    if (PokermonHealth <= 0)
    {
        Console.WriteLine($"You lost after defeating {DefeatedPokemonCount}");
    }
    if (EnemyHealth <= 0)
    {
        Console.WriteLine("");
        Console.WriteLine($"You defeated {EnemyPokermon}!");
        //Enemy Re-Randomizer
        EnemyRandomizer = Random.Shared.Next(1, 10);
        if (EnemyRandomizer == 1)
        {
            EnemyPokermon = "Cardizard";
        }
        if (EnemyRandomizer == 2)
        {
            EnemyPokermon = "Purple Rat";
        }
        if (EnemyRandomizer == 3)
        {
            EnemyPokermon = "Bubasaur";
        }
        if (EnemyRandomizer == 4)
        {
            EnemyPokermon = "Raishoe";
        }
        if (EnemyRandomizer == 5)
        {
            EnemyPokermon = "Bugtrio";
        }
        if (EnemyRandomizer == 6)
        {
            EnemyPokermon = "Mr.clown";
        }
        if (EnemyRandomizer == 7)
        {
            EnemyPokermon = "Borelax";
        }
        if (EnemyRandomizer == 8)
        {
            EnemyPokermon = "Metoo";
        }
        if (EnemyRandomizer == 9)
        {
            EnemyPokermon = "Unknown";
        }
        if (EnemyRandomizer == 10)
        {
            EnemyPokermon = "Whynot";
        }
        Thread.Sleep(2000);
        Console.WriteLine($"Your next enemy will be a {EnemyPokermon}");
        //Choose upgrade
        Thread.Sleep(1000);
        Console.WriteLine("Which upgrade do you wish to pick?");
        Console.WriteLine("1.Max HP +20 - 40 2.Max damage + 2-4 3.Max MP + 20-40");
        Console.WriteLine("(Your stats will be regenerated at the start of the next fight)");
        string UpgradeChoice = Console.ReadLine();
        while (UpgradeChoice != "1" && UpgradeChoice != "2" && UpgradeChoice != "3")
        {
            Console.WriteLine("invalid choice, try again");
            UpgradeChoice = Console.ReadLine();
        }
        Thread.Sleep(1000);
        if (UpgradeChoice == "1")
        {
            MaxPokermonHealth += Random.Shared.Next(20, 40);
            Console.WriteLine($"{ChosenPokermon} Max HP was upgraded to {MaxPokermonHealth}");
        }
        if (UpgradeChoice == "2")
        {
            BaseDamage += Random.Shared.Next(2, 4);
            Console.WriteLine($"{ChosenPokermon} Bonus damage was upgraded to +{BaseDamage}");
        }
        if (UpgradeChoice == "3")
        {
            MaxMP += Random.Shared.Next(20, 40);
            Console.WriteLine($"{ChosenPokermon} max MP was upgraded to {MaxMP}");
        }


        //Enemy Powerup
        EnemyMaxHealth += Random.Shared.Next(10, 20);
        EnemyBaseDamage += Random.Shared.Next(1, 3);

        //Restoring stats
        EnemyHealth = EnemyMaxHealth;
        PokermonHealth = MaxPokermonHealth;
        MP = MaxMP;
        Thread.Sleep(1000);
        Console.WriteLine("");
        Console.WriteLine("LET THE BATTLE BEGIN!");
        Thread.Sleep(1000);

    }
}






Console.ReadLine();