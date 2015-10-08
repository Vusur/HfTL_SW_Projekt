//simple collision for the player

//horizontal movement
if(place_meeting(x+hsp, y, obj_block)){
    while(!place_meeting(x+sign(hsp), y, obj_block)){
        x += sign(hsp);
    }
    hsp = 0;
}

//vertical movement
if(place_meeting(x, y+vsp, obj_block)){
    while(!place_meeting(x, y+sign(vsp), obj_block)){
        y += sign(vsp);
    }
    vsp = 0;
}

//execute change of position
x += hsp;
y += vsp;
