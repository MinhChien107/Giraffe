using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private GameController gameController;

    private void Start()
    {
        gameController = FindObjectOfType<GameController>();
    }

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GiraffeParent"))
        {
            gameController.incrementScore();
            gameController.incrementHeight();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("DeathZone"))
        {
            Animator animator = gameObject.GetComponent<Animator>();
            animator.enabled = true;
            gameController.IsStatusGame = true;
        }
    }
}
