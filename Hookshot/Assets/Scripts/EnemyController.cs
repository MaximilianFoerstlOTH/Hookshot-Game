using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    
    public float speed = 1.0f;
    public int health = 100;

    private GameObject target;
    private GameObject Healthbar;
    private Slider slider;
    private Rigidbody2D rb;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Healthbar = gameObject.transform.GetChild(0).transform.GetChild(0).gameObject;
        slider = Healthbar.GetComponent<Slider>();
        target = GameObject.FindGameObjectWithTag("Player");
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Vector2 targetpos = target.transform.position;
        rb.MovePosition(rb.position + (targetpos - rb.position) * speed * Time.deltaTime);
    }

    public void ReduceHealth(int damage)
    {
        health -= damage;
        slider.value = health;
        if(health <= 0)
        {
            death();
        }
    }

    private void death()
    {
        Destroy(gameObject);
    }
}
