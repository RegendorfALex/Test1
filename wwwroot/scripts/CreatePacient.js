document.addEventListener("DOMContentLoaded", ()=>
{
    document.querySelector("#CreatePacient").addEventListener("click", async()=> await CreatePacient());
}
);

async function CreatePacient()
{
    if (document.querySelector("#F").value == "" || document.querySelector("#I").value == "" || document.querySelector("#O").value == "" || document.querySelector("#Phone").value == "" || document.querySelector("#Email").value == "" || document.querySelector("#PasportSeria").value == "" || document.querySelector("#PasportAdres").value == "" || document.querySelector("#Rabota").value == "") {
        alert("Заполните все поля")
        return false
    }

  const myHeaders = new Headers();
  myHeaders.append("Content-Type", "application/json");

      F = document.querySelector("#F").value,
    I = document.querySelector("#I").value,
    O = document.querySelector("#O").value,
    Phone = document.querySelector("#Phone").value,
    Email = document.querySelector("#Email").value,
    Born = document.querySelector("#Born").value,
    PasportSeria = document.querySelector("#PasportSeria").value,
    PasportAdres = document.querySelector("#PasportAdres").value,
    Rabota = document.querySelector("#Rabota").value
    
   
  const raw = JSON.stringify({
    "F" : F,
    "I" : I,
    "O" : O,
    "Phone" : Phone,
    "Email" : Email,
    "Born" : Born,
    "PasportSeria": PasportSeria,
    "PasportAdres" : PasportAdres,
    "Rabota" : Rabota
      
    });
    
    const requestOptions = {
      method: "POST",
      headers: myHeaders,
      body: raw,
      redirect: "follow"
    };

    await fetch("/PacientsController/Create", requestOptions)
        .then((response) => response.json())
        .then((result) => {          
            if (result.statusCode == 200)
            {
                alert("Пациент добавлен")
            }
            if (result.statusCode == 201) {
                alert("Пациент существует")
            }
        }) 
}


   
       
