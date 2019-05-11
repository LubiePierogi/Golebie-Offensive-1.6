using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ptak : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float odl = float.PositiveInfinity;
        Ziarenko najblizej = null;
        List<GameObject> rootObjects = new List<GameObject>();
        Scene scene = SceneManager.GetActiveScene();
        scene.GetRootGameObjects(rootObjects);

        if (rootObjects.Any())
        {

            // iterate root objects and do something
            for (int i = 0; i < rootObjects.Count; ++i)
            {
                Ziarenko z = rootObjects[i].GetComponent<Ziarenko>(); ;
                if (z != null)
                {
                    float o = (transform.position - rootObjects[i].transform.position).sqrMagnitude;
                    if (o < odl)
                    {
                        odl = o;
                        najblizej = z;
                    }
                }
            }
            if (najblizej != null)
            {
                Quaternion targetRotation = Quaternion.LookRotation(najblizej.transform.position - transform.position) * Quaternion.Euler(0f, -90f, 0f);
                transform.rotation = targetRotation;
            }
        }
    }
}
