using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Ghost[] ghosts;
    public PacMan pacman;
    public  Transform pellets;
    public int ghostMultiplier{get;private set;} =1;
    public int score{get;private set;}
    public int lives{get;private set;}
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public TextMeshProUGUI messageText;
    private void Start(){
        NewGame();
    }
    private void Update(){
        if(this.lives<=0 && Input.anyKeyDown){
            NewGame();
        }
    }
    private void NewGame(){
        HideMessage();
        SetScore(0);
        SetLives(3);
        NewRound();
    }
    private void NewRound()
    {
        foreach(Transform pellet in this.pellets){
            pellet.gameObject.SetActive(true);
        }
        ResetState();
    }
    private void ResetState(){
        ResetGhostMultiplier();
        for(int i=0; i<this.ghosts.Length;i++){
           this.ghosts[i].ResetState(); 
        }
        this.pacman.ResetState();
    }
    private void GameOver(){
        for(int i=0; i<this.ghosts.Length;i++){
           this.ghosts[i].gameObject.SetActive(false); 
        }
        this.pacman.gameObject.SetActive(false);
        ShowMessage("Game Over");
    }
    private void SetScore(int score){
       this.score = score; 
       scoreText.text = "Score: " + this.score;
    }
    private void SetLives(int lives){
        this.lives = lives;
        livesText.text = "Lives: "+this.lives;
    }
    public void GhostEaten(Ghost ghost){
        int points = ghost.points*this.ghostMultiplier;
        SetScore(this.score+ points);
        this.ghostMultiplier++;
    }
    public void PacmanEaten(){
        this.pacman.gameObject.SetActive(false);
        SetLives(this.lives-1);
        if(this.lives>0){
            Invoke(nameof(ResetState),3.0f);
        }else{
            GameOver();
        }
    }

    public void PelletEaten(Pellet pellet){
        pellet.gameObject.SetActive(false);
        SetScore(this.score+pellet.points);
        if(!HasRemainingPellets()){
            this.pacman.gameObject.SetActive(false);
            ShowMessage("You Win!");
            Invoke(nameof(NewRound),3.0f);
        }
    }
    public void PowerPelletEaten(PowerPellet pellet){

        for(int i=0;i<this.ghosts.Length;i++){
            this.ghosts[i].frightened.Enable(pellet.duration);
        }
        PelletEaten(pellet);
        CancelInvoke();
        Invoke(nameof(ResetGhostMultiplier),pellet.duration);
    }
    private bool HasRemainingPellets(){
        foreach(Transform pellet in this.pellets){
            if(pellet.gameObject.activeSelf){
                return true;
            }
        }
        return false;
    }

    private void ResetGhostMultiplier(){
        this.ghostMultiplier =1;
    }

    private void ShowMessage(string message) {
        messageText.text = message;
        messageText.gameObject.SetActive(true);
    }

    private void HideMessage() {
        messageText.text = "";
        messageText.gameObject.SetActive(false);
    }

}
