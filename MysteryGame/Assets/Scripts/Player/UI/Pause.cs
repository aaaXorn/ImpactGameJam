using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    static public bool _isPaused;

    public static Pause Instance;

    float _timescale;

    [SerializeField] GameObject _pauseMenu;

    void Start()
    {
        _timescale = Time.timeScale;
        Instance = this;
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseOrUnpause();
        }
    }

    public void PauseOrUnpause()
    {
        _isPaused = !_isPaused;

        Time.timeScale = _isPaused ? 0f : _timescale;
        _pauseMenu.SetActive(_isPaused);

        Cursor.lockState = !_isPaused ? CursorLockMode.Locked : CursorLockMode.None;;
        Cursor.visible = _isPaused;
    }

    public void TryAgain()
    {
        if(_isPaused) PauseOrUnpause();

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
