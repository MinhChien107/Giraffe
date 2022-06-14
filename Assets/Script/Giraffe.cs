using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Giraffe : MonoBehaviour
{
    //constants
    public const float limitXRight = 7f;
    public const float limitXLeft = -6.8f;
    public const float GiraffeY = -7.29f;

    public float moveSpeed = 20;
    private float xDirection;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveGiraffeByHorizontal();
    }

    private void OnMouseDrag()
    {
        moveGiraffeByMouse();
    }

    private void moveGiraffeByHorizontal()
    {
        //Lấy hướng di chuyển
        xDirection = Input.GetAxis("Horizontal");

        float moveStep = moveSpeed * xDirection * Time.deltaTime;

        if ((transform.position.x <= limitXLeft && xDirection < 0) || (transform.position.x >= limitXRight && xDirection > 0)) return;
        
        mirrorGiraffe(xDirection);

        transform.position = transform.position + Vector3.right * moveStep;
    }

    private void moveGiraffeByMouse()
    {
        Vector3 mousePos;
        mousePos = Input.mousePosition;
        mousePos = Camera.main.ScreenToWorldPoint(mousePos);
        
        if ((mousePos.x <= limitXLeft ) || (mousePos.x >= limitXRight )) return;
       
        mirrorGiraffe(mousePos.x);

        gameObject.transform.localPosition = new Vector3((mousePos.x), GiraffeY, 0);

    }


    private void mirrorGiraffe(float xDirection)
    {
        if (xDirection > 0)
        {
            transform.localScale = new Vector3(6f, 6f, 1);
        }
        else if (xDirection < 0)
        {
            transform.localScale = new Vector3(-6f, 6f, 1);
        }

    }
}
