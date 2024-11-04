using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        Dictionary<string, Hero> heroes = new Dictionary<string, Hero>();

        for (int i = 0; i < n; i++)
        {
            string[] heroInfo = Console.ReadLine().Split();
            string name = heroInfo[0];
            int hp = int.Parse(heroInfo[1]);
            int mp = int.Parse(heroInfo[2]);

            heroes.Add(name, new Hero(name, hp, mp));
        }

        string command;
        while ((command = Console.ReadLine()) != "End")
        {
            string[] commandArgs = command.Split(" - ");
            string action = commandArgs[0];
            string heroName = commandArgs[1];

            switch (action)
            {
                case "CastSpell":
                    int mpNeeded = int.Parse(commandArgs[2]);
                    string spellName = commandArgs[3];
                    CastSpell(heroes, heroName, mpNeeded, spellName);
                    break;
                case "TakeDamage":
                    int damage = int.Parse(commandArgs[2]);
                    string attacker = commandArgs[3];
                    TakeDamage(heroes, heroName, damage, attacker);
                    break;
                case "Recharge":
                    int amount = int.Parse(commandArgs[2]);
                    Recharge(heroes, heroName, amount);
                    break;
                case "Heal":
                    int healAmount = int.Parse(commandArgs[2]);
                    Heal(heroes, heroName, healAmount);
                    break;
            }
        }

        PrintHeroes(heroes);
    }

    static void CastSpell(Dictionary<string, Hero> heroes, string heroName, int mpNeeded, string spellName)
    {
        if (heroes.TryGetValue(heroName, out Hero hero))
        {
            if (hero.MP >= mpNeeded)
            {
                hero.MP -= mpNeeded;
                Console.WriteLine($"{heroName} has successfully cast {spellName} and now has {hero.MP} MP!");
            }
            else
            {
                Console.WriteLine($"{heroName} does not have enough MP to cast {spellName}!");
            }
        }
    }

    static void TakeDamage(Dictionary<string, Hero> heroes, string heroName, int damage, string attacker)
    {
        if (heroes.TryGetValue(heroName, out Hero hero))
        {
            hero.HP -= damage;
            if (hero.HP > 0)
            {
                Console.WriteLine($"{heroName} was hit for {damage} HP by {attacker} and now has {hero.HP} HP left!");
            }
            else
            {
                heroes.Remove(heroName);
                Console.WriteLine($"{heroName} has been killed by {attacker}!");
            }
        }
    }

    static void Recharge(Dictionary<string, Hero> heroes, string heroName, int amount)
    {
        if (heroes.TryGetValue(heroName, out Hero hero))
        {
            int maxRecharge = 200 - hero.MP;
            int amountRecovered = Math.Min(amount, maxRecharge);
            hero.MP += amountRecovered;
            Console.WriteLine($"{heroName} recharged for {amountRecovered} MP!");
        }
    }

    static void Heal(Dictionary<string, Hero> heroes, string heroName, int amount)
    {
        if (heroes.TryGetValue(heroName, out Hero hero))
        {
            int maxHeal = 100 - hero.HP;
            int amountRecovered = Math.Min(amount, maxHeal);
            hero.HP += amountRecovered;
            Console.WriteLine($"{heroName} healed for {amountRecovered} HP!");
        }
    }

    static void PrintHeroes(Dictionary<string, Hero> heroes)
    {
        foreach (var hero in heroes.Values)
        {
            Console.WriteLine($"{hero.Name}\n  HP: {hero.HP}\n  MP: {hero.MP}");
        }
    }
}

class Hero
{
    public string Name { get; }
    public int HP { get; set; }
    public int MP { get; set; }

    public Hero(string name, int hp, int mp)
    {
        Name = name;
        HP = hp;
        MP = mp;
    }
}
