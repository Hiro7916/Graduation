using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>属性管理</summary>
public class s_Property : MonoBehaviour
{
    ///<summary>属性</summary>
    public string propertyName;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    ///<summary>属性の取得</summary>
    public string GetProperty()
    {
        return propertyName;
    }
    ///<summary>属性相性を返す（0:何もなし、1:不利,2:有利）</summary>
    public int PropertyCheck(string opp)
    {
        if (propertyName == "水")
        {
            if (opp == "雷")
                return 1;
        }
        if (propertyName == "雷")
        {
            if (opp == "水")
                return 2;
        }
        return 0;
    }
}
