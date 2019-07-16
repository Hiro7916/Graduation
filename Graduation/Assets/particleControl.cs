using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleControl : MonoBehaviour
{

    private string butttonState;

    // Start is called before the first frame update
    void Start()
    {
        butttonState = "down";
    }

    // Update is called once per frame
    void Update()
    {


    }
    public void SetState(string state)
    {
        butttonState = state;
    }
    public string GetState()
    {
        return butttonState;
    }

    private void OnParticleCollision(GameObject other)
    {
        
    }
}
