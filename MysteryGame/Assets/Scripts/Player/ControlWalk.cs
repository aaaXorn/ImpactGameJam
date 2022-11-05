using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;

namespace Player
{
    [RequireComponent(typeof(InputReceiver))]
    [RequireComponent(typeof(MoveWalk))]
    [RequireComponent(typeof(CameraWalk))]
    public class ControlWalk : MonoBehaviour
    {
        InputReceiver _rcv;
        MoveWalk _move;
        CameraWalk _cam;

        void Awake()
        {
            _rcv = GetComponent<InputReceiver>();
            _move = GetComponent<MoveWalk>();
            _cam = GetComponent<CameraWalk>();
        }

        void Update()
        {
            if(!_rcv.isControlled) return;

            _cam.RotateWalk(_rcv.h_cam, _rcv.v_cam);
        }

        void FixedUpdate()
        {

        }
    }
}
