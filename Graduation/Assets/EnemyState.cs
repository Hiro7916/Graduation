using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState : MonoBehaviour
{
    int hp;
    bool deadFlag;
    // Start is called before the first frame update
    void Start()
    {
        hp = 100;
        deadFlag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Damage(int dame)
    {
        hp -= dame;
    }
    void DeadCheck()
    {
        if (hp <= 0)
            deadFlag = true;
    }
    void Dead()
    {
        if(deadFlag)
        {
            Destroy(this.gameObject);

        }
    }

}
