using UnityEngine;
using System.Collections;

namespace Tutorial_02
{
    public class Player : MonoBehaviour
    {
        public void Pickup()
        {
            GetComponent<Renderer>().material.color = Color.red;
        }
    }
}