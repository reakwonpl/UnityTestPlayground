using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour {

    public Transform[] spawns;

    public float spawnTime = 3f;
    public float startSpawn = 2f;
    public GameObject cube;

    public Material[] materials;
    

	void Start ()
    {      
     InvokeRepeating("SpawnCubes", startSpawn, spawnTime);       
    }

    private void Update()
    {
        int rndMat = Random.Range(0, materials.Length);
        changeMat(cube, rndMat);
    }



    void changeMat( GameObject cube,int rnd)
    {                  
     cube.GetComponent<Renderer>().material = materials[rnd];        
    }
   
	

    void SpawnCubes()
    {
        int spawnPointIndex = Random.Range(0, spawns.Length);
        Instantiate(cube, spawns[spawnPointIndex].position, spawns[spawnPointIndex].rotation);
    }
}
