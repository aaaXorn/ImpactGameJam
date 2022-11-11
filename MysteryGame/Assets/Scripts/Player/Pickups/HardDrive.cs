using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HardDrive : MonoBehaviour
{
    [SerializeField] GameEnd[] GE;

    [SerializeField] string txt;

    public void HDGet()
    {
        foreach(GameEnd end in GE)
        {
            end._finishOpen = true;
        }
        Dialogue.Instance.ChangeText(txt);
        gameObject.SetActive(false);
    }
}
