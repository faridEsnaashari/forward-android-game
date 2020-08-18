using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameObjectCreator : MonoBehaviour
{
    public static gameObjectCreator instance;
    public GameObject[] gameElements;
    public GameObject[] instantiatedElements = new GameObject[3];

    private collisionHandler[] handlers = new collisionHandler[4];
    private GameObject ballCollisionDetector;

    private const float PLAIN_X = 0;
    private const float PLAIN_Y = 0;
    private const float PALINS_DISTANCE = 100;

    private void Start()
    {
        instance = this;

        assignHandlersToHandlersArray();

        instantiatedElements[0] = instantiateElements(gameElements[0]);
        instantiatedElements[1] = instantiateElements(gameElements[1] , new Vector3(PLAIN_X , PLAIN_Y , 0));
        instantiatedElements[2] = instantiateElements(gameElements[2] , new Vector3(PLAIN_X , PLAIN_Y , 100));

        subscribeToCollisionOccuredEvent();
    }

    private void subscribeToCollisionOccuredEvent()
    {
        ballCollisionDetector = instantiatedElements[0].GetComponent<getObjects>().getBallCollisionDetector();
        ballCollisionDetector.GetComponent<collisionDetection>().collisionOccured += callHandlers;
    }

    private void assignHandlersToHandlersArray()
    {
        handlers[0] = new coinCollisionHandler();
        handlers[1] = new abstacleCollisionHandler();
        handlers[2] = new fallCollisionHandler();
        handlers[3] = new beginPointCollisionHandler();
    }

    private void callHandlers(string hitedObject)
    {
        foreach(collisionHandler handler in handlers)
        {
            handler.handleCollisionEvent(hitedObject);
        }
    }

    private GameObject instantiateElements(GameObject element)
    {
        return Instantiate(element);
    }
    private GameObject instantiateElements(GameObject element , Vector3 pos)
    {
        return Instantiate(element , pos , Quaternion.identity);
    }
    public void destroyPreviousPlain()
    {
        Destroy(instantiatedElements[1]);
    }
    public void instantiateNextPlain()
    {
        instantiatedElements[1] = instantiatedElements[2];

        float previousPlainZ = instantiatedElements[1].transform.position.z;
        instantiatedElements[2] = instantiateElements(gameElements[2] , new Vector3(PLAIN_X , PLAIN_Y , previousPlainZ + PALINS_DISTANCE));
    }
}
