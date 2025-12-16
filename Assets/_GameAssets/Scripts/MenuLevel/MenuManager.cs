using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject _menuPanel;

    void Start()
    {
        _menuPanel.GetComponent<CanvasGroup>().DOFade(1, 1f);
        _menuPanel.GetComponent<RectTransform>().DOScale(1, 1f).SetEase(Ease.OutBack);
    }

    public void moveNextLevel()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingsPanel()
    {

    }

    public void exitGame()
    {
        Application.Quit();
    }
}
