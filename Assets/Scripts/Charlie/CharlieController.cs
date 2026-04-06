using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.InputSystem;


public class CharlieController : MonoBehaviour
{
    [SerializeField] public Rigidbody2D rigidBody;
    [SerializeField] public Collider2D feetCollider;
    [SerializeField] public Collider2D bodyCollider;
    [SerializeField] public SpriteRenderer sprite;

    [SerializeField] public bool canExit;
    [SerializeField] public bool isAlive = true;
    public bool isGrounded;

    IEnumerator Reload;
    GameplayUI ui;

    void Start()
    {
        Reload = FindAnyObjectByType<ScenesManager>().ReloadDelay();
        ui = FindAnyObjectByType<GameplayUI>();
    }

    void Update()
    {
        Grounded();
        Die();
    }

    void FixedUpdate()
    {
        FindFirstObjectByType<WalkManager>().Walk();
        FindFirstObjectByType<WalkManager>().Iddle();
    }

    void Grounded()
    {
        isGrounded = feetCollider.IsTouchingLayers(LayerMask.GetMask("Floor"));
    }

    void Die()
    {
        if (bodyCollider.IsTouchingLayers(LayerMask.GetMask("Spikes")))
        {
            isAlive = false;
            StartCoroutine(Reload);
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
    }

    public void Kill()
    {
        {
            isAlive = false;
            StartCoroutine(Reload);
            transform.eulerAngles = new Vector3(0, 0, 90);
        }
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
