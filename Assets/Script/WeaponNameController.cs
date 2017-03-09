using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponNameController : MonoBehaviour
{

    public GameObject Pistol;
	public static string weaponname="hand";
	bool fix =true;
    bool parented=false;
    GameObject myNew;
    // Use this for initialization
    void Start()
    {

    }
	void Update()
	{

		if (weaponname == "pistol" && fix || weaponname == "pistol(Clone)"&&fix)
        {
            Debug.Log("Add Weapon" + weaponname);
            myNew = Instantiate (Pistol, gameObject.transform.position, gameObject.transform.rotation);
			myNew.transform.parent = gameObject.transform;
            Cursor.visible = false;
			fix = false;
            parented = true;
		}
        if(weaponname=="pistol" && Input.GetKeyDown(KeyCode.G)|| weaponname == "pistol(Clone)" && Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log("DropWeapon");
            weaponname = "hand";
            Cursor.visible = true;
            parented = false;
            myNew.transform.parent = null;
            fix = true;
        }

        gameObject.name = weaponname;
	}

    // Update is called once per frame


}
