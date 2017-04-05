using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pause_menu : MonoBehaviour
{

    public void Resume()
    {
        Time.timeScale = 1;
        GameObject.Find("PauseMenu").GetComponent<Canvas>().enabled = false;
        if(!PlayerController.CursorResume)
            Cursor.visible = false;
    }

    public void Restart()
    {
        Time.timeScale = 1;
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
