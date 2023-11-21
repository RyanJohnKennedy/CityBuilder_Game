using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom.Build
{
    public class CheckPlacement : MonoBehaviour
    {
        public BuildingManager buildingManager;

        // Start is called before the first frame update
        void Start()
        {
            buildingManager = GameObject.Find("BuildingManager").GetComponent<BuildingManager>();
        }

        private void OnTriggerEnter(Collider other)
        {

        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Object"))
                buildingManager.canPlace = true;
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.CompareTag("Object"))
                buildingManager.canPlace = false;
        }
    }
}