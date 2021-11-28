using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private void Update()
    {
        if (PlayerSingelton.Instance.player)
        {
            if (PlayerSingelton.Instance.player.position.y > transform.position.y)
            {
                transform.position = new Vector3(transform.position.x, PlayerSingelton.Instance.player.position.y, transform.position.z);
                
            }
        }
    }
}
