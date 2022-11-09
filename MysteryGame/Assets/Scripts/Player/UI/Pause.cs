using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    static public bool _isPaused;

    float _timescale;

    [SerializeField] GameObject _pauseMenu;

    void Start()
    {
        _timescale = Time.timeScale;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseOrUnpause();
        }
    }

    private void PauseOrUnpause()
    {
        _isPaused = !_isPaused;

        Time.timeScale = _isPaused ? 0f : _timescale;
        _pauseMenu.SetActive(_isPaused);

        Cursor.lockState = !_isPaused ? CursorLockMode.Locked : CursorLockMode.None;;
        Cursor.visible = _isPaused;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
