var controls = argument0;
var sounds = argument1;
var fullscreen = argument2;
var brightness = argument3;
var frams = argument4; 
var res = argument5;

if(file_exists("__Cucurbitascastle.ini")) 
    file_delete("__Cucurbitascastle.ini");  //delete old ini
ini_open("__Cucurbitascastle.ini");     //create new ini
//write values
ini_write_real("options", "controls", controls);
ini_write_real("options", "sounds", sounds);
ini_write_real("options", "fullscreen", fullscreen);
ini_write_real("options", "brightness", brightness);
ini_write_real("options", "frams", frams);
scr_setRes(res);
ini_close(); //close ini

//set global
global.controls = argument0;
global.sounds = argument1;
global.fullscreen = argument2;
global.brightness = argument3;
global.frams = argument4; 

