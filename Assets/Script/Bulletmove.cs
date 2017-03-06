using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletmove : MonoBehaviour {
    private float t;
    private PigController Pigscript;
    private TreeController Treescript;
    private ItemController Itemscript;
    private StoneController Stonescript;
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
//        Debug.Log(Input.mousePosition);
        gameObject.transform.Translate(Vector3.down * Time.deltaTime * 10f*speed);
        
	}
    void OnTriggerEnter(Collider other)
    {
        ApplyDamage(other.gameObject);
    }

    public void ApplyDamage(GameObject other)
    {
        if (other.tag == "PigTag")
        {
            Destroy(gameObject);
            Pigscript = (PigController)other.GetComponent(typeof(PigController));
            Pigscript.HpController(power);

        }
        if (other.layer==9)
        {
            Debug.Log("LAYER9");
            Destroy(gameObject);
        }

    }
}
