using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotHandler : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 40;

    private float time = 10;
    private Vector2 dir;
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, time);

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + dir * speed * Time.deltaTime);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            EnemyController e = collision.gameObject.GetComponent<EnemyController>();
            e.ReduceHealth(damage);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }

    }
    public void ShootInDirection(Vector2 dir)
    {
        this.dir = dir.normalized;
    }
}
