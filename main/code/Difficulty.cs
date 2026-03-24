using System;

class Difficulty
{
    // Attributes
    private string difficultyLevel;
    private float enemyHealthMultiplier;
    private float enemyDamageMultiplier;
    private float experienceMultiplier;
    private float sanityLossMultiplier;
    private float playerDamageMultiplier;
    
    // Constructor
    public Difficulty()
    {
        difficultyLevel = "Normal";
        SetDifficultyValues();
    }
    
    public Difficulty(string selectedDifficulty)
    {
        difficultyLevel = selectedDifficulty;
        SetDifficultyValues();
    }
    
    // Set values based on difficulty
    private void SetDifficultyValues()
    {
        switch (difficultyLevel.ToLower())
        {
            case "easy":
                enemyHealthMultiplier = 0.7f;
                enemyDamageMultiplier = 0.6f;
                experienceMultiplier = 1.5f;
                sanityLossMultiplier = 0.7f;
                playerDamageMultiplier = 1.2f;
                break;
                
            case "normal":
                enemyHealthMultiplier = 1.0f;
                enemyDamageMultiplier = 1.0f;
                experienceMultiplier = 1.0f;
                sanityLossMultiplier = 1.0f;
                playerDamageMultiplier = 1.0f;
                break;
                
            case "hard":
                enemyHealthMultiplier = 1.5f;
                enemyDamageMultiplier = 1.5f;
                experienceMultiplier = 0.8f;
                sanityLossMultiplier = 1.3f;
                playerDamageMultiplier = 0.9f;
                break;
                
            case "nightmare":
                enemyHealthMultiplier = 2.0f;
                enemyDamageMultiplier = 2.0f;
                experienceMultiplier = 0.6f;
                sanityLossMultiplier = 2.0f;
                playerDamageMultiplier = 0.8f;
                break;
                
            default:
                // Default to normal if invalid
                enemyHealthMultiplier = 1.0f;
                enemyDamageMultiplier = 1.0f;
                experienceMultiplier = 1.0f;
                sanityLossMultiplier = 1.0f;
                playerDamageMultiplier = 1.0f;
                break;
        }
    }
    
    // Get methods
    public string GetDifficultyLevel()
    {
        return difficultyLevel;
    }
    
    public float GetEnemyHealthMultiplier()
    {
        return enemyHealthMultiplier;
    }
    
    public float GetEnemyDamageMultiplier()
    {
        return enemyDamageMultiplier;
    }
    
    public float GetExperienceMultiplier()
    {
        return experienceMultiplier;
    }
    
    public float GetSanityLossMultiplier()
    {
        return sanityLossMultiplier;
    }
    
    public float GetPlayerDamageMultiplier()
    {
        return playerDamageMultiplier;
    }
    
    // Calculate modified values
    public int CalculateEnemyHealth(int baseHealth)
    {
        return (int)(baseHealth * enemyHealthMultiplier);
    }
    
    public int CalculateEnemyDamage(int baseDamage)
    {
        return (int)(baseDamage * enemyDamageMultiplier);
    }
    
    public int CalculateExperience(int baseExperience)
    {
        return (int)(baseExperience * experienceMultiplier);
    }
    
    public int CalculateSanityLoss(int baseLoss)
    {
        return (int)(baseLoss * sanityLossMultiplier);
    }
    
    public int CalculatePlayerDamage(int baseDamage)
    {
        return (int)(baseDamage * playerDamageMultiplier);
    }
    
    // Change difficulty mid-game
    public void SetDifficulty(string newDifficulty)
    {
        difficultyLevel = newDifficulty;
        SetDifficultyValues();
        Console.WriteLine("\nDifficulty changed to: " + difficultyLevel);
        ShowDifficultyInfo();
    }
    
    // Display difficulty info
    public void ShowDifficultyInfo()
    {
        Console.WriteLine("\n╔════════════════════════════════════╗");
        Console.WriteLine("║     DIFFICULTY: " + difficultyLevel.PadRight(8) + "     ║");
        Console.WriteLine("╠════════════════════════════════════╣");
        Console.WriteLine("║ Enemy Health:      x" + enemyHealthMultiplier + "              ║");
        Console.WriteLine("║ Enemy Damage:      x" + enemyDamageMultiplier + "              ║");
        Console.WriteLine("║ Experience Gain:   x" + experienceMultiplier + "              ║");
        Console.WriteLine("║ Sanity Loss:       x" + sanityLossMultiplier + "              ║");
        Console.WriteLine("║ Player Damage:     x" + playerDamageMultiplier + "              ║");
        Console.WriteLine("╚════════════════════════════════════╝");
    }
    
    // Get warning message for difficulty
    public string GetDifficultyWarning()
    {
        if (difficultyLevel.ToLower() == "hard")
        {
            return "  HARD MODE: The Upside Realm will test your limits! ";
        }
        else if (difficultyLevel.ToLower() == "nightmare")
        {
            return " NIGHTMARE MODE: Vecna awaits the unprepared! ";
        }
        else if (difficultyLevel.ToLower() == "easy")
        {
            return " EASY MODE: A gentler journey through the Upside Realm ";
        }
        else
        {
            return " NORMAL MODE: A balanced experience ";
        }
    }
}
