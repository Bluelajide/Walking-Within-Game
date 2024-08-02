using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Countdown : MonoBehaviour
{
    [SerializeField] GameObject panel;
    [SerializeField] Image timeImage;
    [SerializeField] Text timeText;
    [SerializeField] float duration, currentTime;

    void Start()
    {
        panel.SetActive(false);
        currentTime = duration;
        StartCoroutine(TimeIEn());
    }

    IEnumerator TimeIEn()
    {
        while(currentTime >= 0)
        {
            timeImage.fillAmount = Mathf.InverseLerp(0, duration, currentTime);
            yield return new WaitForSeconds(1f);
            currentTime--;
        }
        OpenPanel();
    }

    void OpenPanel()
    {
        panel.SetActive(true);
    }
   
}
