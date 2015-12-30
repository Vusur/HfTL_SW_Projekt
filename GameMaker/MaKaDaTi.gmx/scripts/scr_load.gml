var i = argument0;

var file = "__save"+string(i)+".ini"

rm = -1;
date = "--";

if(file_exists(file)){
    ini_open(file);
    rm = ini_read_real("save", "room", -1);
    date = ini_read_string("save", "date", "--");
    //Score Laden
    score = ini_read_real("save", "score", 0);
    if(instance_exists(obj_score)){
        obj_score.var_highscore_history=score;
        obj_score.visible=false;
    }
    ini_close();
}

