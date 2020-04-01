using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public bool check = false;
    public GameObject bullet;
    public GameObject hp;
    public GameObject text;
    public float health;
    public int HealthInt;
    public float hplocation;
    public float face = 0;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 position = this.transform.position;
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Platform")
        {
            check = false;
        }
        if (collision.gameObject.tag == "Bullet")
        {
            HealthInt = HealthInt - 1;
            health = health - 1;
            hp.transform.localScale = new Vector3(health, (float).5, 1);
            hp.transform.position = new Vector3(position.x - (float)4.5, position.y + (float)4.577, (float)-4.116654);
            text.transform.position = new Vector2(position.x - (float)4.5, position.y + (float)4.577);
            text.GetComponent<TextMesh>().text = HealthInt.ToString();
        }
    }
        void Start()
        {
            Vector2 position = this.transform.position;
            hp = Instantiate(GameObject.Find("HealthBar"));
            text = Instantiate(GameObject.Find("HealthText"));
            bullet = GameObject.Find("Bullet");
            rigidbody = GetComponent<Rigidbody2D>();
            Instantiate(hp);
            hp.transform.position = new Vector3(position.x - (float)4.5, position.y + (float)4.577, (float)-4.116654);
            Instantiate(text);
            health = (float)10;
            HealthInt = 10;
            hp.transform.localScale = new Vector3(health, (float).5, 1);
            hp.GetComponent<Renderer>().material.color = Color.green;
            text.transform.position = new Vector2(position.x - (float)4.5, position.y + (float)4.577);
            text.GetComponent<TextMesh>().characterSize = (float).2;
            text.GetComponent<TextMesh>().text = HealthInt.ToString();
        }
        void Update()
        {
        Vector2 HealthPosition = this.transform.position;
        hp.transform.localScale = new Vector3(health, (float).5, 1);
        hp.transform.position = new Vector3(HealthPosition.x - (float)4.5, HealthPosition.y + (float)4.577, (float)-4.116654);
        text.transform.position = new Vector2(HealthPosition.x - (float)4.5, HealthPosition.y + (float)4.577);
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
            if (Input.GetKeyDown(KeyCode.W) && !check)
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
                if (face == 0)
                {
                    Vector2 newpos = new Vector2(xpos + (float).5, ypos);
                    GameObject clone;
                    clone = Instantiate(bullet);
                    clone.transform.position = newpos;
                    clone.GetComponent<Rigidbody2D>().velocity = 40 * transform.localScale.x * clone.transform.right;
                } else if (face == 1)
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