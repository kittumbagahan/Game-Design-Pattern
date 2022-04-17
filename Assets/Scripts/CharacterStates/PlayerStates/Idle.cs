using Interfaces;
using State;
using UnityEngine;

public class Idle : BaseState
{
    private readonly int _idle = Animator.StringToHash("Idle");
    
    protected Idle(ICharacter baseCharacterController, Animator animator) : base(baseCharacterController, animator)
    {
        BaseCharacterController = baseCharacterController;
        Animator = animator;
    }
    
    protected override void Enter()
    {
        Animator.SetTrigger(_idle);
        base.Enter();
    }

    protected override void Update()
    {
        Debug.Log("Update");
        base.Update();
    }

    protected override void Exit()
    {
        Animator.ResetTrigger(_idle);
        base.Exit();
    }
}
