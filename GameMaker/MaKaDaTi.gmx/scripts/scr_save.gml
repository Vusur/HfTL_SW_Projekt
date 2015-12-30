var i = argument0;
var rm = argument1;
var file = "__save"+string(i)+".ini"


var dateText = string(current_day) + "." + string(current_month) + "." + string(current_year) + "   "
dateText = dateText + string(current_hour) + ":";
if(current_minute < 10) dateText = dateText + "0";
dateText = dateText + string(current_minute);

if(file_exists(file)) file_delete(file)

ini_open(file);    
ini_write_real("save", "room", rm);
ini_write_string("save", "date", dateText);
// Kills im aktuellen Raum wieder abziehen, da Raum beim nächsten mal Neu gestartet wird
with(obj_score){
    score -= var_highscore_kills_this_room * var_highscore_points_per_kill;
}
ini_write_real("save", "score", score);
ini_close();
