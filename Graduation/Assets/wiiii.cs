using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wiiii : MonoBehaviour
{
public AudioClip a;
public AudioSource s;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
if(!s_PoseControl.GetLoadsavePose())  
return;      

        if(Input.GetButtonDown("A")||Input.GetKeyDown(KeyCode.Space))
s.PlayOneShot(a);

    }


}
