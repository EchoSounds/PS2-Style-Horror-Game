using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSword : MonoBehaviour
{
    private bool playerInRange;
    public InventoryManager im;

    private void OnTriggerStay(Collider other)
    {
        im = other.GetComponent<InventoryManager>();

        if (Input.GetKeyUp(KeyCode.E) || playerInRange)
        {
            im.hasSword = true;
            Destroy(this.gameObject);
        }


    }
}
