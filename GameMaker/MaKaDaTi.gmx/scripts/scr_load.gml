var i = argument0;

var file = "__save"+string(i)+".ini"

rm = -1;
date = "--";

if(file_exists(file)){
    ini_open(file);
    rm = ini_read_real("save", "room", -1);
    date = ini_read_string("save", "date", "--");
    ini_close();
}
