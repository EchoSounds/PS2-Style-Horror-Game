using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour
{
	public GameObject endOfGameScreen;

    void Update()
    {
        if(globalVariables.itemOne == 1 && globalVariables.itemTwo == 2)
		{
			endOfGameScreen.SetActive(true);
		}
    }
}
