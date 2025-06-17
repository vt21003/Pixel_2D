using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int diem = 0;
    [SerializeField] private TextMeshProUGUI diemText;
    [SerializeField] private GameObject go;
    [SerializeField] private GameObject gw;
    [SerializeField] private GameObject pause;
    private bool isGameOver = false;
    private bool isGameWin = false;
    public TextMeshProUGUI timeText;
    private float startTime;
    private float kichhoatTime;
    private bool daKichHoat;
    // Start is called before the first frame update
    void Start()
    {
        UpdateDiem();
        go.SetActive(false);
        gw.SetActive(false);
        pause.SetActive(false);
        startTime = Time.time;  

    }

    // Update is called once per frame
    void Update()
    {
        float timeTroi =Time.time - startTime;
        int minutes = ((int)timeTroi / 60);
        int seconds = ((int)timeTroi % 60);
        timeText.text = string.Format("{0:00}:{1:00}", minutes,seconds);
        if(timeTroi>= kichhoatTime && !daKichHoat)
        {
            daKichHoat = true;
        }
    }
    public void AddDiem(int points)
    {
        if (!isGameOver && !isGameWin)
        {
            diem += points;
            UpdateDiem();
        }

    }
    private void UpdateDiem()
    {
        diemText.text = diem.ToString();
    }
    public void GameOver()
    {
        isGameOver = true;
        diem = 0;
        Time.timeScale = 0;
        go.SetActive(true);
    }
    public void GameWin()
    {
        isGameOver = true;
        Time.timeScale = 1;
        gw.SetActive(true);
    }

    public void TogglePause()
    {
        bool isPaused = Time.timeScale == 0;

        if (isPaused)
        {
            // Resume
            Time.timeScale = 1;
            pause.SetActive(false);
        }
        else
        {
            // Pause
            Time.timeScale = 0;
            pause.SetActive(true);
        }
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
        pause.SetActive(false);
    }

    public void RestartGameLevel1_1()
    {
        isGameOver = false;
        diem = 0;
        UpdateDiem();
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1_1");
    }
    public void RestartGameLevel1_2()
    {
        isGameOver = false;
        diem = 0;
        UpdateDiem();
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1_2");
    }
    public bool IsGameOver()
    {
        return isGameOver;
    }
    public bool IsGameWin()
    {
        return isGameWin;
    }
}
