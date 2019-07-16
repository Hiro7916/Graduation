using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThunderControl : MonoBehaviour
{
    // Start is called before the first frame update
    string state;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Dead();
    }
   void Dead()
    {
        if (GetComponent<particleControl>().GetState() == "Up")
            Destroy(this.gameObject);
    }
}
