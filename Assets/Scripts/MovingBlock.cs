using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingBlock : MonoBehaviour
{
    public GameObject leftTurnPoint;
    public GameObject rightTurnPoint;
    public float moveSpeed = 10f;
    bool moveRight = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x > rightTurnPoint.transform.position.x)
        {
            moveRight = false;
        }
        if (transform.position.x < leftTurnPoint.transform.position.x)
        {
            moveRight = true;
        }

        if (moveRight)
        {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }
    }
}
