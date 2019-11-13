using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour
{

    GameObject randomBlock;

    GameObject[] blocksArray;

    Vector2 startingPosition, blockPosition;

    // Start is called before the first frame update
    void Start()
    {
        //set the startingPosition of blocks
        startingPosition = transform.position;
        blockPosition = startingPosition;

        GetAndLoadRandomBlocks();

        
    }

    private void GetAndLoadRandomBlocks()
    {
        blocksArray = Resources.LoadAll<GameObject>("Blocks");

        for (int y = 5; y > 1; y--)
        {
            //spawn blocks left to right
            for (int x = 1; x <= 8; x++)
            {
                int randomNumber = Random.Range(0, blocksArray.Length);
                randomBlock = blocksArray[randomNumber];
                Instantiate(randomBlock, blockPosition, transform.rotation);
                blockPosition.x += 2;
            }

            blockPosition.x = startingPosition.x;
            blockPosition.y -= 2;

        }



    }


  
}
