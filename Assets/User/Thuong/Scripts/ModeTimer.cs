using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ModeTimer : MonoBehaviour
{
    [SerializeField] private Image uiFill;
    [SerializeField] private Text uiText;

    private int remainingDuration;

    private bool Pause;


    public void Being2(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer(Second));
    }

    private IEnumerator UpdateTimer(int setTime)
    {
        while (remainingDuration >= 0)
        {
            if (!Pause)
            {
                uiText.text = remainingDuration.ToString(); //$"{remainingDuration / 60:00}:{remainingDuration % 60:00}";
                uiFill.fillAmount = Mathf.InverseLerp(0, setTime, remainingDuration);
                remainingDuration--;
                yield return new WaitForSeconds(1f);
            }
            yield return null;
        }
    }
}
