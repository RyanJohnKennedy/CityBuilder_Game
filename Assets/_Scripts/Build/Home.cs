using Custom.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom.Build
{
    public class Home : Building
    {
        [Header("Resident Info")]
        public List<NPCController> residents = new List<NPCController>();
        public int maxResidents = 2;

        public int NumResidents { get => residents.Count; }

        // Start is called before the first frame update
        void Start()
        {
            gameController.AddHome(this);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void NPCMoveIn(NPCController NPC)
        {
            residents.Add(NPC);
        }

        public bool AddResident(NPCController nPC)
        {
            if(NumResidents < maxResidents)
            {
                Debug.Log("true");
                residents.Add(nPC);
                return true;
            }
            return false;
        }
    }
}