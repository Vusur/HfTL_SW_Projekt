var tosplit = argument0;

//zu splitten rm_000_X_Y_C_INI wird zu 
//array[0] -> "000"
//array[1] -> "X Y C"

var i, p, len, item, ch, arrcount, __array;
len = string_length(tosplit);
item = "";
arrcount = 0;
name = "";
for(p = 0; p <= len; p++){
    ch = string_char_at(tosplit, p);
    if(ch == "_" && string_char_at(tosplit, p+1) != "_"){
        __array[arrcount] = item;
        arrcount++;
        
        item = "";
    } else if(ch != "_"){
        item += ch;
    }
}

nr = __array[1];
for(p = 2; p < arrcount; p++){
    name += __array[p];
    name += " ";
}
rmCompute = true;


