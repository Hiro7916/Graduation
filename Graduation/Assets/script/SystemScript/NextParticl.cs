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
     transform.position+=new Vector3(0,-0.1f,0)*Time.deltaTime;   
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

    public bool HitstageChack(Vector3 vec)
    {
        Ray ray = new Ray(transform.position , vec);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit,100))
            if (hit.transform.tag == "stage")
            {
              transform.position=hit.transform.position+new Vector3(0,2,0);
Debug.Log("hhhhh");
                return true;
            }


        return false;

    }
}
