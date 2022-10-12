// Unity-Design-Patterns
// Project: https://github.com/GoodNightGG/Unity-Design-Patterns/
// 2022-10-07 Create by:
// GoodNightGG <https://github.com/GoodNightGG>

using UnityEngine;
using UnityEngine.XR;

namespace StateStructure
{
    public class StateStructure : MonoBehaviour
    {
        void Start()
        {
            Context context = new Context(new ConcreteStateA());

            context.Request();
            context.Request();
            context.Request();
            context.Request();
            context.Request();
        }
        
    }

    public class Context
    {
        private State _state;

        public Context(State state)
        {
            _state = state;
        }

        public void Request()
        {
            _state.Handle(this);
        }

        public void ChangeState(State state)
        {
            _state = state;
            Debug.Log("ChangeState: " + state.GetType().Name);
        }
    }

    public abstract class State
    {
        public abstract void Handle(Context context);
    }

    public class ConcreteStateA : State
    {
        public override void Handle(Context context)
        {
            context.ChangeState(new ConcreteStateB());
        }
    }

    public class ConcreteStateB : State
    {
        public override void Handle(Context context)
        {
            context.ChangeState(new ConcreteStateA());
        }
    }
}