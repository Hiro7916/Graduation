using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magic : MonoBehaviour
{
    public string property;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Hit(ParticleSystem[] ps, int num, ParticleSystem.Particle[] pars,string pro)
    {
        if (Chack(pro))
        {
            pars[num].size = 0;
           // pars[num].position = new Vector3(0, 1000, 0);
            ps[0].SetParticles(pars);
        }
    }

    public void Set(ParticleSystem ps)
    {
        
    }

    public string GetPro()
    {
        return property;
    }

    public bool Chack(string str)
    {
        if (property == "雷")
        {
            
            if (str == "火")
            {
                Debug.Log("on");
                return true;
            }
        }
        if (property == "火")
        {
            if (str == "水")
                return true;
            if (str == "雷")
                return true;
        }
        return false;
    }

}
