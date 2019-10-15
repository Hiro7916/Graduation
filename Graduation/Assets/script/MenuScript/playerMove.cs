using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMove : MonoBehaviour
{
    float x, z;

    void Start()
    {

    }

    void Update()
    {

    }

    //Playerの動きをPause中に止める為Fixedに記述
    private void FixedUpdate()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        transform.Translate(new Vector3(x, 0f, z));
    }
}
