using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    private bool CanWalk = true;
    private bool CanJump = true;
    private bool usingitem = false;
    public float force = 5;
    public float MouseSpeed = 3;
    private float distToGround;
	// Use this for initialization
	void Start () {
        distToGround = gameObject.GetComponent<Collider>().bounds.extents.y;
    }
	
	// Update is called once per frame
	void Update () {
        //Mouse rotate control
        CanJump = IsGrounded();
        float mouseInput = Input.GetAxis("Mouse X");
        Vector3 lookhere = new Vector3(0, mouseInput, 0);
        transform.Rotate(lookhere);

        if (Input.GetAxis("Horizontal")!=0&&CanWalk)
        {
            gameObject.transform.Translate(Input.GetAxis("Horizontal") *Vector3.right*Time.deltaTime * 1f*force);
        }

        if(Input.GetAxis("Vertical")!=0&&CanWalk)
        {
            gameObject.transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * 1f*force);
        }

        if(Input.GetKeyDown(KeyCode.Space)&&CanJump)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector2(0, 200));
        }

        if (Input.GetKeyDown(KeyCode.I))
        {
            if(usingitem==false)
            {
                CanWalk = false;
                CanJump = false;
                usingitem = true;
            }
            else if(usingitem==true)
            {
                CanWalk = true;
                CanJump = true;
                usingitem = false;
            }
        }
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

    }
    bool IsGrounded(){
   return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
 }
}
