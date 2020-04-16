using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformPhysics : MonoBehaviour
{
    public GameObject player;
    public int drop;
    public float dropTime;
    void Start()
    {
        player = GameObject.Find("playercube");


    }
    void Update()
    {
            Vector2 playerPos = player.transform.position;
            Vector2 platformPos = this.transform.position;
            float distance = playerPos.y - platformPos.y;
            if (distance >= .25)
            {
                GetComponent<Collider2D>().enabled = true;
            }
            else
            {
                GetComponent<Collider2D>().enabled = false;


            }
        if (Input.GetKeyDown(KeyCode.S))
        {
            drop++;
            if(drop == 2)
            {
                dropTime = Time.time;
            }
        }
        if(drop>= 2)
        {
            GetComponent<Collider2D>().enabled = false;
        }
        if (drop >= 2 && Time.time-dropTime >= .4)
        {
            GetComponent<Collider2D>().enabled = true;
            drop = 0;
        }
    }
}