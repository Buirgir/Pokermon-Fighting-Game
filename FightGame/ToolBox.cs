public class ToolBox
{
    public static void Save(int maxPokermonHealth, int enemyMaxHealth, int pokermonHealth, int enemyHealth, int baseDamage, int enemyBaseDamage, int MP, int maxMP, int defeatedPokemonCount)
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
    public static List<int> Load(int maxPokermonHealth, int enemyMaxHealth, int pokermonHealth, int enemyHealth, int baseDamage, int enemyBaseDamage, int MP, int maxMP, int defeatedPokemonCount)
    {
        String[]stats= File.ReadAllLines(@"save.txt");
        string[] stringStats= {stats[0],stats[1],stats[2],stats[3],stats[4],stats[5],stats[6],stats[7],stats[8] };
        // int[] intArray = Array.ConvertAll(intStats, int.Parse);
        //List since it changes length
        List<int> intList = new List<int>();
        for (int i = 0; i < 9; i++)
        {
            bool sucess = int.TryParse(stringStats[i], out int b);
            if(sucess)
            {
                intList.Add(b);
            }
            else
            {
                break;
            }
        }
        return intList;
    }
    public static string WhatIsEffectiveAgainst(String enemyType, string[] elements)
    {
        string counter = "None";
        //Simple if statements to just check what element should be the counter
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
    public static int CheckAnswer(int min, int max)
    {
        //hell nah
        int value;
        //gets first input
        string answer = Console.ReadLine();
        //Cheks if entered value is a number
        bool sucess = int.TryParse(answer, out value);
        while (true)
        {
            //Cheks that the answer is a int, and is less than maaximum aswell as more than min, and then breaks out of loop
            if(sucess == true && min <= value && max >= value) break;
                Console.WriteLine("Invalid choice, Please try again");
            answer = Console.ReadLine();
            sucess = int.TryParse(answer, out value);
        }
        return value;
    }
    public static void StartRound(int MP, string chosenPokermon, int pokermonHealth, string enemyPokermon, int enemyHealth)
    {
        Console.WriteLine("");
        Console.WriteLine("Its your turn");
        Console.WriteLine($"You have {MP} mana left");
        Console.WriteLine($"{chosenPokermon} has {pokermonHealth} hp left");
        Console.WriteLine($"{enemyPokermon} has {enemyHealth} hp left");
        Console.WriteLine("");
        Console.WriteLine(@"Which action do you wish to take?
        1.Attack, 2.Power attack (-20mp), 3.Heal 10-25hp (-20mp), 4.Regen mana (+20mp), 5.Check counter");
    }
    public static string[] EnemyPokermonPickerAndElement()
    {
        string[] enemyNames = ["Bulbusur", "Cardizard", "Purple_Rat", "Raishoe", "Bugtrio", "Mr_clown", "Borelax", "Meetoo", "Unknown", "Whynot"];
        int enemy = Random.Shared.Next(enemyNames.Length);
        String enemyPokermon = enemyNames[enemy];
        string[] enemyTypes = ["Grass", "Fire", "Dark", "Electric", "Grass", "Dark", "Water", "Dark", "Dark", "Electric"];
        string enemyType = enemyTypes[enemy];
        return [enemyPokermon, enemyType];
    }
    public static int[] UpgradeCheck(int upgradeChoice, int maxPokermonHealth, int baseDamage, int maxMP, string chosenPokermon)
    {
            if (upgradeChoice == 1)
            {
                maxPokermonHealth += Random.Shared.Next(20, 40);
                Console.WriteLine($"{chosenPokermon} Max HP was upgraded to {maxPokermonHealth}");
            }
            if (upgradeChoice == 2)
            {
                baseDamage += Random.Shared.Next(2, 4);
                Console.WriteLine($"{chosenPokermon} Bonus damage was upgraded to +{baseDamage}");
            }
            if (upgradeChoice == 3)
            {
                maxMP += Random.Shared.Next(20, 40);
                Console.WriteLine($"{chosenPokermon} max MP was upgraded to {maxMP}");
            }
        return [maxPokermonHealth, baseDamage, maxMP];
    }
}