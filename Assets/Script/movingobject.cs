using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingobject : MonoBehaviour {

    private BoxCollider2D boxColider;
    public LayerMask layerMask;     //충돌할 때 통과불가능한 레이어
    public float speed = 1.5f;
    private Vector3 target;
    private Animator animator;
    public Vector3 direction = new Vector3();
    public Vector3 position = new Vector3();

    void Start()
    {
        boxColider = GetComponent<BoxCollider2D>();
        animator = gameObject.GetComponent<Animator>();
        //target = transform.position;
    }

    void Update()
    {
        position = gameObject.transform.position;
       // animator.SetFloat("DirX", target.x);
        //animator.SetFloat("DIrY", target.y);

        if (Input.GetMouseButtonDown(0))
        {
            
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
      
        if(target != Vector3.zero && (target-position).magnitude >= .06)
        {
      //     direction = (target - position).normalized;
      //     gameObject.transform.position += direction * speed * Time.deltaTime;
            
     //     animator.SetFloat("DirX", direction.x);
     //     animator.SetFloat("DirY", direction.y);

            RaycastHit2D hit;
            Vector2 start = gameObject.transform.position;
            Vector2 end = start+ new Vector2(direction.x*speed*Time.deltaTime,direction.y*speed*Time.deltaTime);

            boxColider.enabled = false;
            hit = Physics2D.Linecast(start, end, layerMask);
            boxColider.enabled = true;


            if (hit.collider == null)
            {
                direction = (target - position).normalized;
                gameObject.transform.position += direction * speed * Time.deltaTime;

                animator.SetFloat("DirX", direction.x);
                animator.SetFloat("DirY", direction.y);
                animator.SetBool("Moving", true);


            }
            else if (hit.collider != null)
            {
                animator.SetBool("Moving", false);
                target = position = gameObject.transform.position;
                animator.SetBool("Moving", true);

            }
        }//animator.SetBool("Moving", true);
        //transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        else
        {
            direction = Vector3.zero;
            animator.SetBool("Moving", false);
        }
        
    }    
}
