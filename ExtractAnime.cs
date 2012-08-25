using UnityEditor;
using UnityEngine;

public class ExtractAnime : MonoBehaviour
{
    const string assetPathPrefix = "Assets/";

    static void CopyClip(string importedPath, string copyPath, string outputName)
    {
        AnimationClip newClip = new AnimationClip();
        newClip.name = outputName;
        AssetDatabase.CreateAsset(newClip, copyPath);
        AssetDatabase.Refresh();
    }

    public struct ExtractInfo
    {
        public float src_time { get { return ((float)src_sec + (float)src_frame / 30.0f); } }
        public float dst_time { get { return ((float)dst_sec + (float)dst_frame / 30.0f); } }

        public int src_sec;
        public int src_frame;
        public int dst_sec;
        public int dst_frame;

        public ExtractInfo(int src_sec, int src_frame, int dst_sec, int dst_frame)
        {
            this.src_sec = src_sec;
            this.src_frame = src_frame;
            this.dst_sec = dst_sec;
            this.dst_frame = dst_frame;
        }
    }

    [MenuItem("Assets/AnimeExtract")]
    static void CopyCurvesToDuplicate()
    {
        // Edit here
        int src_sec   = 0;
        int src_frame = 17;

        ExtractInfo extractInfo = new ExtractInfo(src_sec,  src_frame, 0, 1);
        AnimationClip imported = Selection.activeObject as AnimationClip;

        string outputName = imported.name + "_"
                          + extractInfo.src_sec  .ToString() + "_"
                          + extractInfo.src_frame.ToString() + "_"
                          + extractInfo.dst_sec  .ToString() + "_"
                          + extractInfo.dst_frame.ToString() + ".anim";

        if (imported == null)
        {
            Debug.Log("Selected object is not an AnimationClip");
            return;
        }

        AnimationClipCurveData[] curveDatas    = AnimationUtility.GetAllCurves(imported, true);
        AnimationCurve[] curveTmp = new AnimationCurve[curveDatas.Length];

        for (int i = 0; i < curveDatas.Length; i++)
        {
            curveTmp[i] = new AnimationCurve();
            curveTmp[i].preWrapMode  = curveDatas[i].curve.preWrapMode;
            curveTmp[i].postWrapMode = curveDatas[i].curve.postWrapMode;

            Keyframe keyFrameTmp = new Keyframe();
            
            float val_min = float.MaxValue;

            for (int k = 0; k < curveDatas[i].curve.length; k++)
            {
                float val_tmp = Mathf.Abs(extractInfo.src_time - curveDatas[i].curve.keys[k].time);

                if (val_tmp < val_min)
                {
                    keyFrameTmp = new Keyframe(curveDatas[i].curve.keys[k].time,
                                               curveDatas[i].curve.keys[k].value,
                                               0.0f,  //curveDatas[i].curve.keys[k].inTangent,
                                               0.0f); //curveDatas[i].curve.keys[k].outTangent);
                    val_min = val_tmp;
                }
            }
            keyFrameTmp.time = extractInfo.dst_time;
            curveTmp[i].AddKey(keyFrameTmp);

            Keyframe keyFrameTmp2 = new Keyframe(keyFrameTmp.time,
                                                 keyFrameTmp.value,
                                                 0.0f,  //keyFrameTmp.inTangent,
                                                 0.0f); //keyFrameTmp.outTangent);
            keyFrameTmp2.time = 0.0f;
            curveTmp[i].AddKey(keyFrameTmp2);
        }

        AnimationClip extractClip = null;
        string importedPath = AssetDatabase.GetAssetPath(imported);
        string extractPath  = "Assets/" + outputName;
        CopyClip(importedPath, extractPath, outputName);
        extractClip = AssetDatabase.LoadAssetAtPath(extractPath, typeof(AnimationClip)) as AnimationClip;
        if (extractClip == null)
        {
            Debug.Log("No copy found at " + extractPath);
            return;
        }

        // Output fusion Animation
        {
            for (int i = 0; i < curveDatas.Length; i++)
            {
                AnimationUtility.SetEditorCurve(
                    extractClip,
                    curveDatas[i].path,
                    curveDatas[i].type,
                    curveDatas[i].propertyName,
                    curveTmp[i] );
            }
        }

        Debug.Log("Extracting animation into " + extractClip.name + " is done");
    }
}
