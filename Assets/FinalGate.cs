using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalGate : MonoBehaviour
{
    [SerializeField] private GameObject gate;
    [SerializeField] private GameObject key;
    [SerializeField] private InventoryManager im;
    public bool playerInRange, hasKeyy, interactt;

    private void OnTriggerStay(Collider other)
    {
        if (im != null)
        {
            if(key==null)hasKeyy = true;
            interactt = im.interact;
        }

        if (playerInRange)
        {
            if (interactt && hasKeyy)
            {

                Debug.Log("doing the thing");
                Destroy(gate.gameObject);
                StartCoroutine(EndTimer());
            }
        }
    }

    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other) { playerInRange = true; im = other.gameObject.GetComponent<InventoryManager>(); Debug.Log(other); }
    private void OnTriggerExit(Collider other) { playerInRange = false; }

    IEnumerator EndTimer()
    {
        yield return new WaitForSeconds(3);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
