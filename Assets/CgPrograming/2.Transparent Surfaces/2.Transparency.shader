// About blending
Shader "CgPrograming/Transparent Surfaces/2.Transparency"
{
	SubShader
	{
		Tags { "Queue" = "Transparent"}

		Pass
		{
			Cull Front

			ZWrite Off
			Blend SrcAlpha OneMinusSrcAlpha

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

				return float4(0.0, 1.0, 0.0, 0.3); // green
			}

			ENDCG
		}

		Pass
			{
				Cull Back

				ZWrite Off
				Blend SrcAlpha OneMinusSrcAlpha

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

				return float4(1.0, 0.0, 0.0, 0.3);
			}

				ENDCG
			}
	}
}
