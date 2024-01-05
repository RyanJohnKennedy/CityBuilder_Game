using Custom.Build;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;

public enum DayNight
{
    Day,
    Night
}
public class GameController : MonoBehaviour
{
    public DayNight dayNight;
    public int timeOfDay = 0000;
    public DateController dateController;

    public NavMeshSurface navMeshSurface;


    [Header("Builings Info")]
    public List<Building> homes = new List<Building>();

    public int HomeSpots { get => homes.Count; }

    // Start is called before the first frame update
    void Start()
    {
        dateController = new DateController(DateTime.Now);
    }

    // Update is called once per frame
    void Update()
    {
        DateTime ingameTime = dateController.InGameTime;
        //Print time and date
        //ingameTime.ToLongTimeString();
    }

    public void AddHome(Building homeToAdd)
    {
        homes.Add(homeToAdd);
    }
    

}
