using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
public class MoveController : MonoBehaviour
{

    public GameObject gameCanvas, pauseCanvas, currentScore;
    public AudioSource jumpSource;
    public Logic logic;
    public Text currentScoreText;
    public ObjectSpawner spawner;

    private Rigidbody2D rb;
    private Animator animator;

    private bool doubleJump = false;

    void Start()
    {
        this.animator = this.GetComponent<Animator>();
        this.rb = this.GetComponent<Rigidbody2D>();
        this.rb.freezeRotation = true;
    }

    private void fixPosition()
    {
        if(Physics2D.RaycastAll(this.gameObject.transform.position, Vector2.right, 0.2f).Length >= 2) {
            Vector3 vector = this.transform.position;
            vector.x -= 0.4f;
            this.transform.position = vector;
        }
    }

    public void move(Vector3 vector)
    {

        if (vector == Vector3.up)
        {
            if (isGrounded())
            {
                if (this.doubleJump) this.doubleJump = false;
                this.animator.Play("Jump", -1);
                this.fixPosition();
                this.rb.AddForce(new Vector2(0, 4.5f), ForceMode2D.Impulse);
                if(this.jumpSource.enabled) this.jumpSource.Play();
            }
            else
            {
                if (this.doubleJump) return;
                this.doubleJump = true;
                this.animator.Play("Jump", -1);
                this.fixPosition();
                this.rb.AddForce(new Vector2(0, 4.5f), ForceMode2D.Impulse);
                if (this.jumpSource.enabled) this.jumpSource.Play();
            }

        } else if(vector == Vector3.down)
        {
            this.rb.AddForce(new Vector2(0, -6f), ForceMode2D.Impulse);
        }
        else
        {
            this.gameObject.transform.localScale = vector == Vector3.right ? new Vector3(0.5f, 0.5f, 0) : new Vector3(-0.5f, 0.5f, 0);
            if (this.isGrounded())
            {
                this.animator.Play("Walk", -1);
            }
            this.transform.position += vector * 0.1f;
        }
    }

    private bool isGrounded()
    {
        return Physics2D.RaycastAll(this.gameObject.transform.position, Vector2.down, 1).Length >= 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Finish")
        {
            this.spawner.stop();
            this.gameCanvas.SetActive(false);
            this.pauseCanvas.SetActive(true);
            this.currentScoreText.text = Logic.userData.currentScore.ToString();

            if(Logic.userData.currentScore > Logic.userData.hightScore)
            {
                Logic.userData.hightScore = Logic.userData.currentScore;
                this.logic.bestScoreText.text = Logic.userData.hightScore.ToString();
                DataSystem.save(Logic.userData);
            }
            Logic.userData.currentScore = 0;
            this.currentScore.SetActive(true);
            this.gameObject.SetActive(false);
        }
    }

}
