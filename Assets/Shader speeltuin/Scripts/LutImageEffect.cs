using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class LutImageEffect : MonoBehaviour
{
    [SerializeField]
    private Texture lutTexture;
    private Material effectMaterial;

    void Start()
    {
        effectMaterial = new Material(Shader.Find("Hidden/LutImageEffectShader"));
        effectMaterial.SetTexture("_LutTex", lutTexture);
    }

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, effectMaterial);
    }
}
