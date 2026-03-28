class Player
{
   
    private string name;
    private int sanity;
    private int xp;
    private int health;
    private int level;
    private Inventory inventory;
    
   
    public string Name
    {
        get { return name; }
        set { name = value; }
    }
    
    public int Sanity
    {
        get { return sanity; }
        set 
        { 
            sanity = value;
            if (sanity < 0) sanity = 0;
            if (sanity > 100) sanity = 100;
        }
    }

   public int Sanity
    {
        get { return health; }
        set 
        { 
            health = value;
            if (health < 0) health = 0;
            if (health > 100) health = 100;
        }
    }
    
    public int XP
    {
        get { return xp; }
        set 
        { 
            xp = value;
            if (xp >= 100)
            {
                LevelUp();
            }
        }
    }
    
    public int Level
    {
        get { return level; }
        set { level = value; }
    }
    
    public Inventory PlayerInventory
    {
        get { return inventory; }
        set { inventory = value; }
    }

   private Difficulty difficulty;

   public Player(string playerName, Difficulty difficulty)
   {
       name = playerName;
       this.difficulty = difficulty;
   
       sanity = 100 + difficulty.PlayerSanityModifier;
   
       xp = 0;
       level = 1;
       inventory = new Inventory();
   }
    
    
    public Player(string playerName)
    {
        name = playerName;
        sanity = 100;
        health = 100;
        xp = 0;
        level = 1;
        inventory = new Inventory(); // Creates inventory object
        
        Console.WriteLine(name + " has joined the adventure!");
        Console.WriteLine("Sanity: " + sanity + " | Level: " + level + " | XP: " + xp);
    }
    
    
    public virtual int ChooseAction()
    {
        Console.WriteLine("\n=== Choose your action ===");
        Console.WriteLine("1. Attack");
        Console.WriteLine("2. Use Special Ability");
        Console.WriteLine("3. Use Item");
        Console.WriteLine("4. Check Status");
        Console.WriteLine("5. Show Inventory");
        Console.Write("Enter choice: ");
        
        int choice = int.Parse(Console.ReadLine());
        return choice;
    }
    
  
    public virtual void UseItem()
    {
        if (inventory != null)
        {
            inventory.ShowInventory();
            Console.Write("Enter item name to use: ");
            string itemName = Console.ReadLine();
            
            inventory.UseItem(itemName);
            
            if (itemName.ToLower() == "health potion")
            {
                Console.WriteLine("Health restored!");
            }
            else if (itemName.ToLower() == "sanity potion")
            {
                Sanity += 25;
                Console.WriteLine("Sanity restored to: " + sanity);
            }
        }
        else
        {
            Console.WriteLine("No inventory available!");
        }
    }
    
   
    public virtual void LevelUp()
    {
        level++;
        xp = xp - 100;
        
        Console.WriteLine("\n==================================");
        Console.WriteLine("     LEVEL UP! Now Level " + level);
        Console.WriteLine("==================================");
        Console.WriteLine("Sanity increased by 10!");
        
        Sanity += 10;
        Console.WriteLine("Current sanity: " + sanity);
        
        if (xp >= 100)
        {
            LevelUp();
        }
    }
    
  
    public virtual void Attack(Enemy target)
    {
        int attackValue = 15 + (level * 2);
        Console.WriteLine(name + " attacks " + target.Name + " for " + attackValue + " damage!");
        target.TakeDamage(attackValue);
    }
    
    
    public virtual void SpecialAbility()
    {
        Console.WriteLine(name + " has no special ability yet!");
    }
    
    
    public void TakeSanityDamage(int sanityLoss)
    {
        Sanity -= sanityLoss;
        Console.WriteLine(name + " loses " + sanityLoss + " sanity! Sanity: " + sanity);
        
        if (sanity <= 0)
        {
            Console.WriteLine(name + " has lost their mind! Game Over!");
        }
    }
    
    
    public void GainXP(int xpGain)
    {
        XP += xpGain;
        Console.WriteLine(name + " gained " + xpGain + " XP! Total XP: " + xp + "/100");
    }
    
    
    public void ShowStatus()
    {
        Console.WriteLine("\n=== Player Status ===");
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Level: " + level);
        Console.WriteLine("Sanity: " + sanity + "/100");
        Console.WriteLine("XP: " + xp + "/100");
        Console.WriteLine("====================");
    }
    
   
    public void ShowInventory()
    {
        if (inventory != null)
        {
            inventory.ShowInventory();
        }
    }
    
    
    public void AddItem(string item)
    {
        inventory.AddItem(item);
    }
}


// Player Subclass

