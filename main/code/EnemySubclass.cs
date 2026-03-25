using System;

// Base Enemy Class 
class Enemy
{
    // Attributes
    protected string name;
    protected int health;
    protected int maxHealth;
    protected int attackPower;
    protected int specialPoints;
    protected string description;
    protected string enemyType; // "Physical" or "Psychological"
    
    // Constructor
    public Enemy(string name, int health, int attackPower, string description, string enemyType)
    {
        this.name = name;
        this.health = health;
        this.maxHealth = health;
        this.attackPower = attackPower;
        this.specialPoints = 100;
        this.description = description;
        this.enemyType = enemyType;
    }
    
    // Virtual methods that can be overridden by subclasses
    public virtual void DisplayInfo()
    {
        Console.WriteLine("=== Enemy Encounter ===");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Description: " + description);
        Console.WriteLine("Type: " + enemyType + " Enemy");
        Console.WriteLine("Health: " + health + "/" + maxHealth);
        Console.WriteLine("=======================");
    }
    
    public virtual int Attack()
    {
        Console.WriteLine(name + " attacks you!");
        return attackPower;
    }
    
    public virtual int SpecialAttack()
    {
        if (enemyType == "Psychological")
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
    
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0) health = 0;
        Console.WriteLine(name + " takes " + damage + " damage! Health: " + health + "/" + maxHealth);
    }
    
    public bool IsAlive()
    {
        return health > 0;
    }
    
    public string GetName()
    {
        return name;
    }
    
    public string GetEnemyType()
    {
        return enemyType;
    }
}

// Physical Enemy Subclass
class PhysicalEnemy : Enemy
{
    private int physicalResistance;
    
    public PhysicalEnemy(string name, int health, int attackPower, string description, int resistance) 
        : base(name, health, attackPower, description, "Physical")
    {
        this.physicalResistance = resistance;
    }
    
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Physical Resistance: " + physicalResistance + "%");
    }
    
    public override int Attack()
    {
        Console.WriteLine(name + " charges at you with brute force!");
        return attackPower;
    }
    
    public override int SpecialAttack()
    {
        Console.WriteLine(name + " uses 'Brutal Strike'!");
        Console.WriteLine("The ground shakes beneath you!");
        return attackPower + 10;
    }
    
    public override void TakeDamage(int damage)
    {
        // Physical enemies take reduced damage
        int reducedDamage = damage * (100 - physicalResistance) / 100;
        base.TakeDamage(reducedDamage);
    }
}

// Psychological Enemy Subclass
class PsychologicalEnemy : Enemy
{
    private int sanityDamage;
    
    public PsychologicalEnemy(string name, int health, int attackPower, string description, int sanityDamage) 
        : base(name, health, attackPower, description, "Psychological")
    {
        this.sanityDamage = sanityDamage;
    }
    
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Sanity Damage: " + sanityDamage);
    }
    
    public override int Attack()
    {
        Console.WriteLine(name + " whispers dark thoughts into your mind!");
        return attackPower;
    }
    
    public override int SpecialAttack()
    {
        Console.WriteLine(name + " uses 'Mind Break'!");
        Console.WriteLine("Visions of your worst fears surround you!");
        Console.WriteLine("Sanity Damage: " + sanityDamage);
        return attackPower + sanityDamage;
    }
    
    // Method  psychological enemies
    public void SanityDrain(ref int playerSP)
    {
        Console.WriteLine(name + " drains your sanity!");
        playerSP -= sanityDamage;
        if (playerSP < 0) playerSP = 0;
        Console.WriteLine("SP remaining: " + playerSP);
    }
}

// Demogorgon Subclass
class Demogorgon : PhysicalEnemy
{
    private bool isEnraged;
    
    public Demogorgon() 
        : base("Demogorgon", 50, 15, "A creature with no face and a petal-like maw lunges from the fog!", 20)
    {
        isEnraged = false;
    }
    
    public override int Attack()
    {
        Console.WriteLine("The Demogorgon's flower-like face opens wide!");
        if (isEnraged)
        {
            Console.WriteLine("Enraged by your attacks, it strikes with furious power!");
            return attackPower + 8;
        }
        return attackPower;
    }
    
    public override int SpecialAttack()
    {
        Console.WriteLine("Demogorgon uses 'Petal Maw'!");
        Console.WriteLine("It lunges with terrifying speed!");
        isEnraged = true;
        return attackPower + 12;
    }
    
    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        
        // Demogorgon enrages when health drops below half
        if (health <= maxHealth / 2 && !isEnraged)
        {
            Console.WriteLine("The Demogorgon lets out a furious screech! It's enraged!");
            isEnraged = true;
        }
    }
}

// Mind Flayer Subclass
class MindFlayer : PsychologicalEnemy
{
    private int shadowTendrils;
    
