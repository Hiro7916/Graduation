using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_ParticlControl : MonoBehaviour
{
    private List<GameObject> list;
    private ParticleSystem.Particle[] myp;
    private ParticleSystem.Particle[] yp;

    bool dead;

    int num = 0;
    // Start is called before the first frame update
    void Start()
    {
        list = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
         num = 0;
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Magic");

        foreach (var o in objs)
        {
   
            if (o.GetComponent<magic>() == null)
            {
                continue;
            }
            foreach (var ob in objs)
            {
                Debug.Log(ob.GetComponent<magic>() == null);
                if (ob.GetComponent<magic>() == null)
                {
                    continue;
                }
                if (o != ob)
                {
                    myp = new ParticleSystem.Particle[o.GetComponent<ParticleSystem>().particleCount];
                    o.GetComponent<ParticleSystem>().GetParticles(myp);
                    int parNum = 0;
                    foreach (var p in myp)
                    {
                        dead = false;
                        yp = new ParticleSystem.Particle[ob.GetComponent<ParticleSystem>().particleCount];
                        ob.GetComponent<ParticleSystem>().GetParticles(yp);
                        int yNum = 0;
                        foreach (var y in yp)
                        {
                            Check(p.position, y.position, p.size, y.size, o, myp, parNum, ob, yp, yNum);
                            yNum++;

                        }
                        if (dead)
                        {
                            Mydead(o, myp, parNum, ob);
                        }
                        parNum++;
                    }
                }
            }
        }
    }

    public void Check(Vector3 my,Vector3 y,float ms,float ys,GameObject o,ParticleSystem.Particle[] mps,int nu, GameObject yo, ParticleSystem.Particle[] ymps, int ynu)
    {
        if (Vector3.Distance(my,y)<(ms*1.2f+ys*1.2f))
        {
            ParticleSystem[] par = new ParticleSystem[1];

            par[0] = yo.GetComponent<ParticleSystem>();
            yo.GetComponent<magic>().Hit(par, ynu, ymps, o.GetComponent<magic>().GetPro());
            dead = true;

        }

    }

    private void Mydead( GameObject o, ParticleSystem.Particle[] mps, int nu, GameObject yo)
    {
        ParticleSystem[] par = new ParticleSystem[1];
        par[0] = o.GetComponent<ParticleSystem>();
        o.GetComponent<magic>().Hit(par, nu, mps, yo.GetComponent<magic>().GetPro());
    }

}
