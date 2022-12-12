using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseScript : MonoBehaviour
{
    public GameObject pauseMenu;

	void Start()
	{
		Time.timeScale = 0;
	}

    void Update()
    {
        if(Input.GetKeyDown("escape"))
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void resumeTime()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void quitProgram()
    {
        Application.Quit();
    }
}
