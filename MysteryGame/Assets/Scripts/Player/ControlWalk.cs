using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;

namespace Player
{
    [RequireComponent(typeof(InputReceiver))]
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(CameraWalk))]
    public class ControlWalk : MonoBehaviour
    {
        InputReceiver _input;
        Movement _move;
        CameraWalk _cam;

        void Awake()
        {
            _input = GetComponent<InputReceiver>();
            _move = GetComponent<Movement>();
            _cam = GetComponent<CameraWalk>();
        }

        void Update()
        {
            if(!_input.isControlled) return;

            //rotate and position the camera
            _cam.Rotate(_input.h_cam, _input.v_cam);
        }

        void FixedUpdate()
        {
            if(!_input.isControlled) return;

            //sets the direction based on the player's input
            Vector3 dir = new Vector3(_input.h_move, 0, _input.v_move).normalized;
            //transforms the direction from world to local
            dir = transform.TransformDirection(dir);
            //moves the player
            if(dir != Vector3.zero)
                _move.MoveForce(dir);
            //rigidbody drag without Y
            _move.CustomDrag();
        }
    }
}
