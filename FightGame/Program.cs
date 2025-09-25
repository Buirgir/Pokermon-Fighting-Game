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

Enemy Bulbusur = new()
{
    name = "Bulbusur"
};
Enemy Cardizard = new()
{
    name = "Cardizard"
};
Enemy Purple_Rat = new()
{
    name = "Purple Rat"
};
Enemy Raishoe = new()
{
    name = "Raishoe"
};
Enemy Bugtrio = new()
{
    name = "Bugtrio"
};
Enemy Mr_clown = new()
{
    name = "Mr.clown"
};
Enemy Borelax = new()
{
    name = "Borelax"
};
Enemy Meetoo = new()
{
    name = "Metoo"
};
Enemy Unknown = new()
{
    name = "Unknown"
};
Enemy Whynot = new()
{
    name = "Whynot"
};

List<Enemy> Enemies = [Bulbusur, Cardizard, Purple_Rat, Raishoe, Bugtrio, Mr_clown, Borelax, Meetoo, Unknown, Whynot];
Enemy EnemyPokermon = Enemies[Random.Shared.Next(Enemies.Count)];

//Introduction

Thread.Sleep(1000);
Console.WriteLine($"Your enemy is a {EnemyPokermon.name}");
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
        Console.WriteLine(EnemyPokermon.name + " has " + EnemyHealth + " hp left");
        Console.WriteLine("");
        Console.WriteLine("Which action do you wish to take?");
        Console.WriteLine("1.Attack, 2.Power attack (-20mp), 3.Heal 10-25hp (-20mp), 4.Regen mana (+20mp)");
        string Action = Console.ReadLine();
        while (Action != "1" && Action != "2" && Action != "3" && Action != "4" && Action != "67")
        {
            if (Action != "1" && Action != "2" && Action != "3" && Action != "4" && Action != "67")
                Console.WriteLine("Invalid choice, Please try again");
            Action = Console.ReadLine();
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
            Console.WriteLine($"{ChosenPokermon} attacks {EnemyPokermon.name} for {10 + BaseDamage}");
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
        if (Action == "67")
        {
            PokermonHealth = 0;
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
            Console.WriteLine($"{EnemyPokermon.name} attacks {ChosenPokermon} for {EnemyDamage}");
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
                Console.WriteLine($"{EnemyPokermon.name} Heals to {EnemyHealth}hp");
            }
            if (EnemyAction == 2 || EnemyAction == 3)
            {
                EnemyDamage = Random.Shared.Next(5, 10);
                EnemyDamage += EnemyBaseDamage;
                Console.WriteLine($"{EnemyPokermon.name} attacks {ChosenPokermon} for {EnemyDamage}");
                PokermonHealth -= EnemyDamage;
            }
        }
    }
    Thread.Sleep(1000);
    if (PokermonHealth <= 0)
    {
        Console.WriteLine($"You lost after defeating {DefeatedPokemonCount} pokermons");
        Console.WriteLine(@"
             _       __           _   
            | |     / _|         | |  
          __| | ___| |_ ___  __ _| |_ 
         / _` |/ _ \  _/ _ \/ _` | __|
        | (_| |  __/ ||  __/ (_| | |_ 
        \__,_|\___|_| \___|\__,_|\__|
        ");
    }
    if (EnemyHealth <= 0)
    {
        Console.WriteLine("");
        Console.WriteLine($"You defeated {EnemyPokermon}!");
        //Enemy Re-Randomizer
        EnemyPokermon = Enemies[Random.Shared.Next(Enemies.Count)];
        Thread.Sleep(2000);
        Console.WriteLine($"Your next enemy will be a {EnemyPokermon.name}");
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