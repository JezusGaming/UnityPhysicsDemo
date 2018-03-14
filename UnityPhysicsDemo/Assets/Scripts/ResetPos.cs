using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPos : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Ragdoll")
        {
			Vector3 pos = new Vector3(4.641f, 9.29f, -3.88f);
			other.transform.position = pos;
        }
    }
}
