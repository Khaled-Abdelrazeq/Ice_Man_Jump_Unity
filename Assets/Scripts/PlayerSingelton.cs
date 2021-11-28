using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingelton : MonoBehaviour
{
    public static PlayerSingelton Instance;
    public Transform player;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;

        player = transform;
    }
}
