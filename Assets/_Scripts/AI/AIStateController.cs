using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;
using Custom.Build;

namespace Custom.AI
{
    public class AIStateController : MonoBehaviour
    {
        public State currentState;

        public AIStats stats;
        public Transform eyes;


        [HideInInspector] public NavMeshAgent navMeshAgent;
        [HideInInspector] public GameController gameController;

        //Temp
        public List<Transform> wayPoints;
        [HideInInspector] public int nextWayPoint;

        public Building home;
        public Building work;

        public bool aiActive;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            gameController = GameObject.Find("GameController").GetComponent<GameController>();
        }

        private void Update()
        {
            if (!aiActive)
                return;

            currentState.UpdateState(this);
        }

        private void OnDrawGizmos()
        {
            if (currentState != null && eyes != null)
            {
                Gizmos.color = currentState.sceneGizmoColor;
                Gizmos.DrawWireSphere(eyes.position, stats.lookShereCastRadius);
            }
        }
    }
}