using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeControl : MonoBehaviour
{
    public float speed;

    int hp = 5;
    public int Hp
    {
        get { return hp; }
        set
        {
            hp = value;
            CheckHp();
        }
    }

    float destroy_time = 1.5f;
    bool death = false;

    Rigidbody2D rb;
    Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        if (death == true)
            return;

        Vector2 temp = rb.position + -Vector2.right * speed;
        rb.MovePosition(temp);
    }

    void CheckHp()
    {
        if (hp > 0)
            anim.SetTrigger("Hit");
        else if(hp == 0)
        {
            death = true;
            anim.SetTrigger("Death");
            Destroy(gameObject, destroy_time);
        }
    }

}
