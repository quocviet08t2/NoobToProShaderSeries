Shader "NoodToProUnityShader/3a_Specular"
{
	Properties
	{
		_Color("Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_SpecColor("Specular Color", Color) = (1.0, 1.0, 1.0, 1.0)
		_Shininess("Shininess", float) = 10
	}

	SubShader
	{
		Tags
		{
			"LightMode" = "ForwardBase"
		}

		Pass
		{
			CGPROGRAM
#pragma vertex vert
#pragma fragment frag

			//user defined variables
			uniform float4 _Color;
			uniform float4 _SpecColor;
			uniform float _Shininess;

			//unity defined variables
			uniform float4 _LightColor0;

			struct vertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
			};

			struct vertexOutput
			{
				float4 pos : SV_POSITION;
				float4 col : COLOR;
			};

			vertexOutput vert(vertexInput v)
			{
				vertexOutput o;

				float3 normalDirection = normalize(_World2Object[0].xyz * v.normal.x +
					_World2Object[1].xyz * v.normal.y +
					_World2Object[2].xyz * v.normal.z);

				float3 viewDirection = normalize(_WorldSpaceCameraPos - mul(UNITY_MATRIX_MVP, v.vertex));
				float aten = 1.0;

				float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);			
				float3 diffuseReflection = aten * _LightColor0.xyz * max(0.0, dot(normalDirection, lightDirection));

				float3 specularDirection = aten * _SpecColor * max(0.0, dot(normalDirection, lightDirection)) * pow(max(0.0, dot(reflect(-lightDirection, normalDirection), viewDirection)), _Shininess);
				float3 lightFinal = diffuseReflection + specularDirection + UNITY_LIGHTMODEL_AMBIENT;

				o.col = float4(lightFinal * _Color, 1.0);
				o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
				return o;
			}

			float4 frag(vertexOutput i) : COLOR
			{
				return i.col;
			}
			ENDCG
		}
	}
	//Fallback "Diffuse"
}
