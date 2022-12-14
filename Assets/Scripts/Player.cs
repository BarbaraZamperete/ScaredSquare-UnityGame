using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private Rigidbody2D player;
    private float movePlayer;
    public float speed,jumpForce, alturaCamera, speedWin;
    private bool jump, isGrounded, restartPlayer, win;
    private GameObject cameraPos, inicialPoint, score;
    public GameObject panelWin;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        inicialPoint = GameObject.Find("InicialPoint");
        cameraPos = GameObject.Find("Main Camera");
        score = GameObject.Find("Score");

        win = false;
        // isGrounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        print(win);
        movePlayer = Input.GetAxis("Horizontal");
        jump = Input.GetButtonDown("Jump");
        cameraPos.transform.position = new Vector3(cameraPos.transform.position.x, player.transform.position.y+alturaCamera, cameraPos.transform.position.z);
        score.transform.position = new Vector2(score.transform.position.x, score.transform.position.y);
        player.velocity = new Vector2(movePlayer * speed, player.velocity.y);

        if(jump && isGrounded){
            player.AddForce(new Vector2(0,jumpForce));
            isGrounded = false;
        }

        RestartPlayer();
        WinGame();
    }

    private void OnCollisionEnter2D(Collision2D col){
        if(col.gameObject.layer == 8){
            isGrounded = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D col){

        if(col.CompareTag("armadilhas") == true){
            restartPlayer=true;
        }

        if(col.CompareTag("win") == true){
            win = true;
        }
        
    }

    private void RestartPlayer(){
        if(restartPlayer == true){
            player.transform.position = new Vector2(inicialPoint.transform.position.x, inicialPoint.transform.position.y);
            restartPlayer = false;
        }
    }

    private void WinGame(){
        if(win == true){
            coinsScript.save = true;
            player.velocity = new Vector2(0,0);
            // player.transform.position = new Vector2(0,0);
            panelWin.transform.position =  Vector2.MoveTowards(panelWin.transform.position, cameraPos.transform.position, speedWin * Time.deltaTime);
            timer.stopTime=true;
        }
    }
}
