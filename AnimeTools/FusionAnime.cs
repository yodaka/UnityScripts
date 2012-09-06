using UnityEditor;
using UnityEngine;

public class FusionAnime : MonoBehaviour
{
    // Set here

    const string assetPathPrefix = "Assets/AnimeFrames";
    const string outputName      = "fusion.anim";

    public float speed = 1.0f;

    public float srcFps = 30.0f;
    public float dstFps = 30.0f;

    void CopyClip(string importedPath, string copyPath)
    {
        AnimationClip newClip = new AnimationClip();
        newClip.name = outputName;
        AssetDatabase.CreateAsset(newClip, copyPath);
        AssetDatabase.Refresh();
    }

    public struct FusionInfo
    {
        public string anim_src_name;
        public float src_time { get { return ((float)src_sec + src_frame / src_fps); } }
        public float dst_time { get { return ((float)dst_sec + dst_frame / dst_fps); } }

        private float src_fps;
        private int src_sec;
        private float src_frame;
        private float dst_fps;
        private int dst_sec;
        private float dst_frame;

        //public FusionInfo(
        //    string anim_name,
        //    float src_fps,
        //    int src_sec,
        //    float src_frame,
        //    float dst_fps,
        //    int dst_sec,
        //    float dst_frame)
        //{
        //    this.anim_src_name = anim_name;
        //
        //    this.src_fps = src_fps;
        //    this.src_sec = src_sec;
        //    this.src_frame = src_frame;
        //
        //    this.dst_fps = dst_fps;
        //    this.dst_sec = dst_sec;
        //    this.dst_frame = dst_frame;
        //}
        public FusionInfo(string anim_name, float src_fps, int src_sec, float src_frame, float dst_fps, float dst_frame)
        {
            this.anim_src_name = anim_name;
            this.src_fps = src_fps;
            this.src_sec = src_sec;
            this.src_frame = src_frame;

            this.dst_fps = dst_fps;
            this.dst_sec   = Mathf.FloorToInt(dst_frame / dst_fps);
            this.dst_frame = dst_frame - dst_fps * this.dst_sec;
        }
    }

    [MenuItem("AnimeTool/Fusion Anime")]
    void CopyCurvesToDuplicate()
    {
        // Edit here
        FusionInfo[] fusionInfo = {
                                     new FusionInfo("MyAnime0.anim",  srcFps, 0,  0, dstFps,   0 * speed),
                                     new FusionInfo("MyAnime3.anim",  srcFps, 0,  0, dstFps,   6 * speed),
                                     new FusionInfo("MyAnime5.anim",  srcFps, 0,  0, dstFps,  10 * speed),
                                     new FusionInfo("MyAnime7.anim",  srcFps, 0,  0, dstFps,  14 * speed),
                                     new FusionInfo("MyAnime10.anim", srcFps, 0,  0, dstFps,  20 * speed),
                                     new FusionInfo("MyAnime12.anim", srcFps, 0,  0, dstFps,  24 * speed),
                                     new FusionInfo("MyAnime13.anim", srcFps, 0,  0, dstFps,  26 * speed),
                                     new FusionInfo("MyAnime14.anim", srcFps, 0,  0, dstFps,  28 * speed),
                                     new FusionInfo("MyAnime15.anim", srcFps, 0,  0, dstFps,  30 * speed),
                                     new FusionInfo("MyAnime23.anim", srcFps, 0,  0, dstFps,  46 * speed),
                                     new FusionInfo("MyAnime33.anim", srcFps, 0,  0, dstFps,  66 * speed),
                                     new FusionInfo("MyAnime40.anim", srcFps, 0,  0, dstFps,  80 * speed),
                                     new FusionInfo("MyAnime45.anim", srcFps, 0,  0, dstFps,  90 * speed),
                                     new FusionInfo("MyAnime50.anim", srcFps, 0,  0, dstFps, 100 * speed),
                                     new FusionInfo("MyAnime55.anim", srcFps, 0,  0, dstFps, 110 * speed),
                                     new FusionInfo("MyAnime70.anim", srcFps, 0,  0, dstFps, 140 * speed),
                                     new FusionInfo("MyAnime90.anim", srcFps, 0,  0, dstFps, 180 * speed),
                                 };

        AnimationClipCurveData[][] curveDatasSrc = new AnimationClipCurveData[fusionInfo.Length][];
        Debug.Log(assetPathPrefix + fusionInfo[0].anim_src_name);
        AnimationClip imported0 = (AnimationClip)AssetDatabase.LoadAssetAtPath(assetPathPrefix + fusionInfo[0].anim_src_name, typeof(AnimationClip));

        if (imported0 == null)
        {
            Debug.Log("Selected object is not an AnimationClip");
            return;
        }
        AnimationClipCurveData[] curveDatas0 = AnimationUtility.GetAllCurves(imported0, true);
        AnimationCurve[] curveTmp = new AnimationCurve[curveDatas0.Length];

        for (int L = 0; L < fusionInfo.Length; L++)
        {
            AnimationClip imported = (AnimationClip)AssetDatabase.LoadAssetAtPath(assetPathPrefix + fusionInfo[L].anim_src_name, typeof(AnimationClip));

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
                    curveTmp[i].preWrapMode  = curveDatasSrc[L][i].curve.preWrapMode;
                    curveTmp[i].postWrapMode = curveDatasSrc[L][i].curve.postWrapMode;
                }

                Keyframe keyFrameTmp = new Keyframe();
                float val_min = float.MaxValue;
                for (int k = 0; k < curveDatasSrc[L][i].curve.length; k++)
                {
                    float val_tmp = Mathf.Abs(fusionInfo[L].src_time - curveDatasSrc[L][i].curve.keys[k].time);
                    if (val_tmp < val_min)
                    {
                        keyFrameTmp = new Keyframe(curveDatasSrc[L][i].curve.keys[k].time,
                                                   curveDatasSrc[L][i].curve.keys[k].value,
                                                   curveDatasSrc[L][i].curve.keys[k].inTangent,
                                                   curveDatasSrc[L][i].curve.keys[k].outTangent);
                        val_min = val_tmp;
                    }
                }
                keyFrameTmp.time = fusionInfo[L].dst_time;
                curveTmp[i].AddKey(keyFrameTmp);
            }
        }

        AnimationClip fusionClip = null;
        string importedPath = AssetDatabase.GetAssetPath(imported0);
        string fusionPath = assetPathPrefix + outputName;
        CopyClip(importedPath, fusionPath);
        fusionClip = AssetDatabase.LoadAssetAtPath(fusionPath, typeof(AnimationClip)) as AnimationClip;
        if (fusionClip == null)
        {
            Debug.Log("No copy found at " + fusionPath);
            return;
        }

        // Output fusion anime
        {
            AnimationClip imported2 = (AnimationClip)AssetDatabase.LoadAssetAtPath(assetPathPrefix + fusionInfo[0].anim_src_name, typeof(AnimationClip));

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
