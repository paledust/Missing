using UnityEngine;  
public class DoubleVisionEffect : MonoBehaviour  
{  
    public float blurAmount = 0.8f;  
    public Shader shader;  
    private Material mat;  
    public RenderTexture accumTexture;  
    void Start()  
    {  
        mat = new Material(shader); //创建一个材质  
        mat.hideFlags = HideFlags.HideAndDontSave;  
    }  
    void OnRenderImage (RenderTexture src, RenderTexture dst)  
    {  
        if (accumTexture == null)  
        {  
            accumTexture = new RenderTexture(src.width, src.height, 0);  
            accumTexture.hideFlags = HideFlags.HideAndDontSave;  
            Graphics.Blit( src, accumTexture );     //将最初的屏幕画面复制到accumTexture里面  
        }  
        blurAmount = Mathf.Clamp( blurAmount, 0.0f, 1f );     
        mat.SetTexture("_AccumTex", accumTexture);  //指定着色器中参数_AccumTex为accumTexture  
        mat.SetFloat("_AccumAmt", blurAmount);      //设置着色器中参数_AccumAmt为blurAmount

        Graphics.Blit (src, accumTexture, mat);     //将屏幕当前画面与accumTexture合并  
        Graphics.Blit(accumTexture, dst);           //将合并后的最终画面输出到dst  
    }  
}  