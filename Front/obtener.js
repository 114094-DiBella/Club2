function listarUsuarios(){
const url = "https://localhost:7236/usuarios/Get"
fetch(url)
    .then(users => users.json())
    .then(users => {
        if(!users.success){
            alert("Error")
            alert("user.errorMessage")
        }else{
            const cuerpotabla = document.querySelector('tbody')
                users.data.forEach(element => {
                    const fila = document.createElement('<tr>')
                    fila.innerHTML += "<td>"+element.email+"</td>"
                    fila.innerHTML += "<td>"+element.name+"</td>"

                    cuerpotabla.append(fila)
                });
            
        }
    }).catch(err =>{
        alert("Algo salio mal"+ err)
    })
}