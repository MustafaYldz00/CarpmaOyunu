using System.Collections;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public static Timer Instance { get; private set; }

    [SerializeField] private TMP_Text _timerText;
    [SerializeField] GameObject _timeOverPanel;

    public int _remainingTime = 12;
    public bool _running = true;

    private void Awake()
    {
        Instance = this;
    }

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
                _timeOverPanel.SetActive(true);
                InputBlocker.IsUIBlockingInput = true;
            }
            _remainingTime --;
        }
    }


   
}
