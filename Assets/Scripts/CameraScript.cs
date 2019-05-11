using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public const float Max_W = 1.75f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Screen.width;
        float q = (float)Screen.width / Screen.height;
        //Debug.Log(q);
        if (q < Max_W)
        {
            GetComponent<Camera>().orthographicSize = 5f * Max_W / q;
        }
        else
        {

            GetComponent<Camera>().orthographicSize = 5f;
        }
    }
}
