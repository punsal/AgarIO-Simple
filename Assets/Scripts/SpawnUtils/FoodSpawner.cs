using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour {
    #region Food Attributes in Editor
    public Transform foodObject;
    public float spawnSpeed = 2;
    public int foodPoolCapasity = 12;
    #endregion
    private Vector3 Target
    {
        get {
            Vector3 target = Camera.main.ScreenToWorldPoint(
                new Vector3(
                    Random.Range(0, Camera.main.scaledPixelHeight),
                    Random.Range(0, Camera.main.scaledPixelWidth),
                    0));
            target.z = 0;
            return target;
        }
    }
    private Queue<Transform> foodPool;
    // Start is called before the first frame update
    private void Start() {
        foodPool = new Queue<Transform>(12);
        InvokeRepeating("Generate", 0, spawnSpeed);
    }
    public void Generate() {
        if(foodPool.Count <= foodPoolCapasity) {
            var food = Instantiate(
                foodObject,
                Target,
                Quaternion.identity);
            food.SetParent(transform);
            food.gameObject.SetActive(true);
            foodPool.Enqueue(food);
        } else {
            var food = foodPool.Dequeue();
            food.position = Target;
            food.gameObject.SetActive(true);
            foodPool.Enqueue(food);
        }
    }
}
