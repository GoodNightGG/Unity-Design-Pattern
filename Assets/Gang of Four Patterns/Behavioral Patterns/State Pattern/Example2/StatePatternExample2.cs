// Unity-Design-Patterns
// Project: https://github.com/GoodNightGG/Unity-Design-Patterns/
// 2022-10-07 Create by:
// GoodNightGG <https://github.com/GoodNightGG>

using StateStructure;
using UnityEngine;

namespace StatePatternExample2
{
    public class StatePatternExample2 : MonoBehaviour
    {
        void Start()
        {
            Context context = new Context();
            context.ChangeState(new ConcreteStateA(context));
            context.Request(10);
            context.Request(15);
            context.Request(20);
            context.Request(50);
        }
    }

    public class Context
    {
        private State _state;

        public void Request(int Value)
        {
            _state.Handle(Value);
        }

        public void ChangeState(State state)
        {
            Debug.Log("ChangerState: " + state.GetType().Name);
            _state = state;
        }
    }
    public abstract class State
    {
        protected Context m_Context = null;

        public State(Context context)
        {
            m_Context = context;
        }
        public abstract void Handle(int Value);
    }
    public class ConcreteStateA : State
    {
        public ConcreteStateA(Context context) : base(context)
        { }

        public override void Handle(int Value)
        {
            Debug.Log("ConcreteStateA Handle");
            if (Value > 10)
                m_Context.ChangeState(new ConcreteStateB(m_Context));
        }

    }
    public class ConcreteStateB : State
    {
        public ConcreteStateB(Context context) : base(context)
        { }

        public override void Handle(int Value)
        {
            Debug.Log("ConcreteStateB Handle");
            if (Value > 20)
                m_Context.ChangeState(new ConcreteStateC(m_Context));
        }

    }
    public class ConcreteStateC : State
    {
        public ConcreteStateC(Context context) : base(context)
        { }

        public override void Handle(int Value)
        {
            Debug.Log("ConcreteStateC Handle");
        }

    }
}