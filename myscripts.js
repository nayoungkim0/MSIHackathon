


let computer = new Array( //PC array
    "A1","A2","A3","A4","A5",
    "B1","B2","B3","B4","B5",
    "C1","C2","C3","C4","C5","C6",
    "D1","D2","D3","D4","D5","D6",
    "E1","E2","E3","E4"
);

let login = new Array(26).fill(false); //login array
login[3] = true;                                                    //NEED get login true/false 
login[10] = true;
let Timelogin = new Array(26); //login time array 
Timelogin[3] = new Date(2023,10,19,14,0,0);
Timelogin[10] = new Date(2023,10,19,13,0,0);

var code = '<%=pcNumber%>';

document.querySelector(".here").textContent = code;          

function getUsingtime(startTime, currentTime){
    let diffms = Math.abs(currentTime-startTime)/1000;

    const hours = Math.floor(diffms / 3600) % 24;
    diffms -= hours * 3600;
   
    const minutes = Math.floor(diffms / 60) % 60;
    diffms -= minutes * 60;

    var secd = ~~diffms % 60;
    var seconds = Math.ceil(secd);
 
    const durTime = hours + "h " + minutes + "m " + seconds + "s";  
    return durTime;
}

function refreshTime(){
    const timeDisplay = document.getElementById("time");
    const dateString = new Date().toLocaleString([],{
        year: 'numeric', month: 'numeric', day: 'numeric',
        hour: '2-digit',minute: '2-digit', second: '2-digit'
    });
    timeDisplay.innerHTML = dateString;
}

const alldiv = document.querySelectorAll(".content");
let i;
for (i=0; i < alldiv.length; i++){
    alldiv[i].style.background = "#E4D5B6"; //cream
}

let str = " ";
function updatePC(){
    for (let j = 0; j < computer.length; j++){
        let dot = ".";
        let pc = computer[j];
        let whichpc = dot.concat(pc);
        let time = dot.concat("T");
        time = time.concat(pc);
        document.querySelector(whichpc).style.fontWeight = "normal";
        document.querySelector(time).style.fontWeight = "normal";

        if (login[j] == true){ //logged in
            document.querySelector(whichpc).innerHTML =  "<br> reserved";
            document.querySelector(whichpc).style.color = "#F0461A"; //red
            let current = new Date();
            let userstart = Timelogin[j];
            const using = getUsingtime(userstart, current);
            document.querySelector(time).innerHTML = using;
            
            //document.querySelector(".here").innerHTML = time;
            //change time to actual runing time 
            //document.querySelector(time).textContent =  "h ";
        }
        else{ //empty
            document.querySelector(whichpc).innerHTML = "<br> empty";
            document.querySelector(time).innerHTML = "<br>";
        
        }
    }
}

function repeat(){
    updatePC();
    refreshTime();
}

repeat();
setInterval(repeat);