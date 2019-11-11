using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{

    [SerializeField] AudioClip breakSound;
    [SerializeField] GameObject blockSparklesVFX;

    [SerializeField] Sprite[] hitSprites;

    [SerializeField] int maxHits;
    [SerializeField] int currentHits = 0;

    Level level;

    void Start()
    {
        //find object Level and assign to level
        level = FindObjectOfType<Level>();

        if (gameObject.tag == "Breakable")
        {
            //add 1 to breakableBlocks
            level.CountBreakableBlocks();
        }
    }

    private void ShowNextHitSprite()
    {
        int spriteIndex = currentHits - 1;
        GetComponent<SpriteRenderer>().sprite = hitSprites[spriteIndex];
    }

    private void TriggerSparklesVFX()
    {
        GameObject particles = Instantiate(blockSparklesVFX, transform.position, transform.rotation);
        Destroy(particles, 1f);
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (gameObject.tag == "Breakable")
        {
            currentHits++;

            if (currentHits >= maxHits)
            {
                AudioSource.PlayClipAtPoint(breakSound, Camera.main.transform.position);
                FindObjectOfType<GameStatus>().AddToScore();
                Destroy(gameObject);
                TriggerSparklesVFX();
                level.BlockDestroyed();
            }
            else
            {
                ShowNextHitSprite();
            }
        }
    }
}
