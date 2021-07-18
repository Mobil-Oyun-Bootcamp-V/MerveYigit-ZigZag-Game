using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
   
    [SerializeField] private float speed;
    [SerializeField] private float ballAccelerate;
    [SerializeField] private float fallDealy = 3f;
    [SerializeField] private bool isDead = false;

    //public Animator gameOverAnim;

    Vector3 direction;
    public static bool ballDrop;
    public Spawner spawnerScript;
    

    private void Start()
    {
        direction = Vector3.forward;
        ballDrop = false;
    }


    void Update()
    {
        if(transform.position.y<=0.5f)
        {
            ballDrop = true;
            isDead = true;
             //Debug.Log("Öldü");
            GameManager.instance.GameOver();

        }
        if (ballDrop==true)
        {
            return;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (direction.x==0)
            {
                direction = Vector3.left;
            }
            else
            {
                direction = Vector3.forward;
            }
        }

        speed = speed + ballAccelerate * Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Vector3 movement = direction * Time.deltaTime * speed;
        transform.position += movement;
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag=="Path")
        {
            GameManager.instance.score++;
            collision.gameObject.AddComponent<Rigidbody>();
            spawnerScript.PathGeneration();
            StartCoroutine(PathRemove(collision.gameObject));
        }

    }

    private void OnTriggerEnter(Collider other) //diamond creation
    {
        CollectDiamond collectDiamond = other.GetComponent<CollectDiamond>();
        if (collectDiamond)
        {
            GameManager.instance.CollectDiamond();
            Destroy(other.gameObject);
        }
    }

    IEnumerator PathRemove(GameObject pathremove) //Removing the created path
    {
        yield return new WaitForSeconds(fallDealy);
        Destroy(pathremove);
    }
}
