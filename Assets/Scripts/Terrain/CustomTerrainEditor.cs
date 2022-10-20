#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(CustomTerrain))]
[CanEditMultipleObjects]

public class CustomTerrainEditor : Editor
{
    private SerializedProperty _resetTerrain;
    private bool _showSinglePerlin = false;

    //PERLIN NOISE ----------------------
    private SerializedProperty _perlinXScale;
    private SerializedProperty _perlinYScale;
    private SerializedProperty _perlinXOffset;
    private SerializedProperty _perlinYOffset;
    private SerializedProperty _perlinOctaves;
    private SerializedProperty _perlinPersistence;
    private SerializedProperty _perlinHeightScale;


    private void OnEnable()
    {
        _perlinXScale = serializedObject.FindProperty("perlinXScale");
        _perlinYScale = serializedObject.FindProperty("perlinYScale");
        _perlinXOffset = serializedObject.FindProperty("perlinXOffset");
        _perlinYOffset = serializedObject.FindProperty("perlinYOffset");
        _perlinOctaves = serializedObject.FindProperty("perlinOctaves");
        _perlinPersistence = serializedObject.FindProperty("perlinPersistence");
        _perlinHeightScale = serializedObject.FindProperty("perlinHeightScale");
        _resetTerrain = serializedObject.FindProperty("resetTerrain");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();
        CustomTerrain customTerrain = (CustomTerrain)target;

        EditorGUILayout.BeginVertical();

        EditorGUILayout.PropertyField(_resetTerrain);

        _showSinglePerlin = EditorGUILayout.Foldout(_showSinglePerlin, "Single Perlin Noise");
        if (_showSinglePerlin)
        {
            EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
            GUILayout.Label("Set Perlin X and Y Scale", EditorStyles.boldLabel);
            EditorGUILayout.Slider(_perlinXScale, 0, 1, new GUIContent("X Scale"));
            EditorGUILayout.Slider(_perlinYScale, 0, 1, new GUIContent("Y Scale"));
            EditorGUILayout.IntSlider(_perlinXOffset, 0, 10000, new GUIContent("X Offset"));
            EditorGUILayout.IntSlider(_perlinYOffset, 0, 10000, new GUIContent("Y Offset"));
            EditorGUILayout.IntSlider(_perlinOctaves, 1, 10, new GUIContent("Octaves"));
            EditorGUILayout.Slider(_perlinPersistence, 1, 10, new GUIContent("Persistence"));
            EditorGUILayout.Slider(_perlinHeightScale, 0, 1, new GUIContent("Height Scale"));

            if (GUILayout.Button("Apply Single Perlin"))
            {
                customTerrain.SinglePerlin();
            }
        }

        EditorGUILayout.LabelField("", GUI.skin.horizontalSlider);
        if (GUILayout.Button("Reset Height"))
        {
            customTerrain.ResetTerrain();
        }

        EditorGUILayout.EndVertical();

        serializedObject.ApplyModifiedProperties();
    }
}
#endif