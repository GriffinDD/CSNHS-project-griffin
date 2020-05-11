using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public bool check = false;
    public GameObject bulletPrefab;
    public GameObject hp;
    public GameObject text;
    public float health;
    public int level;
    public int bossFight;
    public float StartX;
    public float StartY;
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
            text.GetComponent<TextMesh>().text = HealthInt.ToString();
            if(bossFight != 1)
            {
                hp.transform.position = new Vector3(position.x - (float)4.5, position.y + (float)4.577, (float)-4.116654);
                text.transform.position = new Vector2(position.x - (float)4.5, position.y + (float)4.577);
            }
            if(health <= 0)
            {
                if (level == 1)
                {
                    SceneManager.LoadScene("Level1.unity");
                }else if (level == 2)
                {
                    SceneManager.LoadScene("Level2.unity");
                }
                else if (level == 3)
                {
                    SceneManager.LoadScene("bossfight.unity");
                }
                else if (level == 4)
                {
                    SceneManager.LoadScene("Level3.unity");
                }
                else if (level == 5)
                {
                    SceneManager.LoadScene("Level4.unity");
                }
                else if (level == 6)
                {
                    SceneManager.LoadScene("Boss2.unity");
                }
            }
        }else if(collision.gameObject.tag == "Lazer")
        {
            HealthInt = HealthInt - 3;
            health = health - 3;
            hp.transform.localScale = new Vector3(health, (float).5, 1);
            text.GetComponent<TextMesh>().text = HealthInt.ToString();
            if (bossFight != 1)
            {
                hp.transform.position = new Vector3(position.x - (float)4.5, position.y + (float)4.577, (float)-4.116654);
                text.transform.position = new Vector2(position.x - (float)4.5, position.y + (float)4.577);
            }
            if (health <= 0)
            {
                SceneManager.LoadScene("Level1.unity");
            }
        }
    }
        void Start()
        {
            Vector2 position = this.transform.position;
            StartX = position.x;
            StartY = position.y;
            hp = Instantiate(GameObject.Find("HealthBar"));
            text = Instantiate(GameObject.Find("HealthText"));
            rigidbody = GetComponent<Rigidbody2D>();
            Instantiate(hp);
            Instantiate(text);
            health = (float)10;
            HealthInt = 10;
            hp.transform.localScale = new Vector3(health, (float).5, 1);
            hp.GetComponent<Renderer>().material.color = Color.green;
            text.GetComponent<TextMesh>().characterSize = (float).2;
            text.GetComponent<TextMesh>().text = HealthInt.ToString();
            if(bossFight == 1)
        {
            hp.transform.position = new Vector3((float)-4.6, (float)4.7, (float)-4.116654);
            text.transform.position = new Vector2((float)-4.6, (float)4.7);
        }
        else
        {
            hp.transform.position = new Vector3(position.x - (float)4.5, position.y + (float)4.577, (float)-4.116654);
            text.transform.position = new Vector2(position.x - (float)4.5, position.y + (float)4.577);
        }
        }
        void Update()
        {
        Vector2 position = this.transform.position;
        if(position.y < (float)-50)
        {
            this.transform.position = new Vector2(StartX,StartY);
            HealthInt = HealthInt - 2;
            health = health - 2;
            hp.transform.localScale = new Vector3(health, (float).5, 1);
            text.GetComponent<TextMesh>().text = HealthInt.ToString();
            if (bossFight != 1)
            {
                hp.transform.position = new Vector3(position.x - (float)4.5, position.y + (float)4.577, (float)-4.116654);
                text.transform.position = new Vector2(position.x - (float)4.5, position.y + (float)4.577);
            }
            if (health <= 0)
            {
                SceneManager.LoadScene("Level1.unity");
            }
        }
        if (bossFight != 1) {
            Vector2 HealthPosition = this.transform.position;
            hp.transform.localScale = new Vector3(health, (float).5, 1);
            hp.transform.position = new Vector3(HealthPosition.x - (float)4.5, HealthPosition.y + (float)4.577, (float)-4.116654);
            text.transform.position = new Vector2(HealthPosition.x - (float)4.5, HealthPosition.y + (float)4.577);
        }
        if (Input.GetKey(KeyCode.A))
            {
                position.x = position.x - (float).025;
                this.transform.position = position;
                face = 1;
            }
            if (Input.GetKey(KeyCode.D))
            {
                position.x = position.x + (float).025;
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
                float xpos = position.x;
                float ypos = position.y;
                if (face == 0)
                {
                    Vector2 newpos = new Vector2(xpos + (float).5, ypos);
                    GameObject clone;
                    clone = Instantiate(bulletPrefab);
                    clone.transform.position = newpos;
                    clone.GetComponent<Rigidbody2D>().velocity = 40 * transform.localScale.x * clone.transform.right;
                } else if (face == 1)
                {
                    Vector2 newpos = new Vector2(xpos - (float).5, ypos);
                    GameObject clone;
                    clone = Instantiate(bulletPrefab);
                    clone.transform.position = newpos;
                    clone.GetComponent<Rigidbody2D>().velocity = 40 * transform.localScale.x * clone.transform.right * -1;
                }

            }
        }
}
