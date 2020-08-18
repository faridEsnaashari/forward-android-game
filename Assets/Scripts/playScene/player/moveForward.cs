using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour
{
    private float _speed = 5;

    private float lastSpeedBeforeStop;
    private float lastZ = -48;

    private const float WATE_TIME_FOR_SPEED = 1f;
    private const float MAX_SPEED = 15f;

    public float speed
    {
        get {return _speed;}
        set 
        {
            if(value == 0)
            {
                lastSpeedBeforeStop = _speed;
                _speed = 0;
                transform.Find("ballIllustrate").gameObject.GetComponent<moveHorizontally>().speed=0;

                StopCoroutine("increaseSpeed");
            }
            else
            {
                _speed = lastSpeedBeforeStop;
                transform.Find("ballIllustrate").gameObject.GetComponent<moveHorizontally>().speed=.2f;

                StopCoroutine("increaseSpeed");
            }
        }
    }
    private void Start()
    {
        StartCoroutine("increaseSpeed");
    }
    private void Update()
    {
        move();
        increaseScore();
    }
    private IEnumerator increaseSpeed()
    {
        while(_speed <= MAX_SPEED)
        {
            _speed += .2f;
            yield return new WaitForSeconds(WATE_TIME_FOR_SPEED);
        }
    }
    private void increaseScore()
    {
        if(transform.position.z > lastZ + 1)
        {
            Score.instance.incScore();
            lastZ = transform.position.z;

            gamePlayController.instance.updateScoreUI(Score.instance.score);
        }
    }

    private void move()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }
}
