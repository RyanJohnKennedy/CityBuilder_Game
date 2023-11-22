using Custom.Build;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using Custom.Build;

public class NPCController : MonoBehaviour
{
    public Building home;
    public Building work;

    [HideInInspector] public LineRenderer lineRenderer;
    [HideInInspector] public NavMeshAgent navMeshAgent;

    public bool VisualisePath;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (home == null)
            FindHome();
        
        if (VisualisePath && navMeshAgent != null && navMeshAgent.hasPath)
        {
            lineRenderer.positionCount = navMeshAgent.path.corners.Length;
            lineRenderer.SetPositions(navMeshAgent.path.corners);
            lineRenderer.enabled = true;
        }
        else
            lineRenderer.enabled = true;
    }

    private void FindHome()
    {
        Home[] possibleHomes = FindObjectsOfType(typeof(Home)) as Home[];
        Debug.Log(possibleHomes.Length);
        foreach (Home h in possibleHomes)
        {
            if (h.AddResident(this))
            {
                home = h;
                return;
            }
        }
    }
}
