using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Player
{
    public class CameraChair : MonoBehaviour
    {
        [Tooltip("Object with the camera component.")]
        [SerializeField] GameObject _camObj;
        [Tooltip("Object the camera will be following.")]
        [SerializeField] GameObject _camFollowObj;

        [SerializeField] float _cam_rotSpd;

        void Start()
        {
            //debugging
            if(_camObj == null)
            {
                Debug.LogError("_camObj not defined.");
                Destroy(gameObject);
            }
        }

        //used in Update()
        public void PosAndRot()
        {
            _camObj.transform.position = _camFollowObj.transform.position;
            _camObj.transform.rotation = Quaternion.RotateTowards(_camObj.transform.rotation, _camFollowObj.transform.rotation, _cam_rotSpd * Time.deltaTime);
        }
    }
}