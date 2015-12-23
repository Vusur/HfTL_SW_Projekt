if(keyboard_check_pressed(vk_alt)){
    room_goto_next();
    scr_destroyPersistent();
}
if(keyboard_check_pressed(vk_control)){ 
    room_goto_previous();
    scr_destroyPersistent();   
}



