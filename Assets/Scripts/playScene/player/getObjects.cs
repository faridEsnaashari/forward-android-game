using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getObjects : MonoBehaviour
{
    public GameObject getBallCollisionDetector()
    {
        return transform.Find("ballIllustrate/ballCollisionDetector").gameObject;
    }
    public GameObject getBallIllustrate()
    {
        return transform.Find("ballIllustrate").gameObject;
    }
}
