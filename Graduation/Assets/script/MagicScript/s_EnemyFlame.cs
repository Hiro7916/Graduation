using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_EnemyFlame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnParticleTrigger()
    {
       
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.name);;
        if (other.tag == "Player")
        {
            other.GetComponent<s_PlayerStatus>().Damage(2);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision.gameObject.name); ;
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<s_PlayerStatus>().Damage(2);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name); ;
        if (other.tag == "Player")
        {
            other.GetComponent<s_PlayerStatus>().Damage(2);
        }
    }
}
