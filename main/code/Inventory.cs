using System;
using System.Collections.Generic;

class Inventory
{
    // Attributes
    private List<string> items;
    private string equippedItem;

    // Constructor
    public Inventory()
    {
        items = new List<string>();
        equippedItem = null;
    }

    // Add item
    public void AddItem(string item)
    {
        items.Add(item);
        Console.WriteLine(item + " added to inventory.");
    }

    // Remove item
    public void RemoveItem(string item)
    {
        if (items.Contains(item))
        {
            items.Remove(item);
            Console.WriteLine(item + " removed from inventory.");
        }
        else
        {
            Console.WriteLine(item + " not found in inventory.");
        }
    }

    // Use item
    public void UseItem(string item)
    {
        if (items.Contains(item))
        {
            Console.WriteLine("You used " + item + ".");
        }
        else
        {
            Console.WriteLine(item + " is not in inventory.");
        }
    }

    // Equip item
    public void EquipItem(string item)
    {
        if (items.Contains(item))
        {
            equippedItem = item;
            Console.WriteLine(item + " is now equipped.");
        }
        else
        {
            Console.WriteLine(item + " cannot be equipped.");
        }
    }

    // Show inventory
    public void ShowInventory()
    {
        Console.WriteLine("Inventory Items:");

        foreach (string item in items)
        {
            Console.WriteLine("- " + item);
        }
    }
}