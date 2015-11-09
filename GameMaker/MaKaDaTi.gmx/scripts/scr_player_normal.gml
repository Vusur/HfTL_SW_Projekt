///behaveior player -- state normal
scr_getInputs();
scr_drawDirection();
//fall
if(vsp < 10) vsp += grav;

//jump
if(place_meeting(x, y+1, obj_block)){
    if(key_up) vsp = -jumpspeed;
}

//move
hsp = movespeed * (key_right - key_left);

scr_collideAndMove();
