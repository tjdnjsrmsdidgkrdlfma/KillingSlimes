using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletControl : MonoBehaviour
{
    public float speed;

    Transform tr;
    Rigidbody2D rb;

    void Awake()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        StartCoroutine(Destroy());
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(3);

        Destroy(gameObject);
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        Vector2 temp = tr.position + tr.right * speed;
        rb.MovePosition(temp);
    }
}
