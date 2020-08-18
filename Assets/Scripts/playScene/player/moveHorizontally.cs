using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveHorizontally : MonoBehaviour
{
    private const float DISTANSE_BETWEEN_CAMERA_AND_BALL = 8;
    private float _speed = .2f;


    private void Update()
    {
        //the parent object of ball move forward
        move();
    }

    private void move()
    {
        if(Input.touchCount > 0)
        {
            float touchXPosition = getTouchXPosition();

            if(transform.position.x > touchXPosition + .1f)
            {
                transform.Translate(-_speed, 0, 0);
            }
            else if(transform.position.x < touchXPosition - .1f)
            {
                transform.Translate(_speed, 0, 0);
            }
            else
            {
                transform.position = new Vector3(touchXPosition, transform.position.y, transform.position.z);
            }
        }
    }

    private float getTouchXPosition()
    {
        // Vector3 touchPosition = Input.mousePosition;

        Touch touch = Input.GetTouch(0);

        Vector3 touchPosition = touch.position;
        touchPosition.z = DISTANSE_BETWEEN_CAMERA_AND_BALL;

        touchPosition = Camera.main.ScreenToWorldPoint(touchPosition);

        return touchPosition.x;
    }

    public float speed
    {
        set { _speed = value; }
    }
}
