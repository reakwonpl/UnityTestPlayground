﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour {

    Rigidbody rb; 
   
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
            
        }
	
	// Update is called once per frame
	void Update () {
        rb.AddForce(transform.forward);
		
	}

    private void OnMouseDown()
    {
        Debug.Log(transform.position);
        Destroy(gameObject);
    }
}
