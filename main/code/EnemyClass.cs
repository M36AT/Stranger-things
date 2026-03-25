using System;

class Enemy
{
    // Attributes
    private string name;
    private int health;
    private int maxHealth;
    private int attackPower;
    private int specialPoints;
    private string description;
    private string type; // "Physical" or "Psychological"
    
    // Constructor
    public Enemy(string name, int health, int attackPower, string description, string type)
    {
        this.name = name;
        this.health = health;
        this.maxHealth = health;
        this.attackPower = attackPower;
        this.specialPoints = 100;
        this.description = description;
        this.type = type;
    }
    
    public string GetName()
    {
        return name;
    }
    
    public int GetHealth()
    {
        return health;
    }
    
    public int GetMaxHealth()
    {
        return maxHealth;
    }
    
    public string GetType()
    {
        return type;
    }
    
    // Check if enemy is alive
    public bool IsAlive()
    {
        return health > 0;
    }
    
    // Take damage
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;
        Console.WriteLine(name + " takes " + damage + " damage! Health: " + health + "/" + maxHealth);
    }
    
    // Attack player
    public int Attack()
    {
        Console.WriteLine(name + " attacks you!");
        return attackPower;
    }
    
    // Special attack based on enemy type
    public int SpecialAttack()
    {
        if (type == "Psychological")
        {
            Console.WriteLine(name + " uses 'Sanity Drain'! It reveals your deepest regrets.");
            return attackPower + 5;
        }
        else
        {
            Console.WriteLine(name + " lunges with a vicious strike!");
            return attackPower + 3;
        }
    }
    
    // Display enemy info
    public void DisplayInfo()
    {
        Console.WriteLine("=== Enemy Encounter ===");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Description: " + description);
        Console.WriteLine("Type: " + type + " Enemy");
        Console.WriteLine("Health: " + health + "/" + maxHealth);
        Console.WriteLine("=======================");
    }
    
    // Display battle menu
    public void DisplayBattleMenu()
    {
        Console.WriteLine("\nWhat will you do?");
        Console.WriteLine("[A] Attack");
        Console.WriteLine("[D] Defend");
        Console.WriteLine("[I] Use Item");
        Console.WriteLine("[R] Run");
    }
    
    // Create specific enemies from the storyline
    public static Enemy CreateDemogorgon()
    {
        return new Enemy("Demogorgon", 50, 15, 
            "A creature with no face and a petal-like maw lunges from the fog!", 
            "Physical");
    }
    
    public static Enemy CreateMindFlayer()
    {
        return new Enemy("Mind Flayer", 80, 20, 
            "A massive shadow towers over the trees. The Mind Flayer has arrived!", 
            "Psychological");
    }
    
    public static Enemy CreateShadowGuard()
    {
        return new Enemy("Shadow Guard", 40, 12, 
            "An echo of your own fears attacks your mind!", 
            "Psychological");
    }
    
    public static Enemy CreateVecna()
    {
        return new Enemy("Vecna", 100, 25, 
            "Vecna stands connected to vines. 'Your time is up,' he rasps.", 
            "Psychological");
    }
}


