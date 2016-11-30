#version 330

layout(location = 0)in vec2 vert_pos;
layout(location = 1)in vec4 vert_col;
layout(location = 2)in vec2 vert_tex;

uniform vec2 screen_size_half;
uniform vec4 cam_pos;

out vec4 color;
out vec2 texcoord;
out vec2 vp;

void main(void)
{    
	gl_Position = vec4(((vert_pos.x - screen_size_half.x) / screen_size_half.x - (cam_pos.x / screen_size_half.x)) * cam_pos.z,
						(((screen_size_half.y * 2) - vert_pos.y) / screen_size_half.y - 1.0f + (cam_pos.y / screen_size_half.y)) * cam_pos.w,
						0.0, 1.0);
	
	color = vert_col;
	texcoord = vert_tex;
	vp = vert_pos;
}