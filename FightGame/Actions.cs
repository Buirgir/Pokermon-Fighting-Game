public class Actions
{
    public static int Attack(string[] elements, int pokermonDamage, int baseDamage, string counter , string chosenPokermon, int enemyHealth, string enemyPokermon)
    {
    
        Console.WriteLine("Which element would you like to use?");
        for (int i = 0; i < elements.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {elements[i]}");
        }
        int actionInt = ToolBox.CheckAnswer(1, elements.Length);
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
        return enemyHealth;
    }
    public static int[] PwrAttack(string chosenPokermon, string enemyPokermon, int baseDamage, int enemyHealth, int MP)
    {
        Console.WriteLine($"{chosenPokermon} attacks {enemyPokermon} for {10 + baseDamage}");
        enemyHealth -= 10 + baseDamage;
        MP -= 20;
        return [enemyHealth, MP];
    }
    public static int Heal(int pokermonHealth, int maxPokermonHealth, string chosenPokermon)
    {
        pokermonHealth += Random.Shared.Next(10, 25);
        if (pokermonHealth >= maxPokermonHealth)
        {
            pokermonHealth = maxPokermonHealth;
        }
        Console.WriteLine($"You heal {chosenPokermon} to {pokermonHealth}hp");
        return pokermonHealth;
    }
    public static int ManaRegen(int MP, int maxMP)
    {
        Console.WriteLine("You regenerate mana");
        MP += 20;
        if (MP > maxMP)
        {
            MP = maxMP;
        }
        return MP;
    }
    public static int[] EnemyMove(int enemyHealth, int enemyAction, int enemyDamage, int enemyBaseDamage, string enemyPokermon, string chosenPokermon, int pokermonHealth, int enemyMaxHealth)
    {
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
        return[pokermonHealth, enemyHealth];
    }
}