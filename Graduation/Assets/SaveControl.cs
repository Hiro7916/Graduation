using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveControl : MonoBehaviour
{
     bool hit;
    // Start is called before the first frame update
    void Start()
    {
        hit = false;   
    }

    // Update is called once per frame
    void Update()
    {
        Save();
        Load();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="SavePoint")
        hit = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "SavePoint")
            hit = false;
    }

    void Save()
    {
        if (hit && Input.GetKeyDown(KeyCode.Alpha0))
            Debug.Log("save");
    }
    void Load()
    {
        if (hit && Input.GetKeyDown(KeyCode.Alpha9))
            Debug.Log("Load");
    }
    public bool GetHit()
    {
        return hit;
    }
}
