using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.EventSystems;

public class CooldownButton : MonoBehaviour
{
    [SerializeField] Navigation _navigation;
    public Button[] buttons;
    public Text cooldownText;
    public float cooldownTime = 1f;
    private bool isCooldown = false;

    private void Start()
    {
        cooldownText.text = "";
    }

    private void Update()
    {
        // В Update() нет необходимости для отсчета времени, так как мы используем корутин
    }

    public void OnButtonClicked(Button sender)
    {
        if (!isCooldown)
        {
            Debug.Log("Button Clicked!");
            isCooldown = true;
            foreach (Button button in buttons)
            {
                button.interactable = false;
            }
            StartCoroutine(StartCooldown(sender));
        }
        else
        {
            Debug.Log("Buttons are on cooldown");
        }
    }

    private IEnumerator StartCooldown(Button button)
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
        _navigation.OnArriveToSector(button);
    }
}
