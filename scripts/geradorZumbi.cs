using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class geradorZumbi : MonoBehaviour
{
    public GameObject Zumbi;
    private float contaTempo = 0;
    public float TempoCriar = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        contaTempo += Time.deltaTime;
        if(contaTempo>=TempoCriar)
        {
            Instantiate(Zumbi,transform.position,transform.rotation);
            contaTempo = 0;
        }
    }
}
