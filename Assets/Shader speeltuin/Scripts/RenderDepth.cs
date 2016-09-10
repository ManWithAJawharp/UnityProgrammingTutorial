using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class RenderDepth : MonoBehaviour {

	// Use this for initialization
	void Awake()
    {
        GetComponent<Camera>().depthTextureMode = DepthTextureMode.DepthNormals;
    }
}
