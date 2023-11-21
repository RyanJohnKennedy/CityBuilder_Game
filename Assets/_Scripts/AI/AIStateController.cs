using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;
using Custom.Build;
using System.Xml.Serialization;

namespace Custom.AI
{
    public class AIStateController : MonoBehaviour
    {
        public State currentState;

        public AIStats stats;
        public Transform eyes;
        public State remainState;


        [HideInInspector] public NavMeshAgent navMeshAgent;
        [HideInInspector] public GameController gameController;
        [HideInInspector] public float stateTimeElapsed;
        [HideInInspector] public LineRenderer lineRenderer;

        //Temp
        public List<Transform> wayPoints;
        [HideInInspector] public int nextWayPoint;

        public Building home;
        public Building work;

        public bool aiActive;
        public bool VisualisePath;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            gameController = GameObject.Find("GameController").GetComponent<GameController>();
            lineRenderer = GetComponent<LineRenderer>();
        }

        private void Update()
        {
            if (!aiActive)
                return;

            currentState.UpdateState(this);
 
            if(VisualisePath && navMeshAgent != null && navMeshAgent.hasPath)
            {
                lineRenderer.positionCount = navMeshAgent.path.corners.Length;
                lineRenderer.SetPositions(navMeshAgent.path.corners);
                lineRenderer.enabled = true;
            }
            else
                lineRenderer.enabled = true;
        }

        private void OnDrawGizmos()
        {
            if (currentState != null && eyes != null)
            {
                Gizmos.color = currentState.sceneGizmoColor;
                Gizmos.DrawWireSphere(eyes.position, stats.lookShereCastRadius);
            }
        }

        public void TransitionToState(State nextState)
        {
            if (nextState != remainState)
                currentState = nextState;
        }

        public bool CheckIfCountDownElapsed(float duration)
        {
            stateTimeElapsed += Time.deltaTime;
            return (stateTimeElapsed >= duration);
        }

        private void OnExitState()
        {
            stateTimeElapsed = 0;
        }
    }
}