using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;

namespace Player
{
    [RequireComponent(typeof(InputManager))]
    public class SwapPlayer : MonoBehaviour
    {
        InputManager _inputM;

        bool _isChair;

        [SerializeField] InputReceiver _walkInput, _chairInput;


        void Start()
        {
            _inputM = GetComponent<InputManager>();
        }

        void Update()
        {
            if(Input.GetKeyDown(KeyCode.E)) SwapChair();
        }

        public void SwapChair()
        {
            if(_isChair)
            {
                _inputM.ChangeReceiver(_walkInput);
            }
            else
            {
                _inputM.ChangeReceiver(_chairInput);
            }

            _isChair = !_isChair;
        }
    }
}