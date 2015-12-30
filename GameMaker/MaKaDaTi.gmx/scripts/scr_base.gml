// erzeuge, dass der Bildschirm abdunkelt
    draw_set_colour(c_black)
    draw_set_alpha(0.35);
    draw_rectangle(view_xview[0], view_yview[0], view_xview[0] + view_wview[0], view_yview[0] + view_hview[0], false);
    
    //zeichne Pergament
    draw_set_colour(c_white);
    draw_set_alpha(1);
    draw_sprite(spr_pergament, 0, ((view_xview[0] + view_wview[0]) / 2), ((view_yview[0] + view_hview[0]) / 2));
    
    // erzeuge, dass der Bildschirm noch mehr abdunkelt
    draw_set_colour(c_black)
    draw_set_alpha(0.35);
    draw_rectangle(view_xview[0], view_yview[0], view_xview[0] + view_wview[0], view_yview[0] + view_hview[0], false);
// Highscore
if(instance_exists(obj_score))obj_score.visible=false;
