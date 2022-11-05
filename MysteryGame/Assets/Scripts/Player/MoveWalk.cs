using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class MoveWalk : MonoBehaviour
    {
        Rigidbody _rigid;

        [SerializeField] float _walkSpd;

        void Awake()
        {
            _rigid = GetComponent<Rigidbody>();
        }

        //used in FixedUpdate()
        public void Move(Vector3 dir)
        {
            _rigid.velocity = new Vector3(dir.x * _walkSpd, _rigid.velocity.y, dir.z * _walkSpd);
        }
    }
}