using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tst1 : MonoBehaviour
{
    private Text tst;
    void Start()
    {
        tst=gameObject.GetComponent<Text>();
        tst.text=Fa.faConvert("بالاترین امتیاز");
    }

}
