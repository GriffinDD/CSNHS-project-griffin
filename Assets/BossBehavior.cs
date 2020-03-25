using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{
    Random rnd = new Random();
    int rando;
    int saver;
    float scale = 1;
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
        if (Time.time % 5 < .1 && Time.time % 5 >= 0)
        {
            rando = Random.Range(0, 3);
            saver = rando;
            while (rando == saver)
            {
                rando = Random.Range(0, 3);
            }
        }
        if (((int)Time.time % 10 >= 3 && (int)Time.time % 10 < 5) || (int)Time.time % 10 >= 8) { 
            Vector2 position = this.transform.position;
            position.y = (float)-.25 + (float)(rando * scale);
            this.transform.position = position;
            aimTime = Time.time;
            lazer.transform.position = new Vector2(this.transform.position.x - 7, this.transform.position.y);
            lazer.transform.localScale = new Vector2((float)13.40155, (float)0.343154);
            lazer.GetComponent<Renderer>().material.color = Color.red;

        }else
        {
            lazer.transform.position = new Vector2((float)-3.64,(float)3.39);
            lazer.transform.localScale = new Vector2(0,0);
        }
    }
}