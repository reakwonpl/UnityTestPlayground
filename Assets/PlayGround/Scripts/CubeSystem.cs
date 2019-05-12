using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSystem : MonoBehaviour {

   // public bool stateOnGuard = false;
    //public bool stateGuardPoints = false;
    //public bool stateWander = false;
    private Rigidbody rb;

    public enum CoyoteSystem { onGuard, guardPoints, justWander};
    public CoyoteSystem coyoteSystem;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        switch(coyoteSystem)
        {
            case CoyoteSystem.onGuard:
                OnGuard();
                break;
            case CoyoteSystem.guardPoints:
                GuardPoints();
                break;
            case CoyoteSystem.justWander:
                Wander();
                break;
            default:
                break;
        }

        //if(stateOnGuard == true)
        //{
        //    OnGuard();
        //    stateGuardPoints = false;
        //    stateWander = false;
        //} else if( stateGuardPoints == true)
        //{
        //    GuardPoints();
        //    stateOnGuard = false;
        //    stateWander = false;
        //} else if( stateWander == true)
        //{
        //    Wander();
        //    stateOnGuard = false;
        //    stateGuardPoints = false;
        //}
		
	}

    void OnGuard()
    {
        rb.AddForce(transform.forward * Time.deltaTime);
        Debug.Log("OnGuard state");
    }

    void GuardPoints()
    {
        rb.AddForce(transform.up * Time.deltaTime);
        Debug.Log("GuardPoints state");
    }

    void Wander()
    {
        rb.AddForce(transform.right *Time.deltaTime);
        Debug.Log("Wander state");
    }
}
