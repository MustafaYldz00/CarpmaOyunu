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
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
        SceneManager.LoadScene(1);
    }

    public void SettingsPanel()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
    }

    public void exitGame()
    {
        Application.Quit();
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
    }
}
