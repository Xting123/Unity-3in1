using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class Snake : MonoBehaviour{
    bool ate = false;       // Did the snake eat something?
    public GameObject tailPrefab;       // Tail Prefab
    public static float speed = 0.3f;
    public static bool IsOver = false;

    Vector2 dir = Vector2.right;            //向右移動
    List<Transform> tail = new List<Transform>();       // Keep Track of Tail

    // Start is called before the first frame update
    void Start(){
        InvokeRepeating("Move", speed, speed);        //每300毫秒移動一次
    }

    // Update is called once per frame
    void Update(){
            // Move in a new Direction?
            if ( (Input.GetKey(KeyCode.RightArrow)) || (Input.GetKey(KeyCode.D)) )
                dir = Vector2.right;
            else if ( (Input.GetKey(KeyCode.DownArrow)) || (Input.GetKey(KeyCode.S)) )
                dir = -Vector2.up;          // '-up' means 'down'
            else if ( (Input.GetKey(KeyCode.LeftArrow)) || (Input.GetKey(KeyCode.A)) ) 
                dir = -Vector2.right;       // '-right' means 'left'
            else if ( (Input.GetKey(KeyCode.UpArrow)) || (Input.GetKey(KeyCode.W)) )
                dir = Vector2.up;
    }

    void Move(){
        if (!IsOver)
        {
            // Move head into new direction
            Vector2 v = transform.position;      // Save current position (gap will be here)
            transform.Translate(dir);            // Move head into new direction (now there is a gap)根據一個向量來位移

            // Do we have a Tail?
            if (ate)
            {
                GameObject g = (GameObject)Instantiate(tailPrefab, v, Quaternion.identity);     // Load Prefab into the world
                tail.Insert(0, g.transform);        // Keep track of it in our tail list
                ate = false;        // Reset the flag
            }
            else if (tail.Count > 0)
            {
                tail.Last().position = v;       // Move last Tail Element to where the Head was
                // Add to front of list, remove from the back
                tail.Insert(0, tail.Last());
                tail.RemoveAt(tail.Count - 1);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D coll){
        if ( coll.name.StartsWith("FoodPrefab") ){        // Food?
            ate = true;          // Get longer in next Move call
            Destroy(coll.gameObject);          
        }
        // Collided with Tail or Border
        if( coll.gameObject.CompareTag("Finish") )
        {
            IsOver = true;// ToDo 'You lose' screen
            speed = 0;
            SpawnFood.isover = IsOver;
        }
    }
}
