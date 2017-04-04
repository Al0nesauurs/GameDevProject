using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_menu : MonoBehaviour {
	
	public void Resume()
	{
		GameObject.Find("PauseMenu").GetComponent<Canvas>().enabled = false;
	}

	public void Restart()
	{
		SceneManager.LoadScene("MyGame");
	}

	public void ShowKeyControl()
	{
		GameObject.Find("KeyboardControl").GetComponent<Canvas>().enabled = true;
	}

	public void Back()
	{
		GameObject.Find("KeyboardControl").GetComponent<Canvas>().enabled = false;
	}




}
