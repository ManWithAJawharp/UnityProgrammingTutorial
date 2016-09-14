using UnityEngine;
using System.Collections;

[SerializeField]
struct textureParams
{
    public int textureSize;
    public int rows;
    public int coloms;
}


public class LutImageEffect : MonoBehaviour
{
    [SerializeField]
    private Texture lutTexture;
    [SerializeField]
    private textureParams lutParams;
    private Material effectMaterial;

    void Start()
    {
        //effectMaterial = new Material(Shader.Find("Hidden/LutImageEffectShader"));
        // effectMaterial.SetTexture("_LutTex", make3DLutTexture(lutTexture, lutParams.textureSize, lutParams.rows, lutParams.coloms));
        make3DLutTexture(16,4,8);
    }

    void make3DLutTexture(int texSize, int rows, int coloms)
    {
        //Texture3D tex = new Texture3D(texSize, texSize, (rows * coloms), TextureFormat.RGB24,false);
        //Color[] pixels = new Color[tex.height * tex.width * tex.depth];

        for (int z = 0; z < texSize; z++)
        {
            for (int y = 0; y < texSize; y++)
            {
                for (int x = 0; x < texSize; x++)
                {
                    Debug.Log(x.ToString() + ',' + y.ToString() + ',' + z.ToString());
                }
            }
        }

        //tex.SetPixels(pixels);
        //return tex;
    }

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        //Graphics.Blit(source, destination, effectMaterial);
    }
}
