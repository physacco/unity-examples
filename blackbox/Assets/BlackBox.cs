/*
 * This example shows how to create a textured cube with MeshFilter and MeshRenderer.
 *
 * Refer to:
 * 1. http://docs.unity3d.com/ScriptReference/Mesh.html
 * 2. http://docs.unity3d.com/ScriptReference/Material-mainTexture.html
 */

using UnityEngine;
using System.Collections;

public class BlackBox : MonoBehaviour {

    void Start () {
        Vector3[] vertices = new Vector3[] {
            // front
            new Vector3(0, 0, 0),
            new Vector3(0, 1, 0),
            new Vector3(1, 1, 0),
            new Vector3(1, 0, 0),

            // back
            new Vector3(0, 0, 1),
            new Vector3(1, 0, 1),
            new Vector3(1, 1, 1),
            new Vector3(0, 1, 1),

            // left
            new Vector3(0, 0, 0),
            new Vector3(0, 0, 1),
            new Vector3(0, 1, 1),
            new Vector3(0, 1, 0),

            // right
            new Vector3(1, 0, 0),
            new Vector3(1, 1, 0),
            new Vector3(1, 1, 1),
            new Vector3(1, 0, 1),

            // up
            new Vector3(0, 1, 0),
            new Vector3(0, 1, 1),
            new Vector3(1, 1, 1),
            new Vector3(1, 1, 0),

            // down
            new Vector3(0, 0, 0),
            new Vector3(1, 0, 0),
            new Vector3(1, 0, 1),
            new Vector3(0, 0, 1),
        };

        int[] triangles = new int[] {
            // front
            0, 1, 2,
            2, 3, 0,

            // back
            4, 5, 6,
            6, 7, 4,

            // left
            8, 9, 10,
            10, 11, 8,

            // right
            12, 13, 14,
            14, 15, 12,

            // up
            16, 17, 18,
            18, 19, 16,

            // down
            20, 21, 22,
            22, 23, 20,
        };

        Vector2[] uv = new Vector2[] {
            // front
            new Vector2(0.25f, 0.25f),
            new Vector2(0.25f, 0.5f),
            new Vector2(0.5f, 0.5f),
            new Vector2(0.5f, 0.25f),

            // back
			new Vector2(1.0f, 0.25f),
            new Vector2(0.75f, 0.25f),
			new Vector2(0.75f, 0.5f),
            new Vector2(1.0f, 0.5f),

            // left
            new Vector2(1.0f, 0.5f),
            new Vector2(0.75f, 0.5f),
            new Vector2(0.75f, 0.75f),
            new Vector2(1.0f, 0.75f),

            // right
            new Vector2(0.75f, 0.0f),
            new Vector2(0.75f, 0.20f),
            new Vector2(1.0f, 0.25f),
            new Vector2(1.0f, 0.0f),

            // up
            new Vector2(0.0f, 0.25f),
            new Vector2(0.0f, 0.5f),
            new Vector2(0.25f, 0.5f),
            new Vector2(0.25f, 0.25f),

            // down
			new Vector2(0.5f, 0.5f),
			new Vector2(0.75f, 0.5f),
			new Vector2(0.75f, 0.25f),
            new Vector2(0.5f, 0.25f),
        };

        Mesh mesh = new Mesh();
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        MeshFilter filter = gameObject.AddComponent<MeshFilter>();
        filter.mesh = mesh;

        MeshRenderer renderer = gameObject.AddComponent<MeshRenderer>();
        renderer.material = new Material(Shader.Find("Unlit/Texture"));
		Texture2D texture = Resources.Load("cube_uv") as Texture2D;
		renderer.material.mainTexture = texture;
    }
}
