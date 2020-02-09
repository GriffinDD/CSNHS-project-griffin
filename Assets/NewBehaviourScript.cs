using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public bool check = false;
    public GameObject bullet;
<<<<<<< HEAD
    public GameObject hp;
    public GameObject text;
    public float health;
    public int HealthInt;
    public float hplocation;
    public float face = 0;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Platform")
        {
            check = false;
        }
        if (collision.gameObject.tag == "Bullet")
        {
            health = health - (float).6;
            HealthInt = HealthInt - 1;
            hp.transform.localScale = new Vector3(health, (float).5, 1);
            hplocation = hp.transform.position.x- (float)1.2;
            hp.transform.position = new Vector3(hplocation, (float)4.577, (float)-4.116654);
            text.transform.position = new Vector2((float)-9.12, (float)4.7);
            text.GetComponent<TextMesh>().text = HealthInt.ToString();
=======
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            check = false;
>>>>>>> 5b0471cbc637fb1cc01dc1eaf75d857acb618c2d
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        hp = GameObject.Find("HealthBar");
        text = GameObject.Find("HealthText");
        bullet = GameObject.Find("Bullet");
        rigidbody = GetComponent<Rigidbody2D>();
        Instantiate(hp);
        Instantiate(text);
        health = (float)6;
        HealthInt = 10;
        hp.transform.localScale = new Vector3(health, (float).5, 1);
        hp.GetComponent<Renderer>().material.color = Color.green;
        text.GetComponent<TextMesh>().characterSize = (float).2;
        text.GetComponent<TextMesh>().text = HealthInt.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector2 position = this.transform.position;
            position.x = position.x - (float).02;
            this.transform.position = position;
            face = 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector2 position = this.transform.position;
            position.x = position.x + (float).02;
            this.transform.position = position;
            face = 0;
        }
        if (Input.GetKeyDown(KeyCode.W)&& !check)
        {
            check = true;
            this.rigidbody.velocity = Vector2.up * 5;  
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
            if(face == 0)
            {
                Vector2 newpos = new Vector2(xpos + (float).5, ypos);
                GameObject clone;
                clone = Instantiate(bullet);
                clone.transform.position = newpos;
                clone.GetComponent<Rigidbody2D>().velocity = 40 * transform.localScale.x * clone.transform.right;
            }else if(face == 1)
            {
                Vector2 newpos = new Vector2(xpos - (float).5, ypos);
                GameObject clone;
                clone = Instantiate(bullet);
                clone.transform.position = newpos;
                clone.GetComponent<Rigidbody2D>().velocity = 40 * transform.localScale.x * clone.transform.right * -1;
            }
            
        }
    }
    }