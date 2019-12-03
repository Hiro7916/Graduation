using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class s_EneHPGauge : MonoBehaviour
{
public Canvas can;
public Slider s;
    // Start is called before the first frame update
    void Start()
    {
        transform.position=transform.parent.position;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerDis();
    }

    private void PlayerDis()
    {
        float dis = 0;
        if (GameObject.Find("o_player") == null)
            return;

        dis = Vector3.Distance(GameObject.Find("o_player").transform.position, transform.position);

        //if (dis > 15)
        //    can.GetComponent<Canvas>().enabled = false;
        //else
        //    can.GetComponent<Canvas>().enabled = true;

Debug.Log(transform.parent.name);
        s.value =transform.parent.parent.GetComponent<s_EnemyState>().hp;
        s.maxValue = transform.parent.parent.GetComponent<s_EnemyState>().maxHp;

           transform.LookAt( Camera.main.transform.position);

    }
}
