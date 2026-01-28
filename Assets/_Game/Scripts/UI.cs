using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UI : MonoBehaviour {
    [SerializeField] private Ball _ball;
    [SerializeField] private Sprite _fullHeartSprite;
    [SerializeField] private Sprite _emptyHeartSprite;
    [SerializeField] private List<Image> _hearts;


    void Start() {
        _ball._currentHealth = _hearts.Count;
    }

    public void UpdateHearts() {
        for (int i = 0; i < _hearts.Count; i++) {
            _hearts[i].sprite = i < _ball._currentHealth ? _fullHeartSprite : _emptyHeartSprite;
        }
    }
}
