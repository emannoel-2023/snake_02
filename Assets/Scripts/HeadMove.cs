using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadMove : MonoBehaviour
{
    [SerializeField] Vector2 direction;
    [SerializeField] List<Transform> snakePiecesBody;
    [SerializeField] Transform body;

    GameManager gM;
    AudioController audioController;

    private void Start()
    {
        gM = FindObjectOfType<GameManager>();
        audioController = FindObjectOfType<AudioController>();
        snakePiecesBody = new List<Transform>();
        snakePiecesBody.Add(transform);

        gM.hScore = PlayerPrefs.GetInt("hScore");
        gM.hScoreText.text = "H-score: " + gM.hScore.ToString();
    }
    private void Update()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        float yAxis = Input.GetAxisRaw("Vertical");

        if (xAxis != 0)
        {
            direction = Vector2.right * xAxis;
        }
        if (yAxis != 0)
        {
            direction = Vector2.up * yAxis;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // roda o método 'SairDoJogo()'
            SairDoJogo();
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            // roda o método 'BtnRestartGame()'
            BtnRestartGame();
        }
    }
    private void FixedUpdate()
    {
        for (int i = snakePiecesBody.Count - 1; i > 0; i--)
        {
            snakePiecesBody[i].position = snakePiecesBody[i - 1].position;
        }
        MoveSnake();
    }
    void MoveSnake()
    {
        float roundPosiX = Mathf.Round(transform.position.x);
        float roundPosiY = Mathf.Round(transform.position.y);

        transform.position = new Vector2(roundPosiX + direction.x, roundPosiY + direction.y);
    }
    public void BtnRestartGame()
    {
        gM.startPanel.SetActive(false);
        gM.gameOverPanel.SetActive(false);
        Time.timeScale = 1;
        transform.position = Vector2.zero;
        direction = Vector2.zero;
        audioController.ReiniciarMusica();

        for (int i = 1; i < snakePiecesBody.Count; i++)
        {
            Destroy(snakePiecesBody[i].gameObject);
        }
        snakePiecesBody.Clear();
        snakePiecesBody.Add(transform);

        gM.score = 0;
        gM.ScoreText.text = "Score : 0";

        gM.hScore = PlayerPrefs.GetInt("hScore");
        gM.hScoreText.text = "H-score: " + gM.hScore.ToString();
    }
    public void SairDoJogo()
    {
        // escreve uma mensagem na aba 'Console' para termos certeza de que esse método foi chamado
        Debug.Log("Saiu do jogo");
        // fecha o nosso jogo
        Application.Quit();
    }
    void GrowingSnake()
    {
        Transform SpawnBody = Instantiate(body, snakePiecesBody[snakePiecesBody.Count - 1].position, Quaternion.identity);
        snakePiecesBody.Add(SpawnBody);
        gM.SetScore(10);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.tag)
        {
            case "Food":
                GrowingSnake();
                break;
            case "Obstacle":
                gM.GameOver();
                break;
        }
    }
}
