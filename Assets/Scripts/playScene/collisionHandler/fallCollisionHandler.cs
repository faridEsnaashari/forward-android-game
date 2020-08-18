using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallCollisionHandler : collisionHandler
{
    public override void handleCollisionEvent(string hitedObject)
    {
        if(hitedObject == "fall")
        {
            gamePlayController.instance.activateBallGravity();
            gamePlayController.instance.showGameOverUI();
            gamePlayController.instance.savePlayerStatus();
        }
    }
}
