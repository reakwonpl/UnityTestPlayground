using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathPlacer : MonoBehaviour {

    public  Vector2[] currentpoint;
   
    int targetIndex = 0;
    public float speed;

    public float spacing = 0.1f;
    public float resolution = 1f;
   Vector2[] points;

	// Use this for initialization
	void Start () {
       points = FindObjectOfType<PathCreator>().path.CalculateEvenlySpacedPoints(spacing, resolution);
        //foreach(Vector2 p in points)
        //{
        //    GameObject g = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //    g.transform.position = p;
        //    g.transform.localScale = Vector3.one * spacing * .5f;
        //}
        

        currentpoint = points;
       	}
	
	// Update is called once per frame
	void FixedUpdate () {

        
       transform.position = Vector3.MoveTowards(transform.position, currentpoint[targetIndex], Time.deltaTime * speed);
        if(transform.position == (Vector3)currentpoint[targetIndex])
        {
            targetIndex = (targetIndex + 1) % currentpoint.Length;
            Debug.Log(targetIndex);
        }
	}
}
