using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Focus : MonoBehaviour //��Ŀ���� �����, Ǯ���� �ϴ� ��ũ��Ʈ
{
    [SerializeField] private float _waitTime = 1.1f;
    [SerializeField] private float _apertureValue = 2.5f;

    private PostProcessVolume _postProcess;
    
    private bool _isApertureUp = false;

    [HideInInspector] public DepthOfField depthOfField;

    private void Awake()
    {
        _postProcess = GetComponent<PostProcessVolume>();
        _postProcess.sharedProfile.TryGetSettings<DepthOfField>(out depthOfField);
    }

    private void Start()
    {
        depthOfField.active = true;
        depthOfField.aperture.value = 0.1f;
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

    private void ApertureChange() //��Ŀ�� ����
    {
        if (_isApertureUp)
            depthOfField.aperture.value += _apertureValue * Time.deltaTime;
        else
            depthOfField.aperture.value -= _apertureValue * Time.deltaTime;
    }
}
