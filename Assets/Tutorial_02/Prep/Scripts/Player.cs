using UnityEngine;
using System.Collections;

namespace Tutorial_02
{
	public class Player : MonoBehaviour
    {
		public delegate void StateDelegate(int newState, int oldState);
		public static event StateDelegate onStateChanged;

        public void Pickup()
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}