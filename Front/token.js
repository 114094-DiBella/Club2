function enviarFormulario() {
    const socioData = {
      nombre: document.getElementById('nombre').value,
      apellido: document.getElementById('apellido').value,
      dni: document.getElementById('dni').value,
      nombreDeporte: document.getElementById('deporte').value,
    };

    const token = localStorage.getItem('token');

    const url = ""
    fetch(url, {
      method: 'POST',
      headers: {
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${token}`
      },
      body: JSON.stringify(socioData)
    })
    .then(response => response.json())
    .then(data => {
      const mensajeDiv = document.getElementById('mensaje');
      if (data.success) {
        mensajeDiv.innerHTML = `<div class="alert alert-success">Socio creado exitosamente!</div>`;
      } else {
        mensajeDiv.innerHTML = `<div class="alert alert-danger">Error al crear el socio: ${data.message}</div>`;
      }
    })
    .catch(error => {
      console.error('Error:', error);
      document.getElementById('mensaje').innerHTML = `<div class="alert alert-danger">Ocurrió un error al crear el socio.</div>`;
    });
  }