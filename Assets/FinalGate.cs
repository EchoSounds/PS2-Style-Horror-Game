using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalGate : MonoBehaviour
{
    [SerializeField] private GameObject gate;
    private void OnTriggerStay(Collider other)
    {
        InventoryManager im = other.GetComponent<InventoryManager>();

        if (im.hasKey && Input.GetKeyDown(KeyCode.E)) 
        {
            Destroy(gate.gameObject);
            EndTimer();
        }
    }

    IEnumerator EndTimer()
    {
        yield return new WaitForSeconds(3);
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

}
