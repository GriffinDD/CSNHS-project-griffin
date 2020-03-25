using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("playercube");
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 playerpos = player.transform.position;
        this.transform.position = new Vector3(playerpos.x, playerpos.y, -10);
    }
}
