using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownController : MonoBehaviour {
    float mouseInputX, mouseInputY;
    public float MouseSpeed = 3;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        mouseInputY += Input.GetAxis("Mouse X") * MouseSpeed;
        mouseInputX -= Input.GetAxis("Mouse Y") * MouseSpeed;
        mouseInputX = Mathf.Clamp(mouseInputX, -80, 45);
        gameObject.transform.rotation = Quaternion.Euler(mouseInputX, mouseInputY, 0);
    }
}
