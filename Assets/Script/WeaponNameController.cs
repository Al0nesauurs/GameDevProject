using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponNameController : MonoBehaviour
{

    public GameObject Pistol;
	public static string weaponname="hand";
	bool fix =true;
    // Use this for initialization
    void Start()
    {

    }
	void Update()
	{
		if (weaponname == "pistol" && fix) {
			var myNew = Instantiate (Pistol, gameObject.transform.position, gameObject.transform.rotation);
			myNew.transform.parent = gameObject.transform;
            Cursor.visible = false;
			fix = false;
		}
		gameObject.name = weaponname;
	}

    // Update is called once per frame


}
