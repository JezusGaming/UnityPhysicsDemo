using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RayCastScript : MonoBehaviour {

    public GameObject Object;
	private bool Opening;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);
		if(Object.transform.position.x >= -2.5f)
		{
			if (Physics.Raycast(transform.position, fwd, 1))
			{
				//print("There is something in front of the object!");
				Rigidbody RB = Object.GetComponent<Rigidbody>();
				RB.velocity = new Vector3(-1, RB.velocity.y, RB.velocity.z);
			}
		}
		else
		{
			Rigidbody RB = Object.GetComponent<Rigidbody>();
			RB.velocity = new Vector3(1, RB.velocity.y, RB.velocity.z);
		}
    }
}
