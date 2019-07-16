using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveObjControl : MonoBehaviour
{
    public GameObject particle;
    int addObjTimer;
    int memoryAddObjTimer;
    List<GameObject> particles;
    // Start is called before the first frame update
    void Start()
    {
        addObjTimer =  20;
        memoryAddObjTimer = addObjTimer;
        particles = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        TimerUpdate();
        AddParticle();
        ParticleUpdate();
    }
    void TimerUpdate()
    {
        if (addObjTimer > 0)
            addObjTimer--;

    }
    void AddParticle()
    {
        if(addObjTimer<=0)
        {
            GameObject par = Instantiate(particle, transform.position, Quaternion.identity);
            par.transform.Rotate(Vector3.right,90);
            par.transform.localScale=new Vector3(2,2,2);
            
            addObjTimer = memoryAddObjTimer;
            particles.Add(par);
        }
    }

    void ParticleUpdate()
    {
        if (particles.Count == 0)
            return;
        for(int i=0;i<particles.Count;i++)
        {
            Vector3 posi = particles[i].transform.position;
            posi.y += 0.02f;
            particles[i].transform.position = posi;


            if (Mathf.Abs(transform.position.y - particles[i].transform.position.y)> 6)
            {
                Destroy(particles[i]);
                particles.Remove(particles[i]);
            }

        }
    }
    
}
