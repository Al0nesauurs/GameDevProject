﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionController : MonoBehaviour {

    GameObject player;
    Transform playertran;
    float trun = 0;
    public int hp = 50;
    public static float damageApply = 0;
    bool running = false;
    bool fliping = false;
    float TimetoWalk = -10;
    public float speedup = 0;
    public GameObject meat; 
    public float lionspeed = 0.03f;

    int fieldOfViewRange = 45;
    UnityEngine.AI.NavMeshAgent nav;

    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playertran = player.transform; 

        nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            run();
        }
        else
        {
            if(CanSeePlayer())
            {
                Debug.Log("Detected!!!");
                running = true;
            }
            if (TimetoWalk <= 0)
            {
                if (!fliping)
                {
                    Vector3 wayPoint = new Vector3(Random.Range(-100, 100), gameObject.transform.position.y, Random.Range(-100, 100));
                    gameObject.transform.LookAt(wayPoint);
                    fliping = true;
                }


                gameObject.transform.Translate(Vector3.forward * lionspeed);
                TimetoWalk -= Time.deltaTime;
                if (TimetoWalk <= -5)
                {
                    fliping = false;
                    TimetoWalk = Random.Range(10, 15);
                }
            }
            else
            {
                TimetoWalk -= Time.deltaTime + speedup;
            }
        }

    }

    public void HpController(int damage)
    {
        Debug.Log("HP CON!");
        running = true;
        fliping = true;
        gameObject.transform.Translate(Vector3.up * Time.deltaTime * 10f);
        hp -= damage;

        if (hp <= 0)
        {
            DropItem();
            DropItem();
            DropItem();
            Destroy(gameObject);
        }
    }
    void run()
    {

        var targetPosition = playertran.position;
        //targetPosition.y = transform.position.y;
        //gameObject.transform.LookAt(targetPosition);
        //gameObject.transform.Translate(Vector3.forward * lionspeed * 2.75f);

        nav.SetDestination(targetPosition); 

    }
    void DropItem()
    {
        Vector3 meatposition = new Vector3(Random.Range(gameObject.transform.position.x + 0.3f, gameObject.transform.position.x - 0.3f), gameObject.transform.position.y, gameObject.transform.position.z);
        Instantiate(meat, meatposition, Quaternion.identity);
    }


    bool CanSeePlayer()
    {
        var rayDirection = player.transform.position - transform.position;
        RaycastHit hit;
        int layerMask = 1 << 10;
        layerMask = ~layerMask;

        if (Physics.Raycast(transform.position, rayDirection, out hit,3,layerMask))
        { // If the player is very close behind the player and in view the enemy will detect the player

            //Debug.Log(hit.transform.name);

            if (hit.transform.tag == "Player")
            { 
                //Debug.Log("Close");
                return true;
            }
        }
        if ((Vector3.Angle(rayDirection, transform.forward)) <= fieldOfViewRange){ // Detect if player is within the field of view
            if (Physics.Raycast(transform.position, rayDirection, out hit,20,layerMask))
            {
                //Debug.Log((Vector3.Angle(rayDirection, transform.forward)));
                if (hit.transform.tag == "Player")
                {
                    //Debug.Log("Can see player");
                    return true;
                }
                else {
                    //Debug.Log("Can not see player");
                    return false;
                }
            }
        }
        return false;
    }
}



   