using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    public Transform food;
    public float spawnSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Generate", 0, spawnSpeed);
    }

    private void Generate()
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(
            new Vector3(
                Random.Range(0, Camera.main.scaledPixelHeight * 2),
                Random.Range(0, Camera.main.scaledPixelWidth * 2),
                0));
        target.z = 0;

        Instantiate(food, target, Quaternion.identity);
    }
}
