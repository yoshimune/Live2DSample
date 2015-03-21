using UnityEngine;
using System;
using System.Collections;
using live2d;
using live2d.framework;

[ExecuteInEditMode]
public class SimpleModel : MonoBehaviour 
{
    public TextAsset mocFile;
    public TextAsset physicsFile;
    public Texture2D[] textureFiles;
	
	private Live2DModelUnity live2DModel;
    private EyeBlinkMotion eyeBlink = new EyeBlinkMotion();
    private L2DTargetPoint dragMgr = new L2DTargetPoint();
    private L2DPhysics physics;
    private Matrix4x4 live2DCanvasPos; 
    private AMotion motion = new Live2DMotion();

    private float faceX = 0;//  顔の向き -1..1
    private float faceY = 0;



    enum Expression {
        Usually,
        Smile,
        Angly
    }
	
	void Start () 
	{
		Live2D.init();

        load();

	}

    void load()
    {
        live2DModel = Live2DModelUnity.loadModel(mocFile.bytes);

        for (int i = 0; i < textureFiles.Length; i++)
        {
            live2DModel.setTexture(i, textureFiles[i]);
        }

        float modelWidth = live2DModel.getCanvasWidth();
        live2DCanvasPos = Matrix4x4.Ortho(0, modelWidth, modelWidth, 0, -50.0f, 50.0f);

        if (physicsFile != null) physics = L2DPhysics.load(physicsFile.bytes);
    }
    

    void Update()
    {
        var pos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
        {
            tapModel(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            dragMgr.Set(pos.x/Screen.width*2-1, pos.y/Screen.height*2-1);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            dragMgr.Set(0, 0);
        }
    }

	
	void OnRenderObject()
	{
        if (live2DModel == null)
        {
            load();
        }

        live2DModel.setMatrix(transform.localToWorldMatrix * live2DCanvasPos);

        if ( ! Application.isPlaying)
        {
            live2DModel.update();
            live2DModel.draw();
            return;
        }

        updateAngle();
        breath ();

        eyeBlink.setParam(live2DModel);

        if (physics != null) physics.updateParam(live2DModel);

		live2DModel.update();
		live2DModel.draw();
	}

     void updateAngle ()
    {
        dragMgr.update();

        live2DModel.setParamFloat( "PARAM_ANGLE_X" , dragMgr.getX()*30 ) ;
        live2DModel.setParamFloat("PARAM_ANGLE_Y", dragMgr.getY() * 30);
        
        live2DModel.setParamFloat("PARAM_BODY_ANGLE_X", dragMgr.getX() * 10);

        //live2DModel.setParamFloat("PARAM_EYE_BALL_X", -dragMgr.getX());
        //live2DModel.setParamFloat("PARAM_EYE_BALL_Y", -dragMgr.getY());
    }

     void breath()
    {
        double timeSec = UtSystem.getUserTimeMSec() / 1000.0;
        double t = timeSec * 2 * Math.PI;
        live2DModel.setParamFloat("PARAM_BREATH", (float)(0.5f + 0.5f * Math.Sin(t / 3.0)));
    }

    void tapModel(Vector3 mousePosition)
    {
        const String FACE_COLLIDER = "FaceCollider";
        const String TITS_COLLIDER = "TitsCollider";

        Collider2D collider = Physics2D.OverlapPoint(Camera.main.ScreenToWorldPoint(mousePosition));
        if (!collider) {
            updateExpression(Expression.Usually);
            return;
        }

        GameObject obj = collider.transform.gameObject;
        Debug.Log (obj.name);

        if (collider) {
            switch (obj.name)
            {
            case FACE_COLLIDER:
                updateExpression(Expression.Smile);
                break;

            case TITS_COLLIDER:
                updateExpression(Expression.Angly);
                break;

            default:
                updateExpression(Expression.Usually);
                break;
            }
        }
    }

     void tapFace()
    {

    }

    void tapTits()
    {
    }

    void updateExpression(Expression  expression)
    {
        switch (expression) {
        case Expression.Usually:
            switchExpressionUsually();
            break;
        case Expression.Smile:
            switchExpressionSmile();
            break;
        case Expression.Angly:
            switchExpressionAngly();
            break;
        }
    }

    void switchExpressionUsually()
    {
        live2DModel.setParamFloat("PARAM_EYE_L_OPEN", 2);
        live2DModel.setParamFloat("PARAM_EYE_R_OPEN", 2);
        live2DModel.setParamFloat("PARAM_EYE_L_SMILE", 0);
        live2DModel.setParamFloat("PARAM_EYE_R_SMILE", 0);
        live2DModel.setParamFloat("PARAM_BROW_L_ANGLE", 0);
        live2DModel.setParamFloat("PARAM_BROW_R_ANGLE", 0);
        live2DModel.setParamFloat("PARAM_BROW_L_FORM", 0);
        live2DModel.setParamFloat("PARAM_BROW_R_FORM", 0);
        live2DModel.setParamFloat("PARAM_BROW_L_Y", 0);
        live2DModel.setParamFloat("PARAM_BROW_R_Y", 0);
        live2DModel.setParamFloat("PARAM_MOUTH_FORM", 1);
        live2DModel.setParamFloat("PARAM_TERE", 0);
    }

    void switchExpressionSmile()
    {
        live2DModel.setParamFloat("PARAM_EYE_L_OPEN", 0);
        live2DModel.setParamFloat("PARAM_EYE_R_OPEN", 0);
        live2DModel.setParamFloat("PARAM_EYE_L_SMILE", 1);
        live2DModel.setParamFloat("PARAM_EYE_R_SMILE", 1);
        live2DModel.setParamFloat("PARAM_BROW_L_ANGLE", 0);
        live2DModel.setParamFloat("PARAM_BROW_R_ANGLE", 0);
        live2DModel.setParamFloat("PARAM_BROW_L_FORM", 1);
        live2DModel.setParamFloat("PARAM_BROW_R_FORM", 1);
        live2DModel.setParamFloat("PARAM_BROW_L_Y", 0);
        live2DModel.setParamFloat("PARAM_BROW_R_Y", 0);
        live2DModel.setParamFloat("PARAM_MOUTH_FORM", 1);
        live2DModel.setParamFloat("PARAM_TERE", 1);
    }

    void switchExpressionAngly()
    {
        live2DModel.setParamFloat("PARAM_EYE_L_OPEN", 0.8f);
        live2DModel.setParamFloat("PARAM_EYE_R_OPEN", 0.8f);
        live2DModel.setParamFloat("PARAM_EYE_L_SMILE", 0);
        live2DModel.setParamFloat("PARAM_EYE_R_SMILE", 0);
        live2DModel.setParamFloat("PARAM_BROW_L_ANGLE", -1);
        live2DModel.setParamFloat("PARAM_BROW_R_ANGLE", -1);
        live2DModel.setParamFloat("PARAM_BROW_L_FORM", -1);
        live2DModel.setParamFloat("PARAM_BROW_R_FORM", -1);
        live2DModel.setParamFloat("PARAM_BROW_L_Y", -1);
        live2DModel.setParamFloat("PARAM_BROW_R_Y", -1);
        live2DModel.setParamFloat("PARAM_MOUTH_FORM", -1);
        live2DModel.setParamFloat("PARAM_TERE", 1);
    }
}