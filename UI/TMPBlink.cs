using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Feto
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public class TMPBlink : MonoBehaviour
    {
        [SerializeField] TMPBlinkScriptable _settings;
        TextMeshProUGUI text;
        float timeChecker;
        Color TextColor;

        private void Awake() {
            text = GetComponent<TextMeshProUGUI>();
        }

        private void OnEnable() {
            timeChecker = 0;
            TextColor = text.color;
            StartCoroutine(DoBlink());
        }

        private IEnumerator DoBlink() {
            bool mustBlink = true;
            while (mustBlink) {
                timeChecker += Time.deltaTime;
                if (timeChecker < _settings.FadeInTime) {
                    text.color = new Color(TextColor.r, TextColor.g, TextColor.b, timeChecker / _settings.FadeInTime);
                    yield return null;
                }
                else if (timeChecker < _settings.FadeInTime + _settings.FadeInStayTime) {
                    text.color = new Color(TextColor.r, TextColor.g, TextColor.b, 1);
                    yield return null;
                }
                else if (timeChecker < _settings.FadeInTime + _settings.FadeInStayTime + _settings.FadeOutTime) {
                    text.color = new Color(TextColor.r, TextColor.g, TextColor.b, 1 - (timeChecker - (_settings.FadeInTime + _settings.FadeInStayTime)) / _settings.FadeOutTime);
                    yield return null;
                }
                else if (timeChecker < _settings.FadeInTime + _settings.FadeInStayTime + _settings.FadeOutTime + _settings.FadeOutStayTime) {
                    yield return null;
                }
                else {
                    if (!_settings.loop) {
                        mustBlink = false;
                    }
                    timeChecker = 0;
                }
            }
        }
    }
}

