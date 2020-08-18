using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeAbstacleColor : MonoBehaviour
{
    private Renderer leftCubeRenderer;
    private Renderer rightCubeRenderer;

    private const string LEFTCUBE_NAME = "leftCube";
    private const string RIGHTCUBE_NAME = "rightCube";

    private const float WATE_TIME = 2f;

    private void Start()
    {
        leftCubeRenderer = gameObject.transform.Find(LEFTCUBE_NAME).gameObject.GetComponent<Renderer>();
        rightCubeRenderer = gameObject.transform.Find(RIGHTCUBE_NAME).gameObject.GetComponent<Renderer>();

        StartCoroutine("changeCubesColorEvery2Second");
    }

    private IEnumerator changeCubesColorEvery2Second()
    {
        while(true)
        {
            changeCubesColor();
            yield return new WaitForSeconds(WATE_TIME);
        }
    }

    private void changeCubesColor()
    {
        Color _color = generateColor();

        leftCubeRenderer.material.color = _color;
        rightCubeRenderer.material.color = _color;

    }    

    private Color generateColor()
    {
        int rand = Random.Range(1, 7);
        float r = 0;
        float g = 0;
        float b =0;
        
        switch (rand)
        {
            case 1 :
                r = 1;
                g = Random.Range(.2f, 1);
                b = 0;
                break;

            case 2 :
                r = 1;
                g = 0;
                b = Random.Range(.2f, 1);
                break;

            case 3 :
                r = Random.Range(.2f, 1);
                g = 0;
                b = 1;
                break;
            
            case 4 :
                r = 0;
                g = Random.Range(.2f, 1);
                b = 1;
                break;
            
            case 5 :
                r = 0;
                g = 1;
                b = Random.Range(.2f, 1);
                break;

            case 6 :
                r = Random.Range(.2f, 1);
                g = 1;
                b = 0;
                break;
        }

        return new Color(r, g, b);
    }
}


