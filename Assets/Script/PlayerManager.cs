using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour {

    public float speed;
    private Vector3 vector;
    public int walkCount;
    private int currentWalkCount;

    private Animator animator;
    private BoxCollider2D boxColider;
    public LayerMask layerMask;

    public static bool putin;
    public static PlayerManager instance;

    public string currentSceneName;

    public bool canMove;

    public static int whichpan;

    public Transform carryLocation;// this is empty gameobject as a child of player, object will be carried on this position
    public Transform currentItem = null;

    public Transform Table1;
    public Transform Table2;
    public Transform Table3;
    public Transform Table4;
    public Transform Table5;
    public Transform Table6;

    private int lrKey;
    private int udkey;
    // Use this for initialization
    public Vector3 table;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "pan1"){
            whichpan = 1;
        }
        if (other.gameObject.tag == "pan2")
        {
            whichpan = 2;
        }
        
        if(other.CompareTag("TomatoPasta") )
        {
            if(currentItem == null)
            {
                currentItem = other.transform;
                currentItem.position = carryLocation.position;

                currentItem.parent = transform;
            }
      
        }
        else if (other.CompareTag("CreamPasta"))
        {
            if (currentItem == null)
            {
                currentItem = other.transform;
                currentItem.position = carryLocation.position;

                currentItem.parent = transform;
            }

        }
        else if (other.CompareTag("OilPasta"))
        {
            if (currentItem == null)
            {
                currentItem = other.transform;
                currentItem.position = carryLocation.position;

                currentItem.parent = transform;
            }

        }
      if (other.gameObject.tag == "Table2" && currentItem != null)
            {
                table = new Vector3(22f, 5.6f, 0f);
            }
            else if (other.gameObject.tag == "Table1" && currentItem != null)
            {
                table = new Vector3(15.5f, 5.6f, 0f);
            }
            else if (other.gameObject.tag == "Table3" && currentItem != null)
            {
                table = new Vector3(15.5f, 0.8f, 0f);
            }
            else if (other.gameObject.tag == "Table4" && currentItem != null)
            {
                table = new Vector3(22f, 0.8f, 0f);
            }
            else if (other.gameObject.tag == "Table5" && currentItem != null)
            {
                table = new Vector3(15.5f, -4.0f, 0f);
            }
            else if (other.gameObject.tag == "Table6" && currentItem != null)
            {
                table = new Vector3(22f, -4.0f, 0f);
            }       

         
    }
   
    public void touchtable()
    {
        if (currentItem != null)
        {
            currentItem.parent = null;
            currentItem.position = table;
            currentItem = null;
            putin = true; 
        }
    }

    void Start()
    {
        instance = this;
        boxColider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();

    }

    public void LbuttonDown()
    {
        lrKey = -1;
    }
    public void LbuttonUp()
    {
        lrKey = 0;
    }
    public void RbuttnDown()
    {
        lrKey = 1;
    }
    public void RbuttnUp()
    {
        lrKey = 0;
    }
    public void UbuttonDown()
    {
        udkey = 1;
    }
    public void UbuttonUp()
    {
        udkey = 0;
    }
    public void DbuttonDown()
    {
        udkey = -1;
    }
    public void DbuttonUp()
    {
        udkey = 0;
    }
      public IEnumerator MoveCoroutine()
      {
          while (lrKey != 0 || udkey != 0)
          {
              vector.Set(lrKey, udkey, transform.position.z);

              if (lrKey != 0)
                  udkey = 0;

              animator.SetFloat("DirX", lrKey);
              animator.SetFloat("DirY", udkey);
              RaycastHit2D hit;
              Vector2 start = gameObject.transform.position;
              Vector2 end = start + new Vector2(lrKey * speed * walkCount, udkey * speed * walkCount);

              boxColider.enabled = false;
              hit = Physics2D.Linecast(start, end, layerMask);
              boxColider.enabled = true;

              if (hit.transform != null)
                  break;
              animator.SetBool("Moving", true);

              while (currentWalkCount < walkCount)
              {
                  if (lrKey != 0)
                  {
                      transform.Translate(lrKey * speed, 0, 0);
                  }
                  else if (udkey != 0)
                  {
                      transform.Translate(0, udkey * speed, 0);
                  }
                  currentWalkCount++;
                  yield return new WaitForSeconds(0.01f);
              }
              currentWalkCount = 0;

          }
          animator.SetBool("Moving", false);
          canMove = true;
      }
    // Update is called once per frame
    void Update()
    {
        if (canMove)
        {
            if (udkey != 0 || lrKey != 0)
            {
                canMove = false;
                StartCoroutine(MoveCoroutine());
            }

        }
        // Update is called once per frame
    }
}
