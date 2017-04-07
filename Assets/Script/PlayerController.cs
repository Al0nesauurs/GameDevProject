using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    private bool CanWalk = true;
    private bool CanJump = true;
    private bool usingitem = false;
    public static bool CursorResume = true;
    public static bool canrightclick = true;
    private float distToGround;
    public float force = 5;
    public float MouseSpeed = 3;
    float mouseInputX, mouseInputY;
    public static int PlayerHealth = 100;
    public WeaponController WeaponControl;
    public WeaponNameController WeaponNameControl;
    public Camera Tps;
    public Camera Fps;
    public Slider healthSlider;
	//public Image damageImage;
	public Color flashColour = new Color(1f, 0f, 0f, 0.1f);
	private double timer = 1.0;
	public Image Heart;



    void Start()
    {
        PlayerHealth = 100;
        Tps.enabled = true;
        Fps.enabled = false;
        distToGround = GameObject.Find("LegRight").GetComponent<Collider>().bounds.extents.y;
        GameObject.Find("Crosshair").GetComponent<Canvas>().enabled = false;

    }

    void Update()
    {
        //Mouse rotate control
        CanJump = IsGrounded();

        mouseInputY += Input.GetAxis("Mouse X") * MouseSpeed * Time.deltaTime * 20;
        mouseInputX -= Input.GetAxis("Mouse Y") * MouseSpeed * Time.deltaTime * 20;
        mouseInputX = Mathf.Clamp(mouseInputX, -80, 45);
        gameObject.transform.rotation = Quaternion.Euler(mouseInputX, mouseInputY, 0);

        if (Input.GetAxis("Horizontal") != 0 && CanWalk)
        {
            gameObject.transform.Translate(Input.GetAxis("Horizontal") * Vector3.right * Time.deltaTime * 1f * force);
        }

        if (Input.GetAxis("Vertical") != 0 && CanWalk)
        {
            gameObject.transform.Translate(Input.GetAxis("Vertical") * Vector3.forward * Time.deltaTime * 1f * force);
        }

        if (Input.GetKeyDown(KeyCode.Space) && CanJump)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(new Vector2(0, 2000));
        }
        if (Input.GetAxis("Mouse ScrollWheel") < 0 || Input.GetKeyDown(KeyCode.Z) && Tps.enabled == false)
        {
            GameObject.Find("Crosshair").GetComponent<Canvas>().enabled = false;
            Tps.enabled = true;
            Fps.enabled = false;
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0 || Input.GetKeyDown(KeyCode.Z) && Tps.enabled == true)
        {
            GameObject.Find("Crosshair").GetComponent<Canvas>().enabled = true;
            Tps.enabled = false;
            Fps.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            if (WeaponNameController.weaponname != "hand")
            {
                CursorResume = false;
            }
            if (Time.timeScale == 1)
            {
                Cursor.visible = true;
                Time.timeScale = 0;
                GameObject.Find("PauseMenu").GetComponent<Canvas>().enabled = true;
            }
            else
            {
                if (CursorResume)
                    Cursor.visible = true; 
                else
                    Cursor.visible=false;
                Time.timeScale = 1;
                GameObject.Find("PauseMenu").GetComponent<Canvas>().enabled = false;
            }

        }
        if (Input.GetKeyDown(KeyCode.Mouse0)&&Time.timeScale == 1)
        {
            WeaponControl.CheckWeapon();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1)&&Time.timeScale == 1)
        {
            RaycastHit vHit = new RaycastHit();
            Ray vRay = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(vRay, out vHit, 0.5f) && canrightclick)
            {
                if (vHit.collider.gameObject.tag == "ItemTag")
                {
                    //Debug.Log("Right");
                    WeaponNameControl = (WeaponNameController)vHit.collider.gameObject.GetComponent(typeof(WeaponNameController));
                    WeaponNameController.weaponname = vHit.collider.gameObject.name;
                    Destroy(vHit.collider.gameObject);
                    canrightclick = false;
                }

            }
        }

        if (Input.GetKeyDown(KeyCode.R) && WeaponNameController.weaponname != "hand"&&Time.timeScale == 1)
        {
            WeaponController.ammo = 0;
            WeaponController.startReload = true;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

		timer -= Time.deltaTime;


		if (timer <= 0) 
		{
			if (timer <= -0.5) 
			{
				timer = 0.5;
			}
			if (PlayerHealth < 50) 
			{
				Heart.GetComponent<Canvas>().enabled = false;
			}
		} 
		else if (timer > 0) 
		{
			Heart.GetComponent<Canvas>().enabled = true;
		}
		



    }

    public void TakeDamage(int damage)
    {
        PlayerHealth -= damage;
        healthSlider.value = PlayerHealth;
        Debug.Log("DAMAGE! " + damage + "now player health = " + PlayerHealth);
        if (PlayerHealth <= 0)
        {
            Time.timeScale = 0;
            GameObject.Find("Crosshair").GetComponent<Canvas>().enabled = true;
            GameObject.Find("Crosshair").GetComponent<Text>().text = "You are DEAD!";
        }
    }

    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.1f);
    }
}
