using UnityEditor;
using UnityEngine;

public class FusionAnime : MonoBehaviour
{
    const string assetPathPrefix  = "Assets/";
    const string outputName = "fusion.anim";

    static void CopyClip(string importedPath, string copyPath)
    {
        AnimationClip newClip = new AnimationClip();
        newClip.name = outputName;
        AssetDatabase.CreateAsset(newClip, copyPath);
        AssetDatabase.Refresh();
    }

    public struct FusionInfo
    {
        public string anim_src_name;
        public float src_time { get { return (src_sec + src_frame / 30.0f); } }
        public float dst_time { get { return (dst_sec + dst_frame / 30.0f); } }

        private int src_sec;
        private int src_frame;
        private int dst_sec;
        private int dst_frame;

        public FusionInfo(string anim_name, int src_sec, int src_frame, int dst_sec, int dst_frame)
        {
            this.anim_src_name = anim_name;
            this.src_sec = src_sec;
            this.src_frame = src_frame;
            this.dst_sec = dst_sec;
            this.dst_frame = dst_frame;
        }
    }

    [MenuItem("Assets/AnimeFusion")]
    static void CopyCurvesToDuplicate()
    {
        // Edit here
        FusionInfo[] animeInfo = { new FusionInfo("die_copy.anim", 0,  3 , 0, 0),
                                  new FusionInfo("die_copy.anim", 0,  5 , 0, 5),
                                  new FusionInfo("die_copy.anim", 0,  4 , 0, 10),
                                  new FusionInfo("die_copy.anim", 0,  5 , 0, 15),
                                  new FusionInfo("die_copy.anim", 0,  4 , 0, 20),
                                  new FusionInfo("die_copy.anim", 0,  5 , 0, 25),
                                  new FusionInfo("die_copy.anim", 0,  4 , 1, 20) };

        AnimationClipCurveData[][] curveDatasSrc = new AnimationClipCurveData[animeInfo.Length][];
        AnimationClip imported0 = (AnimationClip)AssetDatabase.LoadAssetAtPath(assetPathPrefix + animeInfo[0].anim_src_name, typeof(AnimationClip));

        if (imported0 == null)
        {
            Debug.Log("Selected object is not an AnimationClip");
            return;
        }
        AnimationClipCurveData[] curveDatas0 = AnimationUtility.GetAllCurves(imported0, true);
        AnimationCurve[] curveTmp = new AnimationCurve[curveDatas0.Length];

        for (int L = 0; L < animeInfo.Length; L++)
        {
            AnimationClip imported = (AnimationClip)AssetDatabase.LoadAssetAtPath(assetPathPrefix + animeInfo[L].anim_src_name, typeof(AnimationClip));

            if (imported == null)
            {
                Debug.Log("Selected object is not an AnimationClip");
                return;
            }
        
            curveDatasSrc[L] = AnimationUtility.GetAllCurves(imported, true);

            for (int i = 0; i < curveDatasSrc[L].Length; i++)
            {
                if (L == 0)
                {
                    curveTmp[i] = new AnimationCurve();
                    curveTmp[i].preWrapMode = curveDatasSrc[L][i].curve.preWrapMode;
                    curveTmp[i].postWrapMode = curveDatasSrc[L][i].curve.postWrapMode;
                }

                Keyframe keyFrameTmp = new Keyframe();
                float val_min = float.MaxValue;
                for (int k = 0; k < curveDatasSrc[L][i].curve.length; k++)
                {
                    float val_tmp = Mathf.Abs(animeInfo[L].src_time - curveDatasSrc[L][i].curve.keys[k].time);
                    if (val_tmp < val_min)
                    {
                        keyFrameTmp = new Keyframe(curveDatasSrc[L][i].curve.keys[k].time,
                                                   curveDatasSrc[L][i].curve.keys[k].value,
                                                   curveDatasSrc[L][i].curve.keys[k].inTangent,
                                                   curveDatasSrc[L][i].curve.keys[k].outTangent);
                        val_min = val_tmp;
                    }
                }
                keyFrameTmp.time = animeInfo[L].dst_time;
                curveTmp[i].AddKey(keyFrameTmp);
            }
        }

        AnimationClip fusionClip = null;
        string importedPath = AssetDatabase.GetAssetPath(imported0);
        string fusionPath = "Assets/" + outputName;
        CopyClip(importedPath, fusionPath);
        fusionClip = AssetDatabase.LoadAssetAtPath(fusionPath, typeof(AnimationClip)) as AnimationClip;
        if (fusionClip == null)
        {
            Debug.Log("No copy found at " + fusionPath);
            return;
        }

        // Output fusion Animation
        {
            AnimationClip imported2 = (AnimationClip)AssetDatabase.LoadAssetAtPath(assetPathPrefix + animeInfo[0].anim_src_name, typeof(AnimationClip));

            if (imported2 == null)
            {
                Debug.Log("Selected object is not an AnimationClip");
                return;
            }

            AnimationClipCurveData[] curveDatas = AnimationUtility.GetAllCurves(imported2, true);

            for (int i = 0; i < curveDatas.Length; i++)
            {
                AnimationUtility.SetEditorCurve(
                    fusionClip,
                    curveDatas[i].path,
                    curveDatas[i].type,
                    curveDatas[i].propertyName,
                    curveTmp[i] );
            }
        }

        Debug.Log("Generating fusion animation into " + fusionClip.name + " is done");
    }
}
