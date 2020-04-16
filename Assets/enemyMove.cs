using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public float loc;
    public int health = 3;
    public float fire;
    public float form;
    public float StartX;
    public GameObject player;
    public GameObject player2;
    public GameObject bulletPrefab;
    public float TimeFire;
    public int timer = 0;
    public int stopper = 0;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health = health - 1;
        }
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        player = GameObject.Find("playercube");
        player2 = GameObject.Find("Player2");
        Vector2 position = this.transform.position;
        StartX = position.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = this.transform.position;
        if (form == 1)
        {
            if (position.x <= (float)1.22 && stopper == 0)
            {
                if (loc == 0)
                {
                    fire = 0;
                    timer = 0;
                }
                loc = (float)1;
            }
            else if (position.x >= (float)8.45 && stopper == 0)
            {
                if (loc == 1)
                {
                    fire = 0;
                    timer = 0;
                }
                loc = (float)0;
            }
            if (loc == (float)1 && stopper == 0)
            {
                position.x = position.x + (float).01;
                this.transform.position = position;
            }
            else if (loc == (float)0 && stopper == 0)
            {
                position.x = position.x - (float).01;
                this.transform.position = position;
            }
        }
        else if(form == 2)
        {
            if (position.x <= StartX -(float)2.8204 && stopper == 0)
            {
                if (loc == 0)
                {
                    fire = 0;
                    timer = 0;
                }
                loc = (float)1;
            }
            else if (position.x >= StartX + (float)2.8204 && stopper == 0)
            {
                if (loc == 1)
                {
                    fire = 0;
                    timer = 0;
                }
                loc = (float)0;
            }
            if (loc == (float)1 && stopper == 0)
            {
                position.x = position.x + (float).01;
                this.transform.position = position;
            }
            else if (loc == (float)0 && stopper == 0)
            {
                position.x = position.x - (float).01;
                this.transform.position = position;
            }
        }else if (form == 3)
        {
            if (position.x <= StartX - (float)1.4391 && stopper == 0)
            {
                if (loc == 0)
                {
                    fire = 0;
                    timer = 0;
                }
                loc = (float)1;
            }
            else if (position.x >= StartX + (float)1.4391 && stopper == 0)
            {
                if (loc == 1)
                {
                    fire = 0;
                    timer = 0;
                }
                loc = (float)0;
            }
            if (loc == (float)1 && stopper == 0)
            {
                position.x = position.x + (float).01;
                this.transform.position = position;
            }
            else if (loc == (float)0 && stopper == 0)
            {
                position.x = position.x - (float).01;
                this.transform.position = position;
            }
        }
        Vector2 playerpos = player.transform.position;
        Vector2 player2pos = player2.transform.position;
        if((playerpos.x <= position.x && loc == 0 && (position.y <= playerpos.y+(float).75 && position.y >= playerpos.y-(float).75))||(player2pos.x <= position.x && loc == 0 && (position.y <= player2pos.y + (float).75 && position.y >= player2pos.y - (float).75)))
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
                clone = Instantiate(bulletPrefab);
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
        else if ((playerpos.x >= position.x && loc == 1 && (position.y <= playerpos.y + (float).75 && position.y >= playerpos.y - (float).75))||(player2pos.x >= position.x && loc == 1 && (position.y <= player2pos.y + (float).75 && position.y >= player2pos.y - (float).75)))
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
                    clone = Instantiate(bulletPrefab);
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
