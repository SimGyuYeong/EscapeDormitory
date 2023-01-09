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

    private Queue<Transform> targetQ = new Queue<Transform>();
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
        if(targetQ.Count<=0)
        {
            List<int >indexArr = new List<int>();

            for(int i=0;i<posTargets.Length; i++)
            {
                indexArr.Add(i);
            }
            int posLength = posTargets.Length;
            for(int i=posTargets.Length;i>0;i--)
            {
                int index = Random.Range(0, posLength);
                targetQ.Enqueue(posTargets [indexArr[index]]);
                indexArr.RemoveAt(index);
                
                posLength--;
            }
        }

        if(posTargets.Length > 0)
        {
            posTarget = targetQ.Dequeue();
            print(posTarget);
        }

        return null;
    }

        
}
