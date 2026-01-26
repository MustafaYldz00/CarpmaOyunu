using DG.Tweening;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubMenuManager : MonoBehaviour
{
    public static SubMenuManager Instance { get; private set; }
    [SerializeField] GameObject _subMenuPanel;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SubPanelOpen();
    }
    public void SubPanelOpen()
    {
        if (_subMenuPanel != null)
        {
            if (Time.timeScale != 1f)
                Time.timeScale = 1f;
            _subMenuPanel.GetComponent<CanvasGroup>().DOFade(1, 0.5f);
            _subMenuPanel.GetComponent<RectTransform>().DOScale(1, 0.5f).SetEase(Ease.OutBack);
        }
    }

    public void WhichGame(string gameLevelName)
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
                AudioManager.Instance.Play(SoundType.ButtonClickSound);
        }
        PlayerPrefs.SetString("gameLevelName", gameLevelName);
        StartCoroutine(LoadSceneWithDelay());
    }

    private IEnumerator LoadSceneWithDelay()
    {
        if (Time.timeScale != 1f)
        {
            yield return new WaitForSeconds(0.05f);
            InputBlocker.IsUIBlockingInput = false;
            SceneManager.LoadScene(2);
        }
        else
        {
            yield return new WaitForSeconds(0.05f);
            InputBlocker.IsUIBlockingInput = false;
            SceneManager.LoadScene(2);
        }

        
    }

    public void backButton()
    {
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            AudioManager.Instance.Play(SoundType.ButtonClickSound);
        }
        StartCoroutine(LoadBackScene());
    }
    private IEnumerator LoadBackScene()
    {
        if (Time.timeScale != 1f)
        {
            yield return new WaitForSeconds(0.05f);
            MenuManager.Instance.MenuPanelOped();
            SceneManager.LoadScene(0);
        }
        else
        {
            yield return new WaitForSeconds(0.05f);
            MenuManager.Instance.MenuPanelOped();
            SceneManager.LoadScene(0);
        }

        
    }
}
