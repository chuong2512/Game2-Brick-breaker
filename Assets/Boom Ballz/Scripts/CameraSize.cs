using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSize : MonoBehaviour
{
    float screenAspectRatio = 0;
    // Start is called before the first frame update
    void Start()
    {
        screenAspectRatio = (float)Screen.width / (float)Screen.height;
        float orthographicSize = (float)(6 - (screenAspectRatio - 0.5) * 11.66);
        if(orthographicSize <= 5.3f) {
            Camera.main.orthographicSize = 5.3f;
        }else {
            Camera.main.orthographicSize = orthographicSize;
        }
    }
}
