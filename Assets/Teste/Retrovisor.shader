Shader "Hidden/Retrovisor"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_TexReflexo("Texture", 2D) = "white" {}

	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float2 screenuv : TEXCOORD1;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = mul(UNITY_MATRIX_MVP, v.vertex);
				o.screenuv = (o.vertex.xy/o.vertex.w + 1) * 0.5f;
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;
			sampler2D _TexReflexo;

			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 col = tex2D(_MainTex, i.uv);
				fixed4 colReflexo = tex2D(_TexReflexo, i.screenuv);
				col = lerp(col, colReflexo, 0.5);
				return col;
			}
			ENDCG
		}
	}
}
