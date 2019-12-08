using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMove : MonoBehaviour
{
    public float loc;
    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = this.transform.position;
        if (position.x ==  (float)1.22)
        {
             loc = (float)1;
        }else if(position.x == (float)8.45)
        {
             loc = (float)0;
        }
        if(loc == (float)1)
        {
            position.x = position.x + (float).01;
            this.transform.position = position;
        }else if(loc == (float)0)
        {
            position.x = position.x - (float).01;
            this.transform.position = position;
        }
    }
}
