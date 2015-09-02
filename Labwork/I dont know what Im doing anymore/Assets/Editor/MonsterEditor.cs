using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(Monster))]
public class MonsterEditor : Editor
{
    Monster monsterScript;
    bool visibleRange = false;
    bool transitionRange = false;
    bool spawnTypes = false;

    void Awake()
    {
        monsterScript = (Monster)target;
    }

    void OnInspectorGUI()
    {
        visibleRange = EditorGUILayout.Foldout(visibleRange, "Visibility Settings");

        transitionRange = EditorGUILayout.Foldout(transitionRange, "Transition Settings");

        spawnTypes = EditorGUILayout.Foldout(spawnTypes, "Spawn Settings");

    }
}
