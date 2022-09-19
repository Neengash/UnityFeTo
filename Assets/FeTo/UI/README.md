# Blink Text
This component add fade in and fade out effect to text from TextMeshPro.

## How it works
1. Add __*TMPBlink*__ to an object with a TextMeshPro component
2. Create new scriptable object, use right click Create -> Scriptables -> UnityFeTo -> TMPBlinkScriptable
3. Add this new scriptable to __*TMPBlink*__ component.
4. Configure the component with the scriptable

## Configuration
In order to get the desired effect configure the __*TMPBlinkScriptable*__. The availble elements to configure are the following
- __Fade in time__: Time needed to text to be fully visible
- __Fade in stay time__: Time during which the text will be displayed
- __Fade out time__: Time needed to text to vanish
- __Fade out stay time__: Time during which the text will be vanished
- __Loop__: enables loop or disable it