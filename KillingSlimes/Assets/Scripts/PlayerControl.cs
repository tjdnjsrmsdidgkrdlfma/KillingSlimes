using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class PlayerControl : MonoBehaviour
{
    public GameObject bullet;

    bool fire = false;

    Transform tr;

    void Awake()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        GetInput();
        Fire();
    }

    void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
            fire = true;
        else
            fire = false;
    }

    void Fire()
    {
        if (fire == false)
            return;

        Vector2 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float angle = Mathf.Atan2(mouse.y - tr.position.y, mouse.x - tr.position.x) * Mathf.Rad2Deg;

        Instantiate(bullet, tr.position, Quaternion.AngleAxis(angle, Vector3.forward));
    }
}
