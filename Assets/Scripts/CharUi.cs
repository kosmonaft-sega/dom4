using UnityEngine;
using UnityEngine.UI;
using TMPro;
using TMPro.EditorUtilities;

public class CharUi : MonoBehaviour
{
    [SerializeField] private CharStats charStats;
    [SerializeField] private TMP_Text textField;
    [SerializeField] private Slider hpBar;

    public void Start()
    {
        hpBar.maxValue = charStats.charData.MaxHp;
        hpBar.value = charStats.charData.MaxHp;
        textField.text = charStats.charData.CharName;
    }

    private void OnEnable() {
        charStats.hpChange += DrawHp;
    }

    private void OnDisable() {
        charStats.hpChange -= DrawHp;
    }

    public void DrawHp(float hp)
    {
        hpBar.value = hp;
    }
}
