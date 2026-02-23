using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using UnityEngine.SceneManagement;

public class AdBanner : MonoBehaviour
{
    public string bannerID = ""; // Reklam birim kimliði (ID) burada tanýmlanýr.
    private BannerView _bannerView;

    // Reklam boyutunu seçmek için enum
    public enum BannerSize
    {
        Banner,
        MediumRectangle,
        Leaderboard,
        SmartBanner,
        IABBanner,         // IAB Banner olarak düzenlendi
    }

    // Reklam pozisyonunu seçmek için enum
    public enum BannerPosition
    {
        Top,
        Bottom
    }

    // Farklý sahneler için reklam ayarlarý
    public BannerSize bannerSize = BannerSize.Banner;
    public BannerPosition bannerPosition = BannerPosition.Bottom;

    void Start()
    {
        // Google Mobile Ads SDK'yý baþlatýyoruz.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // SDK baþlatýldýktan sonra banner reklamýný oluþturuyoruz.
            CreateBannerView();
        });

    }

    public void CreateBannerView()
    {
        Debug.Log("Banner görüntüsü oluþturuluyor.");

        // Eðer banner daha önce oluþturulmuþsa, eskiyi yok ediyoruz.
        if (_bannerView != null)
        {
            DestroyAd();
        }

        // Banner boyutunu ve pozisyonunu enum'dan seçiyoruz
        AdSize adSize = GetAdSize(bannerSize);
        AdPosition adPosition = GetAdPosition(bannerPosition);

        // Banner reklamýnýn boyutu ve pozisyonu ayarlanýr.
        _bannerView = new BannerView(bannerID, adSize, adPosition);

        // Reklam yükleme iþlemi çaðrýlýr.
        LoadAd();
    }

    // Enum'dan doðru AdSize'i almak için yardýmcý fonksiyon
    private AdSize GetAdSize(BannerSize size)
    {
        switch (size)
        {
            case BannerSize.Banner: return AdSize.Banner;
            case BannerSize.MediumRectangle: return AdSize.MediumRectangle;
            case BannerSize.Leaderboard: return AdSize.Leaderboard;
            case BannerSize.IABBanner: return AdSize.IABBanner;  // IABBanner kullanýldý
            default: return AdSize.Banner;
        }
    }

    // Enum'dan doðru AdPosition'ý almak için yardýmcý fonksiyon
    private AdPosition GetAdPosition(BannerPosition position)
    {
        switch (position)
        {
            case BannerPosition.Top: return AdPosition.Top;
            case BannerPosition.Bottom: return AdPosition.Bottom;
            default: return AdPosition.Bottom;
        }
    }

    public void LoadAd()
    {
        // Reklam yükleme isteði oluþturuluyor.
        var adRequest = new AdRequest();

        // Reklam yükleme iþlemi baþlatýlýyor.
        _bannerView.LoadAd(adRequest);
    }

    public void HideBanner()
    {
        if (_bannerView != null)
        {
            Debug.Log("Hiding banner ad.");
            _bannerView.Hide();
        }
    }

    public void ShowBanner()
    {
        if (_bannerView != null)
        {
            Debug.Log("Showing banner ad.");
            _bannerView.Show();
        }
    }

    public void DestroyAd()
    {
        if (_bannerView != null)
        {
            Debug.Log("Banner görüntüsü yok ediliyor.");
            _bannerView.Destroy();
            _bannerView = null;
        }
    }

    private void OnDestroy()
    {
        DestroyAd();
    }
}


//AdSize.Banner: Reklam boyutunu belirler. Örneðin:

//AdSize.Banner: 320x50 boyutunda standart banner.
//AdSize.MediumRectangle: 300x250 boyutunda orta dikdörtgen.
//AdSize.Leaderboard: 728x90 boyutunda liderlik tahtasý.
//AdSize.SmartBanner: Cihaz geniþliðine göre otomatik ayarlanýr.
//AdSize.IABBanner: 468x60 — IAB (medium-yatay) 

//AdPosition.Top: Reklamýn konumunu belirler. Örneðin:
//AdPosition.Top: Reklam ekranýn üst kýsmýnda.
//AdPosition.Bottom: Reklam ekranýn alt kýsmýnda.