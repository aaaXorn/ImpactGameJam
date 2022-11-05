using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class ChairMovement : MonoBehaviour
    {
        [Tooltip("Rotation speed.")]
        [SerializeField] float _rotSpd;

        //used in Update()
        public void RotateChair(float h_input)
        {
            //rotates the player object
            Vector3 rot_dir = new Vector3(0, h_input * _rotSpd * Time.deltaTime, 0);
            transform.Rotate(rot_dir);
        }
    }
}