using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Custom.Build
{
    public class Building : MonoBehaviour
    {
        public GameController gameController;

        private void Awake()
        {
            gameController = GameObject.Find("GameController").GetComponent<GameController>();
        }

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