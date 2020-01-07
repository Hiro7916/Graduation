using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class cAtex : MonoBehaviour
{public Text t;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
                if (other.name == "o_player")
        {
            t.text = "R1 or L1で魔法変更";
        }
    }

    private void OnTriggerExit(Collider other)
    {
                     if (other.name == "o_player")
        {
            t.text = "";
        }
    }
}
