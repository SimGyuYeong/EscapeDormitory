using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class InfoUp : MonoBehaviour
{

    [SerializeField] private Image infoUI;
    private Image InfoUIUse;

    private void Start()
    {
        InfoUIUse = Instantiate(infoUI, FindObjectOfType<Canvas>().transform).GetComponent<Image>();
        InfoUIUse.transform.DOScale(Vector3.one, 1f).SetEase(Ease.InFlash).SetLoops(-1, LoopType.Yoyo);
    }
    public void InfoUP()
    {
        
    }
    public void Update()
    {
            InfoUIUse.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.8f, 0));
            
    }
    

    
}
