using UnityEngine;
using System.Collections;

namespace Tutorial_02
{
    public class Pickup : MonoBehaviour
    {
        private enum State
        {
            Idle, Excited, Action
        }

        private Transform avatar;
        private State currentState;
        private float state_t;

        protected void Awake()
        {
            avatar = transform.GetChild(0);
            currentState = State.Idle;
            state_t = 0.0f;
        }

        protected void Update()
        {
            switch (currentState)
            {
                case State.Idle:
                    avatar.position = 0.3f * Mathf.Sin(Time.time) * Vector3.up;
                    avatar.eulerAngles = 20.0f * Time.time * Vector3.up;
                    break;
                case State.Excited:
                    avatar.position = 0.3f * Mathf.Abs(Mathf.Sin(4f * Time.time)) * Vector3.up;
                    avatar.eulerAngles = 80.0f * Time.time * Vector3.up;

                    break;
                case State.Action:
                    avatar.position = 2.0f * state_t * Vector3.up;
                    avatar.eulerAngles = 60.0f * Time.time * Vector3.up;
                    avatar.localScale = 5f * (0.2f - state_t) * Vector3.one;

                    if (state_t > 0.2f)
                    {
                        Destroy(gameObject);
                    }

                    break;
            }

            state_t += Time.deltaTime;
        }

        protected void OnTriggerEnter(Collider col)
        {
            if (col.tag == "Player")
            {
                col.GetComponent<Player>().Pickup();
                SetState(State.Action);
            }
        }

        private void SetState(State newState)
        {
            State oldState = currentState;
            currentState = newState;
            state_t = 0.0f;
        }
    }
}