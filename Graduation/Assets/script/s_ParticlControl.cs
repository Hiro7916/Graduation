using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_ParticlControl : MonoBehaviour
{
    private List<GameObject> list;
    private ParticleSystem.Particle[] myp;
    private ParticleSystem.Particle[] yp;
    // Start is called before the first frame update
    void Start()
    {
        list = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        //int num = 0;
        //GameObject[] objs = GameObject.FindGameObjectsWithTag("Magic");
        //foreach (var o in objs)
        //{
        //    foreach (var ob in objs)
        //    {
        //        if (o != ob)
        //        {
        //            myp =new ParticleSystem.Particle[o.GetComponent<ParticleSystem>().particleCount];
        //            o.GetComponent<ParticleSystem>().GetParticles(myp);
        //            foreach (var p in myp)
        //            {

        //            }
        //        }
        //    }
        //}

    }
}
