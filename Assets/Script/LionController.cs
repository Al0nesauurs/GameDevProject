using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LionController : MonoBehaviour {

    Transform playerarm;
    float trun = 0;
    public float hp = 50;
    public static float damageApply = 0;
    bool running = false;
    bool fliping = false;
    float TimetoWalk = -10;
    public float speedup = 0;
    public GameObject meat;
    public float lionspeed = 0.03f;

    // Use this for initialization
    void Start()
    {
        playerarm = GameObject.Find("PlayerArm").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            run(trun += Time.deltaTime);
        }
        else
        {
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
    void run(float timerun)
    {

        if (timerun >= 10)
        {
            running = false;
            trun = 0;
        }
        var targetPosition = playerarm.position;
        targetPosition.y = transform.position.y;
        gameObject.transform.LookAt(targetPosition);
        gameObject.transform.Translate(Vector3.forward * lionspeed * 2.75f);

    }
    void DropItem()
    {
        Vector3 meatposition = new Vector3(Random.Range(gameObject.transform.position.x + 0.3f, gameObject.transform.position.x - 0.3f), gameObject.transform.position.y, gameObject.transform.position.z);
        Instantiate(meat, meatposition, Quaternion.identity);
    }
}
