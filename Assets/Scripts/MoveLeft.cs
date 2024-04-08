using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float speed;
    private PlayerController plControllerScript;
    // Start is called before the first frame update
    void Start()
    {
        plControllerScript = GameObject.Find("MyPlayer").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!plControllerScript.gameOver)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }

        if (gameObject.CompareTag("Obst") && gameObject.transform.position.x < -15)
        {
            Destroy(gameObject);
        }
    }
}
