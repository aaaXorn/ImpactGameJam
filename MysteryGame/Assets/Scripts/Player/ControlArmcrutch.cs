using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;

namespace Player
{
    [RequireComponent(typeof(InputReceiver))]
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(ArmcrutchMove))]
    [RequireComponent(typeof(CameraChair))]
    public class ControlArmcrutch : MonoBehaviour
    {
        InputReceiver _input;
        Movement _move;
        ChairMovement _crutchMove;
        CameraChair _cam;

        void Awake()
        {
            _input = GetComponent<InputReceiver>();
            _move = GetComponent<Movement>();
            _crutchMove = GetComponent<ChairMovement>();
            _cam = GetComponent<CameraChair>();
        }

        void Update()
        {
            if(!_input.isControlled) return;

            _cam.PosAndRot();
        }

        void FixedUpdate()
        {
            if(!_input.isControlled) return;

        }
    }
}