using UnityEngine;
using System.Collections;

public class changeColorOfTheCamera : MonoBehaviour
{
	private const float WATE_TIME = 2f;
	private Camera cam;
    private void Start()
    {
		cam = gameObject.GetComponent<Camera>();
        StartCoroutine("changeCameraBackgroundColorEvery2Second");
    }

    private IEnumerator changeCameraBackgroundColorEvery2Second()
    {
        while(true)
        {
            changeCameraBackgroundColor();
            yield return new WaitForSeconds(WATE_TIME);
        }
    }

    private void changeCameraBackgroundColor()
    {
        Color _color = generateColor();
		cam.backgroundColor = _color;
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