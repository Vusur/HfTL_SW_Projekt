var controls = 0;
var sounds = 0;
var fullscreen = 1;
var brightness = 1;
var frams = 1; 

if(file_exists("__Cucurbitascastle.ini")) { //try to load options
    ini_open("__Cucurbitascastle.ini");
    controls = ini_read_real("options", "controls", 0);
    sounds = ini_read_real("options", "sounds", 0);
    fullscreen = ini_read_real("options", "fullscreen", 1);
    brightness = ini_read_real("options", "brightness", 0);
    frams = ini_read_real("options", "frams", 0);
    ini_close();
}

//from.ini
global.controls = controls;
global.sounds = sounds;
global.fullscreen = fullscreen;
global.brightness = brightness;
global.frams = frams; 

//copy into temp from menu
with(obj_menuEntry){
    tempControls = global.controls;
    tempSounds = global.sounds;
    tempBrightness = global.brightness;
    tempFullscreen = global.fullscreen;
    tempFrames = global.frams; 
}
