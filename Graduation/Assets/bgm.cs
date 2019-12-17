using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgm : MonoBehaviour
{

public AudioClip a;
public AudioSource s;
public AudioClip aa;
public AudioSource ss;

    // Start is called before the first frame update
    void Start()
    {
        s.PlayOneShot(a);
    }

    // Update is called once per frame
    void Update()
    {
               if(Input.GetButtonDown("A")||Input.GetKeyDown(KeyCode.Space))
ss.PlayOneShot(aa);
    }
}
