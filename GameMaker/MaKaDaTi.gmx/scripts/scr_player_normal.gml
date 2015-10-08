//behaveior of the player -- state normal
scr_getInputs();

if(vsp < 10) vsp += grav;
hsp = movespeed * (key_right - key_left);

if(place_meeting(x, y+1, obj_block)){
    if(key_jump) vsp = -jumpspeed;
}

scr_collideMove();

