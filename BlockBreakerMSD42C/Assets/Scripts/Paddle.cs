using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float screenWidthInUnits = 16f;

    Vector2 paddlePosition;

    // Start is called before the first frame update
    void Start()
    {
        paddlePosition = new Vector2(transform.position.x, transform.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        float mousePos = Input.mousePosition.x / Screen.width * screenWidthInUnits;

        //setting the limit of the mouse on the x-axis between 1 and 15
        paddlePosition.x = Mathf.Clamp(mousePos, 1f, 15f);

        this.transform.position = paddlePosition;
        
    }
}
