using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class TimeLineEnd : MonoBehaviour //Ÿ�Ӷ��� ����� ����
{
    [SerializeField] private PostProcessProfile _noneProfile;

    private Focus _focus;
    private Flicker _flicker;

    private void Awake()
    {
        _focus = GetComponent<Focus>();
        _flicker = GetComponent<Flicker>();
    }

    public void TimeLineend()
    {
        _focus.postProcess.profile = _noneProfile;
        _focus.enabled = false;

        _flicker.enabled = false;
    }
}
