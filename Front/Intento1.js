const url = "https://localhost:7082/get"

async function obtenerSocios(){
try{
    const response = await fetch(url)

    if(!response.ok){
        throw new Error('Error al obtener datos de la Api')
    }
    const socios = await response.json()
    console.log('Socios obtenidos:', socios);

    const tablaSocios = document.getElementById('sociosTableBody');
    tablaSocios.innerHTML = "";

    socios.forEach(socio => {
        const fila = document.createElement('tr');
            fila.innerHTML = `
                <td>${socio.nombre}</td>
                <td>${socio.apellido}</td>
                <td>${socio.dni}</td>
                <td>${socio.nombreDeporte}</td>
                <td>Acciones...</td>
            `;
            tablaSocios.appendChild(fila);
    });

}catch(error){
    console.error('Errror' +error)
}}

window.addEventListener('DOMContentLoaded', obtenerSocios);