using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubMenuManager : MonoBehaviour
{
    [SerializeField] GameObject _subMenuPanel;
    void Start()
    {
        if (_subMenuPanel != null)
        {
            _subMenuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
            _subMenuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
        }
    }

    public void WhichGame(string gameLevelName)
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
        PlayerPrefs.SetString("gameLevelName", gameLevelName);
        StartCoroutine(LoadSceneWithDelay());
    }

    private IEnumerator LoadSceneWithDelay()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(2);
    }

    public void backButton()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
        StartCoroutine(LoadBackScene());
    }
    private IEnumerator LoadBackScene()
    {
        yield return new WaitForSeconds(0.1f);
        SceneManager.LoadScene(0);
    }
}
