using System;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI tapTEXT;
    public TextMeshProUGUI score;
    public TextMeshProUGUI highScore_One, highScore_Two;
    
    
    public GameObject topPanel;
    public GameObject gameOverPanel;
    private Tweener blinkTween;

    private float defaultY_tapText, defaultY_topPanel;

    public static UIManager Instance;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        defaultY_tapText = tapTEXT.transform.localPosition.y;
        defaultY_topPanel = topPanel.transform.localPosition.y;
        tapTextBlinkStart();
    }

    private void tapTextBlinkStart()
    { 
        blinkTween = tapTEXT.DOFade(0f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InOutSine);
        blinkTween.Play();
    }

    public void tapTextBlinkStop()
    {
        blinkTween.Kill();
    }

    public void tapTextHide()
    {
        Sequence downSequence = DOTween.Sequence();
        
        downSequence.Append(tapTEXT.rectTransform.DOMoveY(-100f, 0.5f));
        downSequence.Join(tapTEXT.DOFade(0f, 0.35f));
        downSequence.SetEase(Ease.OutSine);
        downSequence.Play();
    }

    public void tapTextShow()
    {
        tapTEXT.transform.localPosition = Vector3.one * defaultY_tapText;
        tapTEXT.DOFade(1f, 0.2f);
    }

    public void TopPanelHide()
    {
        topPanel.transform.DOMoveY(500f, 0.5f).SetAutoKill();
    }

    public void TopPanelShow()
    {
        topPanel.transform.DOMoveY(defaultY_topPanel, 0.5f).SetAutoKill();
    }

    public void GameOverPanelShow()
    {
        gameOverPanel.transform.localScale = Vector3.zero;
        gameOverPanel.SetActive(true);
        
        gameOverPanel.transform.DOScale(Vector3.one, 0.5f).SetAutoKill().SetEase(Ease.OutBounce);
    }

    public void GameOverPanelHide()
    {
        gameOverPanel.transform.DOScale(Vector3.zero, 0.5f).SetAutoKill().SetEase(Ease.InBounce);
        gameOverPanel.SetActive(false);
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(0);
    }
    
    
}
