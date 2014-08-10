using UnityEngine;
using System.Collections;

public class SineCurveControl : MonoBehaviour {
    public Color StartColor = Color.yellow;
    public Color EndColor = Color.red;
    private float LineWidth = 0.05f;
    private int VertexCount = 100;
    private float HorizontalScale = 0.1f;
    private float VerticalScale = 1.5f;
    private LineRenderer Renderer;

    void Start () {
        Renderer = gameObject.AddComponent<LineRenderer>();
        Renderer.material = new Material(Shader.Find("Particles/Additive"));
        Renderer.SetColors(StartColor, EndColor);
        Renderer.SetWidth(LineWidth, LineWidth);
        Renderer.SetVertexCount(VertexCount);
    }
    
    void Update () {
        for (int i = 0; i < VertexCount; i++) {
            float x = (i - VertexCount / 2) * HorizontalScale;
            float y = Mathf.Sin(x + Time.time) * VerticalScale;
            Vector3 pos = new Vector3(x, y, 0);
            Renderer.SetPosition(i, pos);
        }
    }
}
