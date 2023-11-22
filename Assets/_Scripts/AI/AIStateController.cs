using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.AI;
using Custom.Build;
using System.Xml.Serialization;
using Unity.AI.Navigation;

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
        [HideInInspector] public NPCController nPCController;

        public bool aiActive;

        private void Awake()
        {
            navMeshAgent = GetComponent<NavMeshAgent>();
            gameController = GameObject.Find("GameController").GetComponent<GameController>();
            nPCController = GetComponent<NPCController>();
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