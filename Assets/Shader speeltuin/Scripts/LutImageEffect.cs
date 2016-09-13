using UnityEngine;
using System.Collections;

[SerializeField]
struct textureParams
{
    public int textureSize;
    public int rows;
    public int coloms;
}

[ExecuteInEditMode]
public class LutImageEffect : MonoBehaviour
{
    [SerializeField]
    private Texture lutTexture;
    [SerializeField]
    private textureParams lutParams;
    private Material effectMaterial;

    void Start()
    {
        effectMaterial = new Material(Shader.Find("Hidden/LutImageEffectShader"));
        effectMaterial.SetTexture("_LutTex", make3DLutTexture(lutTexture, lutParams.textureSize, lutParams.rows, lutParams.coloms));
    }

    Texture3D make3DLutTexture(Texture Texture,int texSize, int rows, int coloms)
    {
        Texture3D tex = new Texture3D(texSize, texSize, (rows * coloms), TextureFormat.RGBAFloat,false);
        //Color[]
    }

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, effectMaterial);
    }
}
