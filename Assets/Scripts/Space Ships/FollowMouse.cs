using UnityEngine;

public class FollowMouse : MonoBehaviour
{
    Vector3 mousePosition;
    [SerializeField] private float moveSpeed = 0.3f;
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
        position = Vector2.Lerp(transform.position, mousePosition, moveSpeed);
    }

    private void FixedUpdate()
    {
        rb.MovePosition(position);
    }
}
