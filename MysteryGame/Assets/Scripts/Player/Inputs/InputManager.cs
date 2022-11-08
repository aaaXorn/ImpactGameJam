using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputs
{
    public class InputManager : MonoBehaviour
    {
        //singleton of this object's instance
        //any script can access this through InputManager.Instance
        //remember to add using Inputs; at the top of the script
        public static InputManager Instance {get; private set;}

        [SerializeField]
        //the player object that is currently receiving inputs
        InputReceiver _currPlayer;

        void Awake()
        {
            //sets the singleton as this instance
            if (Instance == null) Instance = this;
            //if there's  already an instance, destroy the object
            else
            {
                Destroy(gameObject);
                Debug.LogError("InputManager instance already exists.");
            }
        }

        void Update()
        {
            //if there's an object available to receive the inputs
            if(_currPlayer != null)
            {
                GetInputs(_currPlayer);
            }
        }

        //sends the inputs to the player object
        private void GetInputs(InputReceiver rcv)
        {
            rcv.h_move = Input.GetAxis("Move H");
            rcv.v_move = Input.GetAxis("Move V");

            rcv.h_cam = Input.GetAxisRaw("Camera H");//Mathf.Clamp(Input.GetAxisRaw("Camera H"), -1f, 1f);
            rcv.v_cam = Input.GetAxisRaw("Camera V");//Mathf.Clamp(Input.GetAxisRaw("Camera V"), -1f, 1f);

            rcv.interact = Input.GetButtonDown("Interact");
            rcv.swap_move = Input.GetButtonDown("SwapMovement");
        }

        public void ChangeReceiver(InputReceiver rcv)
        {
            _currPlayer.isControlled = false;
            rcv.isControlled = true;
            _currPlayer = rcv;
        }
    }
}