shader_type canvas_item;
render_mode unshaded;

uniform int intensity : hint_range(0,200); 
uniform float precision : hint_range(0,0.02);
uniform vec4 outline_color : hint_color;

varying vec2 o;
varying vec2 f;

void vertex()
{
	o = VERTEX;
	vec2 uv = (UV - 0.5);
	VERTEX += uv * float(intensity);
	f = VERTEX;
}

void fragment()
{
	ivec2 t = textureSize(TEXTURE, 0);
	vec2 regular_uv;
	regular_uv.x = UV.x + (f.x - o.x)/float(t.x);
	regular_uv.y = UV.y + (f.y - o.y)/float(t.y);
	
	vec4 regular_color = texture(TEXTURE, regular_uv);
	if((regular_uv.x < 0.0 || regular_uv.x > 1.0) || (regular_uv.y < 0.0 || regular_uv.y > 1.0) || regular_color.a <=0.25){
		regular_color = vec4(0.0); 
	}
	
	vec2 ps = TEXTURE_PIXEL_SIZE * float(intensity) * precision;
	
	COLOR = vec4(0);
	if (regular_color.r <= 0f
		&& regular_color.g <= 0f
		&& regular_color.b <= 0f) {
		COLOR = vec4(outline_color.rgb, regular_color.a); 
	}
}