using UnityEngine;
/// <summary>
/// Simple Movement component.
/// Uses rigidbody to move around.
/// Its receiving input as a direction where it should go.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    // Reference to rigidbody
    private Rigidbody2D rb;
    // Storing input for movement in FixedUpdate
    private Vector2 input;
    // Movement speed
    [SerializeField]
    private float moveSpeed = 10;
    /// <summary>
    /// Initialization of movement.
    /// </summary>
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        rb.gravityScale = 0;
    }
    /// <summary>
    /// Physics Update.
    /// Used to move UFO around.
    /// </summary>
    private void FixedUpdate()
    {
        input *= moveSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + input);
    }
    /// <summary>
    /// Passing direction as input where UFO should fly.
    /// </summary>
    /// <param name="input">Input - direciton.</param>
    public void Move(Vector2 input)
    {
        if (input.magnitude > 1)
        {
            input.Normalize();
        }
        this.input = input;
    }
}