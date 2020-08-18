using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinCollisionHandler : collisionHandler
{
    public override void handleCollisionEvent(string hitedObject)
    {
        if(hitedObject == "coin")
        {
            coin.instance.incCoinAmount();
            gamePlayController.instance.updateCoinUI(coin.instance.coinAmount);
        }
    }
}
