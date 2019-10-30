using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Paddle myPaddle;

    //array declaration
    [SerializeField] AudioClip[] ballSounds;

    Vector2 paddleToBallDistance;

    bool hasStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallDistance = this.transform.position - myPaddle.transform.position;
            
            
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted) // hasStarted == false
        {
            LockBallToPaddle();
            LaunchBallOnClick();
        }
    }

    private void OnCollisionEnter2D(Collision2D coll)
    {
        //generate random number
        int randomNumber = Random.Range(0, ballSounds.Length);
        //save random audio in clip
        AudioClip clip = ballSounds[randomNumber];
        //play the random clip
        GetComponent<AudioSource>().PlayOneShot(clip);
    }


    private void LaunchBallOnClick()
    {
        if (Input.GetMouseButtonDown(0)) //left Click
        {
            hasStarted = true;
            //shoot the ball
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 15f);
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePosition = myPaddle.transform.position;
        //set the Ball Position = Paddle Position + the Distance
        this.transform.position = paddlePosition + paddleToBallDistance;
    }
}
