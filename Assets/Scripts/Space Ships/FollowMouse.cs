using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    Vector3 mousePosition;
    [SerializeField] private float moveSpeed = 0.3f;
    [SerializeField] private float minX;
    [SerializeField] private float minY;
    Rigidbody2D rb;
    Vector2 position = new Vector2(0f, 0f);
    Camera mainCamera;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    private void Update()
    {
        mousePosition = Input.mousePosition; //gets position in pixels
        mousePosition = mainCamera.ScreenToWorldPoint(mousePosition); //gets position in world points
        mousePosition.x = Mathf.Clamp(mousePosition.x, minX, -minX); //the difference between max and min       
        mousePosition.y = Mathf.Clamp(mousePosition.y, minY, -minY); //values is the minus        
        position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(position);
    }
}
