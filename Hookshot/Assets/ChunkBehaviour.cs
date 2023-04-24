using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChunkBehaviour : MonoBehaviour
{
    public GameObject Chunk;
    public List<Sprite> Sprites;
    float creationTime;
    int spriteSize = 2;
    bool canCollideWithPlayer = false;
    private void Start()
    {
        creationTime = Time.realtimeSinceStartup;
        canCollideWithPlayer = false;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") && canCollideWithPlayer == true)
        {
            CreateAlL();
        }
        checkDestroy(collision);

        createSprite();
    }

    private void checkDestroy(Collider2D collision)
    {
        ChunkBehaviour c = collision.gameObject.GetComponent<ChunkBehaviour>();
        //collision.transform.position. == gameObject.transform.position
        if (collision.gameObject.CompareTag("Chunk") && (collision.transform.position - gameObject.transform.position).magnitude < 0.1f && c.creationTime <= creationTime)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            canCollideWithPlayer = true;
            return;
        }
    }

    public void createSprite()
    {
        
        
    }

    public void CreateAlL()
    {
        for (int i = -Mathf.FloorToInt(transform.localScale.x / spriteSize / 2); i < transform.localScale.x / spriteSize / 2; i = i + spriteSize / 2)
        {
            for (int j = -Mathf.FloorToInt(transform.localScale.x / spriteSize / 2); j < transform.localScale.y / spriteSize / 2; j = j + spriteSize / 2)
            {
                GameObject empty = new GameObject();
                GameObject h = Instantiate(empty, transform.position + new Vector3(i, j, 0), Quaternion.identity);
                h.transform.parent = gameObject.transform;
                SpriteRenderer s = h.AddComponent<SpriteRenderer>();
                s.sprite = Sprites[Random.Range(0, Sprites.Count)];
                s.sortingOrder = -2;
                // h.transform.localScale *= spriteSize / 2;
                h.isStatic = true;
                Destroy(empty);
            }
        }
        createTopLeft();
        createTop();
        createTopRight();
        createLeft();
        createRight();
        createBottomLeft();
        createBottom();
        createBottomRight();
    }

    public void setCollidable()
    {
        canCollideWithPlayer = true;
    }

    public void createTop()
    {
        GameObject g = Instantiate(Chunk, transform.position + new Vector3(0 , 1 , 0) * transform.localScale.x /2 , Quaternion.identity );
        g.transform.parent = gameObject.transform.parent;
        
    }
    public void createBottom()
    {
        GameObject g = Instantiate(Chunk, transform.position + new Vector3(0, -1, 0) * transform.localScale.x / 2, Quaternion.identity);
        g.transform.parent = gameObject.transform.parent;
    }
    public void createLeft()
    {
        GameObject g = Instantiate(Chunk, transform.position + new Vector3(-1, 0, 0) * transform.localScale.x / 2, Quaternion.identity);
        g.transform.parent = gameObject.transform.parent;
    }
    public void createRight()
    {
        GameObject g = Instantiate(Chunk, transform.position + new Vector3(1, 0, 0) * transform.localScale.x / 2, Quaternion.identity);
        g.transform.parent = gameObject.transform.parent;
    }
    public void createTopLeft()
    {
        GameObject g = Instantiate(Chunk, transform.position + new Vector3(-1, 1, 0) * transform.localScale.x / 2, Quaternion.identity);
        g.transform.parent = gameObject.transform.parent;
    }
    public void createTopRight()
    {
        GameObject g = Instantiate(Chunk, transform.position + new Vector3(1, 1, 0) * transform.localScale.x / 2, Quaternion.identity);
        g.transform.parent = gameObject.transform.parent;
    }
    public void createBottomLeft()
    {
        GameObject g = Instantiate(Chunk, transform.position + new Vector3(-1, -1, 0) * transform.localScale.x / 2, Quaternion.identity);
        g.transform.parent = gameObject.transform.parent;
    }
    public void createBottomRight()
    {
        GameObject g = Instantiate(Chunk, transform.position + new Vector3(1, -1, 0) * transform.localScale.x / 2, Quaternion.identity);
        g.transform.parent = gameObject.transform.parent;
    }

}
