using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUi : MonoBehaviour
{
    [SerializeField] private Button attackButton;
    [SerializeField] private Player player;

    private void Awake() {
        attackButton.onClick.AddListener(player.Damage);
    }
}
