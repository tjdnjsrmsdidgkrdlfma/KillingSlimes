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
    bool attack = false;
    bool death = false;

    Rigidbody2D rb;
    BoxCollider2D coll;
    Animator anim;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
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
            coll.enabled = false;
            Destroy(gameObject, destroy_time);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Wall"))
        {
            if(attack == false)
            {
                attack = true;
                anim.SetBool("Attack", true);
                Invoke("AttackFalse", 1.16f);
            }
        }
    }

    void AttackFalse()
    {
        attack = false;
    }
}
