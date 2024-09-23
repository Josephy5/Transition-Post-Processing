//Shader code is based on Dan Moran's Shader case study of Pokemon Battle Transition YouTube video
//The only change is the removal of the distort calculation and parameters since we want this effect to be
//able to be used generally rather than to be something that is meant close as to the pokemon's transitions
Shader "Hidden/Transition"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_TransitionTex("Transition Texture", 2D) = "white" {}
		_TransitionScreenTex("Transition Screen Texture", 2D) = "white" {}
		_Color("Screen Color", Color) = (1,1,1,1)
		_Cutoff("Cutoff", Range(0, 1)) = 0
		_Fade("Fade", Range(0, 1)) = 0
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
					float2 uv1 : TEXCOORD1;
					float4 vertex : SV_POSITION;
				};

				float4 _MainTex_TexelSize;
				/*
				v2f simplevert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);
					o.uv = v.uv;
					return o;
				}*/

				v2f vert(appdata v)
				{
					v2f o;
					o.vertex = UnityObjectToClipPos(v.vertex);

					o.uv = v.uv;
					o.uv1 = v.uv;

					#if UNITY_UV_STARTS_AT_TOP
					if (_MainTex_TexelSize.y < 0)
						o.uv1.y = 1 - o.uv1.y;
					#endif

					return o;
				}

				sampler2D _TransitionTex;
				sampler2D _TransitionScreenTex;
				int _UseTransitionScreenTex;
				float _Fade;

				sampler2D _MainTex;
				float _Cutoff;
				float4 _Color;
				
				/*
				fixed4 simplefrag(v2f i) : SV_Target
				{
					if (i.uv.x < _Cutoff)
						return _Color;

					return tex2D(_MainTex, i.uv);
				}

				fixed4 simplefragopen(v2f i) : SV_Target
				{
					if (0.5 - abs(i.uv.y - 0.5) < abs(_Cutoff) * 0.5)
						return _Color;

					return tex2D(_MainTex, i.uv);
				}

				fixed4 simpleTexture(v2f i) : SV_Target
				{
					fixed4 transit = tex2D(_TransitionTex, i.uv);

					if (transit.b < _Cutoff)
						return _Color;

					return tex2D(_MainTex, i.uv);
				}
				*/
				fixed4 frag(v2f i) : SV_Target
				{
					fixed4 transit = tex2D(_TransitionTex, i.uv1);

					fixed2 direction = float2(0,0);

					fixed4 col = tex2D(_MainTex, i.uv + _Cutoff * direction);
					
					fixed4 targetCol = _UseTransitionScreenTex ? tex2D(_TransitionScreenTex, i.uv) : _Color;
					
					if (transit.b < _Cutoff){
						col = lerp(col, targetCol, _Fade);
					}
					
					return col;
				}					
				ENDCG
			}
		}
}
