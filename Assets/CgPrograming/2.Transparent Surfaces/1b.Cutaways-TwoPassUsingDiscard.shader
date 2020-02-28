// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'
// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "CgPrograming/Transparent Surfaces/Cg shader with two passes using discard"
{
    SubShader
    {
        Pass
        {
            Cull Front // turn off triangle culling, alternatives are:
            // Cull Back (or nothing): cull only back faces
            // Cull Front : cull only front faces
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            struct vertexInput
            {
                float4 vertex: POSITION;
            };

            struct vertexOutput
            {
                float4 pos: SV_POSITION;
                float4 posInObjectCoords: TEXCOORD0;
            };

            vertexOutput vert(vertexInput input)
            {
                vertexOutput output;

                output.pos = UnityObjectToClipPos(input.vertex);
                output.posInObjectCoords = mul(unity_ObjectToWorld, input.vertex);

                return output;
            }

            float4 frag(vertexOutput input): COLOR
            {
                if (input.posInObjectCoords.y > 0.0)
                {
                    discard; // drop the fragment if y coordinate > 0
                }

                return float4(1.0, 0.0, 0.0, 1.0); // red
            }

            ENDCG

        }

        Pass
        {
            Cull Back // turn off triangle culling, alternatives are:
            // Cull Back (or nothing): cull only back faces
            // Cull Front : cull only front faces
            CGPROGRAM

            #pragma vertex vert
            #pragma fragment frag

            struct vertexInput
            {
                float4 vertex: POSITION;
            };

            struct vertexOutput
            {
                float4 pos: SV_POSITION;
                float4 posInObjectCoords: TEXCOORD0;
            };

            vertexOutput vert(vertexInput input)
            {
                vertexOutput output;

                output.pos = UnityObjectToClipPos(input.vertex);
                output.posInObjectCoords = mul(unity_ObjectToWorld, input.vertex);

                return output;
            }

            float4 frag(vertexOutput input): COLOR
            {
                if (input.posInObjectCoords.y > 0.0)
                {
                    discard; // drop the fragment if y coordinate > 0
                }

                return float4(0.0, 1.0, 0.0, 1.0); // green
            }

            ENDCG

        }
    }
}
