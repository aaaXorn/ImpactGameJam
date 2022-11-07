using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;

namespace Player
{
    [RequireComponent(typeof(InputReceiver))]
    [RequireComponent(typeof(Movement))]
    [RequireComponent(typeof(ArmcrutchMove))]
    [RequireComponent(typeof(CameraArmcrutch))]
    public class ControlArmcrutch : MonoBehaviour
    {
        InputReceiver _input;
        Movement _move;
        ArmcrutchMove _crutchMove;
        CameraArmcrutch _cam;

        void Awake()
        {
            _input = GetComponent<InputReceiver>();
            _move = GetComponent<Movement>();
            _crutchMove = GetComponent<ArmcrutchMove>();
            _cam = GetComponent<CameraArmcrutch>();
        }

        void Update()
        {
            if(!_input.isControlled) return;

            _cam.PosAndRot(_input.h_cam);

            _crutchMove.WalkTimer(_input.h_move);
        }

        void FixedUpdate()
        {
            if(!_input.isControlled) return;

            _crutchMove.CrutchMove();
        }
    }
}