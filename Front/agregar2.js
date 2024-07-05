const url = "https://localhost:7082/nuevo"

const altaSocioForm = document.getElementById('altaSocioForm')
const mensajeDiv = document.getElementById('mensaje')

altaSocioForm.addEventListener('submit', async (event) =>{
    event.preventDefault()

    const nombre = document.getElementById('nombre').value;
    const dni = document.getElementById('dni').value;
    const deporte = document.getElementById('deporte').value;

    const socio = {
        nombre: nombre,
        dni: dni,
        nombreDeporte: deporte
    };
    try {
        const response = await fetch(url, {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(socio)
        });

        if (!response.ok) {
            throw new Error('Error al dar de alta al socio');
        }

        const data = await response.json();
        mensajeDiv.innerHTML = `<div class="alert alert-success" role="alert">
                                    Socio creado exitosamente con ID: ${data.id}
                                </div>`;

        // Limpiar el formulario después de éxito
        altaSocioForm.reset();

    } catch (error) {
        mensajeDiv.innerHTML = `<div class="alert alert-danger" role="alert">
                                    Error al dar de alta al socio: ${error.message}
                                </div>`;
    }
})