using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Cube")
        {
            Debug.Log(other.transform.position);
            Destroy(other.gameObject);
        }
    }
}
