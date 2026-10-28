using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    [SerializeField] private Button attackButton;
    [SerializeField] private Button healButton;
    [SerializeField] private Button eatButton;
    [SerializeField] private Player player;

    private void Awake() {
        attackButton.onClick.AddListener(player.Damage);

        healButton.onClick.AddListener(player.Heal);

        eatButton.onClick.AddListener(player.Eat);
    }
}
