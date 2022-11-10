using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float _time;
    [SerializeField] float _maxTime;

    bool _isActive;

    [SerializeField] GameObject _timerObj;

    void Update()
    {
        if(!_isActive) return;

        _time -= Time.deltaTime;

        if(_time <= 0)
        {
            GameOver();
        }
    }

    public void StartTimer()
    {
        _isActive = true;
        _time = _maxTime;

        _timerObj.SetActive(true);
    }

    private void GameOver()
    {

    }
}