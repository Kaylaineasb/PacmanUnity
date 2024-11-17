using UnityEngine;
[RequireComponent(typeof(Moviment))]

public class PacMan : MonoBehaviour
{
    public Moviment moviment { get;private set;}

    private void Awake(){
        this.moviment = GetComponent<Moviment>();
    }
    private void Update(){
        if(Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)){
            this.moviment.SetDirection(Vector2.up);
        }
        else if(Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow)){
            this.moviment.SetDirection(Vector2.down);
        }
        else if(Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow)){
            this.moviment.SetDirection(Vector2.left);
        }
        else if(Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow)){
            this.moviment.SetDirection(Vector2.right);
        }
        float angle = Mathf.Atan2(this.moviment.direction.y,this.moviment.direction.x);
        this.transform.rotation = Quaternion.AngleAxis(angle*Mathf.Rad2Deg,Vector3.forward);
    }
    public void ResetState(){
        this.gameObject.SetActive(true);
        this.moviment.ResetState();
    }
}
