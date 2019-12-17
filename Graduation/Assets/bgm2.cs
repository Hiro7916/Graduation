using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgm2 : MonoBehaviour
{
    // Start is called before the first frame update
public AudioClip a;
public AudioSource s;


    // Start is called before the first frame update
    void Start()
    {
        s.PlayOneShot(a);
    }


}
