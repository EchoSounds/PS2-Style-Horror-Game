using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public Dialogue dialogue;

    private void OnTriggerEnter(Collider other)
    { if (other.CompareTag("Player")) FindObjectOfType<DialogueManager>().StartDialogue(dialogue); }
    private void OnTriggerExit(Collider other)
    { if (other.CompareTag("Player")) FindObjectOfType<DialogueManager>().EndDialogue(); }
}
