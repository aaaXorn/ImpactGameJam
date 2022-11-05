using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Inputs;

namespace Player
{
    [RequireComponent(typeof(InputReceiver))]
    [RequireComponent(typeof(MoveWalk))]
    public class ControlWalk : MonoBehaviour
    {
        InputReceiver _rcv;
        MoveWalk _walk;

        void Awake()
        {
            _rcv = GetComponent<InputReceiver>();
            _walk = GetComponent<MoveWalk>();
        }

        void Update()
        {
            if(_rcv.h_move != 0 || _rcv.h_cam != 0)
                print(_rcv.h_move + " " + _rcv.h_cam);
        }

        void FixedUpdate()
        {

        }
    }
}
