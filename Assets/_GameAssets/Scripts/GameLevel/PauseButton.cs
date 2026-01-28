using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseButton : MonoBehaviour
{
    public static PauseButton Instance { get; private set; }

    [SerializeField] private GameObject _gamePausedPanel;

    private void Awake()
    {
        Instance = this;
    }

    public void Pause()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
        _gamePausedPanel.SetActive(true);
        InputBlocker.IsUIBlockingInput = true;
        Time.timeScale = 0f;
    }
    public void Resume()
    {
        StartCoroutine(ResumeWait());
        _gamePausedPanel.SetActive(false);
        Time.timeScale = 1f;
    }
    IEnumerator ResumeWait()
    {
        yield return new WaitForSeconds(0.5f);
        InputBlocker.IsUIBlockingInput = false;
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
    }
    public void Mainmenu()
    {

        if (Time.timeScale == 1f)
        {
            MenuManager.Instance.MenuPanelOped();
        }
        InputBlocker.IsUIBlockingInput = false;
        SceneManager.LoadScene(0);
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
    }
    public void SubMenu()
    {
        if (Time.timeScale == 1f)
        {
            SubMenuManager.Instance.SubPanelOpen();
        }
        InputBlocker.IsUIBlockingInput = false;
        SceneManager.LoadScene(1);
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
    }
    
}
