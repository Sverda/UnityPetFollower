using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Follow_pet;

public class Follower : MonoBehaviour
{
    public Transform target;
    public float speed;
    public Vector3 distanceLimit;

    private void Start()
    {
        PetFollower.Rb = GetComponent<Rigidbody>();
        PetFollower.MyTransform = GetComponent<Transform>();
        PetFollower.Target = target;
        PetFollower.MoveBehaviour.speed = speed;
        PetFollower.MoveBehaviour.distanceLimit = distanceLimit;
    }

    private void Update()
    {
        PetFollower.MoveBehaviour.UpdateMove();
    }

    private void LateUpdate()
    {
        PetFollower.MoveBehaviour.ComputeDistance();
    }
}
