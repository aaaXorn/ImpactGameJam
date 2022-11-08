using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;

namespace Player
{
    [RequireComponent(typeof(InputReceiver))]
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(ChairMovement))]
    [RequireComponent(typeof(CameraChair))]
    public class ControlChair : MonoBehaviour
    {
        InputReceiver _input;
        Movement _move;
        ChairMovement _chairMove;
        CameraChair _cam;

        [Tooltip("Position of the armcrutch player after leaving the chair.")]
        [SerializeField] Transform _crutchSwapPos;
        [Tooltip("Armcrutch player object.")]
        [SerializeField] GameObject _objCrutch;
        InputReceiver _walkInput;

        [Tooltip("Detection collider for the player to return to the chair.")]
        [SerializeField] GameObject _chairDetection;

        void Awake()
        {
            _input = GetComponent<InputReceiver>();
            _move = GetComponent<Movement>();
            _chairMove = GetComponent<ChairMovement>();
            _cam = GetComponent<CameraChair>();

            _walkInput = _objCrutch.GetComponent<InputReceiver>();
        }

        void Update()
        {
            if(!_input.isControlled) return;

            //rotate the player
            if(_input.h_move != 0) _chairMove.RotateChair(_input.h_move);

            //clamps the player rotation, so they don't fall over
            //experimental and still glitchy, so for now use rigidbody constraints instead
            //_chairMove.ClampRotation();

            _cam.PosAndRot();

            if(_input.swap_move) LeaveChair();
        }

        void FixedUpdate()
        {
            if(!_input.isControlled) return;
            
            //sets the direction based on the player's input
            Vector3 dir_move = new Vector3(0, 0, _input.v_move).normalized;
            //transforms the direction from world to local
            dir_move = transform.TransformDirection(dir_move);
            //moves the player
            if(dir_move != Vector3.zero)
                _move.MoveForce(dir_move);
            
            //rigidbody drag without Y
            _move.CustomDragWUp(1.25f);
        }

        private void LeaveChair()
        {
            //exits the chair
            _objCrutch.SetActive(true);
            //moves the armcrutch player into position
            _objCrutch.transform.position = _crutchSwapPos.position;

            RayHitboxSetActive(true);

            InputManager.Instance.ChangeReceiver(_walkInput);
        }

        public void RayHitboxSetActive(bool active)
        {
            _chairDetection.SetActive(active);
        }
    }
}