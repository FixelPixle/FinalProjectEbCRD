using System.Collections.Generic;
using UnityEngine;

public class GlobalInventory : MonoBehaviour
{
    public static GlobalInventory Instance; // Singleton instance

    // Dictionary to store multiple items with unique identifiers (like "Key1", "Key2", etc.)
    private Dictionary<string, bool> inventory = new Dictionary<string, bool>();

    void Awake()
    {
        
        if (Instance == null)
        {
            Instance = this; // Ensure the inventory persists across scenes
        }
        else
        {
            Destroy(gameObject); // Ensure only one instance exists
        }
    }

    // Add item to the inventory
    public void AddItem(string itemName)
    {
        if (!inventory.ContainsKey(itemName))
        {
            inventory.Add(itemName, true); // Store the item in the inventory
        }
    }

    // Check if the inventory contains a specific item
    public bool HasItem(string itemName)
    {
        return inventory.ContainsKey(itemName);
    }
}