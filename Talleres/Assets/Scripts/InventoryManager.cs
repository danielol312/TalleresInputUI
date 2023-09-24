using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [SerializeField] GameObject prefabItem;
    [SerializeField] List<Item> currentItems;
    List<GameObject> currentItemsObjects = new List<GameObject>();
    InventorySlot[] slots;
    private void Awake()
    {
        slots = GetComponentsInChildren<InventorySlot>();
    }
    void Start()
    {
        //inicialize curentItems list and fill the slots
        for (int i = 0;i<currentItems.Count;i++)
        {
            var item = Instantiate(prefabItem, slots[i].transform);
            item.GetComponent<DragableItem>().InitializeItem(currentItems[i].name, currentItems[i].itemIcon,
                currentItems[i].category, currentItems[i].information, currentItems[i].damage);
            currentItemsObjects.Add(item);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public enum ItemCategory
{
    Weapon,
    Helmet,
    Chest,
    Potion,
    // Agrega más categorías según tus necesidades
}

