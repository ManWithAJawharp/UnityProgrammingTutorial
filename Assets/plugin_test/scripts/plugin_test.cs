using UnityEngine;
using System.Collections;
using System.Runtime.InteropServices;

public class plugin_test : MonoBehaviour
{
	[DllImport ("libcpp_library_test")]
	private static extern void Sort(int[] a, int length);

	// Use this for initialization
	void Start ()
	{
		int[] a = new int[] {5, 1, 20, 4, 8, 19};
		Sort (a, a.Length);
		for (int i = 0; i < a.Length; i++)
		{
			Debug.Log(a [i]);
		}
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
