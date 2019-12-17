using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextParticl : MonoBehaviour
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
        if(collision.gameObject.name == "o_player")
        {
             GameObject.Find("o_SceneManager").GetComponent<s_SceneManager>().ScenNext();

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "o_player")
        {
             GameObject.Find("o_SceneManager").GetComponent<s_SceneManager>().ScenNext();

        }   
    }
}
