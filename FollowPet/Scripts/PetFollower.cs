using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.Follow_pet
{
    public class PetFollower
    {
        private Transform target;
        private float distanceLimit;
        private NavMeshAgent agent;

        public PetFollower(Transform target, float distanceLimit, NavMeshAgent agent)
        {
            this.target = target;
            this.distanceLimit = distanceLimit;
            this.agent = agent;
        }

        public void UpdateMove()
        {
            runTo(target.position);
        }

        private void runTo(Vector3 target)
        {
            Vector3 randomDirection = UnityEngine.Random.insideUnitSphere * distanceLimit;
            randomDirection.y = 0;
            randomDirection += target;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, distanceLimit, 1);
            Vector3 finalPosition = hit.position;
            agent.SetDestination(finalPosition);
        }
    }
}
