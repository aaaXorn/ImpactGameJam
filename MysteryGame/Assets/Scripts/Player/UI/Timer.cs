using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Timer : MonoBehaviour
{
    float _time;
    [SerializeField] float _maxTime;

    bool _isActive;

    [SerializeField] GameObject _timerObj;

    [SerializeField] GameObject GameOverScreen;

    [SerializeField] Pause pause;

    [SerializeField] TextMeshProUGUI _tmpTxt, _timerTxt;

    void Update()
    {
        if(!_isActive) return;

        _time -= Time.deltaTime;
        _timerTxt.text = "" + (int)_time;

        if(_time <= 0)
        {
            GameOver();
        }
    }

    public void StartTimer()
    {
        _isActive = true;
        _time = _maxTime;

       // _timerObj.SetActive(true);
    }

    private void GameOver()
    {
        if(!Pause._isPaused) Pause.Instance.PauseOrUnpause();

        _tmpTxt.text = "GAME OVER";

        GameOverScreen.SetActive(true);
    }

    public void TryAgain()
    {
        if(Pause._isPaused) Pause.Instance.PauseOrUnpause();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Quit()
    {
        Application.Quit();
    }
}