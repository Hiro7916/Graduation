using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectBallControl : MonoBehaviour
{
    // Start is called before the first frame update
    int timer = 60 * 10;
    Vector3 velocity;
    bool deadFlag;
    void Start()
    {
        if (GameObject.Find("Main Camera") != null)
            velocity = GameObject.Find("Main Camera").transform.forward;

        transform.parent = null;
        deadFlag = false;

    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(transform.position);
        Move();
        TimerUpdate();
        Dead();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name != "player")
            deadFlag = true;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name != "player")
            deadFlag = true;

    }
    void Move()
    {
        Vector3 posi = transform.position;
        posi += velocity;
        transform.position = posi;
    }
    void TimerUpdate()
    {
        if (timer > 0)
            timer--;
    }
    void Dead()
    {
        if (timer <= 0||deadFlag)
            Destroy(this.gameObject);
    }
}
