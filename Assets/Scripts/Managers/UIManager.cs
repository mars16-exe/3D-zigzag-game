using System;
using UnityEngine;
using TMPro;
using DG.Tweening;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI tapTEXT;
    public GameObject topPanel;
    private Tweener blinkTween;

    private float defaultY_tapText, defaultY_topPanel;

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

    public void tapTextRemove()
    {
        Sequence downSequence = DOTween.Sequence();
        
        downSequence.Append(tapTEXT.rectTransform.DOMoveY(-100f, 0.5f));
        downSequence.Join(tapTEXT.DOFade(0f, 0.35f));
        downSequence.SetEase(Ease.OutSine);
        downSequence.Play();
    }

    public void tapTextRestore()
    {
        tapTEXT.transform.localPosition = Vector3.one * defaultY_tapText;
        tapTEXT.DOFade(1f, 0.2f);
    }

    public void TopPanelRemove()
    {
        topPanel.transform.DOMoveY(500f, 0.5f).SetAutoKill();
    }

    public void TopPanelRestore()
    {
        topPanel.transform.DOMoveY(defaultY_topPanel, 0.5f).SetAutoKill();
    }
    
    
}
