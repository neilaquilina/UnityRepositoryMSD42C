using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float movementSpeed = 10f;

    float xMin, xMax, yMin, yMax;

    float padding = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void SetUpMoveBoundaries()
    {

        Camera gameCamera = Camera.main;
        //save the minimum and max x-axis of the camera in xMin and xMax
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

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
        float xPos = Mathf.Clamp(MoveX(), xMin, xMax);
        float yPos = Mathf.Clamp(MoveY(), yMin, yMax);

        transform.position = new Vector2(xPos, yPos);
;    }
}
