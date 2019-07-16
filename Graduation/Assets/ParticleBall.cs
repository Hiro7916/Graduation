using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBall : MonoBehaviour
{
    // Start is called before the first frame update
    float size;
    void Start()
    {
        size = 0.02f;
    }

    // Update is called once per frame
    void Update()
    {
        if (size < 3)
        {
            size+=0.02f;
            Vector3 sc = new Vector3(1, 1, 1);
            sc *= size;
            transform.localScale = sc;
        
        }
    }
}
