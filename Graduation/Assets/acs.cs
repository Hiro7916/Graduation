using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class acs : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnAni(AudioClip a)
    {
        GetComponent<AudioSource> ().PlayOneShot(a);   }
}
