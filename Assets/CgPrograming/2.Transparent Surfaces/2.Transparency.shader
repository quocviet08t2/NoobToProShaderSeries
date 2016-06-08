// About blending
Shader "CgPrograming/Transparent Surfaces/2.Transparency"
{
	SubShader
	{
		Pass
		{
			Cull Off // turn off triangle culling, alternatives are:
				 // Cull Back (or nothing): cull only back faces
				 // Cull Front : cull only front faces
			CGPROGRAM

#pragma vertex vert
#pragma fragment frag

			struct vertexInput
			{
				float4 vertex : POSITION;
			};

			struct vertexOutput
			{
				float4 pos : SV_POSITION;
			};

			vertexOutput vert(vertexInput input)
			{
				vertexOutput output;

				output.pos = mul(UNITY_MATRIX_MVP, input.vertex);

				return output;
			}

			float4 frag(vertexOutput input) : COLOR
			{

				return float4(0.0, 0.0, 1.0, 1.0); // green
			}

			ENDCG
		}
	}
}
