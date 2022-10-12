using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class TimeLineEnd : MonoBehaviour //타임라인 종료시 실행
{
    [SerializeField] private PostProcessProfile _noneProfile;

    private Focus _focus;
    private Flicker _flicker;

    private Image _blackImage;

    private void Awake()
    {
        _focus = GetComponent<Focus>();
        _flicker = GetComponent<Flicker>();
        _blackImage = GameObject.Find("BlackImage").GetComponent<Image>();
    }

    public void TimeLineend()
    {
        _focus.postProcess.profile = _noneProfile;
        
        _flicker.eyeImage.enabled = false;

        _focus.enabled = false;
        _flicker.enabled = false;
    }

    public void TimeLineFadeOutEnd()
    {
        _blackImage.enabled = false;
    }
}
