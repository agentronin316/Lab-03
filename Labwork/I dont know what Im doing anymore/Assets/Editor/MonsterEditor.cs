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

    public override void OnInspectorGUI()
    {
        visibleRange = EditorGUILayout.Foldout(visibleRange, "Visibility Settings");
        if(visibleRange)
        {
            EditorGUI.indentLevel++;
            monsterScript.VariableVisibleTime = EditorGUILayout.Toggle("Variable Visible Time?", monsterScript.VariableVisibleTime);
            if (monsterScript.VariableVisibleTime)
            {
                EditorGUILayout.LabelField("Minimum - Maximum Time");
                EditorGUILayout.BeginHorizontal();
                monsterScript.VisibleTimeMin = EditorGUILayout.FloatField(monsterScript.VisibleTimeMin);
                monsterScript.VisibleTimeMax = EditorGUILayout.FloatField(monsterScript.VisibleTimeMax);
                EditorGUILayout.EndHorizontal();

            }
            else
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Visible Time:");
                monsterScript.VisibleTimeMax = EditorGUILayout.FloatField(monsterScript.VisibleTimeMax);
                EditorGUILayout.EndHorizontal();
            }
            EditorGUI.indentLevel--;
        }
        EditorGUILayout.Space();

        transitionRange = EditorGUILayout.Foldout(transitionRange, "Transition Settings");

        spawnTypes = EditorGUILayout.Foldout(spawnTypes, "Spawn Settings");

    }
}
