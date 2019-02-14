using UnityEngine;

[RequireComponent(typeof(Camera))]
public class EquirectRenderer : MonoBehaviour
{
    RenderTexture m_cubemap;

	[SerializeField]
    RenderTexture m_EquirectTexture; //このテクスチャをCanvasなどを使って最前面に描画

    Camera m_Camera;

     void Start()
    {
        m_Camera = this.GetComponent<Camera>();

        m_cubemap = new RenderTexture(1024, 1024, 24);
        m_cubemap.dimension = UnityEngine.Rendering.TextureDimension.Cube;  //Cubemap形式に設定
    }

    private void LateUpdate()
    {
        m_Camera.RenderToCubemap(m_cubemap);    //カメラの映像をCubemapに撮像

        m_cubemap.ConvertToEquirect(m_EquirectTexture); //CubemapをEquirectangularに変換
    }
}

