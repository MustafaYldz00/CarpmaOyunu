using DG.Tweening;
using System.Collections;
using UnityEngine;

public class GameLevelManager : MonoBehaviour
{
    [SerializeField] private GameObject _startText;
    
    void Start()
    {
        if (PlayerPrefs.HasKey("gameLevelName"))
        {
            //Debug.Log(PlayerPrefs.GetString("gameLevelName"));
        }

        StartCoroutine(StartTextRoutine());
    }

    IEnumerator StartTextRoutine()
    {
        _startText.GetComponent<RectTransform>().DOScale(1f,0.1f);
        yield return new WaitForSeconds(0.5f);
        _startText.GetComponent<RectTransform>().DOScale(0f,0.5f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.5f);
        StartGame();
    }

    public void StartGame()
    {
        Debug.Log("Oyuna Baþladý");
    }


}
