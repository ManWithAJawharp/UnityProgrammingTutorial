using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class ImageEffect : MonoBehaviour
{
    [SerializeField]
    private Material effectMaterial;

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, effectMaterial);
    }
}
