using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOnePickUp : MonoBehaviour
{
    public GameObject promptSprite;

    public AudioSource audioScource;
    public AudioClip soundFX;
	
	void Start()
	{
		globalVariables.itemOne = 0;
	}

    private void Update()
    {
        if (promptSprite.activeInHierarchy && Input.GetKeyDown("e"))
        {
            globalVariables.itemOne = globalVariables.itemOne + 1;
            audioScource.clip = soundFX;
            audioScource.Play();
            Destroy(gameObject);
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            promptSprite.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            promptSprite.SetActive(false);
        }
    }

}
