using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallowCamera : MonoBehaviour
{   
    [SerializeField] GameObject thingToFallow;
    // Camera position should be the same as the car position 
    
    void LateUpdate()
    {
        transform.position = thingToFallow.transform.position + new Vector3 (0,0,-10);
    } 
}
