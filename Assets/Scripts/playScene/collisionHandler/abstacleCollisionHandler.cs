using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class abstacleCollisionHandler : collisionHandler
{
    public override void handleCollisionEvent(string hitedObject)
    {
        if(hitedObject == "abstacle")
        {
            gamePlayController.instance.destroyBall();
            gamePlayController.instance.showGameOverUI();
            gamePlayController.instance.savePlayerStatus();
        }
    }
}
