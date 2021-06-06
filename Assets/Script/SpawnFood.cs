using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour
{
    public GameObject foodPrefab;
    //borders,Transform可調position
    public Transform borderTop;
    public Transform borderBottom;
    public Transform borderLeft;
    public Transform borderRight;
    public static bool isover = Snake.IsOver;

    // Start is called before the first frame update
    // Use this for initialization
    void Start()
    {
        if (!isover) 
        {
            // Spawn food every 4 seconds, starting in 3
            InvokeRepeating("Spawn", 3, 4);     //(函數名,第1次調用時間,間格調用時間)
        }
    }

    // Spawn one piece of food
    void Spawn()
    {
            int x = (int)Random.Range(borderLeft.position.x, borderRight.position.x);       // x position between left & right border
            int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);       // y position between top & bottom border
            // Instantiate the food at (x, y)
            Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity); // default rotation
    }

    void Update()
    {
        if (isover)
        {
            CancelInvoke();
        }
    }
}

