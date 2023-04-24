using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Die Geschwindigkeit, mit der sich der Charakter bewegt
    public float moveSpeed = 5f;
    //Geschwindigkeit mit der man sich im Hook bewegt
    public float hookspeed = 0.05f;
    //Geschwindigkeit des heranziehens
    public float hookdrag = 1f;
    //Zeit, in der man seinen Hookspeed verliert
    public float hookDecay = 0.9f;
    //Die Maximale hook Geschwindigkeit
    public float maxhookSpeed = 3;
    // Die Richtung, in die sich der Charakter bewegt
    private Vector2 movement;

    private Animator animator;
    private Rigidbody2D rb;
    private bool inHookshot = false;
    private Vector2 hitpoint;
    private Vector2 hookmove;
    private Vector2 moveto;
    void Start()
    {
        // Den Animator und den Rigidbody des Charakters initialisieren
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Die Bewegungsrichtung aus den Eingabegerät-Axen lesen
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");


        // Den Animator mit der Bewegungsrichtung des Charakters aktualisieren

        /*
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        */
    }

    void FixedUpdate()
    {
        int move = 0;
        if (!inHookshot)
        {
            move = 1;
            // Den Charakter in die angegebene Richtung bewegen
            hookmove = hookmove * hookDecay;
            if (Mathf.Abs(hookmove.x) < 0.1)
            {
                hookmove.x = 0;
            }
            if (Mathf.Abs(hookmove.y) < 0.1)
            {
                hookmove.y = 0;
            }

        }
        else
        {
            move = 0;
            moveto = (hitpoint - rb.position);
            moveto.Normalize();
            moveto *= hookdrag;

            hookmove += moveto;

            Debug.DrawLine(rb.position, hitpoint, color:Color.black);
            //rb.MovePosition(rb.position + hookmove * hookspeed * Time.fixedDeltaTime);

        }
        
        if (Mathf.Abs(hookmove.x) > maxhookSpeed || Mathf.Abs(hookmove.y) > maxhookSpeed)
        {
            hookmove *= 0.9f;
        }
        rb.MovePosition(rb.position + (movement * moveSpeed * move + hookmove * hookspeed) * Time.fixedDeltaTime);
    }

    public void HookshootMove(RaycastHit2D hit)
    {
        hitpoint = hit.point;
        //hookmove = movement;
        inHookshot = true;
    }

    public void dissableHookshot()
    {
        inHookshot = false;
    }

    public bool getHookshot()
    {
        return inHookshot;
    }

}
