using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionSpawn : MonoBehaviour {

    public GameObject LionModel;
    public float AllTime = 0;
    public static int number = 0;
    public static bool start = true;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        AllTime += Time.deltaTime;
        // Debug.Log("number = " +number);
        //Debug.Log(GameObject.FindGameObjectsWithTag("PigTag").Length);

        if (GameObject.FindGameObjectsWithTag("LionTag").Length < number && start)
        {
            Vector3 position = new Vector3(Random.Range(-7f, 8.5f), 5, Random.Range(0, 10f));
            var myNew = Instantiate(LionModel, position, Quaternion.identity);
            myNew.transform.parent = gameObject.transform;
        }
        else
        {
            LionSpawn.start = false;
        }


    }
}
