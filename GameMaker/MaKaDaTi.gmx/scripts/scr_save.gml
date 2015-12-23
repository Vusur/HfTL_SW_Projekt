var i = argument0;
var rm = argument1;
var file = "__save"+string(i)+".ini"

var date = date_time_string(date_current_datetime());

if(file_exists(file)) file_delete(file)

ini_open(file);    
ini_write_real("save", "room", rm);
ini_write_string("save", "date", date);
ini_close();
