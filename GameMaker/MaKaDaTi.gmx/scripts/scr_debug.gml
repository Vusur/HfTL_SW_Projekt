if(keyboard_check(vk_alt)){
    if(keyboard_check_pressed(vk_pageup)){
        room_goto_next();
        scr_destroyPersistent();
    }
    if(keyboard_check_pressed(vk_pagedown)){ 
        room_goto_previous();
        scr_destroyPersistent();  
    } 
}



