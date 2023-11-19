let login = true; 

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
const alldiv = document.querySelectorAll("div > div");
    let i;
if(login == true){
    document.getElementById("status").innerHTML = "reserved";
   // document.getElementsById("status").style.color = "red";
    document.getElementById("status").style.color = "red";
    //document.querySelector("div").style.background = "green";

    for (i=0; i < alldiv.length; i++){
        alldiv[i].style.background = "red";
    }
   
}
else{
    document.getElementById("status").innerHTML = "empty";
    for (i=0; i < alldiv.length; i++){
        alldiv[i].style.background = "green";
    }
}

