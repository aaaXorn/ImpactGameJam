using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public bool _finishOpen;

    [SerializeField] GameObject EndScreen;

    [SerializeField] Pause pause;

    void OnCollisionEnter(Collision other)
    {
        if(!_finishOpen) return;

        if(other.gameObject.CompareTag("Player"))
        {
            Finish();
        }
    }

    private void Finish()
    {
        if(!Pause._isPaused) Pause.Instance.PauseOrUnpause();

        Pause.Instance.enabled = false;

        EndScreen.SetActive(true);
    }
}
