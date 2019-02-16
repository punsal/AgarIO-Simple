using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {
    #region Food Attributes in Editor
    public Transform foodObject;
    public float spawnSpeed = 2;
    public int foodPoolCapasity = 12;
    #endregion
    #region Singleton Attributes
    private static FoodSpawner instance;
    public static FoodSpawner Instance
    {
        get {
            if(instance == null) {
                instance = new FoodSpawner();
            }
            return instance;
        }
    }
    #endregion
    private Vector3 Target
    {
        get {
            Vector3 target = Camera.main.ScreenToWorldPoint(
                new Vector3(
                    Random.Range(0, Camera.main.scaledPixelHeight * 2),
                    Random.Range(0, Camera.main.scaledPixelWidth * 2),
                    0));
            target.z = 0;
            return target;
        }
    }
    private Queue<Transform> foodPool;

    //private Constructor
    private FoodSpawner() {
        //Empty
    }

    // Start is called before the first frame update
    private void Start() {
        Instance.foodPool = new Queue<Transform>(12);
        Instance.InvokeRepeating("Generate", 0, spawnSpeed);
    }

    public void Generate() {
        if(Instance.foodPool.Count <= Instance.foodPoolCapasity) {
            Transform food = Instantiate(
                Instance.foodObject,
                Instance.Target,
                Quaternion.identity);
            Instance.foodPool.Enqueue(food);
        } else {
            Transform food = Instance.foodPool.Dequeue();
            food.position = Instance.Target;
            Instance.foodPool.Enqueue(food);
        }
    }
}
