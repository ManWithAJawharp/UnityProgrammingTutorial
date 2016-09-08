using UnityEngine;
using System.Collections;

public class LottaLeert : MonoBehaviour
{
    [SerializeField]

/*begin variabelen--------------------------------------------------------------------------------------------------------------------------------------------------------*/

   /*declareren(zeggen dat het bestaat)  ->*/ private float  speed /*initialiseren ->*/= 0.05f;

    [SerializeField]
    private Color[] colorArray = { Color.red, Color.green, Color.blue };

    private Renderer renderer;

    float sfpeed;

/*eind variabelen---------------------------------------------------------------------------------------------------------------------------------------------------------*/


/*begin functies (te herkennen aan de haakjes) ---------------------------------------------------------------------------------------------------------------------------*/
    /*datatype, zoals float of int, void heeft eigenlijk geen definitie*/
    void Awake ()
    {
        renderer = GetComponent<Renderer>();
        sfpeed = 0.9845f; /*altijf een 'f' erachter voor games anders eet het teveel geheugen (verschil van 16 of 32 bits)*/
    }


    void Update()
    {
        int kazen = TelKaas(20, 2);
        Debug.Log("Aantal kazen: " + kazen);

        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += 0.5f * Time.deltaTime * Vector3.up;
        }
        
        if (Input.GetKeyDown(KeyCode.A))
        {
           renderer.material.color = new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
        }
        else if (Input.GetKey(KeyCode.B))
        {
            renderer.material.color = Color.black;
        }
    }


    /*Funtie altijd met hoofdletters benoemen. Je moet vertellen wat de computer moet doen wanneer een van de functies wordt aangeroepen*/
    int TelKaas(/*parameters of argumenten (bepaalt wat er van buiten binnen in de functie mee gerekend mag worden*/ int kaasWinkels, int ponieKaas)
    /*Definitie*/
    {
        int kaasPerWinkel = 5 - ponieKaas;
        int totaalKazen = kaasPerWinkel * kaasWinkels;
        return totaalKazen; /*dit is wat er uit komt*/
    }
}
