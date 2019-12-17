using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s_DropHp : MonoBehaviour
{

public int hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Dead()
    {
        Destroy(this.gameObject);
    }
    private void OnParticleCollision(GameObject other)
    {
 
        //プレイヤーと当たった場合
        if (other.tag == "Player")
        {

            other.GetComponent<s_PlayerStatus>().Recovery(hp,true);
            Destroy(this.gameObject);
        }
    }
}
