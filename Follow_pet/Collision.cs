using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Follow_pet;

public class Collision : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Prevents flying away by punched object
    private void OnCollisionExit(UnityEngine.Collision collision)
    {
        if (collision.transform == PetFollower.Target)
        {
            PetFollower.MoveBehaviour.StopMove();
        }
    }
}
