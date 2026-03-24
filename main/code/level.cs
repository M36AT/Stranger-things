using System;
using System.Collections.Generic;

class Level
{
    // Attributes
    private int levelNumber;
    private string levelName;
    private List<Enemy> enemies;
    private bool isCompleted;
    private string levelDescription;
    
    // Constructor
    public Level(int levelNum)
    {
        levelNumber = levelNum;
        enemies = new List<Enemy>();
        isCompleted = false;
        
        if (levelNumber == 1)
        {
            levelName = "Abandoned Woods";
            levelDescription = "A forest where trees look like skeletal fingers reaching for a bruised, purple sky.";
            InitializeLevel1Enemies();
        }
        else if (levelNumber == 2)
        {
            levelName = "The Upside Realm";
            levelDescription = "The core of the nightmare. Gravity feels wrong, and vines move like snakes under your feet.";
            InitializeLevel2Enemies();
        }
    }
    
    // Methods to initialize enemies for each level
    private void InitializeLevel1Enemies()
    {
        // Level 1 enemies - Demogorgons and Shadow Guards
        enemies.Add(new Demogorgon());
        enemies.Add(new Demogorgon());
        enemies.Add(new ShadowGuard("Fear of the dark"));
    }
    
    private void InitializeLevel2Enemies()
    {
        // Level 2 enemies - Stronger enemies
        enemies.Add(new ShadowGuard("Fear of losing yourself"));
        enemies.Add(new ShadowGuard("Fear of being trapped"));
        enemies.Add(new MindFlayer());
        enemies.Add(new Vecna()); // Final boss
    }
    
    // Get methods
    public int GetLevelNumber()
    {
        return levelNumber;
    }
    
    public string GetLevelName()
    {
        return levelName;
    }
    
    public string GetLevelDescription()
    {
        return levelDescription;
    }
    
    public bool IsCompleted()
    {
        return isCompleted;
    }
    
    public int GetRemainingEnemies()
    {
        return enemies.Count;
    }
    
    // Start the level - display intro
    public void StartLevel()
    {
        Console.WriteLine("\n╔════════════════════════════════════════════╗");
        Console.WriteLine("║              LEVEL " + levelNumber + "                      ║");
        Console.WriteLine("║         " + levelName.ToUpper() + "         ║");
        Console.WriteLine("╚════════════════════════════════════════════╝");
        Console.WriteLine("\n" + levelDescription);
        Console.WriteLine("\nPress any key to begin...");
        Console.ReadKey();
    }
    
    // Spawn the next enemy
    public Enemy SpawnEnemy()
    {
        if (enemies.Count > 0)
        {
            Enemy currentEnemy = enemies[0];
            enemies.RemoveAt(0);
            return currentEnemy;
        }
        return null;
    }
    
    // Check if there are more enemies
    public bool HasEnemiesRemaining()
    {
        return enemies.Count > 0;
    }
    
    // Complete the level
    public void CompleteLevel()
    {
        isCompleted = true;
        Console.WriteLine("\n You have completed " + levelName + "! ");
    }
    
    // Show level progress
    public void ShowLevelProgress()
    {
        Console.WriteLine("\n=== Level Progress ===");
        Console.WriteLine("Level: " + levelNumber + " - " + levelName);
        Console.WriteLine("Enemies remaining: " + enemies.Count);
        Console.WriteLine("Status: " + (isCompleted ? "COMPLETED ✓" : "IN PROGRESS"));
        Console.WriteLine("======================");
    }
}
