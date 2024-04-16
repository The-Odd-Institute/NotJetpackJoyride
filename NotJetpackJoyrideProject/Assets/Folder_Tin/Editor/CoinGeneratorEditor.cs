using UnityEditor;

[CustomEditor(typeof(CoinGenerator))]
public class CoinGeneratorEditor : Editor
{
    #region General Config Property
    SerializedProperty generateOnStart;
    SerializedProperty pfCoin;
    SerializedProperty pfCoinGroup;
    SerializedProperty childHolder;
    SerializedProperty alphabetPatterns;
    #endregion

    #region Generate Config Property
    SerializedProperty generateText;
    SerializedProperty textWeigth;
    SerializedProperty coinText;

    SerializedProperty generatePattern;
    SerializedProperty patternWeigth;
    SerializedProperty coinPatterns;
    #endregion

    bool generalGroup = false;


    private void OnEnable()
    {
        generateOnStart = serializedObject.FindProperty("generateOnStart");
        pfCoin = serializedObject.FindProperty("pfCoin");
        pfCoinGroup = serializedObject.FindProperty("pfCoinGroup");
        childHolder = serializedObject.FindProperty("childHolder");
        alphabetPatterns = serializedObject.FindProperty("alphabetPatterns");

        generateText = serializedObject.FindProperty("generateText");
        textWeigth = serializedObject.FindProperty("textWeigth");
        coinText = serializedObject.FindProperty("coinText");

        generatePattern = serializedObject.FindProperty("generatePattern");
        patternWeigth = serializedObject.FindProperty("patternWeigth");
        coinPatterns = serializedObject.FindProperty("coinPatterns");
    }

#if UNITY_EDITOR
    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(generateOnStart);
        generalGroup = EditorGUILayout.BeginFoldoutHeaderGroup(generalGroup, "Prefab");
        if (generalGroup)
        {
            EditorGUILayout.PropertyField(pfCoin);
            EditorGUILayout.PropertyField(pfCoinGroup);
            EditorGUILayout.PropertyField(childHolder);
        }
        EditorGUILayout.EndFoldoutHeaderGroup();
        EditorGUILayout.PropertyField(alphabetPatterns);

        EditorGUILayout.PropertyField(generateText);
        if (generateText.boolValue)
        {
            EditorGUILayout.PropertyField(textWeigth);
            EditorGUILayout.PropertyField(coinText);
        }

        EditorGUILayout.PropertyField(generatePattern);
        if (generatePattern.boolValue)
        {
            EditorGUILayout.PropertyField(patternWeigth);
            EditorGUILayout.PropertyField(coinPatterns);
        }

        serializedObject.ApplyModifiedProperties();
    }
#endif
}
