using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hookshot : MonoBehaviour
{
    private Rigidbody2D rb;
    public float hookspeed;
    private PlayerController controller;
    //private bool inHookshot = false;
    private GameObject currentWall;
    // Start is called before the first frame update
    private BoxCollider2D boxCollider;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controller = GetComponent<PlayerController>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 position = new Vector2(transform.position.x, transform.position.y);
            Vector2 rayDir = mousePos - position;
            RaycastHit2D hit = Physics2D.Raycast(position, rayDir, Vector2.Distance(mousePos, position));

            if (hit.transform == null || hit.transform.gameObject.tag != "Wall" ||hit.transform.gameObject == currentWall)
            {
                currentWall = null;
                controller.dissableHookshot();
                return;
            }
          
            if (hit.transform.gameObject.tag == "Wall")
            {
                currentWall = hit.transform.gameObject;
                controller.HookshootMove(hit);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            currentWall = null;
            controller.dissableHookshot();
        }
    }

}


