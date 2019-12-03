using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eneDame : MonoBehaviour
{
public List<GameObject> ob;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ob.Count; i++)
        {

            ob[i].GetComponent<Renderer>().material.color = Color.Lerp(ob[i].GetComponent<Renderer>().material.color, Color.white, Time.deltaTime);
        }
    }

    public void Dame()
    {
        for(int i=0;i<ob.Count;i++)
        {

            ob[i].GetComponent<Renderer>().material.color = new Color(0.5f, 0, 0);
        }

    }
}
