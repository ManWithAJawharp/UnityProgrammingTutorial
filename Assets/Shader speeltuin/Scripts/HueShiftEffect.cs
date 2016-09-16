using UnityEngine;

[ExecuteInEditMode]
public class HueShiftEffect : MonoBehaviour
{
    [SerializeField, Range(0, 2)]
    private float shiftSpeed;
    private Material effectMaterial;

    void Start()
    {
        effectMaterial = new Material(Shader.Find("Hidden/HueImageEffectShader"));
    }

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        effectMaterial.SetFloat("_Speed", shiftSpeed);
        Graphics.Blit(source, destination, effectMaterial);
    }
}
