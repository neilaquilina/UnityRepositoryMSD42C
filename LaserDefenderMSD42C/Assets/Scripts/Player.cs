using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float movementSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private float MoveX()
    {
        //get the movement on the x-axis
        float deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;
        //update the new x-position 
        float newXPos = transform.position.x + deltaX;

        return newXPos;
    }

    private float MoveY()
    {
        //get the movement on the y-axis
        float deltaY = Input.GetAxis("Vertical") * Time.deltaTime * movementSpeed;
        //update the new y-position 
        float newYPos = transform.position.y + deltaY;

        return newYPos;
    }

    private void Move()
    {
        transform.position = new Vector2(MoveX(), MoveY());
;    }
}
