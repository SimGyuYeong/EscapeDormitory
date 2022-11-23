using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.AI;

public class StateRoaming : State<AIFSM>
{
    private Animator animator;
    private CharacterController characterController;
    private NavMeshAgent agent;

    private AIFSM aiFSM;

    protected int hashMove = Animator.StringToHash("Move");
    protected int hashAttack = Animator.StringToHash("Atk");
    protected int hashTarget = Animator.StringToHash("Target");
    protected int hashMoveSpeed = Animator.StringToHash("MoveSpd");

    public override void OnAwake()
    {
        animator = stateMachineClass.GetComponent<Animator>();
        characterController = stateMachineClass.GetComponent<CharacterController>();
        agent = stateMachineClass.GetComponent<UnityEngine.AI.NavMeshAgent>();

        aiFSM = stateMachineClass as AIFSM;
    }
    public override void OnStart()
    {
        if (stateMachineClass.posTarget == null)
        {
            stateMachineClass.SearchNextTargetPosition();
        }
        if (stateMachineClass.posTarget != null)
        {
            Vector3 destination = stateMachineClass.posTarget.position;
            agent?.SetDestination(destination);
            animator?.SetBool(hashMove, true);
        }

    }
    public override void OnUpdate(float deltaTime)
    {
        Transform target = stateMachineClass.SearchMonster();

        if (target)
        {
            if (stateMachineClass.getFlagAtk)
            {
                stateMachine.ChangeState<StateAtk>();
            }
            else
            {
                stateMachine.ChangeState<StateMove>();
            }
        }
        else
        {
            Debug.Log("===a" + agent.remainingDistance + ":" + agent.stoppingDistance + "/n");
            if (!agent.pathPending && (agent.remainingDistance <= agent.stoppingDistance + 0.01f))
            {
                stateMachineClass.SearchNextTargetPosition();
                stateMachine.ChangeState<StateIdle>();
            }
            else
            {
                characterController.Move(agent.velocity * deltaTime);
                animator.SetFloat(hashMoveSpeed, agent.velocity.magnitude / agent.speed, 0.1f, deltaTime);
            }
        }
    }
    public override void OnEnd()
    {
        agent.stoppingDistance = stateMachineClass.atkRange;
        agent.ResetPath();
    }
    private void SearchNextTargetPosition()
    {
        Transform posTarget = aiFSM.SearchNextTargetPosition();
        if (posTarget != null) agent?.SetDestination(posTarget.position);
    }
}
