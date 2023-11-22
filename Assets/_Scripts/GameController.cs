using Custom.Build;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using UnityEngine;

public enum TimeOfDay
{
    Day,
    Night
}
public class GameController : MonoBehaviour
{
    public TimeOfDay timeOfDay;
    public NavMeshSurface navMeshSurface;

    [Header("Builings Info")]
    public List<Building> homes = new List<Building>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddHome(Building homeToAdd)
    {
        homes.Add(homeToAdd);
    }
}
