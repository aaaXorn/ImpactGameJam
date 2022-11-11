using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Dialogue : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _tmpTxt;

    [SerializeField] RectTransform rect;

    [SerializeField] string startTxt;

    bool _isActive;
    float _activeTime;

    public static Dialogue Instance;

    void Start()
    {
        Instance = this;
        ChangeText(startTxt);
    }

    public void ChangeText(string txt)
    {
        _tmpTxt.text = txt;
        _activeTime = 10f;

        /*if(!_isActive)
        {
            StartCoroutine("MoveTo");
        }*/
    }

    IEnumerator MoveTo()
    {
        _isActive = true;

        int startTime = 20;
        while(startTime > 0)
        {
            rect.anchoredPosition = new Vector3(rect.anchoredPosition.x,
                                                rect.anchoredPosition.y + 20f);

            startTime--;

            yield return new WaitForSeconds(1f/60f);
        }

        while(_activeTime > 0)
        {
            _activeTime -= 1f;
            yield return new WaitForSeconds(1f);
        }

        startTime = 20;
        while(startTime > 0)
        {
            rect.anchoredPosition = new Vector3(rect.anchoredPosition.x,
                                                rect.anchoredPosition.y - 20f);

            startTime--;

            yield return new WaitForSeconds(1f/60f);
        }

        _isActive = false;
    }
}
