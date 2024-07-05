
    async function agregarUsuario() {
        const idElement = document.getElementById("id")
        const nameElement = document.getElementById("name")

        const url = "https://localhost:7236/usuarios/nuevo"
        await fetch(url,{
            method :"POST",
            headers :{
                "Content-Type": "application/json",
            },
            body: JSON.stringify({
                id: idElement.value,
                name: nameElement.value
            })
        })
        .then(response => response.json())
        .then(response => {
            console.log(response)
        })
    }