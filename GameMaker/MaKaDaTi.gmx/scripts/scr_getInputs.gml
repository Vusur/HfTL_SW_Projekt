if(argument0 = true){
    key_left = keyboard_check(vk_left);
    key_right = keyboard_check(vk_right);
    key_up = keyboard_check_pressed(vk_up);
    key_down = keyboard_check_pressed(vk_down);
    key_enter = keyboard_check_pressed(vk_enter);
    key_space = keyboard_check_pressed(vk_space);
    
    key_left_s = keyboard_check_pressed(vk_left);
    key_right_s = keyboard_check_pressed(vk_right);
    
} else {
    key_left = 0;
    key_right = 0;
    key_up = 0;
    key_down = 0;
    key_enter = 0;
    key_space = 0;
    
    key_left_s = 0;
    key_right_s = 0;
}
