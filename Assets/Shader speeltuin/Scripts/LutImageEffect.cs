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
    private Texture2D lutTexture;
    [SerializeField]
    private textureParams lutParams;
    private Material effectMaterial;
    private Texture3D lut3D;

    void Start()
    {
        lut3D = make3DLutTexture(lutTexture, 16);
        lut3D.Apply(); // dit moet buiten de functie zijn
        effectMaterial = new Material(Shader.Find("Hidden/LutImageEffectShader"));
        effectMaterial.SetTexture("_LutTex", lut3D);
        //effectMaterial.set
        //make3DLutTexture(lutTexture, 16);
    }

    Texture3D make3DLutTexture(Texture2D tex2D, int texsize)
    {
        Texture3D tex = new Texture3D(texsize, texsize, texsize, TextureFormat.RGB24, false);
        Color[] pixels = new Color[texsize * texsize * texsize];

        for (int z = 0; z < texsize; z++)
        {
            for (int y = 0; y < texsize; y++)
            {
                for (int x = 0; x < texsize; x++)
                {
                    // Debug.Log("<>" + x.ToString() + ',' + y.ToString() + ',' + z.ToString());
              
                    pixels[(x + (y * texsize) + (z * texsize * texsize))] = tex2D.GetPixel(x + texsize * y, z);
                    // Debug.Log("index: " + (x + (y * texsize) + (z * texsize * texsize)) + " | " + (x + texsize * y) + "," + z + " | " + tex2D.GetPixel(x + texsize * y, z));
                }
            }
        }

        //.Debug.Log(pixels[200]);
        tex.SetPixels(pixels);
        //Debug.Log(tex.GetPixels()[8 + (8 * 16) + (8 * 16 * 16)]);
        return tex;
    }

    public void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, effectMaterial);
    }
}
