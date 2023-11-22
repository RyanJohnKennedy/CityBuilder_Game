using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Custom.AI
{
    [CreateAssetMenu(menuName = "AI/Actions/Wonder")]
    public class WonderAction : Action
    {
        public override void Act(AIStateController controller)
        {
            DelayWonder(controller);
        }

        private void Wonder(AIStateController controller)
        {
            Debug.Log("Run");
            float radius = 20;

            Vector3 randomDirection = Random.insideUnitSphere * radius;
            randomDirection += controller.nPCController.home.transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, radius, 1);
            Vector3 finalPosition = hit.position;

            controller.navMeshAgent.destination = finalPosition;
        }

        private void DelayWonder(AIStateController controller)
        {
            if (controller.CheckIfCountDownElapsed(5))
            {
                Wonder(controller);
                controller.stateTimeElapsed = 0;
            }
        }
    }
}