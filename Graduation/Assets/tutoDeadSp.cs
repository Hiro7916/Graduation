using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutoDeadSp : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name=="o_player")
        {
            collision.gameObject.transform.position = new Vector3(135.6f, 3.56f, -2.99f);
        }
    }
}
