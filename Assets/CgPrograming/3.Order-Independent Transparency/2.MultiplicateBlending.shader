// Additive blending, the code for SrcFactor has to be Zero and the code
// for DstFactor must depend on the fragment color
//	- SrcColor
//	- SrcAlpha
//  - OneMinusSrcColor
//	- OneMinusSrcAlpha
Shader "CgPrograming/3.Order-Independent Transparent/2.MultiplicateBlending"
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
			Blend Zero OneMinusSrcAlpha // additive blending

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
