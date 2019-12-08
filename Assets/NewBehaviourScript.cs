using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 position = this.transform.position;
            position.x = position.x - (float).02;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.D))
        {
            Vector3 position = this.transform.position;
            position.x = position.x + (float).02;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 position = this.transform.position;
            position.y = position.y + (float).03;
            this.transform.position = position;
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.localScale = new Vector3((float).2, (float).2, (float).2);
        }
        else
        {
            gameObject.transform.localScale = new Vector3((float).2, (float).4, (float).2);
        }
    }
}