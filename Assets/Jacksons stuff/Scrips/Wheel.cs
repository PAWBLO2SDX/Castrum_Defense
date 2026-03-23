using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class Wheel : MonoBehaviour
{

    private int randomValue;
    private float timeInterval;
    private bool coroutineAllowed;
    private int finalAngle;

    [SerializeField]
    private TMPro.TMP_Text winText;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        coroutineAllowed = true;

        if (winText == null)
        {
            Debug.LogWarning($"{nameof(Wheel)}: winText is not assigned in the Inspector.");
        }
    }

    // Update is called once per frame
    private void Update()
    {
        
        bool beganTouch = Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !EventSystem.current.IsPointerOverGameObject();
        bool beganMouse = Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject();

        if ((beganTouch || beganMouse) && coroutineAllowed)
        {
            StartCoroutine(Spin());
        }
    }

    
    public void StartSpin()
    {
        if (coroutineAllowed)
        {
            StartCoroutine(Spin());
        }
        else
        {
            Debug.Log($"{nameof(Wheel)}: Spin requested but coroutine not allowed.");
        }
    }

    private IEnumerator Spin()
    {
        coroutineAllowed = false;
        randomValue = Random.Range(20, 30);
        timeInterval = 0.01f;

        for (int i = 0; i < randomValue; i++)
        {
            transform.Rotate(0, 0, 22.5f);
            if (i > Mathf.RoundToInt(randomValue * 0.5f))
            {
                timeInterval = 0.2f;
            }
            if (i > Mathf.RoundToInt(randomValue * 0.85f))
            {
                timeInterval = 0.4f;
            }
            yield return new WaitForSeconds(timeInterval);
        }

        if (Mathf.RoundToInt(transform.eulerAngles.z) % 45 != 0)
        {
            transform.Rotate(0, 0, 22.5f);
        }

        
        finalAngle = Mathf.RoundToInt(transform.eulerAngles.z) % 360;
        if (finalAngle < 0) finalAngle += 360;

        switch (finalAngle)
        {
            case int angle when angle >= 0 && angle <= 44:
                winText.text = "You win a lot";
                break;
            case int angle when angle >= 45 && angle <= 89:
                winText.text = "You win a bit";
                break;
            case int angle when angle >= 90 && angle <= 134:
                winText.text = "You lose half";
                break;
            case int angle when angle >= 135 && angle <= 179:
                winText.text = "You lose a bit";
                break;
            case int angle when angle >= 180 && angle <= 224:
                winText.text = "You win a bit";
                break;
            case int angle when angle >= 225 && angle <= 269:
                winText.text = "You lose a bit";
                break;
            case int angle when angle >= 270 && angle <= 314:
                winText.text = "You lose everything";
                break;
            case int angle when angle >= 315 && angle <= 360:
                winText.text = "You win a bit";
                break;
            default:
                winText.text = $"Angle: {finalAngle}";
                break;
        }
        coroutineAllowed = true;
    }
}
