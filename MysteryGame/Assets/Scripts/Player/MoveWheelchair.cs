using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class MoveWheelchair : MonoBehaviour
    {
        Rigidbody _rigid;

        void Awake()
        {
            _rigid = GetComponent<Rigidbody>();
        }
    }
}