using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponNameController : MonoBehaviour
{

    public GameObject Pistol;
    public GameObject MachineGun;
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

        if (fix&&weaponname!="hand")
        {
            if (weaponname == "pistol" || weaponname == "pistol(Clone)")
            {
                myNew = Instantiate(Pistol, gameObject.transform.position, gameObject.transform.rotation);
                WeaponController.ammo = 10;
                Bulletmove.power = 10;
            }
            else if (weaponname == "machinegun" || weaponname == "machinegun(Clone)")
             {
                myNew = Instantiate(MachineGun, gameObject.transform.position, gameObject.transform.rotation);
                WeaponController.ammo = 30;
                Bulletmove.power = 20;
            }
            Debug.Log("Add Weapon" + weaponname);
			myNew.transform.parent = gameObject.transform;
            Cursor.visible = false;
			fix = false;
            parented = true;
		}
        if(weaponname=="pistol" && Input.GetKeyDown(KeyCode.G)|| weaponname == "pistol(Clone)" && Input.GetKeyDown(KeyCode.G) ||
            weaponname == "machinegun" && Input.GetKeyDown(KeyCode.G) || weaponname == "machinegun(Clone)"&& Input.GetKeyDown(KeyCode.G))
        {
            PlayerController.canrightclick = true;
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
