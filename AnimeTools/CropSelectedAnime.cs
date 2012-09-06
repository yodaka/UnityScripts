using UnityEditor;
using UnityEngine;

public class CropSelectedAnime : ScriptableWizard
{
    public float fps              = 30.0f;
    public int startFramePosition = 0;
    public int endFramePosition   = 0;

    private const string duplicatePostfix = "_crop";

    [MenuItem("AnimeTool/Crop selected anime")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<CropSelectedAnime>("Crop animation.", "Exit", "Generate");
    }

    // This is called when the user clicks on the Create(Exit) button.
    void OnWizardCreate()
    {
    }

    // This is called when the wizard is opened or whenever the user changes something in the wizard.
    void OnWizardUpdate()
    {
        helpString = "Please specify crop range of framesand select\r\n  src animation file and push generate button!";
    }

    // When the user pressed the "Generate" button OnWizardOtherButton is called.
    void OnWizardOtherButton()
    {
        if (endFramePosition <= 0)
        {
            Debug.Log("Please set valid endFramePosition!");
            return;
        }

        if (startFramePosition < 0)
        {
            Debug.Log("Please set valid startFramePosition!");
            return;
        }

        float startTime = (float)startFramePosition / fps;
        float endTime   = (float)  endFramePosition / fps;

        // Get selected AnimationClip
        AnimationClip imported = Selection.activeObject as AnimationClip;
        if (imported == null)
        {
            Debug.Log("Selected object is not an AnimationClip");
            return;
        }

        // Find path of copy
        string importedPath = AssetDatabase.GetAssetPath(imported);
        Debug.Log(importedPath);
        string copyPath = importedPath.Substring(0, importedPath.LastIndexOf("/"));
        copyPath += "/" + imported.name + duplicatePostfix + "From" + startFramePosition.ToString() + "To" + endFramePosition.ToString() + ".anim";

        CopyClip(importedPath, copyPath);

        AnimationClip copy = AssetDatabase.LoadAssetAtPath(copyPath, typeof(AnimationClip)) as AnimationClip;
        if (copy == null)
        {
            Debug.Log("No copy found at " + copyPath);
            return;
        }
        // Copy curves from imported to copy
        AnimationClipCurveData[] curveDatas = AnimationUtility.GetAllCurves(imported, true);

        for (int i = 0; i < curveDatas.Length; i++)
        {
            AnimationCurve curveTmp = new AnimationCurve();

            for (int k = 0; k < curveDatas[i].curve.length; k++)
            {
                if ( curveDatas[i].curve.keys[k].time >= startTime
                  && curveDatas[i].curve.keys[k].time <= endTime)
                {
                    Keyframe keyFrameTmp = new Keyframe(
                                                    curveDatas[i].curve.keys[k].time - startTime,
                                                    curveDatas[i].curve.keys[k].value,
                                                    curveDatas[i].curve.keys[k].inTangent,
                                                    curveDatas[i].curve.keys[k].outTangent);

                    curveTmp.AddKey(keyFrameTmp);
                }
            }

            if (curveTmp.length > 0)
            {
                AnimationUtility.SetEditorCurve(
                    copy,
                    curveDatas[i].path,
                    curveDatas[i].type,
                    curveDatas[i].propertyName,
                    curveTmp //curveDatas[i].curve
                );
            }
        }

        Debug.Log("Copying animation into " + copy.name + " is done");
    }

    static void CopyClip(string importedPath, string copyPath)
    {
        AnimationClip src = AssetDatabase.LoadAssetAtPath(importedPath, typeof(AnimationClip)) as AnimationClip;
        AnimationClip newClip = new AnimationClip();
        newClip.name = src.name + duplicatePostfix;
        AssetDatabase.CreateAsset(newClip, copyPath);
        AssetDatabase.Refresh();
    }

}
