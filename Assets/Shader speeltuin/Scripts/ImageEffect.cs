using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ImageEffect : MonoBehaviour
{
    [SerializeField, Range(0f, 0.3f)]
    private float distortionPower = 0;
    [SerializeField]
    private Texture distortionTexture;
    [SerializeField]
    private Vector2 distortionOffset;
    [SerializeField]
    private Vector2 distortionScale = Vector2.one;
    private Material effectMaterial;

    void Start()
    {
        effectMaterial = new Material(Shader.Find("Hidden/DistortionImageEffectShader"));
        effectMaterial.SetTexture("_DistortionTex", distortionTexture);
    }

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        effectMaterial.SetFloat("_Weirdness", distortionPower);
        effectMaterial.SetTextureOffset("_DistortionTex",distortionOffset);
        effectMaterial.SetTextureScale("_DistortionTex",distortionScale);
        Graphics.Blit(source, destination, effectMaterial);
    }
}
