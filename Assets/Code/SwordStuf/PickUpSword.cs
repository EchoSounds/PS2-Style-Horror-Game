using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSword : MonoBehaviour
{
    private bool playerInRange;
    public SwordAttack sa;

    private void OnTriggerStay(Collider other)
    {
        sa = other.GetComponent<SwordAttack>();

        if (Input.GetKeyUp(KeyCode.E) || playerInRange)
        {
            sa.hasSword = true;
            Destroy(this.gameObject);
        }
    }
}
