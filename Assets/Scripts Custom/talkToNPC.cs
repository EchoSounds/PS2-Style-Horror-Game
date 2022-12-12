using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class talkToNPC : MonoBehaviour
{
    public GameObject dialogueBox;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            dialogueBox.SetActive(true);
        }
    }
}
