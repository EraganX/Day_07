using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float rotationSpeed = 100f;

    public bool isGameOver = false;

    [SerializeField] private Animator animator;


    void Update()
    {
        if (isGameOver) return;

        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");


        Vector3 move = new Vector3(moveX, 0f, moveZ).normalized;

        if (move.magnitude > 0f)
        {
            Vector3 targetDirection = move.normalized;

            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetDirection), rotationSpeed * Time.deltaTime);

            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            GameManager.instance.UpdateCoins();
        }
    }
}
