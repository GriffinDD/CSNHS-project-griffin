using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public float loc;
    public GameObject player;
    public GameObject bullet;
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
        if (position.x <=  (float)1.22)
        {
             loc = (float)1;
        }else if(position.x >= (float)8.45)
        {
             loc = (float)0;
        }
        if(loc == (float)1)
        {
            position.x = position.x + (float).01;
            this.transform.position = position;
        }else if(loc == (float)0)
        {
            position.x = position.x - (float).01;
            this.transform.position = position;
        }
        Vector2 playerpos = player.transform.position;
        if(playerpos.x <= position.x && loc == 0 && (position.y <= playerpos.y+(float).75 && position.y >= playerpos.y-(float).75))
        {
            float xpos = position.x;
            float ypos = position.y;
            Vector2 newpos = new Vector2(xpos - (float).1, ypos);
            GameObject clone;
            clone = Instantiate(bullet);
            clone.transform.position = newpos;
            clone.GetComponent<Rigidbody2D>().velocity = 35 * transform.localScale.x * clone.transform.right*-1;
        }else if (playerpos.x >= position.x && loc == 1 && (position.y <= playerpos.y + (float).75 && position.y >= playerpos.y - (float).75))
        {
            float xpos = position.x;
            float ypos = position.y;
            Vector2 newpos = new Vector2(xpos - (float).1, ypos);
            GameObject clone;
            clone = Instantiate(bullet);
            clone.transform.position = newpos;
            clone.GetComponent<Rigidbody2D>().velocity = 35 * transform.localScale.x * clone.transform.right;
        }

    }
}
