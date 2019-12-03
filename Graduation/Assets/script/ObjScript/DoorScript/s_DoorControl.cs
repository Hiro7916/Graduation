using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

    public Text playerText;

    // Start is called before the first frame update
    void Start()
    {
        dead=false;
        
    }

    // Update is called once per frame
    void Update()
    {
Text();
        BreakCheck();
        if (dead)
            AnimeDead();
    }

    private void OnParticleCollision(GameObject other)
    {

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
            playerText.text = "";
             Destroy(this.gameObject);
        }
    }

    private void Text()
    {
        GameObject player;
        if (GameObject.Find("o_player") != null)
            player = GameObject.Find("o_player");
        else
        {
            playerText.text = "";
            return;
        }
        if (Vector3.Distance(transform.position, player.transform.position) < 20)
            playerText.text = "必要Lv2";
        else
            playerText.text = "";
    }
}
