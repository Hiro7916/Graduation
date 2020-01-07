using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_EnemyFlame : MonoBehaviour
{
public AudioSource s;
public AudioClip a;
    // Start is called before the first frame update
    void Start()
    {

s.PlayOneShot(a);
    }

    // Update is called once per frame
    void Update()
    {
                
    }

    private void OnParticleTrigger()
    {
       
    }

    private void OnParticleCollision(GameObject other)
    {if(this.name=="o_Bubble1(Clone)")
return;
        if (other.tag == "Player")
        {
            other.GetComponent<s_PlayerStatus>().Damage(2);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {

if(this.name=="o_Bubble1(Clone)")
return;
        Debug.Log(collision.gameObject.name); ;
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<s_PlayerStatus>().Damage(2);
        }
    }
    private void OnTriggerEnter(Collider other)
    {

if(this.name=="o_Bubble1(Clone)")
return;
        Debug.Log(other.name); ;
        if (other.tag == "Player")
        {
            other.GetComponent<s_PlayerStatus>().Damage(2);
        }
    }
}
