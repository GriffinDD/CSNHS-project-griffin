using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public float loc;
    public float fire;
    public GameObject player;
    public GameObject bullet;
    public float TimeFire;
    public int timer = 0;
    public int stopper = 0;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("playercube");
        bullet = GameObject.Find("Bullet");
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = this.transform.position;
        if (position.x <=  (float)1.22 && stopper == 0)
        {
             if(loc == 0)
            {
                fire = 0;
                timer = 0;
            }
             loc = (float)1;
        }else if(position.x >= (float)8.45 && stopper == 0)
        {
            if(loc == 1)
            {
                fire = 0;
                timer = 0;
            }
            loc = (float)0;
        }
        if(loc == (float)1 && stopper == 0)
        {
            position.x = position.x + (float).01;
            this.transform.position = position;
        }else if(loc == (float)0 && stopper == 0)
        {
            position.x = position.x - (float).01;
            this.transform.position = position;
        }
        Vector2 playerpos = player.transform.position;
        if(playerpos.x <= position.x && loc == 0 && (position.y <= playerpos.y+(float).75 && position.y >= playerpos.y-(float).75))
        {
            this.GetComponent<Rigidbody2D>().velocity = 35 * transform.localScale.x * this.transform.right *  0;
            stopper = 1;
            if (fire <= 4)
            {
                if (timer == 0)
                {
                float xpos = position.x;
                float ypos = position.y;
                Vector2 newpos = new Vector2(xpos - (float).5, ypos);
                GameObject clone;
                clone = Instantiate(bullet);
                clone.tag = "Bullet";
                clone.transform.position = newpos;
                clone.GetComponent<Rigidbody2D>().velocity = 35 * transform.localScale.x * clone.transform.right * -1;
                TimeFire = Time.time;
                timer = 1;
                fire = fire + 1;
                }
                if (Time.time - TimeFire >= .3)
                {
                    timer = 0;
                }
                        
            }
            if (fire >= 4)
            {
                stopper = 0;
            }
        }
        else if (playerpos.x >= position.x && loc == 1 && (position.y <= playerpos.y + (float).75 && position.y >= playerpos.y - (float).75))
        {
            this.GetComponent<Rigidbody2D>().velocity = 35 * transform.localScale.x * this.transform.right * 0;
            stopper = 1;
            if (fire <= 4)
            {
                if (timer == 0)
                {
                    float xpos = position.x;
                    float ypos = position.y;
                    Vector2 newpos = new Vector2(xpos + (float).5, ypos);
                    GameObject clone;
                    clone = Instantiate(bullet);
                    clone.tag = "Bullet";
                    clone.transform.position = newpos;
                    clone.GetComponent<Rigidbody2D>().velocity = 35 * transform.localScale.x * clone.transform.right * 1;
                    TimeFire = Time.time;
                    timer = 1;
                    fire = fire + 1;
                }
                if (Time.time - TimeFire >= .3)
                {
                    timer = 0;
                }

            }
            if (fire >= 4)
            {
                stopper = 0;
            }
        }

    }
}
