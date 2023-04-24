using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingController : MonoBehaviour
{
    public float normalShotSpeed = 1f;
    public float hookShotSpeed = 0.1f;

    private float time_since_last_shot = 0;

    public ShotHandler shot;

    private PlayerController playerController;
    private void Start()
    {
        time_since_last_shot = Time.realtimeSinceStartup;
        playerController = GetComponent<PlayerController>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            if (playerController.getHookshot())
            {
                if (Time.realtimeSinceStartup > time_since_last_shot + hookShotSpeed)
                {
                    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 position = new Vector2(transform.position.x, transform.position.y);
                    Vector2 shotDir = mousePos - position;


                    ShotHandler s = Instantiate<ShotHandler>(shot);
                    s.transform.position = position;
                    s.ShootInDirection(shotDir);
                    time_since_last_shot = Time.realtimeSinceStartup;
                }
            }
            else
            {
                if (Time.realtimeSinceStartup > time_since_last_shot + normalShotSpeed)
                {
                    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    Vector2 position = new Vector2(transform.position.x, transform.position.y);
                    Vector2 shotDir = mousePos - position;


                    ShotHandler s = Instantiate<ShotHandler>(shot);
                    s.transform.position = position;
                    s.ShootInDirection(shotDir);
                    time_since_last_shot = Time.realtimeSinceStartup;
                }
            }
                
        }
    }
}
