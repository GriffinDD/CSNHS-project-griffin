using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //destroy player character
            Destroy(this.gameObject);
        }else if(collision.gameObject.tag == "Bullet")
        {

        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        bullet = GameObject.Find("Bullet");
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), bullet.GetComponent<Collider2D>());
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
