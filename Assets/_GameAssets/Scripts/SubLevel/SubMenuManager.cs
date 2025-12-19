using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubMenuManager : MonoBehaviour
{
    [SerializeField] GameObject _subMenuPanel;
    void Start()
    {
        _subMenuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        _subMenuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
    }

    public void WhichGame(string gameLevelName)
    {
        PlayerPrefs.SetString("gameLevelName", gameLevelName);
        SceneManager.LoadScene(2);
    }


    public void backButton()
    {
        SceneManager.LoadScene(0);
    }
}
