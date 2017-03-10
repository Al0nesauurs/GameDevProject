using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour {

    public GameObject Bullet;
    public Transform BulletSpawn;
    public GameObject Pistol;
    public Transform ArmLocate;
    float t = 0;
    bool hit = false;

    void Start () {
	}

	
	// Update is called once per frame
	void Update () {
		BulletSpawn = GameObject.Find ("BulletSpawn").transform;

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
    }
    public void CheckWeapon()
    {
        Debug.Log("CheckWEapon" + gameObject.name);
        if(gameObject.name=="hand")
        {
            hit = true;
        }
        else if (gameObject.name=="pistol"|| gameObject.name == "pistol(Clone)")
        {
            Instantiate(Bullet, BulletSpawn.position, BulletSpawn.rotation);
        }
    }
}
