using System.Collections;
using System.Collections.Generic;
using UnityEngine;

///<summary>ボスを起こす</summary>
public class s_BossSwitch : MonoBehaviour
{
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
        if (other.tag == "Player")
        {
            if (GameObject.Find("Boss") != null)
            {
                GameObject.Find("Boss").GetComponent<s_BossMove>().SetMoveOnCheck(true);
            }
        }
    }
}
