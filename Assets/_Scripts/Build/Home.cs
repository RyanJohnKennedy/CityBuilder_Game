using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom.Build
{
    public class Home : Building
    {

        [Header("Resident Info")]
        public List<NPCController> residents = new List<NPCController>();
        public int maxResidents;

        public int NumResidents { get => residents.Count; }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}