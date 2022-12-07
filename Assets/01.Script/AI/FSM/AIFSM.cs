using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;

public class AIFSM : MonoBehaviour
{

    protected StateMachine<AIFSM> fsmManager;
    public StateMachine<AIFSM> FsmManager => fsmManager;

    private FieldOfView fov;
    public Transform target => fov?.target;

    public Transform[] posTargets;
    public Transform posTarget = null;
    private int posTargetsIdx = 0;

    public float atkRange;

    protected virtual void Start()
    {

        fsmManager = new StateMachine<AIFSM>(this, new StateRoaming());
        StateIdle stateIdle = new StateIdle();
        stateIdle.flagRoaming = true;
        fsmManager.AddStateList(stateIdle);
        fsmManager.AddStateList(new StateMove());
        fsmManager.AddStateList(new StateAtk());


        fov = GetComponent<FieldOfView>();
    }

    protected virtual void Update()
    {
        fsmManager.Update(Time.deltaTime);
    }

    public virtual Transform SearchMonster()
    {
        return target;
    }


    public virtual bool getFlagAtk
    {
        get
        {
            if (!target)
            {
                return false;
            }

            float distance = Vector3.Distance(transform.position, target.position);
            return (distance <= atkRange);
        }
    }

    public Transform SearchNextTargetPosition()
    {
        if(posTargets.Length > 0)
        {
            posTarget = posTargets[Random.Range(0, posTargets.Length)];
        }

        return null;
    }

        
}
