using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Fighter
{
    [SerializeField] private DialogueUI dialogueUI;
    
    private Vector3 moveDelta;
    private RaycastHit2D hit;
    
    private enum MovementState { idle, walking, down}
    public DialogueUI DialogueUI => dialogueUI;

    public Interactable interactable { get; set; }
    private void FixedUpdate()
    {
        if (dialogueUI.IsOpen) return;
        
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        //reset moveDelta 
        moveDelta = new Vector3(x,y,0);

        //swap sprite direction, whether you're going right or left
        if (moveDelta.x > 0)
            transform.localScale = Vector3.one;
        else if (moveDelta.x < 0)
            transform.localScale = new Vector3(-1, 1, 1);

        //add push vector, if any
        moveDelta += pushDirection;

        //reduce push force every time, based off recovery speed
        pushDirection = Vector3.Lerp(pushDirection, Vector3.zero, pushRecoverySpeed);

        //make sure we can move in this direction, by casting a box there first, if the box returns null, we're free to move
        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(0, moveDelta.y), Mathf.Abs(moveDelta.y * Time.deltaTime), LayerMask.GetMask("Player", "Blocking")); 
        if(hit.collider == null)
        { 
            // player movement
            transform.Translate(0, moveDelta.y * Time.deltaTime, 0);
        }

        hit = Physics2D.BoxCast(transform.position, boxCollider.size, 0, new Vector2(moveDelta.x,0), Mathf.Abs(moveDelta.x * Time.deltaTime), LayerMask.GetMask("Player", "Blocking"));
        if (hit.collider == null)
        {
            // player movement
            transform.Translate(moveDelta.x * Time.deltaTime, 0, 0);
        }

        UpdateAnimationState();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interactable?.interact(this);
        }
    }

    private void UpdateAnimationState()
    {
        MovementState state;

        if (moveDelta.x > 0f)
        {
            state = MovementState.walking;
        }
        else if (moveDelta.x < 0f)
        {
            state = MovementState.walking;
        }
        else if (moveDelta.y < 0f)
        {
            state = MovementState.down;
        }
        else if (moveDelta.y > 0f)
        {
            state = MovementState.down;
        }
        else
        {
            state = MovementState.idle;
        }
        anim.SetInteger("state", (int)state);
    }
}
