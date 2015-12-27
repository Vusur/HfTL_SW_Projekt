var minEntry = argument0;
var temp = argument1;
var maxEntry = argument2

var xbeg = argument3;
var ybeg = argument4;

if(temp != minEntry){
    if(key_left_s && !active[0]){
        active[0] = true;
        alarm[0] = room_speed / 8;
    }
    if(active[0]){        
        draw_sprite_ext(spr_optionsIndicator, 1, xbeg-16, ybeg+18, -1, 1, 0, c_white, 0.5);
    } else {
        draw_sprite_ext(spr_optionsIndicator, 0, xbeg-16, ybeg+18, -1, 1, 0, c_white, 0.5);
    }   
}

if(temp != maxEntry){
    if(key_right_s && !active[1]){
        active[1] = true;
        alarm[1] = room_speed / 8;
    }
    if(active[1]){
        draw_sprite(spr_optionsIndicator, 1, xbeg+275, ybeg+18);
    } else {
        draw_sprite(spr_optionsIndicator, 0, xbeg+275, ybeg+18);
    }
    
}
