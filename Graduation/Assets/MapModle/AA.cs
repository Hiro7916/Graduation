using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AA : MonoBehaviour
{
    // Start is called before the first frame update

    float x, y = 0;
    public int speed = 3;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        x = Input.GetAxis("Vertical");
        y = Input.GetAxis("Horizontal");
        transform.Translate(y, 0, x);

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -speed, 0);
        }
        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, speed, 0);
        }
    }
}
