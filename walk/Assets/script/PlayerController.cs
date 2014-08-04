using UnityEngine;

public class PlayerController : MonoBehaviour {
    private static float SpeedFactor = 0.05f;
 
    private Animator animator;
 	private Direction direction;
 	private bool moving;
 
    void Start() {
        animator = this.GetComponent<Animator>();
        direction = Direction.South;
        moving = false;
    }
 
    void Update() {
        var vertical = Input.GetAxis("Vertical");
        var horizontal = Input.GetAxis("Horizontal");
		if (Mathf.Abs(vertical) < 1e-3 && Mathf.Abs(horizontal) < 1e-3) {
			moving = false;
			animator.enabled = false;
			//GetComponent<SpriteRenderer>().sprite.name = "professor_walk_cycle_no_hat_0";
			return;
		}
		
        if (vertical > 0) {
			direction = Direction.North;
        } else if (vertical < 0) {
        	direction = Direction.South;
        } else if (horizontal > 0) {
        	direction = Direction.East;
        } else if (horizontal < 0) {
        	direction = Direction.West;
        }
		
		moving = true;
        animator.enabled = true;
        animator.SetInteger("Direction", (int)direction);
    }
    
    void FixedUpdate() {
 		if (!moving) {
 			return;
 		}
 		
    	Vector3 distance = Vector3.zero;
    	if (direction == Direction.South) {
    		distance = -Vector3.up;
    	} else if (direction == Direction.West) {
    		distance = -Vector3.right;
    	} else if (direction == Direction.North) {
    		distance = Vector3.up;
    	} else if (direction == Direction.East) {
    		distance = Vector3.right;
    	}
    	transform.localPosition += distance * SpeedFactor;
    }
    
    public enum Direction {
    	South = 0,
    	West = 1,
    	North = 2,
    	East = 3
    }
}
