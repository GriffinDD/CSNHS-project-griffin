using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    Random rnd = new Random();
    int rando = 5;
    int saver;
    float scale = 1;
    public GameObject lazer;
    public GameObject clone;
    public int health = 30;
    public float aimTime;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health = health - 1;
        }
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    void Start()
    {
        clone = Instantiate(lazer);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = this.transform.position;
        if (Time.time % 5 < .01 && Time.time % 5 >= 0)
        {
            saver = rando;
            rando = Random.Range(0, 3);
            while (rando == saver)
            {
                rando = Random.Range(0, 3);
            }
            position.y = (float)-.25 + (float)(rando * scale);
            this.transform.position = position;
        }
        if (((int)Time.time % 10 >= 3 && (int)Time.time % 10 < 5) || (int)Time.time % 10 >= 8) { 
            aimTime = Time.time;
            clone.transform.position = new Vector2(this.transform.position.x - 7, this.transform.position.y - (float).11);
            clone.transform.localScale = new Vector2((float)13.40155, (float)0.343154);
            clone.GetComponent<Renderer>().material.color = Color.red;

        }else
        {
            clone.transform.position = new Vector2((float)50,(float)50);
            clone.transform.localScale = new Vector2(0,0);
        }
    }
}