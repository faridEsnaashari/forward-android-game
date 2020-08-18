using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beginPointCollisionHandler : collisionHandler
{
    public override void handleCollisionEvent(string hitedObject)
    {
        if(hitedObject == "beginPoint")
        {
            gamePlayController.instance.destroyPreviousPlain();
            gamePlayController.instance.instantiateNextPlain();
        }
    }
}
