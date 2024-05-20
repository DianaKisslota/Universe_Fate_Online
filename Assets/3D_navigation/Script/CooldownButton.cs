using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class CooldownButton : MonoBehaviour
{
    public Button[] buttons;
    public Text cooldownText;
    public float cooldownTime = 1f;
    private bool isCooldown = false;

    private void Start()
    {
        foreach (Button button in buttons)
        {
            button.onClick.AddListener(OnButtonClicked);
            button.interactable = true;
        }
        cooldownText.text = "";
    }

    private void Update()
    {
        // В Update() нет необходимости для отсчета времени, так как мы используем корутин
    }

    private void OnButtonClicked()
    {
        if (!isCooldown)
        {
            Debug.Log("Button Clicked!");
            isCooldown = true;
            foreach (Button button in buttons)
            {
                button.interactable = false;
                EventTrigger eventTrigger = button.GetComponent<EventTrigger>();
                if (eventTrigger != null)
                {
                    eventTrigger.enabled = false; // Блокируем EventTrigger кнопки
                }
            }
            StartCoroutine(StartCooldown());
        }
        else
        {
            Debug.Log("Buttons are on cooldown");
        }
    }

    private IEnumerator StartCooldown()
    {
        float timer = cooldownTime;
        while (timer > 0)
        {
            cooldownText.text = Mathf.Ceil(timer).ToString(); // Отображаем только оставшееся время кулдауна
            yield return new WaitForSeconds(1f);
            timer -= 1f;
        }

        isCooldown = false;
        cooldownText.text = "";
        foreach (Button button in buttons)
        {
            button.interactable = true;
            EventTrigger eventTrigger = button.GetComponent<EventTrigger>();
            if (eventTrigger != null)
            {
                eventTrigger.enabled = true; // Разблокируем EventTrigger кнопки
            }
        }
    }
}
