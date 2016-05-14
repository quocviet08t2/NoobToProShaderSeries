Shader "NoodToProUnityShader/2_Lambert"
{
	Properties
	{
		_Color("Color", Color) = (1.0, 1.0, 1.0, 1.0)
	}

	SubShader
	{
		pass
		{
			Tags
			{
				"LightMode" = "ForwardBase"
			}

			CGPROGRAM
#pragma vertex vert
#pragma fragment frag
			
			// User defined variables
			uniform fixed4 _Color;

			// Unity defined variables
			uniform float4 _LightColor0;
			// float4x4 _Object2World;
			// float4x4 _World2Object;
			// float4x4 _WorldLightPos0;

			// Base input struct
			struct vertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			// base output struct
			struct vertexOutput
			{
				float4 pos : SV_POSITION;
				float4 col : COLOR;
			};

			// vertex function
			vertexOutput vert(vertexInput v)
			{
				vertexOutput o;

				float3 normalDirection = normalize(mul(float4(v.normal, 0.0), _World2Object).xyz);
				float3 lightDirection;
				float aten = 1.0;

				lightDirection = normalize(_WorldSpaceLightPos0.xyz);
				float3 diffuseReflection = aten * _LightColor0.xyz * _Color.rgb * max(0, dot(normalDirection, lightDirection));

				o.col = float4(diffuseReflection, 1.0);
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				return o;
			}

			// fragment function
			fixed4 frag(vertexOutput i) : COLOR
			{
				fixed4 result;
				result = i.col;
				return result;
			}

			ENDCG
		}
	}
	Fallback "Diffuse"
}
