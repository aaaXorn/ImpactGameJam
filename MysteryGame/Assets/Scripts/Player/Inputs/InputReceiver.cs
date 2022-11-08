using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Inputs
{
    public class InputReceiver : MonoBehaviour
    {
        //if this object is being controlled by the player
        public bool isControlled;

        //movement inputs
        //left/right
        public float h_move;
        //back/forward
        public float v_move;

        //camera inputs
        //left/right
        public float h_cam;
        //down/up
        public float v_cam;

        //interact
        public bool interact;
        //swap between chair and armcrutch
        public bool swap_move;
    }
}