// Player: Eleven
class Eleven : Player
{
int psychic power;
public Eleven(string name) : base(name)
{
psychicPower = 50;
Console.WriteLine(" Eleven is the Psychic ");
Console.WriteLine("Special Ability is Mind Power");
Console.WriteLine("Elevens psychic power: "+ psychicPower);
}

public override void SpecialAbility()
    {
        if (psychicPower >= 25)
        {
            Console.WriteLine( Name + " fires a mind power! ");
            Console.WriteLine("Deals 60 massive damage!");
            psychicPower -= 25;
            Console.WriteLine("Psychic power drop to: " + psychicPower);
        }
        else
        {
            Console.WriteLine("\nNot enough power! Need at least 25, we have :" + psychicPower);
        }
    }
    
    public override void LevelUp()
    {
        base.LevelUp();
        psychicPower += 15;
        Console.WriteLine(" Psychic power level up  to  " + psychicPower);
    }
    
    public override void Attack(Enemy target)
    {
        int psychicDamage = 20 + (Level * 2) + (psychicPower / 10);
        Console.WriteLine(Name + " attack on  " + target.Name + "!");
        Console.WriteLine("Deals " + psychicDamage + " damage!");
        target.TakeDamage(psychicDamage);
    }
    
    public void ShowPsychicStatus()
    {
        Console.WriteLine("\nPsychic Power : " + psychicPower + "/100");
    }
}

//Player: Steve
class Steve : Player
{
    private int batDurability;
    
    public Steve(string name) : base(name)
    {
        batDurability = 100;
        Console.WriteLine(" Steve The Protector ");
        Console.WriteLine("Special Ability is Defensive Power");
        Console.WriteLine("Bat Durability: " + batDurability + "%");
    }
    
    public override void SpecialAbility()
    {
        Console.WriteLine( Name +"DEFENSE!");
        Console.WriteLine("Damage reduced by 50% for 3 turns!");
    }
    
    public override void LevelUp()
    {
        base.LevelUp();
        batDurability = Math.Min(100, batDurability + 30);
        Console.WriteLine(" Bat have been repaired! Durability: " + batDurability + "%");
    }
    
    public override void Attack(Enemy target)
    {
        if (batDurability <= 0)
        {
            Console.WriteLine("\n Bat is broken! Using fists!");
            int fistDamage = 8 + Level;
            Console.WriteLine(Name + " punch " + target.Name + " for " + fistDamage + " damage!");
            target.TakeDamage(fistDamage);
            return;
        }
        
        int batDamage = 15 + (Level * 2);
        Console.WriteLine( Name + " attack the bat towards " + target.Name + "!");
        Console.WriteLine("The attack deals " + batDamage + " damage!");
        target.TakeDamage(batDamage);
        
        batDurability -= 8;
        Console.WriteLine("Bat durability: " + batDurability + "%");
    }
    
    public void ShowProtectorStatus()
    {
        Console.WriteLine("\nBat Durability: " + batDurability + "%");
    }
}

// Player : Dustin
class Dustin : Player
{
    private int intelligence;
    private bool hasAnalyzed;
    
    public Dustin(string name) : base(name)
    {
        intelligence = 50;
        hasAnalyzed = false;
        Console.WriteLine(" Dustin The MasterMind");
        Console.WriteLine("Special Ability is Analyze Enemy");
        Console.WriteLine("Intelligence: " + intelligence);
    }
    
    public override void SpecialAbility()
    {
        Console.WriteLine( Name + " analyzes the enemy!");
        Console.WriteLine("Enemy weakness have been  revealed!");
        intelligence += 5;
        hasAnalyzed = true;
        Console.WriteLine("Intelligence power has increased to: " + intelligence);
    }
    
    public override void LevelUp()
    {
        base.LevelUp();
        intelligence += 15;
        Console.WriteLine(" Intelligence power increased to: " + intelligence);
    }
    
    public override void Attack(Enemy target)
    {
        int gadgetDamage = 12 + (Level * 2) + (intelligence / 10);
        
        if (hasAnalyzed)
        {
            gadgetDamage += 15;
            Console.WriteLine("\n Using enemy weakness!");
            hasAnalyzed = false;
        }
        
        Console.WriteLine( Name + " use the gadget on " + target.Name + "!");
        Console.WriteLine("The attack deals " + gadgetDamage + " damage!");
        target.TakeDamage(gadgetDamage);
    }
    
    public void ShowStrategistStatus()
    {
        Console.WriteLine("\nIntelligence: " + intelligence + "/100");
        Console.WriteLine("Weakness Known: " + (hasAnalyzed ? "Yes" : "No"));
    }
}





