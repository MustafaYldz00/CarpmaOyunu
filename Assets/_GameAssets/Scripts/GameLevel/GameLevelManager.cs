using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameLevelManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _startText;
    [SerializeField] private TMP_Text _soruText;
    [SerializeField] private TMP_Text _solSonuc;
    [SerializeField] private TMP_Text _ortaSonuc;
    [SerializeField] private TMP_Text _sagSonuc;
    [SerializeField] private TMP_Text _dogruSayiText;
    [SerializeField] private TMP_Text _yanlisSayiText;
    [SerializeField] private TMP_Text _puanText;
    [SerializeField] private GameObject _dogruImage;
    [SerializeField] private GameObject _yanlisImage;


    private string _gameLevelName;

    int _birinciCarpan;
    int _ikinciCarpan;
    int Sonuc;
    int _yanlisSayisi, _dogruSayisi, _Puan;

    void Start()
    {
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
        if (PlayerPrefs.HasKey("gameLevelName"))
        {
            _gameLevelName = PlayerPrefs.GetString("gameLevelName");
        }
        _yanlisSayisi = 0; _dogruSayisi = 0; _Puan = 0;

        StartCoroutine(StartTextRoutine());
    }

    IEnumerator StartTextRoutine()
    {
        _startText.GetComponent<RectTransform>().DOScale(1f, 0.1f);
        yield return new WaitForSeconds(0.35f);
        _startText.GetComponent<RectTransform>().DOScale(0f, 0.3f).SetEase(Ease.InBack);
        yield return new WaitForSeconds(0.35f);
        StartGame();
    }

    public void StartGame()
    {
        SoruyuYazdir();
    }

    void BirinciCarpanAyarla()
    {
        switch (_gameLevelName)
        {
            case "2":
                _birinciCarpan = 2;
                break;
            case "3":
                _birinciCarpan = 3;
                break;
            case "4":
                _birinciCarpan = 4;
                break;
            case "5":
                _birinciCarpan = 5;
                break;
            case "6":
                _birinciCarpan = 6;
                break;
            case "7":
                _birinciCarpan = 7;
                break;
            case "8":
                _birinciCarpan = 8;
                break;
            case "9":
                _birinciCarpan = 9;
                break;
            case "10":
                _birinciCarpan = 10;
                break;
            case "Karýþýk":
                _birinciCarpan = Random.Range(2, 11);
                break;
        }
        

    }

    void SoruyuYazdir()
    {
        BirinciCarpanAyarla();

        _ikinciCarpan = Random.Range(2, 11);

        int rastgeleDeger = Random.Range(2, 101);

        if (rastgeleDeger <= 50)
        {
            _soruText.text = _birinciCarpan.ToString() + " X " + _ikinciCarpan.ToString();
        }
        else
        {
            _soruText.text = _ikinciCarpan.ToString() + " X " + _birinciCarpan.ToString();
        }

        CevabiYazdir();
    }

    void CevabiYazdir()
    {
        Sonuc = _birinciCarpan * _ikinciCarpan;

        int daireSonucBelirle = Random.Range(2, 5);

        switch (daireSonucBelirle)
        {
            case 2:
                _solSonuc.text = Sonuc.ToString();
                _ortaSonuc.text = Random.Range(5, 25).ToString();
                _sagSonuc.text = Random.Range(25, 45).ToString();
                break;
            case 3:
                _solSonuc.text = Random.Range(5, 25).ToString();
                _ortaSonuc.text = Sonuc.ToString();
                _sagSonuc.text = Random.Range(25, 45).ToString();
                break;
            case 4:
                _solSonuc.text = Random.Range(5, 25).ToString();
                _ortaSonuc.text = Random.Range(25, 45).ToString();
                _sagSonuc.text = Sonuc.ToString();
                break;
        }

    }

    public void SonucuKontrolEt(int textSonucu)
    {
        if (textSonucu == Sonuc)
        {
            _dogruSayisi++;
            _dogruSayiText.text = _dogruSayisi.ToString() + " DOÐRU";
            _Puan += 10;
            _puanText.text = _Puan.ToString()+ " PUAN";
            StartCoroutine(TrueFalseImageAktiflik(_dogruImage));
            if (PlayerPrefs.GetInt("sesDurumu") == 1)
            {
                AudioManager.Instance.Play(SoundType.TrueSound);
            }
        }
        else
        {
            _yanlisSayisi++;
            _yanlisSayiText.text = _yanlisSayisi.ToString() + " YANLIÞ";
            _Puan -= 5;
            _puanText.text = _Puan.ToString()+ " PUAN";
            StartCoroutine(TrueFalseImageAktiflik(_yanlisImage));
            if (PlayerPrefs.GetInt("sesDurumu") == 1)
            {
                AudioManager.Instance.Play(SoundType.FalseSound);
            }
        }
    }

    IEnumerator TrueFalseImageAktiflik(GameObject image)
    {
        image.SetActive(true);
        yield return new WaitForSeconds(0.5f);
        image.SetActive(false);
        SoruyuYazdir();
    }

   
}
