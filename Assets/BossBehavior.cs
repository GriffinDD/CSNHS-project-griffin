using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    Random rnd = new Random();
    int rando;
    int saver;
    public GameObject lazer;
    public float aimTime;
    // Start is called before the first frame update
    void Start()
    {
        lazer = GameObject.Find("Lazer");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time % 2);
        if (Time.time % 2 < .1 && Time.time % 2 >=0)
        {
            rando = Random.Range(0, 3);
            for (int i = 0; i > 0;)
            {
                if(saver == rando)
                {
                   rando = Random.Range(0, 3);
                }else if(rando != saver)
                {
                    i = 2;
                }
            }
            saver = rando;
        }
        if (rando == 2)
        {
            Vector2 position = this.transform.position;
            position.y = (float)1.75;
            this.transform.position = position;
            aimTime = Time.time;
        }
        else if (rando == 1)
        {
            Vector2 position = this.transform.position;
            position.y = (float).75;
            this.transform.position = position;
            aimTime = Time.time;
        }
        else if (rando == 0)
        {
            Vector2 position = this.transform.position;
            position.y = (float)-.25;
            this.transform.position = position;
            aimTime = Time.time;
        }
        for (int i = 0; i > 0;)
        {
            if(aimTime - Time.time >= 2)
            {
                i = 5;
                lazer.transform.position = new Vector2(this.transform.position.x - 7, this.transform.position.y);
                lazer.transform.localScale = new Vector2((float)13.40155, (float)0.343154);
                lazer.GetComponent<Renderer>().material.color = Color.red;
            }
        }
        }
}