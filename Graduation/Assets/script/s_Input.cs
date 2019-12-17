using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class s_Input : MonoBehaviour
{
   static int arroYd=0,arroYu=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static bool getdownArroUp(int num)
    {
        if (num == -1)
        {
            if (Input.GetAxisRaw("arrX") < 0)
            {
                if (arroYd == 0)
                {
                    arroYd = 1;
                    return true;
                }
            }
            else
            {
                arroYd = 0;
            }
        }
        if (num == 1)
        {
            if (Input.GetAxisRaw("arrX") >0)
            {
                if (arroYu == 0)
                {
                    arroYu = 1;
                    return true;
                }
            }
            else
            {
                arroYu = 0;
            }
        }
        return false;
    }

}
