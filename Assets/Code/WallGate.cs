using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WallGate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("box hit");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
}
