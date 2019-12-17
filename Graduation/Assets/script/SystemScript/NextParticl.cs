using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextParticl : MonoBehaviour
{

public string ne;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

public void set(string name){
ne=name;}


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "o_player")
        {
             GameObject.Find("o_SceneManager").GetComponent<s_SceneManager>().ChangeScene(ne);

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.name == "o_player")
        {
             GameObject.Find("o_SceneManager").GetComponent<s_SceneManager>().ChangeScene(ne);

        }   
    }
}
