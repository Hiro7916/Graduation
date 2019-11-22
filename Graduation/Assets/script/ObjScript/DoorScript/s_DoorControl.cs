using System.Collections;
using System.Collections.Generic;
using UnityEngine;
///<summary>扉の管理</summary>
public class s_DoorControl : MonoBehaviour
{
    ///<summary>耐久値</summary>
    public int hp=100;
    ///<summary>ダメージを与えられるLv</summary>
    public int workLv = 2;
    ///<summary>HPが０になったか</summary>
    private bool dead;
    private float rota;
    // Start is called before the first frame update
    void Start()
    {
        dead=false;
        
    }

    // Update is called once per frame
    void Update()
    {
        BreakCheck();
        if (dead)
            AnimeDead();
    }

    private void OnParticleCollision(GameObject other)
    {
        Debug.Log(other.GetComponent<s_ParticleControl>().GetLv());

        if (other.GetComponent<s_ParticleControl>() != null)
        {
            if (other.GetComponent<s_ParticleControl>().GetLv()>= workLv)
            {
                hp -= 1;
            }
        }
    }
    ///<summary>扉が壊れているかの確認</summary>
    private void BreakCheck()
    {
        if (hp <= 0)
        {
            dead=true;
         
        }
    }
    private void AnimeDead()
    { 
        rota += 2;

        if(rota<=90)
        { 
            transform.RotateAround(transform.position+new Vector3(0,-0f,0),transform.forward,2);
        }
        else
        {
             Destroy(this.gameObject);
        }
    }
}
