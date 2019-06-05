// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

///Let's first focus on the discard instruction in the fragment shader. This
//instruction basically just discards the processed fragment. (This was called
//a fragment “kill” in earlier shading languages; I can understand that the
//fragments prefer the term “discard”.) Depending on the hardware, this can be a
//quite expensive technique in the sense that rendering might perform considerably
//worse as soon as there is one shader that includes a discard instruction
//(regardless of how many fragments are actually discarded, just the presence of
//the instruction may result in the deactivation of some important
//optimizations). Therefore, you should avoid this instruction whenever possible
//but in particular when you run into performance problems.
Shader "CgPrograming/Transparent Surfaces/Cg shader using discard"
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
				float4 posInObjectCoords : TEXCOORD0;
			};

			vertexOutput vert(vertexInput input)
			{
				vertexOutput output;

				output.pos = UnityObjectToClipPos(input.vertex);
				output.posInObjectCoords = mul(unity_ObjectToWorld, input.vertex);

				return output;
			}

			float4 frag(vertexOutput input) : COLOR
			{
				if (input.posInObjectCoords.y > 0.0)
				{
					discard; // drop the fragment if y coordinate > 0
				}

				return float4(0.0, 0.0, 1.0, 1.0); // green
			}

			ENDCG
		}
	}
}
