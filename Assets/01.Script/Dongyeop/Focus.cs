using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Focus : MonoBehaviour //초점을 나갔다 다시 돌아왔다 시키는 스크립트
{
    [SerializeField] private float _waitTime = 1.1f;
    [SerializeField] private float _apertureValue = 2.5f;

    private PostProcessVolume _postProcess;
    private DepthOfField _depthOfField;

    private bool _isApertureUp = false;

    private void Awake()
    {
        _postProcess = GetComponent<PostProcessVolume>();
        _postProcess.sharedProfile.TryGetSettings<DepthOfField>(out _depthOfField);
    }

    private void Start()
    {
        _depthOfField.aperture.value = 0.1f;
        StartCoroutine(ApertureChangeSetting());
    }

    private IEnumerator ApertureChangeSetting()
    {
        while (true)
        {
            _isApertureUp = true;
            yield return new WaitForSeconds(_waitTime);
            _isApertureUp = false;
            yield return new WaitForSeconds(_waitTime);
        }
    }

    private void Update()
    {
        ApertureChange();
    }

    private void ApertureChange()
    {
        if (_isApertureUp)
            _depthOfField.aperture.value += _apertureValue * Time.deltaTime;
        else
            _depthOfField.aperture.value -= _apertureValue * Time.deltaTime;
    }
}
