var text = argument0;

draw_set_halign(fa_left);
draw_set_alpha(0.7);
draw_set_font(fn_pause);
draw_text_colour(560, 710, "Info:", c_black, c_black, c_red, c_red, 0.7);

draw_text_colour(560, 760, text, c_black, c_black, c_black, c_black, 0.7);

draw_set_halign(fa_center);

