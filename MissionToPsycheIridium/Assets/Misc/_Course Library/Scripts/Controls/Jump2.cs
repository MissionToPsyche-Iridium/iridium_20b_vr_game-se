using UnityEngine;
using UnityEngine.InputSystem;

public class Jump2 : MonoBehaviour
{

    public InputActionReference jumpButton = null;
    public CharacterController charController;
    public float jumpHeight;
    private float gravityValue = -9.81f;
    private Vector3 playerVelocity;
    public bool jumpButtonReleased;
    private bool isTouchingGround;

    private bool isPaused = false;
    private Vector3 savedVelocity; // Store velocity

    // Start is called before the first frame update
    void Start()
    {
        jumpButtonReleased = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPaused) return;

        playerVelocity.y += gravityValue * Time.deltaTime;
        charController.Move(playerVelocity * Time.deltaTime);

        if (charController.isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
            isTouchingGround = true;
        }

        float jumpVal = jumpButton.action.ReadValue<float>();
        if (jumpVal > 0 && jumpButtonReleased == true)
        {
            jumpButtonReleased = false;
            Jump();
            isTouchingGround = false;
        }
        else if (jumpVal == 0)
        {
            jumpButtonReleased = true;
        }
    }

    public void Jump()
    {
        if (isTouchingGround == false)
        {
            return;
        }
        GetComponent<AudioSource>().Play();
        playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
    }

    // Called when pausing the game
    public void PauseGame()
    {
        //Freeze player
        isPaused = true;
        savedVelocity = playerVelocity; 
        playerVelocity = Vector3.zero;  
        charController.enabled = false; 
    }

    // Called when resuming the game
    public void ResumeGame()
    {
        //Unfreeze player
        isPaused = false;
        charController.enabled = true; 
        playerVelocity = savedVelocity; 
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag.Equals("plane"))
        {
            this.gameObject.transform.parent = collision.transform;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag.Equals("plane"))
        {
            this.gameObject.transform.parent = null;
        }
    }

}
