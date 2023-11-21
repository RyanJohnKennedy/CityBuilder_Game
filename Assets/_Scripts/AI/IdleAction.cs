using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom.AI
{
    [CreateAssetMenu(menuName = "AI/Actions/Idle")]
    public class IdleAction : Action
    {
        public override void Act(AIStateController controller)
        {
            Wonder(controller);
        }

        private void Wonder(AIStateController controller)
        {
            controller.navMeshAgent.destination = controller.wayPoints[controller.nextWayPoint].position;
            controller.navMeshAgent.isStopped = false;

            if (controller.navMeshAgent.remainingDistance <= controller.navMeshAgent.stoppingDistance && !controller.navMeshAgent.pathPending)
            {
                controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPoints.Count;
            }
        }
    }
}