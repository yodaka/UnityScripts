using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

public struct BoneInfo
{
    public Transform transform;
    public float length; // length between this and parent bone
    public string path;  // animation path (e.g., Bip01/Bip01 Pelvis/Bip01 Spine)
}

public class TranslateSelectedAnime : ScriptableWizard
{
    public float scale = 1.0f;

    // Src Transforms

    public Transform srcRoot;
    public Transform srcPelvis;
    public Transform srcSpine;

    public Transform srcLThigh;
    public Transform srcLCalf;
    public Transform srcLFoot;
    public Transform srcLToe;
    public Transform srcLToeNub;
    
    public Transform srcRThigh;
    public Transform srcRCalf;
    public Transform srcRFoot;
    public Transform srcRToe;
    public Transform srcRToeNub;
    
    public Transform srcSpine1;
    public Transform srcNeck;
    
    public Transform srcHead;
    public Transform srcHeadNub;
    
    public Transform srcLClavicle;
    public Transform srcLUpperArm;
    public Transform srcLForeArm;
    public Transform srcLHand;
    public Transform srcLFinger0;
    public Transform srcLFinger01;
    public Transform srcLFinger0Nub;
    public Transform srcLFinger1;
    public Transform srcLFinger11;
    public Transform srcLFinger1Nub;
    
    public Transform srcRClavicle;
    public Transform srcRUpperArm;
    public Transform srcRForeArm;
    public Transform srcRHand;
    public Transform srcRFinger0;
    public Transform srcRFinger01;
    public Transform srcRFinger0Nub;
    public Transform srcRFinger1;
    public Transform srcRFinger11;
    public Transform srcRFinger1Nub;

    // Dst Transforms

    public Transform dstRoot;
    public Transform dstPelvis;
    public Transform dstSpine;
    
    public Transform dstLThigh;
    public Transform dstLCalf;
    public Transform dstLFoot;
    public Transform dstLToe;
    public Transform dstLToeNub;
    
    public Transform dstRThigh;
    public Transform dstRCalf;
    public Transform dstRFoot;
    public Transform dstRToe;
    public Transform dstRToeNub;
    
    public Transform dstSpine1;
    public Transform dstNeck;
    
    public Transform dstHead;
    public Transform dstHeadNub;
    
    public Transform dstLClavicle;
    public Transform dstLUpperArm;
    public Transform dstLForeArm;
    public Transform dstLHand;
    public Transform dstLFinger0;
    public Transform dstLFinger01;
    public Transform dstLFinger0Nub;
    public Transform dstLFinger1;
    public Transform dstLFinger11;
    public Transform dstLFinger1Nub;
    
    public Transform dstRClavicle;
    public Transform dstRUpperArm;
    public Transform dstRForeArm;
    public Transform dstRHand;
    public Transform dstRFinger0;
    public Transform dstRFinger01;
    public Transform dstRFinger0Nub;
    public Transform dstRFinger1;
    public Transform dstRFinger11;
    public Transform dstRFinger1Nub;

    // Src BoneInfo

    private BoneInfo biSrcRoot;
    private BoneInfo biSrcPelvis;
    private BoneInfo biSrcSpine;

    private BoneInfo biSrcLThigh;
    private BoneInfo biSrcLCalf;
    private BoneInfo biSrcLFoot;
    private BoneInfo biSrcLToe;
    private BoneInfo biSrcLToeNub;

    private BoneInfo biSrcRThigh;
    private BoneInfo biSrcRCalf;
    private BoneInfo biSrcRFoot;
    private BoneInfo biSrcRToe;
    private BoneInfo biSrcRToeNub;

    private BoneInfo biSrcSpine1;
    private BoneInfo biSrcNeck;

    private BoneInfo biSrcHead;
    private BoneInfo biSrcHeadNub;

    private BoneInfo biSrcLClavicle;
    private BoneInfo biSrcLUpperArm;
    private BoneInfo biSrcLForeArm;
    private BoneInfo biSrcLHand;
    private BoneInfo biSrcLFinger0;
    private BoneInfo biSrcLFinger01;
    private BoneInfo biSrcLFinger0Nub;
    private BoneInfo biSrcLFinger1;
    private BoneInfo biSrcLFinger11;
    private BoneInfo biSrcLFinger1Nub;

    private BoneInfo biSrcRClavicle;
    private BoneInfo biSrcRUpperArm;
    private BoneInfo biSrcRForeArm;
    private BoneInfo biSrcRHand;
    private BoneInfo biSrcRFinger0;
    private BoneInfo biSrcRFinger01;
    private BoneInfo biSrcRFinger0Nub;
    private BoneInfo biSrcRFinger1;
    private BoneInfo biSrcRFinger11;
    private BoneInfo biSrcRFinger1Nub;

    // Dst BoneInfo

    private BoneInfo biDstRoot;
    private BoneInfo biDstPelvis;
    private BoneInfo biDstSpine;

    private BoneInfo biDstLThigh;
    private BoneInfo biDstLCalf;
    private BoneInfo biDstLFoot;
    private BoneInfo biDstLToe;
    private BoneInfo biDstLToeNub;

    private BoneInfo biDstRThigh;
    private BoneInfo biDstRCalf;
    private BoneInfo biDstRFoot;
    private BoneInfo biDstRToe;
    private BoneInfo biDstRToeNub;

    private BoneInfo biDstSpine1;
    private BoneInfo biDstNeck;

    private BoneInfo biDstHead;
    private BoneInfo biDstHeadNub;

