using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NPCDialogue : MonoBehaviour
{
    private int dialogueProgression = 1;
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
            dialogueProgression = 1;
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
        }

        dialogueText.text = texts[dialogueProgression];
    }

    private void OnTriggerEnter(Collider other) { ToggleDialogueBox(); Debug.Log("entered"); }
    private void OnTriggerExit(Collider other) {  ToggleDialogueBox(); dialogueProgression = 0; Debug.Log("exit"); }
}
