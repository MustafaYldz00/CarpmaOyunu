using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private TMP_Text _timerText;

    private int _remainingTime = 12;
    private bool _running = true;

    void Start()
    {
        StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine()
    {
        while (_running)
        {
            yield return new WaitForSeconds(1f);
            if (_remainingTime < 10)
            {
                _timerText.text = "0" +_remainingTime.ToString();
            }
            else
                _timerText.text =_remainingTime.ToString();


            if (_remainingTime <= 0)
            {
                _timerText.text = "00";
                _running = false;
            }
            _remainingTime --;
        }
    }

   
}
