using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu_Button : MonoBehaviour {

    public void OnClickButton()
    {
        SceneManager.LoadScene("MyGame");
    }
}
