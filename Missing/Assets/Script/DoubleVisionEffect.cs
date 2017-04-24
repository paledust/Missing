using UnityEngine;
public class DoubleVisionEffect{
    private float blurAmount = 0.8f;
    private Shader shader;
    private Material mat;
    private RenderTexture accumTexture;

    public DoubleVisionEffect(Shader Tar_Shader = null, float _BlurAmount = 0.8f){
        blurAmount = _BlurAmount;
        shader = Tar_Shader;
        mat = new Material(shader);
        mat.hideFlags = HideFlags.HideAndDontSave;
    }

    public void _OnRenderImage (RenderTexture src, RenderTexture dst){
        if(accumTexture == null){
            accumTexture = new RenderTexture(src.width, src.height, 0);
            accumTexture.hideFlags = HideFlags.HideAndDontSave;
            Graphics.Blit( src, accumTexture);
        }
        blurAmount = Mathf.Clamp( blurAmount, 0.0f, 1f );
        mat.SetFloat("_BlurAmount", blurAmount);
        mat.SetTexture("_AccumTex", accumTexture);
        mat.SetFloat("_AccumAmt", blurAmount);

        Graphics.Blit (src, accumTexture, mat);
        Graphics.Blit(accumTexture, dst);
    }
    public void SET_BlurAmount(float _blurAmount){
        blurAmount = _blurAmount;
    }
    public float GET_BlurAmount(){
        return blurAmount;
    }
}