Shader "Custom/Trial" { // defines the name of the shader 
	Properties{
		[PerRendererData]_Color("Colour",Color)=(1,1,1,1)
	}
   SubShader { // Unity chooses the subshader that fits the GPU best
      Pass { // some shaders require multiple passes
         CGPROGRAM // here begins the part in Unity's Cg

         #pragma vertex vert 
         #pragma fragment frag

		 struct vertOut{
		 	float4 pos : SV_POSITION;
		 	float4 col : TEXCOORD0;
		 };
		 
         vertOut vert(float4 vertexPos : POSITION)  
         {
         	vertOut output;
         	
         	output.pos = mul(UNITY_MATRIX_MVP, vertexPos);
         	output.col = vertexPos + float4(0.5,0.5,0.5,0.0);
         	return output;
         }

			fixed4 _Color;
         float4 frag(vertOut input) : COLOR // fragment shader
         {
         	if(input.pos.x%2 == input.pos.y%2)
         		input.col = _Color;
         	return input.col;
         }

         ENDCG // here ends the part in Cg 
      }
   }
}