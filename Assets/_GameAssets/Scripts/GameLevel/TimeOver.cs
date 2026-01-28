using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeOver : MonoBehaviour
{
    
    [SerializeField] TMP_Text _trueCount;
    [SerializeField] TMP_Text _falseCount;
    [SerializeField] TMP_Text _score;

    private void Start()
    {
        TimeOverPanelOpen();
    }

    public void TimeOverPanelOpen()
    {
        _trueCount.text = "DOÐRU SAYISI : " + GameLevelManager.Instance._dogruSayisi;
        _falseCount.text = "YANLIÞ SAYISI : " + GameLevelManager.Instance._yanlisSayisi;
        _score.text = "PUAN : " + GameLevelManager.Instance._Puan;
        AudioManager.Instance.Play(SoundType.TimeOverSound);
    }

    public void Restart()
    {
        SceneManager.LoadScene(2);
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
        Timer.Instance._running = true;
        InputBlocker.IsUIBlockingInput = false;
    }
    public void SubMenuOpen()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
        InputBlocker.IsUIBlockingInput = false;
        SceneManager.LoadScene(1);
    }
    public void MainmenuOpen()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
        InputBlocker.IsUIBlockingInput = false;
        SceneManager.LoadScene(0);

    }
}
