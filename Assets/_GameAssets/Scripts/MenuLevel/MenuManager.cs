using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance { get; private set; }

    [SerializeField] GameObject _menuPanel;
    [SerializeField] GameObject _sesPanel;
    [SerializeField] Button _soundButton;  
    [SerializeField] Sprite _soundOnSprite;
    [SerializeField] Sprite _soundOffSprite;

    bool _sesPaneliAcik;
    [SerializeField] private bool _isSoundActive;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        _sesPaneliAcik = false;
        
        _sesPanel.GetComponent<RectTransform>().localPosition = new Vector3(35,-175,0);
       
        if (PlayerPrefs.GetInt("sesDurumu") == 1)
        {
            //_soundButton.image.sprite = _soundOnSprite;
            AudioManager.Instance.SetSoundEffectsMute(false);
            BackgroundMusic.Instance.SetMusicMute(false);
            _isSoundActive = true;
        }
        if (PlayerPrefs.GetInt("sesDurumu") == 0)
        {
           // _soundButton.image.sprite = _soundOffSprite;
            AudioManager.Instance.SetSoundEffectsMute(true);
            BackgroundMusic.Instance.SetMusicMute(true);
            _isSoundActive = false;
        }

        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
            MenuPanelOped();
        }
        else
        {
            MenuPanelOped();
        }
    }

    public void MenuPanelOped()
    {
        if (_menuPanel != null)
        {   
            _menuPanel.GetComponent<CanvasGroup>().DOFade(1, 0.75f);
            _menuPanel.GetComponent<RectTransform>().DOScale(1, 0.75f).SetEase(Ease.OutBack);
        }
    }

    public void moveNextLevel()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;

            AudioManager.Instance.Play(SoundType.ButtonClickSound);
            SceneManager.LoadScene(1);
        }
        else
        {
            AudioManager.Instance.Play(SoundType.ButtonClickSound);
            SceneManager.LoadScene(1);
        }
        
    }

    public void SettingsPanel()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
        if (!_sesPaneliAcik)
        {
            _sesPanel.GetComponent<RectTransform>().DOLocalMoveY(-690, 0.5f);
            if (PlayerPrefs.GetInt("sesDurumu") == 1)
            {
                _soundButton.image.sprite = _soundOnSprite;
            }
            if (PlayerPrefs.GetInt("sesDurumu") == 0)
            {
                _soundButton.image.sprite = _soundOffSprite;
            }
            
            _sesPanel.SetActive(true);
            _sesPaneliAcik=true;
        }
        else
        {
            _sesPanel.GetComponent<RectTransform>().DOLocalMoveY(-175, 0.5f);
            _sesPanel.SetActive(false);
            _sesPaneliAcik = false;
        }
        
    }

    public void exitGame()
    {
        AudioManager.Instance.Play(SoundType.ButtonClickSound);
        Application.Quit();
    }

    public void SoundButtonClicked()
    {
        
        AudioManager.Instance.Play(SoundType.ButtonClickSound);    
        _isSoundActive = !_isSoundActive;
        if (_isSoundActive)
        {
            PlayerPrefs.SetInt("sesDurumu", 1);
            _soundButton.image.sprite = _soundOnSprite;
            AudioManager.Instance.SetSoundEffectsMute(!_isSoundActive);
            BackgroundMusic.Instance.SetMusicMute(!_isSoundActive);
        }
        else
        {
            PlayerPrefs.SetInt("sesDurumu", 0);
            _soundButton.image.sprite = _soundOffSprite;
            AudioManager.Instance.SetSoundEffectsMute(!_isSoundActive);
            BackgroundMusic.Instance.SetMusicMute(!_isSoundActive);
        }

        

    }
    
}
