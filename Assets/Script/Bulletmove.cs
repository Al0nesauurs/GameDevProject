using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmove : MonoBehaviour {
    private float t;
    private PigController Pigscript;
    private WeaponNameController WeaponNameControl;
    private int power = 10;
    public int speed = 1;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        t += Time.deltaTime;
        if (t > 5)
            Destroy(gameObject);
		gameObject.transform.Translate(Vector3.forward * Time.deltaTime * 10f*speed);
        RaycastHit hit;
        Ray fRay = new Ray(transform.position, Vector3.forward);

        if (Physics.Raycast(fRay, out hit,0.5f))
        {

            ApplyDamage(hit.collider.gameObject);
        }
	}


    public void ApplyDamage(GameObject other)
    {
        if (other.tag == "PigTag")
        {
            Pigscript = (PigController)other.GetComponent(typeof(PigController));
            Pigscript.HpController(power);

        }
        Destroy(gameObject);

    }
}
