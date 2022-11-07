using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(Movement))]
    public class ArmcrutchMove : MonoBehaviour
    {
        Rigidbody _rigid;
        Movement _move;

        [SerializeField] TextMeshProUGUI _tmpTxt;
        [SerializeField] Image _img;

        //movement direction (forward/back)
        int _moveDir = 1;

        //time between steps
        float _walkTime;
        [SerializeField] float _walkMaxTime;
        float _targetTime => _walkMaxTime / 2f;
        //difference between target time and pressed time
        [SerializeField] float _maxTimeDiff;
        float _walkCurrTimer;

        float _timeDiff => Mathf.Abs(_targetTime - _walkTime);
        float _forceMod;

        bool _movePressed;

        //if the next step will use h_move > 0
        bool _nextRight;

        void Awake()
        {
            _rigid = GetComponent<Rigidbody>();
            _move = GetComponent<Movement>();
        }

        //A/D
        //timer
        //press btn, more accurate -> higher mult
        //spd *= mult
        //continuous addforce
        //stops if player doesn't move next cicle

        public void WalkTimer(float h_input)
        {
            if(_walkTime >= _walkMaxTime)
            {
                _movePressed = false;
                _forceMod = 0;
                _walkTime = 0f;
            }

            if(!_movePressed && _timeDiff < _maxTimeDiff)
            {
                if(_nextRight ? h_input >= 0.1f : h_input <= -0.1f)
                {
                    print("move");
                    _forceMod = _timeDiff / _targetTime;
                    _movePressed = true;

                    _nextRight = !_nextRight;

                    _tmpTxt.text = _nextRight ? "R" : "L";
                }
            }

            float bar = _timeDiff / _targetTime;
            _img.fillAmount = 1 - bar;

            _walkTime += Time.deltaTime;
        }

        public void CrutchMove()
        {
            if(_forceMod == 0) return;

            Vector3 dir = transform.forward * _moveDir;
            
            _move.MoveForce(dir, _forceMod);
        }

        public void CheckDirection(float v_input)
        {
            if(v_input != 0)
            {
                _moveDir = v_input > 0f ? 1 : -1;
            }
        }
    }
}