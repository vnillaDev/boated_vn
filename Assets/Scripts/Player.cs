using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private float runSpeed = 4f;
    [SerializeField] private GameInput gameInput;


    private GameObject currentCharacterModel;
    private float rotationSpeed = 10f;
    private bool isWalking;
    private bool isRunning;


    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();
        Vector3 moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);

        isRunning = gameInput.IsRunning();
        isWalking = inputVector.magnitude > 0;

        float currentSpeed = isRunning ? runSpeed : moveSpeed;
        Vector3 movement = moveDirection * currentSpeed;

        transform.position += movement * Time.deltaTime;

        if (moveDirection != Vector3.zero)
        {
            transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);
        }
    }



    public bool IsWalking()
    {
        return isWalking;
    }


    public bool IsRunning()
    {
        return isRunning;
    }
}
