document.addEventListener("DOMContentLoaded", ()=>
{
    document.querySelector("#Doc1").addEventListener("click", ()=> Doc1())
}
);

function Doc1()
{
    if (document.querySelector("#F").value==""||document.querySelector("#I").value==""||document.querySelector("#O").value==""||document.querySelector("#PasportSeria").value==""||document.querySelector("#PasportAdres").value=="")
    {
        alert("Не все поля заполнены")
        return false;
    }
    sessionStorage.setItem("F",document.querySelector("#F").value);
    sessionStorage.setItem("I",document.querySelector("#I").value);
    sessionStorage.setItem("O",document.querySelector("#O").value);
    sessionStorage.setItem("PasportSeria",document.querySelector("#PasportSeria").value);
    sessionStorage.setItem("PasportAdres",document.querySelector("#PasportAdres").value);
    window.open("Document1.html")
}