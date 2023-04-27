using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Progress;

public class InventoryManager : MonoBehaviour
{
    public bool hasSword;
    public bool hasBow;
    public bool hasKey;

    [SerializeField]private int currSlot;

    public List<GameObject> hotBarItems;
    public List<ItemInventory> items = new List<ItemInventory>();

    public ItemInventory activeItem;
    private GUIContent _itemButtonContent = new GUIContent();
    private SwordAttack sa;

    private void Start()
    {
        sa = GetComponent<SwordAttack>();
    }

    private void Update()
    {
        float scrollDelta = Input.mouseScrollDelta.y;
        if (scrollDelta > 0)
        {
            currSlot++;
            if (currSlot > items.Count-1)
            {
                currSlot = 0;
            }
            ActivateItem(items[currSlot]);
        }
        else if (scrollDelta < 0)
        {
            currSlot--;
            if (currSlot < 0)
            {
                currSlot = items.Count-1;
            }
            ActivateItem(items[currSlot]);
        }
    }

    public void PickUpItem(ItemInventory item)
    {
        items.Add(item);
        ActivateItem(item);
        foreach (GameObject barItem in hotBarItems)
        {
            if(barItem.name == item.iconLabel)
            {
                barItem.SetActive(true);
            }

            if(item.iconLabel == "Sword")
            {
                sa = GetComponent<SwordAttack>();
            }
        }
    }

    public void ActivateItem(ItemInventory item)
    {
        // Don't bother, this item is already active!
        if (item == activeItem)
            return;
        DeactivateItem();
        // Active inventory item!
        if(item.iconLabel == "Sword") sa.enabled = true;
        if (item.iconLabel == "Key") hasKey = true;

        activeItem = item;
        item.Activate();
    }
    public void DeactivateItem()
    {
        // No item is active, bail!
        if (activeItem == null)
            return;
        sa.enabled = false;
        hasKey = false;
        activeItem.Deactivate();
        activeItem = null;
    }
}
