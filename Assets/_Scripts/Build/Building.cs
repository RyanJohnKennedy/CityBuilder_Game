using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom.Build
{
    public class Building : MonoBehaviour
    {
        private GameController gameController;

        // Start is called before the first frame update
        void Start()
        {
            gameController = GameObject.Find("GameController").GetComponent<GameController>();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}