    private BoneInfo biDstLClavicle;
    private BoneInfo biDstLUpperArm;
    private BoneInfo biDstLForeArm;
    private BoneInfo biDstLHand;
    private BoneInfo biDstLFinger0;
    private BoneInfo biDstLFinger01;
    private BoneInfo biDstLFinger0Nub;
    private BoneInfo biDstLFinger1;
    private BoneInfo biDstLFinger11;
    private BoneInfo biDstLFinger1Nub;

    private BoneInfo biDstRClavicle;
    private BoneInfo biDstRUpperArm;
    private BoneInfo biDstRForeArm;
    private BoneInfo biDstRHand;
    private BoneInfo biDstRFinger0;
    private BoneInfo biDstRFinger01;
    private BoneInfo biDstRFinger0Nub;
    private BoneInfo biDstRFinger1;
    private BoneInfo biDstRFinger11;
    private BoneInfo biDstRFinger1Nub;

    // List
    private List<BoneInfo> srcBoneInfoList;
    private List<BoneInfo> dstBoneInfoList;

    // misc
    private const string duplicatePostfix = "_copy";
    
    [MenuItem("AnimeTool/Translate selected anime")]
    static void CreateWizard()
    {
        ScriptableWizard.DisplayWizard<TranslateSelectedAnime>("Translate animation for another model.", "Exit", "Generate");
    }

    // This is called when the user clicks on the Create(Exit) button.
    void OnWizardCreate()
    {
    }

    // This is called when the wizard is opened or whenever the user changes something in the wizard.
    void OnWizardUpdate()
    {
        helpString = "Please set the bones of both src and dst gameobject \r\n and select src animation file and push generate button!";
    }
    
