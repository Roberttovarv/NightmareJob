using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class CharlieController : MonoBehaviour
{
    private const string DeathsKey = "deaths";

    [SerializeField] public Rigidbody2D rigidBody;
    [SerializeField] public Collider2D feetCollider;
    [SerializeField] public Collider2D bodyCollider;
    [SerializeField] public SpriteRenderer sprite;

    [SerializeField] public bool canExit;
    [SerializeField] public bool isAlive = true;
    WalkManager walkManager;
    public bool isGrounded;

    GameplayUI ui;

    void Start()
    {
        ui = FindAnyObjectByType<GameplayUI>();
        walkManager = FindFirstObjectByType<WalkManager>();
    }

    void Update()
    {
        Grounded();
        Die();
    }

    void FixedUpdate()
    {
        walkManager.Walk();
        walkManager.Iddle();
    }

    void Grounded()
    {
        isGrounded = feetCollider.IsTouchingLayers(LayerMask.GetMask("Floor"));
    }

    void Die()
    {
        if (!isAlive)
        {
            return;
        }

        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Spikes")))
        {
            isAlive = false;
            StartCoroutine(FindAnyObjectByType<ScenesManager>().ReloadDelay());
            transform.eulerAngles = new Vector3(0, 0, 90);
            int currentDeaths = PlayerPrefs.GetInt(DeathsKey);
            PlayerPrefs.SetInt(DeathsKey, currentDeaths + 1);
            PlayerPrefs.Save();

            DeathsManager deaths = FindAnyObjectByType<DeathsManager>();
            deaths.RefreshText();

            print(currentDeaths);
        }
    }

    public void Kill()
    {
        if (!isAlive)
        {
            return;
        }

        isAlive = false;
        StartCoroutine(FindAnyObjectByType<ScenesManager>().ReloadDelay());
        transform.eulerAngles = new Vector3(0, 0, 90);

        int currentDeaths = PlayerPrefs.GetInt(DeathsKey);

        PlayerPrefs.SetInt(DeathsKey, currentDeaths + 1);
        PlayerPrefs.Save();

        DeathsManager deaths = FindAnyObjectByType<DeathsManager>();
        deaths.RefreshText();
    }
    void OnHint()
    {
        if (GameSessionManager.IsPaused)
        {
            ui.DeactivateHelp();
        }
        else
        {
            Button button = ui.helpPanel.GetComponentInChildren<Button>();
            EventSystem.current.SetSelectedGameObject(button.gameObject);
            ui.ActivateHelp();
        }
        print("PResionado");
    }

    void OnPause()
    {

        bool isGamepad = Gamepad.current != null && Gamepad.current.wasUpdatedThisFrame;
        if (GameSessionManager.IsPaused)
        {
            ui.DeactivatePause();
        }
        else
        {
            if (isGamepad)
            {
                Button button = ui.pausePanel.GetComponentInChildren<Button>();
                EventSystem.current.SetSelectedGameObject(button.gameObject);
            }
            ui.ActivatePause();
        }
    }



}
