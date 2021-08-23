using UnityEngine;

public class Player : MonoBehaviour
{
    public int moveSpeed;
    public Animator animator;
    
    void Update()
    {
        var move = Input.GetAxis("Horizontal");
        transform.position += new Vector3(move, 0, 0) * Time.deltaTime * moveSpeed;

        animator.SetFloat("Speed", Mathf.Abs(move)); 

        Vector3 charFace = transform.localScale;
        if (Input.GetAxis("Horizontal") < 0)
        {
            charFace.x = -5;
        }
        if (Input.GetAxis("Horizontal") > 0)
        {
            charFace.x = 5;
        }
        transform.localScale = charFace;
    }
}