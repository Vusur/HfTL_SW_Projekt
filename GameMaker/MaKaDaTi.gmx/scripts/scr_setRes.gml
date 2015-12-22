res = argument0;
var _w;
var _h;
switch(res){
    case 0:
        _w = 768;
        _h = 1024;
        break;
    case 1:
        _w = 800;
        _h = 600;
        break;
    case 2:
        _w = 1024;
        _h = 768;
        break;
    case 3:
        _w = 1280;
        _h = 720;
        break;
    case 4:
        _w = 1280;
        _h = 800;
        break;
    case 5:
        _w = 1280;
        _h = 1014;
        break;
    case 6:
        _w = 1366;
        _h = 768;
        break;
    case 7:
        _w = 1440;
        _h = 900;
        break;
    case 8:
        _w = 1600;
        _h = 900;
        break;
    case 9:
        _w = 1920;
        _h = 1080;
        break;
    default:
        _w = 800;
        _h = 600;
        break;
}
ini_write_real("options", "res", res);
ini_write_real("options", "resW", _w);
ini_write_real("options", "resH", _h);

global.res = res;
global.resW = _w;
global.resH = _h;





