using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCamera : MonoBehaviour
{
    public List<Transform> Planets;

    public int CameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            CameraPosition--;
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            CameraPosition++;
        }

        foreach (Transform planet in Planets)
        {
            if (CameraPosition == Planets.IndexOf(planet))
            {
                transform.position = planet.position - 1 * planet.localScale;
            }
        }
    }
}
