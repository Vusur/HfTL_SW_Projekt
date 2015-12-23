
var controls = 0;
var sounds = 0;
var fullscreen = 1;
var brightness = 1;
var frams = 1;
var res = 0; 
var resWidth = 0;
var resHeight = 0;

if(file_exists("__Cucurbitascastle.ini")) { //try to load options
    ini_open("__Cucurbitascastle.ini");
    controls = ini_read_real("options", "controls", 0);
    sounds = ini_read_real("options", "sounds", 0);
    fullscreen = ini_read_real("options", "fullscreen", 1);
    brightness = ini_read_real("options", "brightness", 0);
    frams = ini_read_real("options", "frams", 0);
    res = ini_read_real("options", "res", 0);
    resWidth = ini_read_real("options", "resW", 800);
    resHeight = ini_read_real("options", "resH", 600);
    ini_close();
}

//from.ini
if(resWidth == 0) resWidth = 800;
if(resHeight ==0) resHeight = 600;
global.controls = controls;
global.sounds = sounds;
global.fullscreen = fullscreen;
global.brightness = brightness;
global.frams = frams;
global.res = res;
global.resW = resWidth;
global.resH = resHeight; 

//copy into temp from menu
with(obj_menuEntry){
    tempControls = global.controls;
    tempSounds = global.sounds;
    tempBrightness = global.brightness;
    tempFullscreen = global.fullscreen;
    tempFrames = global.frams;
    tempRes = global.res; 
}
