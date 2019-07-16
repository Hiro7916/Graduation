using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicAction : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject magicUI;
    List<KeyCode> numberKey;
    public List<GameObject> particles;
    int nowNumber;
    //!!!!
    GameObject preParticl;
    GameObject activeParticl;

    int magicNumver;
    void Start()
    {

        magicUI.GetComponent<MagicUI_Control>().UI_Change(magicNumver.ToString());

        numberKey = new List<KeyCode>();
        for(int i=0;i<10;i++)
        {
            numberKey.Add((KeyCode)48+i);
        }
        activeParticl = particles[1];
    }

    // Update is called once per frame
    void Update()
    {
        MagicOn();
        MagicChange();

    }
    void MagicOn()
    {
        if (Input.GetButtonDown("Jump"))
        {
            activeParticl = particles[magicNumver];
            Quaternion quat = new Quaternion();
            quat.Normalize();
            GameObject par = Instantiate(activeParticl, GameObject.Find("ParticleManager").transform.position, quat); ;
       

            particleControl pa=  par.GetComponent<particleControl>();
            pa.SetState("Down");
            pa.transform.rotation = GameObject.Find("Main Camera").transform.rotation;
            par.transform.parent = GameObject.Find("Main Camera").transform;
           

            preParticl = par;

        }
        if (Input.GetButton("Jump"))
        {
            if (preParticl != null)
            {
                preParticl.GetComponent<particleControl>().SetState("keep");
            }

        }
        if (Input.GetButtonUp("Jump"))
        {
            if (preParticl != null)
                preParticl.GetComponent<particleControl>().SetState("Up");

        }
    }
    void MagicChange()
    {
        if (Input.GetButtonDown("R_Trigger"))
        {
            if (magicNumver > 0)
                magicNumver--;
            else
                magicNumver = particles.Count-1;

              magicUI.GetComponent<MagicUI_Control>().UI_Change(magicNumver.ToString());
        }
        if (Input.GetButtonDown("L_Trigger"))
        {
            if (magicNumver < particles.Count-1)
                magicNumver++;
            else
                magicNumver = 0;

            magicUI.GetComponent<MagicUI_Control>().UI_Change(magicNumver.ToString());
        }
    }
}
