using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    private int dialogueProgression;
    [SerializeField] private List<string> texts = new List<string>();
    public Canvas dialogueCanvas;
    public TextMeshProUGUI dialogueText;
    private bool dCactive = false;
    private bool textFinished;  

    private void Update()
    {
        if(!dCactive)
        {
            return;
        }
        else
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                dialogueProgression++;
                SetDialogueText();
                if(textFinished)
                {
                    textFinished = false;
                }
            }
        }
    }

    private void ToggleDialogueBox()
    {
        if(dCactive == false)
        {
            dCactive = true;
            dialogueCanvas.gameObject.SetActive(true);
            SetDialogueText();
        }
        else
        {
            dCactive = false;
            dialogueCanvas.gameObject.SetActive(false);
        }
    }

    private void SetDialogueText()
    {
        if (dialogueProgression == texts.Count)
        {
            textFinished = true;
            dialogueProgression = 0;
            dialogueText.text = "I wish you luck on your travels, are you confused on what your are meant to do???";
            return;
        }

        dialogueText.text = texts[dialogueProgression];
    }
 
    private void OnTriggerExit(Collider other) {  ToggleDialogueBox(); dialogueProgression = 0; }
    private void OnTriggerEnter(Collider other) { ToggleDialogueBox(); }
}
