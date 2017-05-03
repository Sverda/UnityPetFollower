using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Follow_pet;
using UnityEngine.AI;

public class Follower : MonoBehaviour
{
    public Transform target;
    public float MaxDistance;
    public float MinDistance;
    private PetFollower pf;

    private void Start()
    {
        pf = new PetFollower(target, GetComponent<NavMeshAgent>(), MaxDistance, MinDistance);
    }

    private void Update()
    {
        pf.UpdateMove();
    }
}
