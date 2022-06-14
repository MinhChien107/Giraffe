using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject item;
    public GameObject giraffe;
    private SpriteRenderer sp;
    private float spawnTimer = 0f;
    public float spawnDelay = 5f;
    public UIControler controllerUI;
    private int score;
    private bool isStatusGame;
    private float height = 1.12f;
    public int Score { get => score; set => score = value; }
    public bool IsStatusGame { get => isStatusGame; set => isStatusGame = value; }
    public void incrementScore()
    {
        score++;
        controllerUI.setScoreText("Score: " + score);
    }
    public void incrementHeight()
    {
        height += 0.20f;
        sp.size = new Vector2(0.54f , height);
    }

    public bool isGameOver()
    {
        return isStatusGame;
    }

    public void spawnItem()
    {   
        if (item)
        {

            //Level 1
            int type = 5;
            switch (type)
            {
                case 1:
                    {
                        //Giữa lệch trái 
                        Instantiate(item, new Vector3(0, 18), Quaternion.identity);
                        Instantiate(item, new Vector3(-3, 21), Quaternion.identity);
                        Instantiate(item, new Vector3(-6, 24), Quaternion.identity);
                        Instantiate(item, new Vector3(-3, 27), Quaternion.identity);
                        Instantiate(item, new Vector3(0, 31), Quaternion.identity);
                        Instantiate(item, new Vector3(3, 34), Quaternion.identity);
                        Instantiate(item, new Vector3(6, 37), Quaternion.identity);
                        break;
                    } 
                case 2:
                    {
                        //Lệch trái thiếu 1 cái 
                        Instantiate(item, new Vector3(0, 18), Quaternion.identity);
                        Instantiate(item, new Vector3(-3, 21), Quaternion.identity);
                        Instantiate(item, new Vector3(-6, 24), Quaternion.identity);
                        Instantiate(item, new Vector3(-3, 27), Quaternion.identity);
                        Instantiate(item, new Vector3(0, 31), Quaternion.identity);
                        Instantiate(item, new Vector3(3, 34), Quaternion.identity);
                        break;
                    }
                case 3:
                    {
                        //Giữa lệch phải
                        Instantiate(item, new Vector3(0, 18), Quaternion.identity);
                        Instantiate(item, new Vector3(3, 21), Quaternion.identity);
                        Instantiate(item, new Vector3(6, 24), Quaternion.identity);
                        Instantiate(item, new Vector3(3, 27), Quaternion.identity);
                        Instantiate(item, new Vector3(0, 31), Quaternion.identity);
                        Instantiate(item, new Vector3(-3, 34), Quaternion.identity);
                        Instantiate(item, new Vector3(-6, 37), Quaternion.identity);
                        break;
                    }
                case 4:
                    {
                        //Lệch phải thiếu 1 cái
                        Instantiate(item, new Vector3(0, 18), Quaternion.identity);
                        Instantiate(item, new Vector3(3, 21), Quaternion.identity);
                        Instantiate(item, new Vector3(6, 24), Quaternion.identity);
                        Instantiate(item, new Vector3(3, 27), Quaternion.identity);
                        Instantiate(item, new Vector3(0, 31), Quaternion.identity);
                        Instantiate(item, new Vector3(-3, 34), Quaternion.identity);
                        break;
                    }
                case 5:
                    {
                        //Thẳng hàng dọc
                        float yDirection = 18;
                        float xDirection = Random.Range(-6, 6);
                        for (int i = 0; i < 9; i++)
                        {
                            Instantiate(item, new Vector3(xDirection, yDirection += 2), Quaternion.identity);
                        }
                        break;
                    }
                default:
                    break;
            }

            //Level 2: Làm sau
            
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0;
        controllerUI = FindObjectOfType<UIControler>();
        controllerUI.setScoreText("Score: 0");
        sp = giraffe.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isStatusGame)
        {
            spawnTimer = 0;
            controllerUI.showGameOverPanel(true);
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Item"))
            {
                obj.transform.Translate(Vector3.down * 0 );
            }
            return;
        }

        foreach (GameObject obj  in GameObject.FindGameObjectsWithTag("Item")) 
        {
            obj.transform.Translate(Vector3.down * 9.5f * Time.deltaTime);
        }

        spawnTimer -= Time.deltaTime;
        
        if (spawnTimer <= 0)
        {
            spawnItem();
            spawnTimer = spawnDelay;
        }
    }
}
