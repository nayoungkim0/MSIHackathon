let computer = new Array(
    "A1","A2","A3","A4","A5",
    "B1","B2","B3","B4","B5",
    "C1","C2","C3","C4","C5","C6",
    "D1","D2","D3","D4","D5","D6",
    "E1","E2","E3","E4"
);

let login = new Array(26).fill(false); 
login[3] = true;

var today = new Date();
const dateString = new Date().toLocaleString([],{
    year: 'numeric', month: 'numeric', day: 'numeric',
    hour: '2-digit',minute: '2-digit'
});
document.getElementById("time").innerHTML = dateString;

function refreshTime(){
    const timeDisplay = document.getElementById("time");
    const dateString = new Date().toLocaleString([],{
        year: 'numeric', month: 'numeric', day: 'numeric',
        hour: '2-digit',minute: '2-digit'
    });
    timeDisplay.textContent = dateString;
}
setInterval(refreshTime, 1000);


const alldiv = document.querySelectorAll(".content");
let i;
for (i=0; i < alldiv.length; i++){
    alldiv[i].style.background = "#E4D5B6"; //cream
}

for (let j = 0; j <= computer.length; j++){
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
        document.querySelector(time).innerHTML = "time";
    }
    else{ //empty
        document.querySelector(whichpc).innerHTML = "<br> empty";
        document.querySelector(time).innerHTML = "<br>";
    }
}
