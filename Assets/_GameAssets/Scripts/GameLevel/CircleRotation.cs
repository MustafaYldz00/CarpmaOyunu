using DG.Tweening;
using TMPro;
using UnityEngine;

public class CircleRotation : MonoBehaviour
{
    [HideInInspector] public string _hangiSonuc;

    GameLevelManager _gameLevelManager;

    private void Awake()
    {
        _gameLevelManager = Object.FindAnyObjectByType<GameLevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            if (gameObject.name == "solDaire")
            {
                _hangiSonuc = GameObject.Find("solSonucText").GetComponent<TextMeshProUGUI>().text;
            }
            else if (gameObject.name == "ortaDaire")
            {
                _hangiSonuc = GameObject.Find("ortaSonucText").GetComponent<TextMeshProUGUI>().text;
            }
            else if (gameObject.name == "sagDaire")
            {
                _hangiSonuc = GameObject.Find("sagSonucText").GetComponent<TextMeshProUGUI>().text;
            }
            Debug.Log(_hangiSonuc);

            _gameLevelManager.SonucuKontrolEt(int.Parse(_hangiSonuc));

            gameObject.transform.DORotate(transform.eulerAngles + new Vector3(0, 0, 45), 0.5f);
            Destroy(collision.gameObject);
            
        }
    }
}
