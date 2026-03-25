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
