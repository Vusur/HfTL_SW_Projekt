var entry = argument0;

//set new fontstyle
draw_set_font(fn_header);
            
//draw header
var head ="";
if(entry == 0) head = "Neues Spiel starten";
else head = "Ein Spiel laden";
draw_text_colour(((view_xview[0] + view_wview[0]) / 2),  (view_yview[0] + 125) , head, c_black, c_black, c_red, c_red, 0.75);
        
        
// draw submenu for both
if(!subselected){         
            
    //set new font style
    draw_set_font(fn_pause);
    draw_set_colour(c_black);
    draw_set_halign(fa_left);
    draw_set_alpha(0.7);
            
    //hilfsvariable
    var pos; 
    var text;
    var xbegin = (view_xview[0] + view_wview[0]) / 2;  //center of the view x
    var ybegin = (view_yview[0] + 175)       //center of the view y
    
    //draw subentrys
    for(pos = 0; pos < 4; pos ++){
        //choose right Text
        if(pos == 3)    text = "Abbrechen"        
        else{
            scr_load(pos)
            if(rm == -1){ 
                text = "["+string(pos+1)+"] Neues Spiel"
            } else {
                scr_formatRoomName(room_get_name(rm))
                text = "["+string(pos+1)+"] " + name;
            }
        }
        
        //draw text
        ybegin += 75;
        draw_text(xbegin-300,  ybegin, text);
        
        //draw Highlight
        if(pos == subentry){
            draw_sprite(spr_indicator, 0, xbegin - 325, ybegin+16);
        }
    }
            
        
} else{ //draw sububmenu for entry 0 or 1 (spiel starten oder laden)

    //variable for informationtext
    var info = "";
    //set new font style
    draw_set_font(fn_pause);
    draw_set_colour(c_black);
    draw_set_alpha(0.7);
    draw_set_halign(fa_center);
    
    //Hilfsvariablen         
    var xbegin = (view_xview[0] + view_wview[0]) / 2;  //center of the view x
    var ybegin = ((view_yview[0] + view_hview[0]) / 2)  - 150;                //center of the view y
       
    scr_load(subentry)
    if(rm == -1){ 
        text = "["+string(subentry+1)+"] Neues Spiel"
    } else {
        scr_formatRoomName(room_get_name(rm))
        text = "["+string(subentry+1)+"] " + name;
        draw_text(xbegin, ybegin + 50, "Raum " + nr);
        draw_text(xbegin, ybegin +100, date);
    }
    
    draw_text(xbegin, ybegin, text);
    
    //draw starten & abbrechen
    draw_set_halign(fa_left);
    draw_text(475, 575, " Starten ");
    draw_text(700, 575, "Abbrechen");
    draw_set_halign(fa_center);
        
    if(subsubentry == 0){
        draw_sprite(spr_indicator, 0, 450, 575+16);
        if(rm == -1) info = "Es wird ein neues Spiel gestartet"
        else if(entry == 0) info = "Das Spiel wird überschrieben"
        else info = "Das Spiel wird geladen"
    }
    else if(subsubentry == 1){
        draw_sprite(spr_indicator, 0, 675, 575+16);
        info = "Zurück zur Auswahl"
    }
    
    if (entry == 1){ //draw subsubmenu laden
        if(subsubentry==2){
            draw_sprite(spr_del, 1, 1010, 585)
            if(rm == -1) info = "Kein Spielstand zum Löschen vorhanden"
            else info = "Der Spielstand wird gelöscht"
        }else
            draw_sprite(spr_del, 0, 1010, 585)
    }
    scr_informationText(info);
}
