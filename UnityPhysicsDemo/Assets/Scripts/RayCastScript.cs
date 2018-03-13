using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RayCastScript : MonoBehaviour {

    public GameObject Object;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

        if (Physics.Raycast(transform.position, fwd, 1))
        {
            //print("There is something in front of the object!");
            Rigidbody RB = Object.GetComponent<Rigidbody>();
            RB.velocity = new Vector3(RB.velocity.x, 1, RB.velocity.z);
        }
    }
}
