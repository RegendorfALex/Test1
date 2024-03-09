document.addEventListener("DOMContentLoaded", ()=>
{
    document.querySelector("#vivod1").innerText = sessionStorage.getItem("F");
    document.querySelector("#vivod2").innerText = sessionStorage.getItem("I");
    document.querySelector("#vivod3").innerText = sessionStorage.getItem("O");
}
);