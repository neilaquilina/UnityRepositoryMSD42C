using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{

    [SerializeField] int currentScore = 0;
    [SerializeField] int pointsPerBlockDestroyed = 10;

    TextMeshProUGUI scoreText;

    void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        //if we have more than 1 Game Status
        if(gameStatusCount > 1)
        {
            //disable and delete the 2nd one
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else // only 1 GameStatus object
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        scoreText = FindObjectOfType<TextMeshProUGUI>();
        scoreText.text = currentScore.ToString();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddToScore()
    {
        //currentScore = currentScore + pointsPerBlockDestroyed;
        currentScore += pointsPerBlockDestroyed;
        scoreText.text = currentScore.ToString();
    }
}
