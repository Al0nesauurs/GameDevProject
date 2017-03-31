using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnUnitStep : MonoBehaviour {

    int [] maxpig = {10,7,6,5,2,0,0};
    int [] maxtiger = { 0, 2, 3, 5, 7,0,0 };
    int stage = 0;
    void start()
    {

    }
	
	// Update is called once per frame
	void Update () {
        if (GameObject.FindGameObjectsWithTag("PigTag").Length==0)
        {
            Debug.Log("stage= " + stage);
            PigSpawn.number = maxpig[stage];
            LionSpawn.number = maxtiger[stage];
            PigSpawn.start = true;
            LionSpawn.start = true;
            stage++;
        }



    }
}
