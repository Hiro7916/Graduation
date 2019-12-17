using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eneDame : MonoBehaviour
{
public List<GameObject> ob;
Color[] de;
    // Start is called before the first frame update
    void Start()
    {
de=new Color[ob.Count];

        for (int i = 0; i < ob.Count; i++)
        {
            de[i] = ob[i].GetComponent<Renderer>().material.color;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < ob.Count; i++)
        {

            ob[i].GetComponent<Renderer>().material.color = Color.Lerp(ob[i].GetComponent<Renderer>().material.color, de[i], Time.deltaTime);
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
