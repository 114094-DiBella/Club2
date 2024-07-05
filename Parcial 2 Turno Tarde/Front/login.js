document.getElementById('loginForm').addEventListener('submit', async function(event){
  event.preventDefault();
  
  const dni = document.getElementById('dni').value

  const url = "https://localhost:7082/login"

  const response = await fetch(url , {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json'
    },
    body: JSON.stringify({dni})
  });

  const data = await response.json()
  const mensajeDiv = document.getElementById('mensaje')

  if(response.ok){
    mensajeDiv.innerHTML = `<div class="alert alert-success">${data.Message}</div>`
    localStorage.setItem(`token`, data.Token)
  }else{
    mensajeDiv.innerHTML = `<div class="alert alert-danger">${data.Message}</div>`
  }
});