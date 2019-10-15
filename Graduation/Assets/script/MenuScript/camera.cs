
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    GameObject Player;

    [SerializeField] Vector3 cameraPlus;//カメラ位置

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.position = Player.transform.position+cameraPlus;
    }
}
