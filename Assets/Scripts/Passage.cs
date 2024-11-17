
using UnityEngine;

public class Passage : MonoBehaviour
{
    public Transform connection;
    private void OnTriggerEnter2D(Collider2D other){
        if (other.CompareTag("PacMan"))
        {
            Vector3 position = other.transform.position;
            position.x = this.connection.position.x;
            position.y = this.connection.position.y;
            other.transform.position = position;
        }
        else if (other.CompareTag("Ghost"))
        {
            Ghost ghost = other.GetComponent<Ghost>();
            if (ghost != null)
            {
                ghost.ReverseDirection();
                Debug.Log($"{ghost.name} foi impedido de usar o teletransporte!");
            }
        }
    }
}
