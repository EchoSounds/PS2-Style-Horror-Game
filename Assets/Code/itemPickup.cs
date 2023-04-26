using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class itemPickup : MonoBehaviour
{
    [SerializeField]private bool playerInRange;
    [SerializeField] string itemName;
    private InventoryManager im;
    [SerializeField]private ItemInventory ii;

    private void Start()
    {
        im = FindObjectOfType<InventoryManager>();
    }
    private void OnTriggerStay(Collider other)
    {
        if (playerInRange || Input.GetKeyDown(KeyCode.E))
        {
            if (ii == null) Debug.Log("no itemInventory set on " + gameObject.name);
            im.PickUpItem(ii);
            Destroy(this.gameObject);
        }
    }
}
