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
        // � Update() ��� ������������� ��� ������� �������, ��� ��� �� ���������� �������
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
                    eventTrigger.enabled = false; // ��������� EventTrigger ������
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
            cooldownText.text = Mathf.Ceil(timer).ToString(); // ���������� ������ ���������� ����� ��������
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
                eventTrigger.enabled = true; // ������������ EventTrigger ������
            }
        }
    }
}
