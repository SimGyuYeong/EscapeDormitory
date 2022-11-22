using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flicker : MonoBehaviour // ±ôºýÀÌ´Â°Å ½ÇÇà ÄÚµå 
{
    [SerializeField] private float _flickerTimeSec = .25f;

    private Color _eyeImageA;
    private bool _isFlicker = false;

    [HideInInspector] public Image eyeImage;

    private void Awake()
    {
        eyeImage = GameObject.Find("EyeImage").GetComponent<Image>();

        _eyeImageA = eyeImage.GetComponent<Image>().color;
    }

    private void Update()
    {
        FlickerChange();

        if (_eyeImageA.a >= 1 && _isFlicker)
            _isFlicker = false;
    }

    private void FlickerChange()
    {
        if (_isFlicker)
        {
            if (_eyeImageA.a > 1)
                return;

                _eyeImageA.a += _flickerTimeSec * Time.deltaTime;
        }
        else if (!_isFlicker)
        {
            if (_eyeImageA.a < 0)
                return;

            _eyeImageA.a -= _flickerTimeSec * Time.deltaTime;
        }

        eyeImage.GetComponent<Image>().color = _eyeImageA;
    }

    public void ThisFlicker()
    {
        _isFlicker = true;
    }
}
