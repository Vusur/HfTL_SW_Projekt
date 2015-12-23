if(argument0 = true){
    if(global.controls == 0 || !gamepad_is_connected(0)){   //keyboard
        key_left = keyboard_check(vk_left);
        key_right = keyboard_check(vk_right);
        key_up = keyboard_check_pressed(vk_up);
        key_down = keyboard_check_pressed(vk_down);
        
        
        key_jump = keyboard_check_pressed(vk_up);
        key_fall = keyboard_check(vk_down);
        key_throw = keyboard_check_pressed(vk_space);
        
        key_enter = keyboard_check_pressed(vk_enter);
        key_esc =      keyboard_check_pressed(vk_escape);
        key_pause = keyboard_check_pressed(vk_escape);
        
        key_left_s = keyboard_check_pressed(vk_left);
        key_right_s = keyboard_check_pressed(vk_right);
        
    } else if(global.controls == 1){ //controler
        key_left =  gamepad_button_check(0, gp_padl);
        key_right = gamepad_button_check(0, gp_padr);
        key_up =    gamepad_button_check_pressed(0, gp_padu);
        key_down =  gamepad_button_check_pressed(0, gp_padd);
        
        key_jump =  gamepad_button_check_pressed(0, gp_face1);
        
        key_fall = gamepad_button_check(0, gp_padd);
        key_throw = gamepad_button_check_pressed(0, gp_face3);
        
        key_pause = gamepad_button_check_pressed(0, gp_start);
        key_enter = gamepad_button_check_pressed(0, gp_face1);
        key_esc =   gamepad_button_check_pressed(0, gp_face2);
    
        key_left_s =  gamepad_button_check_pressed(0, gp_padl);
        key_right_s = gamepad_button_check_pressed(0, gp_padr);
    }
    
} else { //block inputs;
        key_left =  0
        key_right = 0
        key_up =    0
        key_down =  0
        
        key_jump =  0
        key_fall = 0
        key_throw = 0
        
        key_pause = 0
        key_enter = 0
        key_esc =   0
    
        key_left_s =  0
        key_right_s = 0
}
