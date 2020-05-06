using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior2 : MonoBehaviour
{
    Random rnd = new Random();
    int rando = 5;
    int saver;
    public GameObject bulletPrefab;
    public int health = 30;
    public int fire = 4;
    public float fired;
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
        fired = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = this.transform.position;
        if (Time.time % 5 < .01 && Time.time % 5 >= 0)
        {
            saver = rando;
            rando = Random.Range(0, 4);
            while (rando == saver)
            {
                rando = Random.Range(0, 4);
            }
            fire = 4;
        }
            if(rando == 0)
            {
                this.transform.position = new Vector2((float)7,(float).35);
                Vector2 newpos = new Vector2((float)6.5,(float).5);
                if(fire >= 0 && Time.time - fired >= .3)
                {
                    GameObject clone;
                    clone = Instantiate(bulletPrefab);
                    clone.transform.position = newpos;
                    clone.GetComponent<Rigidbody2D>().velocity = 35 * transform.localScale.x * clone.transform.right * -1;
                fire--;
                fired = Time.time;
                }
            }
            else if(rando == 1)
            {
                this.transform.position = new Vector2((float)7, (float)-.65);
                Vector2 newpos = new Vector2((float)6.5, (float)-.4);
                if(fire >= 0 && Time.time - fired >= .3)
                {
                    GameObject clone;
                    clone = Instantiate(bulletPrefab);
                    clone.transform.position = newpos;
                    clone.GetComponent<Rigidbody2D>().velocity = 35 * transform.localScale.x * clone.transform.right * -1;
                fire--;
                fired = Time.time;
                }
            }
            else if (rando == 2)
            {
                this.transform.position = new Vector2((float)-7, (float).35);
                Vector2 newpos = new Vector2((float)-6.5, (float).5);
            if (fire >= 0 && Time.time - fired >= .3)
            {
                    GameObject clone;
                    clone = Instantiate(bulletPrefab);
                    clone.transform.position = newpos;
                    clone.GetComponent<Rigidbody2D>().velocity = 35 * transform.localScale.x * clone.transform.right * 1;
                fire--;
                fired = Time.time;
                }
            }
            else if (rando == 3)
            {
                this.transform.position = new Vector2((float)-7, (float)-.65);
                Vector2 newpos = new Vector2((float)-6.5, (float)-.4);
            if (fire >= 0 && Time.time - fired >= .3)
            {
                    GameObject clone;
                    clone = Instantiate(bulletPrefab);
                    clone.transform.position = newpos;
                    clone.GetComponent<Rigidbody2D>().velocity = 35 * transform.localScale.x * clone.transform.right * 1;
                fire--;
                fired = Time.time;
                }
            }
    }
}