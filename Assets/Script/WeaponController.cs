using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponController : MonoBehaviour {

    public GameObject Bullet;
    public Transform BulletSpawn;
    public GameObject Pistol;
    public Transform ArmLocate;
    public static int ammo =0;
    float t = 0;
    bool hit = false;
    float timeReload = 0;
    bool startReload = false;


    void Start () {
	}

	
	// Update is called once per frame
	void Update () {
		BulletSpawn = GameObject.Find ("BulletSpawn").transform;
        if (startReload)
        {
            timeReload += Time.deltaTime;
            if (timeReload < 3)
                GameObject.Find("Crosshair").GetComponent<Text>().text = "RELOADING IN "+(int)(4-timeReload)+"";
            else
            {
                GameObject.Find("Crosshair").GetComponent<Text>().text = "+";
                Debug.Log("RELOAD!" + timeReload);
                if (gameObject.name == "pistol" || gameObject.name == "pistol(Clone)")
                {
                    ammo = 10;
                }
                if (gameObject.name == "machinegun" || gameObject.name == "machinegun(Clone)")
                {
                    ammo = 30;
                }
                startReload = false;
                timeReload = 0;
            }
        }
        if (hit)
        {
            t += Time.deltaTime;
            if (t <= 0.1f)
                MeleeSystem.clicked = true;

            if (t <= 0.4)
            {

                gameObject.transform.Translate(Vector3.forward * Time.deltaTime * 1f);
            }
            if (t >= 0.4)
            {
                gameObject.transform.Translate(Vector3.back * Time.deltaTime * 1f);
            }
            if (t >= 0.8)
            {
                gameObject.transform.position = ArmLocate.transform.position;
                hit = false;
                t = 0;
            }
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            startReload = true;
        }
    }
    public void CheckWeapon()
    {
        Debug.Log("CheckWEapon" + gameObject.name);
        if(gameObject.name=="hand")
        {
            hit = true;
        }
        else if (gameObject.name=="pistol"|| gameObject.name == "pistol(Clone)"|| gameObject.name == "machinegun" || gameObject.name == "machinegun(Clone)")
        {
            if (ammo > 0)
            {
                Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
                ammo--;
            }
            if(ammo==0)
            {
               GameObject.Find("Crosshair").GetComponent<Text>().text = "RELOAD NOW!!";
            }
        }
    }
    
}