    // When the user pressed the "Generate" button OnWizardOtherButton is called.
    void OnWizardOtherButton()
    {
        // Initialize list
        srcBoneInfoList = new List<BoneInfo>();
        dstBoneInfoList = new List<BoneInfo>();

        // ===== Set src bone info =====

        biSrcRoot = new BoneInfo();
        if (srcRoot != null)
        {
            biSrcRoot.transform = srcRoot;
            biSrcRoot.length    = -1.0f; // No parent
            biSrcRoot.path      = srcRoot.name;
        }
        srcBoneInfoList.Add(biSrcRoot);

        biSrcPelvis = new BoneInfo();
        if (srcPelvis != null)
        {
            biSrcPelvis.transform = srcPelvis;
            biSrcPelvis.length = (srcPelvis.position - srcRoot.position).magnitude;
            biSrcPelvis.path = srcRoot.name + "/" + srcPelvis.name;
        }
        srcBoneInfoList.Add(biSrcPelvis);
        
        biSrcSpine = new BoneInfo();
        if (srcSpine != null)
        {
            biSrcSpine.transform = srcSpine;
            biSrcSpine.length = (srcSpine.position - srcPelvis.position).magnitude;
            biSrcSpine.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name;
        }
        srcBoneInfoList.Add(biSrcSpine);
        
        // Src LThigh

        biSrcLThigh = new BoneInfo();
        if (srcLThigh != null)
        {
            biSrcLThigh.transform = srcLThigh;
            biSrcLThigh.length = (srcLThigh.position - srcSpine.position).magnitude;
            biSrcLThigh.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcLThigh.name;
        }
        srcBoneInfoList.Add(biSrcLThigh);
        
        biSrcLCalf = new BoneInfo();
        if (srcLCalf != null)
        {
            biSrcLCalf.transform = srcLCalf;
            biSrcLCalf.length = (srcLCalf.position - srcLThigh.position).magnitude;
            biSrcLCalf.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcLThigh.name + "/"
                            + srcLCalf.name;
        }
        srcBoneInfoList.Add(biSrcLCalf);    
        
        biSrcLFoot = new BoneInfo();
        if (srcLFoot != null)
        {
            biSrcLFoot.transform = srcLFoot;
            biSrcLFoot.length = (srcLFoot.position - srcLCalf.position).magnitude;
            biSrcLFoot.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcLThigh.name + "/"
                            + srcLCalf.name + "/" + srcLFoot.name;
        }
        srcBoneInfoList.Add(biSrcLFoot);
        
        biSrcLToe = new BoneInfo();
        if (srcLToe != null)
        {
            biSrcLToe.transform = srcLToe;
            biSrcLToe.length = (srcLToe.position - srcLFoot.position).magnitude;
            biSrcLToe.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcLThigh.name + "/"
                            + srcLCalf.name + "/" + srcLFoot.name + "/" + srcLToe.name;
        }
        srcBoneInfoList.Add(biSrcLToe);

        biSrcLToeNub = new BoneInfo();
        if (srcLToeNub != null)
        {
            biSrcLToeNub.transform = srcLToeNub;
            biSrcLToeNub.length = (srcLToeNub.position - srcLToe.position).magnitude;
            biSrcLToeNub.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcLThigh.name + "/"
                            + srcLCalf.name + "/" + srcLFoot.name + "/" + srcLToe.name + "/" + srcLToeNub.name;
        }
        srcBoneInfoList.Add(biSrcLToeNub);

        // Src RThigh

        biSrcRThigh = new BoneInfo();
        if (srcRThigh != null)
        {
            biSrcRThigh.transform = srcRThigh;
            biSrcRThigh.length = (srcRThigh.position - srcSpine.position).magnitude;
            biSrcRThigh.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcRThigh.name;
        }
        srcBoneInfoList.Add(biSrcRThigh);

        biSrcRCalf = new BoneInfo();
        if (srcRCalf != null)
        {
            biSrcRCalf.transform = srcRCalf;
            biSrcRCalf.length = (srcRCalf.position - srcRThigh.position).magnitude;
            biSrcRCalf.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcRThigh.name + "/"
                            + srcRCalf.name;
        }
        srcBoneInfoList.Add(biSrcRCalf);
        
        biSrcRFoot = new BoneInfo();
        if (srcRFoot != null)
        {
            biSrcRFoot.transform = srcRFoot;
            biSrcRFoot.length = (srcRFoot.position - srcRCalf.position).magnitude;
            biSrcRFoot.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcRThigh.name + "/"
                            + srcRCalf.name + "/" + srcRFoot.name;
        }
        srcBoneInfoList.Add(biSrcRFoot);

        biSrcRToe = new BoneInfo();
        if (srcRToe != null)
        {
            biSrcRToe.transform = srcRToe;
            biSrcRToe.length = (srcRToe.position - srcRFoot.position).magnitude;
            biSrcRToe.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcRThigh.name + "/"
                            + srcRCalf.name + "/" + srcRFoot.name + "/" + srcRToe.name;
        }
        srcBoneInfoList.Add(biSrcRToe);
        
        biSrcRToeNub = new BoneInfo();
        if (srcRToeNub != null)
        {
            biSrcRToeNub.transform = srcRToeNub;
            biSrcRToeNub.length = (srcRToeNub.position - srcRToe.position).magnitude;
            biSrcRToeNub.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcRThigh.name + "/"
                            + srcRCalf.name + "/" + srcRFoot.name + "/" + srcRToe.name + "/" + srcRToeNub.name;
        }
        srcBoneInfoList.Add(biSrcRToeNub);

        // Src Spine1

        biSrcSpine1 = new BoneInfo();
        if (srcSpine1 != null)
        {
            biSrcSpine1.transform = srcSpine1;
            biSrcSpine1.length = (srcSpine1.position - srcSpine.position).magnitude;
            biSrcSpine1.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name;
        }
        srcBoneInfoList.Add(biSrcSpine1);

        biSrcNeck = new BoneInfo();
        if (srcNeck != null)
        {
            biSrcNeck.transform = srcNeck;
            biSrcNeck.length = (srcNeck.position - srcSpine1.position).magnitude;
            biSrcNeck.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name;
        }
        srcBoneInfoList.Add(biSrcNeck);

        biSrcHead = new BoneInfo();
        if (srcHead != null)
        {
            biSrcHead.transform = srcHead;
            biSrcHead.length = (srcHead.position - srcNeck.position).magnitude;
            biSrcHead.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcHead.name;
        }
        srcBoneInfoList.Add(biSrcHead);
            
        biSrcHeadNub = new BoneInfo();
        if (srcHeadNub != null)
        {
            biSrcHeadNub.transform = srcHeadNub;
            biSrcHeadNub.length = (srcHeadNub.position - srcHead.position).magnitude;
            biSrcHeadNub.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcHead.name + "/" + srcHeadNub.name;
        }
        srcBoneInfoList.Add(biSrcHeadNub);

        // Src LClavicle

        biSrcLClavicle = new BoneInfo();
        if (srcLClavicle != null)
        {
            biSrcLClavicle.transform = srcLClavicle;
            biSrcLClavicle.length = (srcLClavicle.position - srcNeck.position).magnitude;
            biSrcLClavicle.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcLClavicle.name;
        }
        srcBoneInfoList.Add(biSrcLClavicle);
        
        biSrcLUpperArm = new BoneInfo();
        if (srcLUpperArm != null)
        {
            biSrcLUpperArm.transform = srcLUpperArm;
            biSrcLUpperArm.length = (srcLUpperArm.position - srcLClavicle.position).magnitude;
            biSrcLUpperArm.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcLClavicle.name + "/" + srcLUpperArm.name;
        }
        srcBoneInfoList.Add(biSrcLUpperArm);
        
        biSrcLForeArm = new BoneInfo();
        if (srcLForeArm != null)
        {
            biSrcLForeArm.transform = srcLForeArm;
            biSrcLForeArm.length = (srcLForeArm.position - srcLUpperArm.position).magnitude;
            biSrcLForeArm.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcLClavicle.name + "/" + srcLUpperArm.name + "/" + srcLForeArm.name;
        }
        srcBoneInfoList.Add(biSrcLForeArm);
        
        biSrcLHand = new BoneInfo();
        if (srcLHand != null)
        {
            biSrcLHand.transform = srcLHand;
            biSrcLHand.length = (srcLHand.position - srcLForeArm.position).magnitude;
            biSrcLHand.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcLClavicle.name + "/" + srcLUpperArm.name + "/" + srcLForeArm.name + "/"
                           + srcLHand.name;
        }
        srcBoneInfoList.Add(biSrcLHand);
        
        biSrcLFinger0 = new BoneInfo();
        if (srcLFinger0 != null)
        {
            biSrcLFinger0.transform = srcLFinger0;
            biSrcLFinger0.length = (srcLFinger0.position - srcLHand.position).magnitude;
            biSrcLFinger0.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcLClavicle.name + "/" + srcLUpperArm.name + "/" + srcLForeArm.name + "/"
                           + srcLHand.name + "/" + srcLFinger0.name;
        }
        srcBoneInfoList.Add(biSrcLFinger0);
        
        biSrcLFinger01 = new BoneInfo();
        if (srcLFinger01 != null)
        {
            biSrcLFinger01.transform = srcLFinger01;
            biSrcLFinger01.length = (srcLFinger01.position - srcLFinger0.position).magnitude;
            biSrcLFinger01.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcLClavicle.name + "/" + srcLUpperArm.name + "/" + srcLForeArm.name + "/"
                           + srcLHand.name + "/" + srcLFinger0.name + "/" + srcLFinger01.name;
        }
        srcBoneInfoList.Add(biSrcLFinger01);
        
        biSrcLFinger0Nub = new BoneInfo();
        if (srcLFinger0Nub != null)
        {
            biSrcLFinger0Nub.transform = srcLFinger0Nub;
            biSrcLFinger0Nub.length = (srcLFinger0Nub.position - srcLFinger01.position).magnitude;
            biSrcLFinger0Nub.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcLClavicle.name + "/" + srcLUpperArm.name + "/" + srcLForeArm.name + "/"
                           + srcLHand.name + "/" + srcLFinger0.name + "/" + srcLFinger01.name + "/" + srcLFinger0Nub.name;
        }
        srcBoneInfoList.Add(biSrcLFinger0Nub);
        
        biSrcLFinger1 = new BoneInfo();
        if (srcLFinger1 != null)
        {
            biSrcLFinger1.transform = srcLFinger1;
            biSrcLFinger1.length = (srcLFinger1.position - srcLHand.position).magnitude;
            biSrcLFinger1.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcLClavicle.name + "/" + srcLUpperArm.name + "/" + srcLForeArm.name + "/"
                           + srcLHand.name + "/" + srcLFinger1.name;
        }
        srcBoneInfoList.Add(biSrcLFinger1);
        
        biSrcLFinger11 = new BoneInfo();
        if (srcLFinger11 != null)
        {
            biSrcLFinger11.transform = srcLFinger11;
            biSrcLFinger11.length = (srcLFinger11.position - srcLFinger1.position).magnitude;
            biSrcLFinger11.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcLClavicle.name + "/" + srcLUpperArm.name + "/" + srcLForeArm.name + "/"
                           + srcLHand.name + "/" + srcLFinger1.name + "/" + srcLFinger11.name;
        }
        srcBoneInfoList.Add(biSrcLFinger11);
        
        biSrcLFinger1Nub = new BoneInfo();
        if (srcLFinger1Nub != null)
        {
            biSrcLFinger1Nub.transform = srcLFinger1Nub;
            biSrcLFinger1Nub.length = (srcLFinger1Nub.position - srcLFinger11.position).magnitude;
            biSrcLFinger1Nub.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcLClavicle.name + "/" + srcLUpperArm.name + "/" + srcLForeArm.name + "/"
                           + srcLHand.name + "/" + srcLFinger1.name + "/" + srcLFinger11.name + "/" + srcLFinger1Nub.name;
        }
        srcBoneInfoList.Add(biSrcLFinger1Nub);

        // Src RClavicle

        biSrcRClavicle = new BoneInfo();
        if (srcRClavicle != null)
        {
            biSrcRClavicle.transform = srcRClavicle;
            biSrcRClavicle.length = (srcRClavicle.position - srcNeck.position).magnitude;
            biSrcRClavicle.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcRClavicle.name;
        }
        srcBoneInfoList.Add(biSrcRClavicle);
            
        biSrcRUpperArm = new BoneInfo();
        if (srcRUpperArm != null)
        {
            biSrcRUpperArm.transform = srcRUpperArm;
            biSrcRUpperArm.length = (srcRUpperArm.position - srcRClavicle.position).magnitude;
            biSrcRUpperArm.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcRClavicle.name + "/" + srcRUpperArm.name;
        }
        srcBoneInfoList.Add(biSrcRUpperArm);
                
        biSrcRForeArm = new BoneInfo();
        if (srcRForeArm != null)
        {
            biSrcRForeArm.transform = srcRForeArm;
            biSrcRForeArm.length = (srcRForeArm.position - srcRUpperArm.position).magnitude;
            biSrcRForeArm.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcRClavicle.name + "/" + srcRUpperArm.name + "/" + srcRForeArm.name;
        }
        srcBoneInfoList.Add(biSrcRForeArm);

        biSrcRHand = new BoneInfo();
        if (srcRHand != null)
        {
            biSrcRHand.transform = srcRHand;
            biSrcRHand.length = (srcRHand.position - srcRForeArm.position).magnitude;
            biSrcRHand.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcRClavicle.name + "/" + srcRUpperArm.name + "/" + srcRForeArm.name + "/"
                           + srcRHand.name;
        }
        srcBoneInfoList.Add(biSrcRHand);
        
        biSrcRFinger0 = new BoneInfo();
        if (srcRFinger0 != null)
        {
            biSrcRFinger0.transform = srcRFinger0;
            biSrcRFinger0.length = (srcRFinger0.position - srcRHand.position).magnitude;
            biSrcRFinger0.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcRClavicle.name + "/" + srcRUpperArm.name + "/" + srcRForeArm.name + "/"
                           + srcRHand.name + "/" + srcRFinger0.name;
        }
        srcBoneInfoList.Add(biSrcRFinger0);
        
        biSrcRFinger01 = new BoneInfo();
        if (srcRFinger01 != null)
        {
            biSrcRFinger01.transform = srcRFinger01;
            biSrcRFinger01.length = (srcRFinger01.position - srcRFinger0.position).magnitude;
            biSrcRFinger01.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcRClavicle.name + "/" + srcRUpperArm.name + "/" + srcRForeArm.name + "/"
                           + srcRHand.name + "/" + srcRFinger0.name + "/" + srcRFinger01.name;
        }
        srcBoneInfoList.Add(biSrcRFinger01);
        
        biSrcRFinger0Nub = new BoneInfo();
        if (srcRFinger0Nub != null)
        {
            biSrcRFinger0Nub.transform = srcRFinger0Nub;
            biSrcRFinger0Nub.length = (srcRFinger0Nub.position - srcRFinger01.position).magnitude;
            biSrcRFinger0Nub.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcRClavicle.name + "/" + srcRUpperArm.name + "/" + srcRForeArm.name + "/"
                           + srcRHand.name + "/" + srcRFinger0.name + "/" + srcRFinger01.name + "/" + srcRFinger0Nub.name;
        }
        srcBoneInfoList.Add(biSrcRFinger0Nub);

        biSrcRFinger1 = new BoneInfo();
        if (srcRFinger1 != null)
        {
            biSrcRFinger1.transform = srcRFinger1;
            biSrcRFinger1.length = (srcRFinger1.position - srcRHand.position).magnitude;
            biSrcRFinger1.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcRClavicle.name + "/" + srcRUpperArm.name + "/" + srcRForeArm.name + "/"
                           + srcRHand.name + "/" + srcRFinger1.name;
        }
        srcBoneInfoList.Add(biSrcRFinger1);
        
        biSrcRFinger11 = new BoneInfo();
        if (srcRFinger11 != null)
        {
            biSrcRFinger11.transform = srcRFinger11;
            biSrcRFinger11.length = (srcRFinger11.position - srcRFinger1.position).magnitude;
            biSrcRFinger11.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcRClavicle.name + "/" + srcRUpperArm.name + "/" + srcRForeArm.name + "/"
                           + srcRHand.name + "/" + srcRFinger1.name + "/" + srcRFinger11.name;
        }
        srcBoneInfoList.Add(biSrcRFinger11);
        
        biSrcRFinger1Nub = new BoneInfo();
        if (srcRFinger1Nub != null)
        {
            biSrcRFinger1Nub.transform = srcRFinger1Nub;
            biSrcRFinger1Nub.length = (srcRFinger1Nub.position - srcRFinger11.position).magnitude;
            biSrcRFinger1Nub.path = srcRoot.name + "/" + srcPelvis.name + "/" + srcSpine.name + "/" + srcSpine1.name + "/"
                           + srcNeck.name + "/" + srcRClavicle.name + "/" + srcRUpperArm.name + "/" + srcRForeArm.name + "/"
                           + srcRHand.name + "/" + srcRFinger1.name + "/" + srcRFinger11.name + "/" + srcRFinger1Nub.name;
        }
        srcBoneInfoList.Add(biSrcRFinger1Nub);

        // ===== Set dst bone info =====

        biDstRoot = new BoneInfo();
        if (dstRoot != null)
        {
            biDstRoot.transform = dstRoot;
            biDstRoot.length = -1.0f; // no parent
            biDstRoot.path = dstRoot.name;
        }
        dstBoneInfoList.Add(biDstRoot);

        biDstPelvis = new BoneInfo();
        if (dstPelvis != null)
        {
            biDstPelvis.transform = dstPelvis;
            biDstPelvis.length = (dstPelvis.position - dstRoot.position).magnitude;
            biDstPelvis.path = dstRoot.name + "/" + dstPelvis.name;
        }
        dstBoneInfoList.Add(biDstPelvis);

        biDstSpine = new BoneInfo();
        if (dstSpine != null)
        {
            biDstSpine.transform = dstSpine;
            biDstSpine.length = (dstSpine.position - dstPelvis.position).magnitude;
            biDstSpine.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name;
        }
        dstBoneInfoList.Add(biDstSpine);

        // Dst LThigh

        biDstLThigh = new BoneInfo();
        if (dstLThigh != null)
        {
            biDstLThigh.transform = dstLThigh;
            biDstLThigh.length = (dstLThigh.position - dstSpine.position).magnitude;
            biDstLThigh.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstLThigh.name;
        }
        dstBoneInfoList.Add(biDstLThigh);

        biDstLCalf = new BoneInfo();
        if (dstLCalf != null)
        {
            biDstLCalf.transform = dstLCalf;
            biDstLCalf.length = (dstLCalf.position - dstLThigh.position).magnitude;
            biDstLCalf.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstLThigh.name + "/"
                            + dstLCalf.name;
        }
        dstBoneInfoList.Add(biDstLCalf);

        biDstLFoot = new BoneInfo();
        if (dstLFoot != null)
        {
            biDstLFoot.transform = dstLFoot;
            biDstLFoot.length = (dstLFoot.position - dstLCalf.position).magnitude;
            biDstLFoot.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstLThigh.name + "/"
                            + dstLCalf.name + "/" + dstLFoot.name;
        }
        dstBoneInfoList.Add(biDstLFoot);

        biDstLToe = new BoneInfo();
        if (dstLToe != null)
        {
            biDstLToe.transform = dstLToe;
            biDstLToe.length = (dstLToe.position - dstLFoot.position).magnitude;
            biDstLToe.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstLThigh.name + "/"
                            + dstLCalf.name + "/" + dstLFoot.name + "/" + dstLToe.name;
        }
        dstBoneInfoList.Add(biDstLToe);

        biDstLToeNub = new BoneInfo();
        if (dstLToeNub != null)
        {
            biDstLToeNub.transform = dstLToeNub;
            biDstLToeNub.length = (dstLToeNub.position - dstLToe.position).magnitude;
            biDstLToeNub.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstLThigh.name + "/"
                            + dstLCalf.name + "/" + dstLFoot.name + "/" + dstLToe.name + "/" + dstLToeNub.name;
        }
        dstBoneInfoList.Add(biDstLToeNub);

        // Dst RThigh

        biDstRThigh = new BoneInfo();
        if (dstRThigh != null)
        {
            biDstRThigh.transform = dstRThigh;
            biDstRThigh.length = (dstRThigh.position - dstSpine.position).magnitude;
            biDstRThigh.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstRThigh.name;
        }
        dstBoneInfoList.Add(biDstRThigh);

        biDstRCalf = new BoneInfo();
        if (dstRCalf != null)
        {
            biDstRCalf.transform = dstRCalf;
            biDstRCalf.length = (dstRCalf.position - dstRThigh.position).magnitude;
            biDstRCalf.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstRThigh.name + "/"
                            + dstRCalf.name;
        }
        dstBoneInfoList.Add(biDstRCalf);

        biDstRFoot = new BoneInfo();
        if (dstRFoot != null)
        {
            biDstRFoot.transform = dstRFoot;
            biDstRFoot.length = (dstRFoot.position - dstRCalf.position).magnitude;
            biDstRFoot.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstRThigh.name + "/"
                            + dstRCalf.name + "/" + dstRFoot.name;
        }
        dstBoneInfoList.Add(biDstRFoot);

        biDstRToe = new BoneInfo();
        if (dstRToe != null)
        {
            biDstRToe.transform = dstRToe;
            biDstRToe.length = (dstRToe.position - dstRFoot.position).magnitude;
            biDstRToe.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstRThigh.name + "/"
                            + dstRCalf.name + "/" + dstRFoot.name + "/" + dstRToe.name;
        }
        dstBoneInfoList.Add(biDstRToe);

        biDstRToeNub = new BoneInfo();
        if (dstRToeNub != null)
        {
            biDstRToeNub.transform = dstRToeNub;
            biDstRToeNub.length = (dstRToeNub.position - dstRToe.position).magnitude;
            biDstRToeNub.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstRThigh.name + "/"
                            + dstRCalf.name + "/" + dstRFoot.name + "/" + dstRToe.name + "/" + dstRToeNub.name;
        }
        dstBoneInfoList.Add(biDstRToeNub);

        // Dst Spine1

        biDstSpine1 = new BoneInfo();
        if (dstSpine1 != null)
        {
            biDstSpine1.transform = dstSpine1;
            biDstSpine1.length = (dstSpine1.position - dstSpine.position).magnitude;
            biDstSpine1.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name;
        }
        dstBoneInfoList.Add(biDstSpine1);

        biDstNeck = new BoneInfo();
        if (dstNeck != null)
        {
            biDstNeck.transform = dstNeck;
            biDstNeck.length = (dstNeck.position - dstSpine1.position).magnitude;
            biDstNeck.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name;
        }
        dstBoneInfoList.Add(biDstNeck);

        biDstHead = new BoneInfo();
        if (dstHead != null)
        {
            biDstHead.transform = dstHead;
            biDstHead.length = (dstHead.position - dstNeck.position).magnitude;
            biDstHead.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstHead.name;
        }
        dstBoneInfoList.Add(biDstHead);

        biDstHeadNub = new BoneInfo();
        if (dstHeadNub != null)
        {
            biDstHeadNub.transform = dstHeadNub;
            biDstHeadNub.length = (dstHeadNub.position - dstHead.position).magnitude;
            biDstHeadNub.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstHead.name + "/" + dstHeadNub.name;
        }
        dstBoneInfoList.Add(biDstHeadNub);

        // Dst LClavicle

        biDstLClavicle = new BoneInfo();
        if (dstLClavicle != null)
        {
            biDstLClavicle.transform = dstLClavicle;
            biDstLClavicle.length = (dstLClavicle.position - dstNeck.position).magnitude;
            biDstLClavicle.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstLClavicle.name;
        }
        dstBoneInfoList.Add(biDstLClavicle);

        biDstLUpperArm = new BoneInfo();
        if (dstLUpperArm != null)
        {
            biDstLUpperArm.transform = dstLUpperArm;
            biDstLUpperArm.length = (dstLUpperArm.position - dstLClavicle.position).magnitude;
            biDstLUpperArm.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstLClavicle.name + "/" + dstLUpperArm.name;
        }
        dstBoneInfoList.Add(biDstLUpperArm);

        biDstLForeArm = new BoneInfo();
        if (dstLForeArm != null)
        {
            biDstLForeArm.transform = dstLForeArm;
            biDstLForeArm.length = (dstLForeArm.position - dstLUpperArm.position).magnitude;
            biDstLForeArm.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstLClavicle.name + "/" + dstLUpperArm.name + "/" + dstLForeArm.name;
        }
        dstBoneInfoList.Add(biDstLForeArm);

        biDstLHand = new BoneInfo();
        if (dstLHand != null)
        {
            biDstLHand.transform = dstLHand;
            biDstLHand.length = (dstLHand.position - dstLForeArm.position).magnitude;
            biDstLHand.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstLClavicle.name + "/" + dstLUpperArm.name + "/" + dstLForeArm.name + "/"
                           + dstLHand.name;
        }
        dstBoneInfoList.Add(biDstLHand);

        biDstLFinger0 = new BoneInfo();
        if (dstLFinger0 != null)
        {
            biDstLFinger0.transform = dstLFinger0;
            biDstLFinger0.length = (dstLFinger0.position - dstLHand.position).magnitude;
            biDstLFinger0.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstLClavicle.name + "/" + dstLUpperArm.name + "/" + dstLForeArm.name + "/"
                           + dstLHand.name + "/" + dstLFinger0.name;
        }
        dstBoneInfoList.Add(biDstLFinger0);

        biDstLFinger01 = new BoneInfo();
        if (dstLFinger01 != null)
        {
            biDstLFinger01.transform = dstLFinger01;
            biDstLFinger01.length = (dstLFinger01.position - dstLFinger0.position).magnitude;
            biDstLFinger01.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstLClavicle.name + "/" + dstLUpperArm.name + "/" + dstLForeArm.name + "/"
                           + dstLHand.name + "/" + dstLFinger0.name + "/" + dstLFinger01.name;
        }
        dstBoneInfoList.Add(biDstLFinger01);

        biDstLFinger0Nub = new BoneInfo();
        if (dstLFinger0Nub != null)
        {
            biDstLFinger0Nub.transform = dstLFinger0Nub;
            biDstLFinger0Nub.length = (dstLFinger0Nub.position - dstLFinger01.position).magnitude;
            biDstLFinger0Nub.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstLClavicle.name + "/" + dstLUpperArm.name + "/" + dstLForeArm.name + "/"
                           + dstLHand.name + "/" + dstLFinger0.name + "/" + dstLFinger01.name + "/" + dstLFinger0Nub.name;
        }
        dstBoneInfoList.Add(biDstLFinger0Nub);

        biDstLFinger1 = new BoneInfo();
        if (dstLFinger1 != null)
        {
            biDstLFinger1.transform = dstLFinger1;
            biDstLFinger1.length = (dstLFinger1.position - dstLHand.position).magnitude;
            biDstLFinger1.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstLClavicle.name + "/" + dstLUpperArm.name + "/" + dstLForeArm.name + "/"
                           + dstLHand.name + "/" + dstLFinger1.name;
        }
        dstBoneInfoList.Add(biDstLFinger1);

        biDstLFinger11 = new BoneInfo();
        if (dstLFinger11 != null)
        {
            biDstLFinger11.transform = dstLFinger11;
            biDstLFinger11.length = (dstLFinger11.position - dstLFinger1.position).magnitude;
            biDstLFinger11.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstLClavicle.name + "/" + dstLUpperArm.name + "/" + dstLForeArm.name + "/"
                           + dstLHand.name + "/" + dstLFinger1.name + "/" + dstLFinger11.name;
        }
        dstBoneInfoList.Add(biDstLFinger11);

        biDstLFinger1Nub = new BoneInfo();
        if (dstLFinger1Nub != null)
        {
            biDstLFinger1Nub.transform = dstLFinger1Nub;
            biDstLFinger1Nub.length = (dstLFinger1Nub.position - dstLFinger11.position).magnitude;
            biDstLFinger1Nub.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstLClavicle.name + "/" + dstLUpperArm.name + "/" + dstLForeArm.name + "/"
                           + dstLHand.name + "/" + dstLFinger1.name + "/" + dstLFinger11.name + "/" + dstLFinger1Nub.name;
        }
        dstBoneInfoList.Add(biDstLFinger1Nub);

        // Dst RClavicle

        biDstRClavicle = new BoneInfo();
        if (dstRClavicle != null)
        {
            biDstRClavicle.transform = dstRClavicle;
            biDstRClavicle.length = (dstRClavicle.position - dstNeck.position).magnitude;
            biDstRClavicle.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstRClavicle.name;
        }
        dstBoneInfoList.Add(biDstRClavicle);

        biDstRUpperArm = new BoneInfo();
        if (dstRUpperArm != null)
        {
            biDstRUpperArm.transform = dstRUpperArm;
            biDstRUpperArm.length = (dstRUpperArm.position - dstRClavicle.position).magnitude;
            biDstRUpperArm.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstRClavicle.name + "/" + dstRUpperArm.name;
        }
        dstBoneInfoList.Add(biDstRUpperArm);

        biDstRForeArm = new BoneInfo();
        if (dstRForeArm != null)
        {
            biDstRForeArm.transform = dstRForeArm;
            biDstRForeArm.length = (dstRForeArm.position - dstRUpperArm.position).magnitude;
            biDstRForeArm.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstRClavicle.name + "/" + dstRUpperArm.name + "/" + dstRForeArm.name;
        }
        dstBoneInfoList.Add(biDstRForeArm);

        biDstRHand = new BoneInfo();
        if (dstRHand != null)
        {
            biDstRHand.transform = dstRHand;
            biDstRHand.length = (dstRHand.position - dstRForeArm.position).magnitude;
            biDstRHand.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstRClavicle.name + "/" + dstRUpperArm.name + "/" + dstRForeArm.name + "/"
                           + dstRHand.name;
        }
        dstBoneInfoList.Add(biDstRHand);

        biDstRFinger0 = new BoneInfo();
        if (dstRFinger0 != null)
        {
            biDstRFinger0.transform = dstRFinger0;
            biDstRFinger0.length = (dstRFinger0.position - dstRHand.position).magnitude;
            biDstRFinger0.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstRClavicle.name + "/" + dstRUpperArm.name + "/" + dstRForeArm.name + "/"
                           + dstRHand.name + "/" + dstRFinger0.name;
        }
        dstBoneInfoList.Add(biDstRFinger0);

        biDstRFinger01 = new BoneInfo();
        if (dstRFinger01 != null)
        {
            biDstRFinger01.transform = dstRFinger01;
            biDstRFinger01.length = (dstRFinger01.position - dstRFinger0.position).magnitude;
            biDstRFinger01.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstRClavicle.name + "/" + dstRUpperArm.name + "/" + dstRForeArm.name + "/"
                           + dstRHand.name + "/" + dstRFinger0.name + "/" + dstRFinger01.name;
        }
        dstBoneInfoList.Add(biDstRFinger01);

        biDstRFinger0Nub = new BoneInfo();
        if (dstRFinger0Nub != null)
        {
            biDstRFinger0Nub.transform = dstRFinger0Nub;
            biDstRFinger0Nub.length = (dstRFinger0Nub.position - dstRFinger01.position).magnitude;
            biDstRFinger0Nub.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstRClavicle.name + "/" + dstRUpperArm.name + "/" + dstRForeArm.name + "/"
                           + dstRHand.name + "/" + dstRFinger0.name + "/" + dstRFinger01.name + "/" + dstRFinger0Nub.name;
        }
        dstBoneInfoList.Add(biDstRFinger0Nub);

        biDstRFinger1 = new BoneInfo();
        if (dstRFinger1 != null)
        {
            biDstRFinger1.transform = dstRFinger1;
            biDstRFinger1.length = (dstRFinger1.position - dstRHand.position).magnitude;
            biDstRFinger1.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstRClavicle.name + "/" + dstRUpperArm.name + "/" + dstRForeArm.name + "/"
                           + dstRHand.name + "/" + dstRFinger1.name;
        }
        dstBoneInfoList.Add(biDstRFinger1);

        biDstRFinger11 = new BoneInfo();
        if (dstRFinger11 != null)
        {
            biDstRFinger11.transform = dstRFinger11;
            biDstRFinger11.length = (dstRFinger11.position - dstRFinger1.position).magnitude;
            biDstRFinger11.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstRClavicle.name + "/" + dstRUpperArm.name + "/" + dstRForeArm.name + "/"
                           + dstRHand.name + "/" + dstRFinger1.name + "/" + dstRFinger11.name;
        }
        dstBoneInfoList.Add(biDstRFinger11);

        biDstRFinger1Nub = new BoneInfo();
        if (dstRFinger1Nub != null)
        {
            biDstRFinger1Nub.transform = dstRFinger1Nub;
            biDstRFinger1Nub.length = (dstRFinger1Nub.position - dstRFinger11.position).magnitude;
            biDstRFinger1Nub.path = dstRoot.name + "/" + dstPelvis.name + "/" + dstSpine.name + "/" + dstSpine1.name + "/"
                           + dstNeck.name + "/" + dstRClavicle.name + "/" + dstRUpperArm.name + "/" + dstRForeArm.name + "/"
                           + dstRHand.name + "/" + dstRFinger1.name + "/" + dstRFinger11.name + "/" + dstRFinger1Nub.name;
        }
        dstBoneInfoList.Add(biDstRFinger1Nub);




        if (srcBoneInfoList.Count != dstBoneInfoList.Count)
        {
            Debug.LogError("ERROR: srcBoneInfoList.count is not same as dstBoneInfoList.count!");
        }

        // Duplicate Anime

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
        string copyPath  = importedPath.Substring(0, importedPath.LastIndexOf("/"));
        copyPath        += "/" + imported.name + duplicatePostfix + ".anim";

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
            float coef = 1.0f;

            for (int k = 0; k < srcBoneInfoList.Count; k++)
            {
                if (curveDatas[i].path == srcBoneInfoList[k].path)
                {
                    // replace path
                    curveDatas[i].path = dstBoneInfoList[k].path;

                    if (srcBoneInfoList[k].length > 0.001)
                    {
                        coef = dstBoneInfoList[k].length / srcBoneInfoList[k].length;
                    }
                }
            }

            if ( curveDatas[i].propertyName == "m_LocalPosition.x"
              || curveDatas[i].propertyName == "m_LocalPosition.y"
              || curveDatas[i].propertyName == "m_LocalPosition.z")
            {
                AnimationCurve curveTmp = new AnimationCurve();

                for (int k = 0; k < curveDatas[i].curve.length; k++)
                {
                    Keyframe keyTmp = new Keyframe(curveDatas[i].curve[k].time,
                                                   curveDatas[i].curve[k].value * coef * scale, // adjust value
                                                   curveDatas[i].curve[k].inTangent,
                                                   curveDatas[i].curve[k].outTangent);
                    curveTmp.AddKey(keyTmp);
                }

                AnimationUtility.SetEditorCurve(
                    copy,
                    curveDatas[i].path,
                    curveDatas[i].type,
                    curveDatas[i].propertyName,
                    curveTmp // curveDatas[i].curve
                );
            }
            else
            {
                AnimationUtility.SetEditorCurve(
                    copy,
                    curveDatas[i].path,
                    curveDatas[i].type,
                    curveDatas[i].propertyName,
                    curveDatas[i].curve
                );
            }
        }

        Debug.Log("Translating animation into " + copy.name + " is done");
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
