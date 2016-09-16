using UnityEngine;

[ExecuteInEditMode]
public class LutImageEffect : MonoBehaviour
{
    [SerializeField]
    private Texture2D lutTexture;
    private Material effectMaterial;
    private Texture3D lut3D;
    [SerializeField]
    private bool rebuild = false;

    void Start()
    {
        lut3D = make3DLutTexture(lutTexture, 16);
        effectMaterial = new Material(Shader.Find("Hidden/LutImageEffectShader"));
        effectMaterial.SetTexture("_LutTex", lut3D);
        effectMaterial.SetFloat("_LutSize", 16);
    }

    Texture3D make3DLutTexture(Texture2D tex2D, int texsize)
    {
        Texture3D tex = new Texture3D(texsize, texsize, texsize, TextureFormat.RGBA32, false);
        Color[] pixels = new Color[texsize * texsize * texsize];

        for (int z = 0; z < texsize; z++)
        {
            Color[] block = tex2D.GetPixels(0 + (texsize * z), 0, texsize, texsize);
            for (int i = 0; i < block.Length; i++)
            {
                pixels[(texsize * texsize * z) + i] = block[i];
            }
        }

        tex.SetPixels(pixels);
        tex.Apply();
        rebuild = false;
        return tex;
    }

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        if (rebuild)
        {
            lut3D = make3DLutTexture(lutTexture, 16);
            effectMaterial.SetTexture("_LutTex", lut3D);
        }
            
        Graphics.Blit(source, destination, effectMaterial);
    }
}
