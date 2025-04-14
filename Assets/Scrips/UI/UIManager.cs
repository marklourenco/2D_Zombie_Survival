using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public GameObject reloadBar;
    public Image reloadBarFill;

    public Transform playerTransform;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        if (reloadBarFill != null)
        {
            reloadBarFill.fillAmount = 0f;
        }
    }

    private void Update()
    {
        if (playerTransform != null)
        {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(playerTransform.position);
            reloadBar.transform.position = screenPos;
        }
    }

    public void UpdateReloadBar(float progress)
    {
        if (reloadBarFill != null)
        {
            reloadBarFill.fillAmount = Mathf.Lerp(0, 1, progress);
        }

        if (reloadBarFill.fillAmount >= 1.0f)
        {
            reloadBar.SetActive(false);
            reloadBarFill.fillAmount = 0.0f;
        }
    }
}