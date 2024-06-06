// Scripts/Item.cs
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string itemName = "New Item";
    public Sprite icon = null;
    public bool isConsumable = false;

    public virtual void Use()
    {
        // Implementar uso do item
        Debug.Log("Using item: " + itemName);
    }
}