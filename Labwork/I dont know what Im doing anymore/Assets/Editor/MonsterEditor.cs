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
        if(transitionRange)
        {
            EditorGUI.indentLevel++;
            monsterScript.VariableTransitionTime = EditorGUILayout.Toggle("Variable Transmission Time?", monsterScript.VariableTransitionTime);

            if(monsterScript.VariableTransitionTime)
            {
                EditorGUILayout.LabelField("Minimum - Maximum Time");
                EditorGUILayout.BeginHorizontal();
                monsterScript.TransitionTimeMin = EditorGUILayout.FloatField(monsterScript.TransitionTimeMin);
                monsterScript.TransitionTimeMax = EditorGUILayout.FloatField(monsterScript.TransitionTimeMax);
                EditorGUILayout.EndHorizontal();
            }
            else
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.PrefixLabel("Transition Time:");
                monsterScript.TransitionTimeMax = EditorGUILayout.FloatField(monsterScript.TransitionTimeMax);
                EditorGUILayout.EndHorizontal();
            }

            EditorGUI.indentLevel--;
        }

        EditorGUILayout.Space();

        spawnTypes = EditorGUILayout.Foldout(spawnTypes, "Spawn Settings");
        if(spawnTypes)
        {
            EditorGUI.indentLevel++;
            serializedObject.Update();
            EditorGUILayout.PropertyField(serializedObject.FindProperty("possibleTypes"), true);
            EditorGUI.indentLevel--;
        }

        EditorGUILayout.Space();

        monsterScript.PointWorth = EditorGUILayout.IntField("Point Value: ", monsterScript.PointWorth);

        serializedObject.ApplyModifiedProperties();
    }
}
