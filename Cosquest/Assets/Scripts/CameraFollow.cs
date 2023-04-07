using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset;

    public bool bouncyPlanet;

    void FixedUpdate()
    {
        if (bouncyPlanet)
        {
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, player.position.z + offset.z);
        }

        else
        {
            transform.position = new Vector3(player.position.x + offset.x, offset.y, player.position.z + offset.z);
        }
    }
}
