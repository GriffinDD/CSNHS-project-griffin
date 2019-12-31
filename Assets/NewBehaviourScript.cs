using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    Rigidbody2D rigidbody;

    // Start is called before the first frame update
    void Start()
    {
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
        if (Input.GetKey(KeyCode.W))
        {
            this.rigidbody.AddRelativeForce(Vector2.up * 10);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.localScale = new Vector2((float).2, (float).2);
        }
        else
        {
            gameObject.transform.localScale = new Vector2((float).2, (float).4);
        }
    }
}