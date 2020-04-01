﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public bool check = false;
    public GameObject bullet;
    public GameObject hp;
    public GameObject text;
    public GameObject P1;
    public float health;
    public int HealthInt;
    public float hplocation;
    public float face = 0;
    void OnCollisionEnter2D(Collision2D collision)
    {
        Vector2 position = P1.transform.position;
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Platform")
        {
            check = false;
        }
        if (collision.gameObject.tag == "Bullet")
        {
            HealthInt = HealthInt - 1;
            health = health - 1;
            hp.transform.localScale = new Vector3(health, (float).5, 1);
            hp.transform.position = new Vector3(position.x + (float)4.5, position.y + (float)4.577, (float)-4.116654);
            text.transform.position = new Vector2(position.x + (float)4.5, position.y + (float)4.577);
            text.GetComponent<TextMesh>().text = HealthInt.ToString();
        }
    }
    void Start()
    {
        hp = GameObject.Find("HealthBar");
        text = GameObject.Find("HealthText");
        bullet = GameObject.Find("Bullet");
        P1 = GameObject.Find("playercube");
        Vector2 P1pos = P1.transform.position;
        this.transform.position = new Vector2(P1pos.x + 1, P1pos.y);
        Vector2 position = this.transform.position;
        rigidbody = GetComponent<Rigidbody2D>();
        Instantiate(hp);
        hp.transform.position = new Vector3(P1pos.x + (float)4.5, P1pos.y + (float)4.577, (float)-4.116654);
        Instantiate(text);
        text.transform.position = new Vector3(P1pos.x + (float)4.5, P1pos.y + (float)4.577, (float)-4.116654);
        health = (float)10;
        HealthInt = 10;
        hp.transform.localScale = new Vector3(health, (float).5, 1);
        hp.GetComponent<Renderer>().material.color = Color.green;
        text.GetComponent<TextMesh>().characterSize = (float).2;
        text.GetComponent<TextMesh>().text = HealthInt.ToString();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
        }
        Vector2 HealthPosition = this.transform.position;
        hp.transform.localScale = new Vector3(health, (float).5, 1);
        hp.transform.position = new Vector3(HealthPosition.x + (float)4.5, HealthPosition.y + (float)4.577, (float)-4.116654);
        text.transform.position = new Vector2(HealthPosition.x + (float)4.5, HealthPosition.y + (float)4.577);
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Vector2 position = this.transform.position;
            position.x = position.x - (float).02;
            this.transform.position = position;
            face = 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Vector2 position = this.transform.position;
            position.x = position.x + (float).02;
            this.transform.position = position;
            face = 0;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && !check)
        {
            check = true;
            this.rigidbody.velocity = Vector2.up * 5;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            gameObject.transform.localScale = new Vector2((float).2, (float).2);
        }
        else
        {
            gameObject.transform.localScale = new Vector2((float).2, (float).4);
        }
        if (Input.GetKeyDown(KeyCode.RightShift))
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
            }
            else if (face == 1)
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