using UnityEngine;
using System.Collections;

public class SmallGuyController : MonoBehaviour
{
    public float speed;
    public GameObject bulletPrefab;
    public float bulletSpeed;
    private bool touchingDoor = false;
    public bool onGround = false;
    Vector2 lookDirection = Vector2.zero;
    void Start()
    {

    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        lookDirection = (mousePos - (Vector2)transform.position).normalized;
        transform.right = lookDirection;
    }
    void FixedUpdate()
    {
        Rigidbody2D rgbody = GetComponent<Rigidbody2D>();
        Vector3 velocity = Vector3.zero;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (onGround) velocity += Vector3.up * speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            velocity += Vector3.left * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            velocity += Vector3.right * speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (touchingDoor)
            {

            }
        }
        rgbody.velocity = velocity;
        if (Input.GetMouseButtonDown(0))
        {
            GameObject newBullet = Instantiate(bulletPrefab);
            newBullet.transform.rotation = this.transform.rotation;
            newBullet.GetComponent<Rigidbody2D>().velocity = (bulletSpeed + speed) * lookDirection;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
		if (other.gameObject.CompareTag ("floor"))
			onGround = true;
		if (other.gameObject.CompareTag ("door"))
			touchingDoor = true;
	}
    void OnTriggerExit2D(Collider2D other)
    {
		if (other.gameObject.CompareTag ("floor"))
			onGround = false;
    }
}
