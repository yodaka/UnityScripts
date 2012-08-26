using UnityEditor;
using UnityEngine;

public class ExtractPoseFromGameObject : MonoBehaviour
{
    static void setEditorCurveRecursive(
        Transform transform,
        string parentPath,
        AnimationClip animeClipAsset,
        GameObject root )
    {
        foreach (Transform child in transform)
        {
            GameObject childObj = child.gameObject;

            string path = parentPath + childObj.name;
            Debug.Log(path);

            int keyframe_num = 2;

            Keyframe[] keyframesPosX = new Keyframe[keyframe_num];
            Keyframe[] keyframesPosY = new Keyframe[keyframe_num];
            Keyframe[] keyframesPosZ = new Keyframe[keyframe_num];
            Keyframe[] keyframesRotX = new Keyframe[keyframe_num];
            Keyframe[] keyframesRotY = new Keyframe[keyframe_num];
            Keyframe[] keyframesRotZ = new Keyframe[keyframe_num];
            Keyframe[] keyframesRotW = new Keyframe[keyframe_num];
            Keyframe[] keyframesScaX = new Keyframe[keyframe_num];
            Keyframe[] keyframesScaY = new Keyframe[keyframe_num];
            Keyframe[] keyframesScaZ = new Keyframe[keyframe_num];

            float value;

            AnimationUtility.GetFloatValue(root, path, typeof(UnityEngine.Transform), "m_LocalPosition.x", out value);
            keyframesPosX[0] = new Keyframe(0 / 60.0f, value);
            keyframesPosX[1] = new Keyframe(1 / 60.0f, value);
            AnimationUtility.GetFloatValue(root, path, typeof(UnityEngine.Transform), "m_LocalPosition.y", out value);
            keyframesPosY[0] = new Keyframe(0 / 60.0f, value);
            keyframesPosY[1] = new Keyframe(1 / 60.0f, value);
            AnimationUtility.GetFloatValue(root, path, typeof(UnityEngine.Transform), "m_LocalPosition.z", out value);
            keyframesPosZ[0] = new Keyframe(0 / 60.0f, value);
            keyframesPosZ[1] = new Keyframe(1 / 60.0f, value);
            AnimationUtility.GetFloatValue(root, path, typeof(UnityEngine.Transform), "m_LocalRotation.x", out value);
            keyframesRotX[0] = new Keyframe(0 / 60.0f, value);
            keyframesRotX[1] = new Keyframe(1 / 60.0f, value);
            AnimationUtility.GetFloatValue(root, path, typeof(UnityEngine.Transform), "m_LocalRotation.y", out value);
            keyframesRotY[0] = new Keyframe(0 / 60.0f, value);
            keyframesRotY[1] = new Keyframe(1 / 60.0f, value);
            AnimationUtility.GetFloatValue(root, path, typeof(UnityEngine.Transform), "m_LocalRotation.z", out value);
            keyframesRotZ[0] = new Keyframe(0 / 60.0f, value);
            keyframesRotZ[1] = new Keyframe(1 / 60.0f, value);
            AnimationUtility.GetFloatValue(root, path, typeof(UnityEngine.Transform), "m_LocalRotation.w", out value);
            keyframesRotW[0] = new Keyframe(0 / 60.0f, value);
            keyframesRotW[1] = new Keyframe(1 / 60.0f, value);
            AnimationUtility.GetFloatValue(root, path, typeof(UnityEngine.Transform), "m_LocalScale.x", out value);
            keyframesScaX[0] = new Keyframe(0 / 60.0f, value);
            keyframesScaX[1] = new Keyframe(1 / 60.0f, value);
            AnimationUtility.GetFloatValue(root, path, typeof(UnityEngine.Transform), "m_LocalScale.y", out value);
            keyframesScaY[0] = new Keyframe(0 / 60.0f, value);
            keyframesScaY[1] = new Keyframe(1 / 60.0f, value);
            AnimationUtility.GetFloatValue(root, path, typeof(UnityEngine.Transform), "m_LocalScale.z", out value);
            keyframesScaZ[0] = new Keyframe(0 / 60.0f, value);
            keyframesScaZ[1] = new Keyframe(1 / 60.0f, value);

            AnimationCurve animeCurvePosX = new AnimationCurve(keyframesPosX);
            AnimationCurve animeCurvePosY = new AnimationCurve(keyframesPosY);
            AnimationCurve animeCurvePosZ = new AnimationCurve(keyframesPosZ);
            AnimationCurve animeCurveRotX = new AnimationCurve(keyframesRotX);
            AnimationCurve animeCurveRotY = new AnimationCurve(keyframesRotY);
            AnimationCurve animeCurveRotZ = new AnimationCurve(keyframesRotZ);
            AnimationCurve animeCurveRotW = new AnimationCurve(keyframesRotW);
            AnimationCurve animeCurveScaX = new AnimationCurve(keyframesScaX);
            AnimationCurve animeCurveScaY = new AnimationCurve(keyframesScaY);
            AnimationCurve animeCurveScaZ = new AnimationCurve(keyframesScaZ);

            AnimationUtility.SetEditorCurve(
                animeClipAsset,
                path,                          // path
                typeof(UnityEngine.Transform), // type
                "m_LocalPosition.x",           // propertyName
                animeCurvePosX);
            AnimationUtility.SetEditorCurve(
                animeClipAsset,
                path,                          // path
                typeof(UnityEngine.Transform), // type
                "m_LocalPosition.y",           // propertyName
                animeCurvePosY);
            AnimationUtility.SetEditorCurve(
                animeClipAsset,
                path,                          // path
                typeof(UnityEngine.Transform), // type
                "m_LocalPosition.z",           // propertyName
                animeCurvePosZ);
            AnimationUtility.SetEditorCurve(
                animeClipAsset,
                path,                          // path
                typeof(UnityEngine.Transform), // type
                "m_LocalRotation.x",           // propertyName
                animeCurveRotX);
            AnimationUtility.SetEditorCurve(
                animeClipAsset,
                path,                          // path
                typeof(UnityEngine.Transform), // type
                "m_LocalRotation.y",           // propertyName
                animeCurveRotY);
            AnimationUtility.SetEditorCurve(
                animeClipAsset,
                path,                          // path
                typeof(UnityEngine.Transform), // type
                "m_LocalRotation.z",           // propertyName
                animeCurveRotZ);
            AnimationUtility.SetEditorCurve(
                animeClipAsset,
                path,                          // path
                typeof(UnityEngine.Transform), // type
                "m_LocalRotation.w",           // propertyName
                animeCurveRotW);
            AnimationUtility.SetEditorCurve(
                animeClipAsset,
                path,                          // path
                typeof(UnityEngine.Transform), // type
                "m_LocalScale.x",              // propertyName
                animeCurveScaX);
            AnimationUtility.SetEditorCurve(
                animeClipAsset,
                path,                          // path
                typeof(UnityEngine.Transform), // type
                "m_LocalScale.y",              // propertyName
                animeCurveScaY);
            AnimationUtility.SetEditorCurve(
                animeClipAsset,
                path,                          // path
                typeof(UnityEngine.Transform), // type
                "m_LocalScale.z",              // propertyName
                animeCurveScaZ);

            setEditorCurveRecursive(childObj.transform, path + "/", animeClipAsset, root);
        }
    }

    [MenuItem("AnimeTools/Extract pose from selected Gameobject")]
    static void TestFunc()
    {
        GameObject gameObj = Selection.activeGameObject;

        if (gameObj == null)
        {
            Debug.Log("An game object is not selected.");
        }

        AnimationClip animeClipAsset = new AnimationClip();
        animeClipAsset.wrapMode = WrapMode.Default;
        AssetDatabase.CreateAsset(animeClipAsset, "Assets/MyAnime.anim"); // edit here

        setEditorCurveRecursive(gameObj.transform, "", animeClipAsset, gameObj); 
    }
}
