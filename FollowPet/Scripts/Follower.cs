using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Follow_pet;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{
    public Transform target;
    public float distanceLimit;
    private PetFollower pf;

    private void Start()
    {
        pf = new PetFollower(target, distanceLimit, GetComponent<NavMeshAgent>());
    }

    private void Update()
    {
        pf.UpdateMove();
    }
}
