
using UnityEngine;

public class GhostEyes : MonoBehaviour
{
    public SpriteRenderer spriteRenderer{get;private set;}
    public Moviment moviment {get;private set;}
    public Sprite up;
    public Sprite down;
    public Sprite left;
    public Sprite right;
    

    private void Awake(){
        this.spriteRenderer = GetComponent<SpriteRenderer>();
        this.moviment = GetComponentInParent<Moviment>();
    }
    private void Update(){
        if(this.moviment.direction == Vector2.up){
            this.spriteRenderer.sprite = this.up;
        }
        else if(this.moviment.direction == Vector2.down){
            this.spriteRenderer.sprite = this.down;
        }
        else if(this.moviment.direction == Vector2.left){
            this.spriteRenderer.sprite = this.left;
        }
        else if(this.moviment.direction == Vector2.right){
            this.spriteRenderer.sprite = this.right;
        }

    }
}