    public MindFlayer() 
        : base("Mind Flayer", 80, 20, "A massive shadow towers over the trees. The Mind Weaver has arrived!", 15)
    {
        shadowTendrils = 3;
    }
    
    public override int Attack()
    {
        Console.WriteLine("The Mind Flayer extends its massive shadow over you!");
        return attackPower;
    }
    
    public override int SpecialAttack()
    {
        if (shadowTendrils > 0)
        {
            Console.WriteLine("Mind Flayer uses 'Shadow Tendrils'!");
            Console.WriteLine("Dark vines reach from the ground to grab you!");
            shadowTendrils--;
            return attackPower + 15;
        }
        else
        {
            Console.WriteLine("The Mind Flayer's tendrils are exhausted. It screeches in frustration!");
            return attackPower - 5;
        }
    }
    
    public void SummonShadows(ref int enemyCount)
    {
        Console.WriteLine("The Mind Flayer calls upon shadow creatures!");
        enemyCount += 2;
        Console.WriteLine("Two Shadow Guards join the fight!");
    }
    
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Shadow Tendrils Remaining: " + shadowTendrils);
    }
}

// Shadow Guard Subclass
class ShadowGuard : PsychologicalEnemy
{
    private string fearType;
    
    public ShadowGuard(string fearType) 
        : base("Shadow Guard", 40, 12, "An echo of your own fears attacks your mind!", 10)
    {
        this.fearType = fearType;
    }
    
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Manifests as: " + fearType);
    }
    
    public override int Attack()
    {
        Console.WriteLine("The Shadow Guard takes the form of your deepest fear: " + fearType + "!");
        return attackPower;
    }
    
    public override int SpecialAttack()
    {
        Console.WriteLine("Shadow Guard uses 'Fear Manifestation'!");
        Console.WriteLine("It becomes a terrifying vision of your worst memory!");
        return attackPower + 8;
    }
    
    // Method to set fear based on player's actions
    public void SetFearFromInventory(Inventory inventory)
    {
        // This creates dynamic fear based on what the player has
        Random rand = new Random();
        string[] fears = { "Losing your friends", "Being trapped forever", "The darkness consuming you", "Your own reflection" };
        fearType = fears[rand.Next(fears.Length)];
    }
}

// Vecna Subclass (Final Boss)
class Vecna : PsychologicalEnemy
{
    private int curseStacks;
    private bool hasShatteredClock;
    
    public Vecna() 
        : base("Vecna", 100, 25, "Vecna stands connected to vines. 'Your time is up,' he rasps.", 20)
    {
        curseStacks = 0;
        hasShatteredClock = false;
    }
    
    public override int Attack()
    {
        Console.WriteLine("Vecna raises his hand, vines writhing around him!");
        return attackPower;
    }
    
    public override int SpecialAttack()
    {
        curseStacks++;
        Console.WriteLine("Vecna uses 'Vecna's Curse'!");
        Console.WriteLine("He reveals your deepest regrets. Your SP is plummeting!");
        Console.WriteLine("Curse stacks: " + curseStacks);
        return attackPower + (curseStacks * 5);
    }
    
    public void PsychologicalAttack(ref int playerSP, ref int playerHP)
    {
        Console.WriteLine("\nThe room spins. Vecna shows you visions of your failures!");
        Console.WriteLine("You must choose: [1] Fight the vision  [2] Strike Vecna");
        
        string choice = Console.ReadLine();
        
        if (choice == "1")
        {
            Console.WriteLine("You fight through the psychological assault!");
            playerSP -= 15;
            Console.WriteLine("SP -15. Remaining SP: " + playerSP);
        }
        else if (choice == "2")
        {
            Console.WriteLine("You strike Vecna while he's distracted!");
            playerHP -= 10;
            TakeDamage(20);
            Console.WriteLine("You take 10 damage, but Vecna loses 20 health!");
        }
    }
    
    public void GrandfatherClockSequence()
    {
        if (!hasShatteredClock)
        {
            Console.WriteLine("\nThe grandfather clock begins chiming...");
            Console.WriteLine("BONG... BONG... BONG... BONG...");
            Console.WriteLine("Time seems to slow down as Vecna draws power!");
            attackPower += 10;
            hasShatteredClock = true;
        }
    }
    
    public override void DisplayInfo()
    {
        base.DisplayInfo();
        Console.WriteLine("Curse Stacks: " + curseStacks);
        if (hasShatteredClock)
        {
            Console.WriteLine("The grandfather clock has chimed - Vecna is empowered!");
        }
    }
    
    public bool IsDefeated()
    {
        return health <= 0;
    }
    
    public void VictorySequence()
    {
        Console.WriteLine("\nVecna dissolves into ash!");
        Console.WriteLine("The grandfather clock shatters into a million pieces!");
        Console.WriteLine("The vines wither and the realm begins to collapse!");
    }
}
