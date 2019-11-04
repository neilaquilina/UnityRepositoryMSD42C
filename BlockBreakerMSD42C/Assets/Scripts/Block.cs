using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;

    Level level;

    void Start()
    {
        //find object Level and assign to level
        level = FindObjectOfType<Level>();

        //add 1 to breakableBlocks
        level.CountBreakableBlocks();
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
        FindObjectOfType<GameStatus>().AddToScore();
        Destroy(gameObject);
        level.BlockDestroyed();
    }
}
