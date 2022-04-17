using CharacterState;
using Interfaces;
using UnityEngine;

namespace State
{
    public class BaseState
    {
        private StateEvent Stage;
        private States Name;
        private BaseState NextState;
        
        protected ICharacter BaseCharacterController;
        protected Animator Animator;        
        
        public States StateName => Name;

        protected BaseState(ICharacter baseCharacterController, Animator animator)
        {
            BaseCharacterController = baseCharacterController;
            Animator = animator;
        }
        
        protected virtual void Enter()
        {
            Stage = StateEvent.Update;
        }

        protected virtual void Update()
        {
            Stage = StateEvent.Update;
        }

        protected virtual void Exit()
        {
            Stage = StateEvent.Exit;
        }

        public BaseState Process()
        {
            if (Stage == StateEvent.Enter)
                Enter();
            if (Stage == StateEvent.Update)
                Update();
            if (Stage != StateEvent.Exit) return this;
            
            Exit();
            return NextState;

        }
        
        public void ToNextState(BaseState baseState)
        {
            NextState = baseState;
            Stage = StateEvent.Exit;
        }
    }
}
