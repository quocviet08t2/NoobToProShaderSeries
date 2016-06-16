// Additive blending, the code for DstFactor has to be one and the code
// for SrcFactor must not depend on the pixel color in the framebuffer
//	- One
//	- SrcColor
//	- SrcAlpha
//  - OneMinusSrcColor
//	- ONeMinusSrcAlpha
Shader "CgPrograming/3.Order-Independent Transparent/1.AdditiveBlending"
{
	SubShader
	{
		Tags{ "Queue" = "Transparent" }
		// draw after all opaque geometry has been drawn
		Pass
		{
			Cull Off // draw front and back faces
			ZWrite Off // don't write to depth buffer
					   // in order not to occlude other objects
			Blend SrcAlpha One // additive blending

			CGPROGRAM

#pragma vertex vert
#pragma fragment frag

			float4 vert(float4 vertexPos : POSITION) : SV_POSITION
			{
				return mul(UNITY_MATRIX_MVP, vertexPos);
			}

			float4 frag(void) : COLOR
			{
				return float4(1.0, 0.0, 0.0, 0.3);
			}

			ENDCG
		}
	}
}
