using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [Header("Sight Elements")]
    public float eyeRadius = 5f;
    [Range(0, 360)]
    public float eyeAngle = 90f;

    [Header("Search Elements")]

    public LayerMask targetLayerMask;
    public LayerMask blockLayerMask;

    public Transform target;

    void FindTargets()
    {
        target = null;

        Collider[] overlapSphereTargets = Physics.OverlapSphere(transform.position, eyeRadius, targetLayerMask);

        for (int i = 0; i < overlapSphereTargets.Length; i++)
        {
            Transform target = overlapSphereTargets[i].transform;
            Vector3 LookAtTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, LookAtTarget) < eyeAngle / 2)
            {
                float nowFirstDistanceTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, LookAtTarget, nowFirstDistanceTarget, blockLayerMask))
                {
                    this.target = target;
                }
            }
        }
    }

    public float delayFindTime = 0.2f;

    private void Update()
    {
        FindTargets();
    }


    void Start()
    {
        StartCoroutine("updateFindTargets", delayFindTime);
    }

    IEnumerator updateFindTargets(float delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(delay);
            FindTargets();
        }
    }

    public Vector3 findTargetAngle(float degrees, bool flagGlobalAngle)
    {
        if (!flagGlobalAngle)
        {
            degrees += transform.eulerAngles.y;
        }

        return new Vector3(Mathf.Sin(degrees * Mathf.Deg2Rad), 0, Mathf.Cos(degrees * Mathf.Deg2Rad));
    }
}
