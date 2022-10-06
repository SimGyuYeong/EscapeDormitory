using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLineEnd : MonoBehaviour //타임라인 종료시 실행
{
    private Focus _focus;
    private Flicker _flicker;

    private void Awake()
    {
        _focus = GetComponent<Focus>();
        _flicker = GetComponent<Flicker>();
    }

    public void TimeLineend()
    {
        _focus.depthOfField.active = false;
        _focus.enabled = false;

        _flicker.enabled = false;
    }
}
