using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;

public class TimeLineEnd : MonoBehaviour //타임라인 종료시 실행
{
    [SerializeField] private PostProcessProfile _noneProfile;

    private CameraRay cmRay;
    private CameraMove cmMove;

    public GameObject Player;

    private Focus _focus;
    private Flicker _flicker;

    private Image _blackImage;

    private void Awake()
    {
        _focus = GetComponent<Focus>();
        _flicker = GetComponent<Flicker>();
        _blackImage = GameObject.Find("BlackImage").GetComponent<Image>();
        cmMove = GetComponent<CameraMove>();
        cmRay = GetComponent<CameraRay>();
    }

    public void TimeLineend()
    {
        _focus.postProcess.profile = _noneProfile;
        
        _flicker.eyeImage.enabled = false;

        _focus.enabled = false;
        _flicker.enabled = false;

        cmMove.enabled = true;
        cmRay.enabled = true;
        Player.gameObject.SetActive(true);

    }

    public void TimeLineFadeOutEnd()
    {
        _blackImage.enabled = false;
    }
}
