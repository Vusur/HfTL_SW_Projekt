///standard collision and movement

//vertical collsion with solids
if(place_meeting(x, y+vsp, obj_block)){
    while(!place_meeting(x, y+sign(vsp), obj_block)){
        y += sign(vsp);
    }
    vsp = 0;   
}

//horizontal collision with solids
if(place_meeting(x+hsp, y, obj_block)){
    while(!place_meeting(x+sign(hsp), y, obj_block)){
        x += sign(hsp);
    }
    hsp = 0;
}



//move
x += hsp;
y += vsp;
