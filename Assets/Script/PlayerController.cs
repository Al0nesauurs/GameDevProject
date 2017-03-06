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
    public GameObject Bullet;
    public Transform BulletSpawn;
    public Camera Tps;
    public Camera Fps;
    float mouseInputX, mouseInputY;
    


    // Use this for initialization
    void Start () {
        Tps.enabled = true;
        Fps.enabled = false;
        distToGround = GameObject.Find("LegRight").GetComponent<Collider>().bounds.extents.y;
        usingitem = GameObject.Find("PauseMenu").GetComponent<Canvas>().enabled;
    }
	
	// Update is called once per frame
	void Update () {
        //Mouse rotate control
        CanJump = IsGrounded();

         mouseInputY += Input.GetAxis("Mouse X")*MouseSpeed;
         mouseInputX -= Input.GetAxis("Mouse Y")*MouseSpeed;
         mouseInputX = Mathf.Clamp(mouseInputX, -80, 45);
         gameObject.transform.rotation = Quaternion.Euler(mouseInputX, mouseInputY, 0);

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
        if(Input.GetAxis("Mouse ScrollWheel")<0)
        {
            Cursor.visible = true;
            Tps.enabled = true;
            Fps.enabled = false;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            Cursor.visible = false;
            Tps.enabled = false;
            Fps.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(usingitem==false)
            {
                CanWalk = false;
                CanJump = false;
                usingitem = true;
                GameObject.Find("PauseMenu").GetComponent<Canvas>().enabled = true;
            }
            else if(usingitem==true)
            {
                CanWalk = true;
                CanJump = true;
                usingitem = false;
                GameObject.Find("PauseMenu").GetComponent<Canvas>().enabled = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
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
