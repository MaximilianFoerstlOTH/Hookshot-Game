using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class WorldCreator : MonoBehaviour
{
    public GameObject Chunk;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject c = Instantiate(Chunk, player.transform.position, Quaternion.identity);
        c.GetComponent<ChunkBehaviour>().setCollidable();
        c.transform.parent = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}