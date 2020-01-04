using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public bool check = false;
    public GameObject bullet;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            check = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        bullet = GameObject.Find("Bullet");
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector2 position = this.transform.position;
            position.x = position.x - (float).02;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector2 position = this.transform.position;
            position.x = position.x + (float).02;
            this.transform.position = position;
        }
        if (Input.GetKeyDown(KeyCode.W)&& !check)
        {
            check = true;
            this.rigidbody.velocity = Vector2.up * 4;  
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.localScale = new Vector2((float).2, (float).2);
        }
        else
        {
            gameObject.transform.localScale = new Vector2((float).2, (float).4);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector2 position = this.transform.position;
            float xpos = position.x;
            float ypos = position.y;
            Vector2 newpos = new Vector2(xpos+(float).1,ypos);
            GameObject clone;
            clone = Instantiate(bullet);
            clone.transform.position = newpos;
            clone.GetComponent<Rigidbody2D>().velocity = 35 * transform.localScale.x * clone.transform.right;
        }
    }
    }