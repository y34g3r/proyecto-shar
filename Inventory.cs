using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<GameObject> items = new List<GameObject>();

    public void AddItem(GameObject item)
    {
        items.Add(item);
        Debug.Log("Objeto añadido al inventario: " + item.name);
    }

    public void RemoveItem(GameObject item)
    {
        items.Remove(item);
        Debug.Log("Objeto removido del inventario: " + item.name);
    }

    public List<GameObject> GetItems()
    {
        return items;
    }
}
