using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStatus : MonoBehaviour
{

    [SerializeField] int currentScore = 0;
    [SerializeField] int pointsPerBlockDestroyed = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore()
    {
        //currentScore = currentScore + pointsPerBlockDestroyed;
        currentScore += pointsPerBlockDestroyed;
    }
}
