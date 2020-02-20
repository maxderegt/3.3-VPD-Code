using System;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class RadialSection
{
    public Sprite icon = null;
    public SpriteRenderer iconrenderer = null;
    public String name = "";
    public UnityEvent onPress = new UnityEvent();
}
