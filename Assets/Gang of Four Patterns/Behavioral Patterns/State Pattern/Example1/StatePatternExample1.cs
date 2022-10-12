// Unity-Design-Patterns
// Project: https://github.com/GoodNightGG/Unity-Design-Patterns/
// 2022-10-07 Create by:
// GoodNightGG <https://github.com/GoodNightGG>

using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace StatePatternExample1
{
    public class StatePatternExample1 : MonoBehaviour
    {
        List<IPlayer> players = new List<IPlayer>();

        void Start()
        {
            players.Add(new Player("Brain"));
            players.Add(new Player("Jimmy"));
        }

        void Update()
        {
            foreach (IPlayer player in players)
            {
                player.Update(Time.deltaTime, Time.unscaledDeltaTime);
            }
        }
    }

    public class Player : IPlayer
    {
        private State _state;
        private string _name;
        public string Name
        {
            get { return _name; }
        }

        public Player(string name)
        {
            _name = name;
            ChangeState(new IdleState());
        }

        public void ChangeState(State state)
        {
            Debug.Log("Name: " + Name + " Enter " + state.GetType().Name);
            _state = state;
        }

        public void Update(float elapseSeconds, float realElapseSeconds)
        {
            _state.Update(this, elapseSeconds, realElapseSeconds);
        }
    }

    public interface IPlayer
    {
        void ChangeState(State state);
        void Update(float elapseSeconds, float realElapseSeconds);
    }

    public abstract class State
    {
        public abstract void Update(IPlayer player, float elapseSeconds, float realElapseSeconds);
    }

    public class IdleState : State
    {
        public override void Update(IPlayer player, float elapseSeconds, float realElapseSeconds)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow)
                || Input.GetKeyDown(KeyCode.DownArrow)
                || Input.GetKeyDown(KeyCode.LeftArrow)
                || Input.GetKeyDown(KeyCode.RightArrow))
            {
                player.ChangeState(new MoveState());
            }
        }
    }

    public class MoveState : State
    {
        private float stopMoveTimer = 0;
        private readonly float stopTimeLimit = .5f;
        public override void Update(IPlayer player, float elapseSeconds, float realElapseSeconds)
        {
            stopMoveTimer += elapseSeconds;
            if (Input.GetKeyDown(KeyCode.UpArrow)
                || Input.GetKeyDown(KeyCode.DownArrow)
                || Input.GetKeyDown(KeyCode.LeftArrow)
                || Input.GetKeyDown(KeyCode.RightArrow))
            {
                stopMoveTimer = 0;
            }
            if(stopMoveTimer > stopTimeLimit)
            {
                player.ChangeState(new IdleState());
            }
        }
    }
}