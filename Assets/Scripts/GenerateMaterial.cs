using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMaterial : MonoBehaviour
{
    private Material[] materials;

    // Start is called before the first frame update
    void Start()
    {
        //Take materials from 
        materials = Resources.LoadAll<Material>("Materials/" + transform.parent.tag);
        Material randomMaterial = materials[Random.Range(0, materials.Length)];

        GetComponent<Renderer>().material = randomMaterial; 
    }
}
