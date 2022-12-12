using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class restartGame : MonoBehaviour
{
	void Start()
	{
		Time.timeScale = 0;
	}
	
	public void reloadTheScene()
	{
		SceneManager.LoadScene(0);
	}

}
