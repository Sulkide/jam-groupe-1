using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Rigidbody rb;
    [SerializeField] private float threshold = 1.0f, speed = 1f;
    private bool backInControl, hitByPlayer;
    
    // IMPORTANT : changer en private quand on aura le vrai player
    public Transform playerTransform;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if(hitByPlayer) backInControl = (rb.linearVelocity.magnitude < threshold);
        if (backInControl) backInControl = hitByPlayer = false;

        if (!hitByPlayer) MoveTowardsPlayer();


        //IMPORTANT : A tej plus tard, debug
        if (Input.GetKeyDown("f"))
        {
            hitByPlayer = true;
            KnockBack((transform.position - playerTransform.position).normalized,50f);
        }
    }

    private void MoveTowardsPlayer()
    {
        if (!playerTransform) return;
        rb.AddForce((playerTransform.position - transform.position).normalized*speed , ForceMode.Force);
    }

    public void KnockBack(Vector3 direction, float strength)
    {
        rb.AddForce(direction* strength, ForceMode.Impulse);
    }
}
