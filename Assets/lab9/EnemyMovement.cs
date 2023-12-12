using UnityEngine.SceneManagement;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;
    public float runSpeed = 2f;
    public GameObject target1;
    public GameObject target2;
    public GameObject player;
    private GameObject currentTarget;
    private bool followingPlayer = false;

    void Start()
    {
        currentTarget = target1;
    }

    void Update()
    { 
        if (isPlayerInDangerArea() && (Mathf.Abs(player.transform.position.y - transform.position.y) < 1f))
        {
            followingPlayer = true;
        }
        else
        {
            followingPlayer = false;
        }
        if (followingPlayer)
        {
            if (Vector2.Distance(transform.position, player.transform.position) < 2f)
            {
                animator.SetFloat("Speed", 0f);
            }
            else
            {
                animator.SetFloat("Speed", 1f);
                transform.position = Vector2.MoveTowards(transform.position, player.transform.position, runSpeed * Time.deltaTime);
            }
        }
        else
        {
            if (Vector2.Distance(transform.position, currentTarget.transform.position) < 0.1f)
            {
                animator.SetFloat("Speed", 1f);
                currentTarget = (currentTarget == target1) ? target2 : target1;
            }
            transform.position = Vector2.MoveTowards(transform.position, currentTarget.transform.position, runSpeed * Time.deltaTime);
        }
    }

    bool isPlayerInDangerArea()
    {
        float playerPos = player.transform.position.x;
        float target1Pos = target1.transform.position.x;
        float target2Pos = target2.transform.position.x;

        return (playerPos > Mathf.Min(target1Pos, target2Pos) && playerPos < Mathf.Max(target1Pos, target2Pos));
    }
}